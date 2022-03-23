using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Helper;
using Monets.Api.Interfaces;
using Monets.API.Helpers;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class RezervacijaService : BaseCRUDService<Model.Rezervacija, Rezervacija, RezervacijaSearchRequest, RezervacijaUpsertRequest, RezervacijaUpsertRequest>, IRezervacijaService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RezervacijaService(MonetsContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async override Task<List<Model.Rezervacija>> Get(RezervacijaSearchRequest search = null)
        {
            provjeriJesuLiRezervacijeIstekle();
            var entity = Context.Rezervacija.Include("JeloRezervacija").Include("JeloRezervacija.Jelo").Include("Klijent").AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Sifra))
            {
                entity = entity.Where(x => x.Sifra.Contains(search.Sifra));
            }

            if (search.Status == null)
            {
                entity = entity.Where(s => s.Status == false || s.Status == true || s.Status == null);
            }
            else
            {
                if ((bool)search.Status)
                {
                    entity = entity.Where(s => s.Status == true);
                }
                else
                {
                    entity = entity.Where(s => s.Status == false);
                }
            }

            if (search.KlijentId != 0)
            {
                entity = entity.Where(x => x.KlijentId == search.KlijentId);
            }

            if (search.PotvrdjenaKlijent)
            {
                entity = entity.Where(x => x.PotvrdjenaKlijent != true);
            }

            var list = await entity.ToListAsync();

            var result = _mapper.Map<List<Model.Rezervacija>>(list);


            return result;
        }

        private void provjeriJesuLiRezervacijeIstekle()
        {
            var rezervacije = Context.Rezervacija.ToList();

            foreach (var item in rezervacije)
            {
                if (item.PocetakRezervacije<DateTime.Now)
                {
                    item.Status = false;
                    Context.SaveChanges();
                }
            }
        }

        public async override Task<Model.Rezervacija> GetById(int id)
        {
            var entity = await Context.Rezervacija.Include("Stol").Include("JeloRezervacija").Where(x => x.RezervacijaId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Rezervacija nije pronađena!");
            }

            return _mapper.Map<Model.Rezervacija>(entity);
        }

        public async Task<List<Model.Rezervacija>> GetReservationsForDate(DateTime date, int stolId)
        {
            //provjeriti validnost datuma
            if (date == null)
            {
                throw new UserException("Datum nije validan");
            }

            //get rezervacije na taj datum
            var listaRezervacija = await Context.Rezervacija.Where(x => x.StolId == stolId && x.PocetakRezervacije.Year == date.Year && x.PocetakRezervacije.Month == date.Month && x.PocetakRezervacije.Day == date.Day).OrderBy(x => x.PocetakRezervacije).ToListAsync();

            return _mapper.Map<List<Model.Rezervacija>>(listaRezervacija);
        }

        public async Task<List<Model.SlobodnoVrijeme>> GetFreeTimesForDate(DateTime date, int stolId)
        {
            //provjeriti validnost datuma
            if (date == null)
            {
                throw new UserException("Datum nije validan");
            }

            //get rezervacije na taj datum
            var listaRezervacijaNaDan = await GetReservationsForDate(date, stolId);
            var listaSlobodnihTermina = new List<Model.SlobodnoVrijeme>();
            Model.SlobodnoVrijeme trenutnoVrijeme = null;
            if (DateTime.Now.Date.Equals(date))
            {
                trenutnoVrijeme = new Model.SlobodnoVrijeme() { Vrijeme = new DateTime(date.Year, date.Month, date.Day, DateTime.Now.Hour, 00, 0), IsSlobodno = true };
            }
            else
            {
                trenutnoVrijeme = new Model.SlobodnoVrijeme() { Vrijeme = new DateTime(date.Year, date.Month, date.Day, 9, 00, 0), IsSlobodno = true };
            }
            bool flag = false;

            while (trenutnoVrijeme.Vrijeme.Hour < 21)
            {
                foreach (var rezervacija in listaRezervacijaNaDan)
                {
                    if (rezervacija.PocetakRezervacije.Hour == trenutnoVrijeme.Vrijeme.Hour && rezervacija.PocetakRezervacije.Minute == trenutnoVrijeme.Vrijeme.Minute)
                    {
                        flag = true;
                        listaSlobodnihTermina.Add(new Model.SlobodnoVrijeme() { Vrijeme = rezervacija.PocetakRezervacije, IsSlobodno = false });
                        break;
                    }
                }
                if (flag)
                {
                    flag = false;
                    if (trenutnoVrijeme.Vrijeme.Minute == 30)
                    {
                        trenutnoVrijeme = new Model.SlobodnoVrijeme() { Vrijeme = new DateTime(date.Year, date.Month, date.Day, trenutnoVrijeme.Vrijeme.Hour + 3, 00, 0), IsSlobodno = true };
                    }
                    else
                    {
                        trenutnoVrijeme = new Model.SlobodnoVrijeme() { Vrijeme = new DateTime(date.Year, date.Month, date.Day, trenutnoVrijeme.Vrijeme.Hour, trenutnoVrijeme.Vrijeme.Minute + 30, 0), IsSlobodno = true };
                    }
                }
                else
                {
                    listaSlobodnihTermina.Add(new Model.SlobodnoVrijeme() { Vrijeme = trenutnoVrijeme.Vrijeme, IsSlobodno = true });
                    DateTime noviTermin;
                    if (trenutnoVrijeme.Vrijeme.Minute == 30)
                    {
                        noviTermin = new DateTime(trenutnoVrijeme.Vrijeme.Year, trenutnoVrijeme.Vrijeme.Month, trenutnoVrijeme.Vrijeme.Day, trenutnoVrijeme.Vrijeme.Hour + 1, 0, 0);
                    }
                    else
                    {
                        noviTermin = new DateTime(trenutnoVrijeme.Vrijeme.Year, trenutnoVrijeme.Vrijeme.Month, trenutnoVrijeme.Vrijeme.Day, trenutnoVrijeme.Vrijeme.Hour, trenutnoVrijeme.Vrijeme.Minute + 30, 0);
                    }
                    trenutnoVrijeme.Vrijeme = noviTermin;
                }
            }

            return listaSlobodnihTermina;
        }

        public async Task<List<Model.SlobodnoVrijeme>> GetFreeEndTimesForDate(DateTime date, int stolId)
        {
            //provjeriti validnost datuma
            if (date == null)
            {
                throw new UserException("Datum nije validan");
            }

            //get rezervacije na taj datum
            var listaRezervacijaNaDan = await GetReservationsForDate(date, stolId);
            var listaSlobodnihTermina = new List<Model.SlobodnoVrijeme>();
            Model.SlobodnoVrijeme trenutnoVrijeme = new Model.SlobodnoVrijeme() { Vrijeme = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0), IsSlobodno = true };
            if (trenutnoVrijeme.Vrijeme.Minute == 30)
            {
                trenutnoVrijeme.Vrijeme = new DateTime(trenutnoVrijeme.Vrijeme.Year, trenutnoVrijeme.Vrijeme.Month, trenutnoVrijeme.Vrijeme.Day, trenutnoVrijeme.Vrijeme.Hour + 1, 00, 0);
            }
            else
            {
                trenutnoVrijeme.Vrijeme = new DateTime(trenutnoVrijeme.Vrijeme.Year, trenutnoVrijeme.Vrijeme.Month, trenutnoVrijeme.Vrijeme.Day, trenutnoVrijeme.Vrijeme.Hour, trenutnoVrijeme.Vrijeme.Minute + 30, 0);
            }

            //da li 9:30 ima kao pocetno vrijeme
            //ako je zauzeto 9:30 samo vrati 9:30
            //ako nije zauzeto 9:30 nastavi dok ne bude zauzeto

            while (trenutnoVrijeme.Vrijeme.Hour < 21)
            {
                foreach (var rezervacija in listaRezervacijaNaDan)
                {
                    if (rezervacija.PocetakRezervacije.Hour == trenutnoVrijeme.Vrijeme.Hour && rezervacija.PocetakRezervacije.Minute == trenutnoVrijeme.Vrijeme.Minute)
                    {
                        listaSlobodnihTermina.Add(new Model.SlobodnoVrijeme() { Vrijeme = rezervacija.PocetakRezervacije, IsSlobodno = false });
                        return listaSlobodnihTermina;
                    }
                }
                listaSlobodnihTermina.Add(new Model.SlobodnoVrijeme() { Vrijeme = trenutnoVrijeme.Vrijeme, IsSlobodno = true });
                DateTime noviTermin;
                if (trenutnoVrijeme.Vrijeme.Minute == 30)
                {
                    noviTermin = new DateTime(trenutnoVrijeme.Vrijeme.Year, trenutnoVrijeme.Vrijeme.Month, trenutnoVrijeme.Vrijeme.Day, trenutnoVrijeme.Vrijeme.Hour + 1, 00, 0);
                }
                else
                {
                    noviTermin = new DateTime(trenutnoVrijeme.Vrijeme.Year, trenutnoVrijeme.Vrijeme.Month, trenutnoVrijeme.Vrijeme.Day, trenutnoVrijeme.Vrijeme.Hour, trenutnoVrijeme.Vrijeme.Minute + 30, 0);
                }
                trenutnoVrijeme.Vrijeme = noviTermin;
            }

            return listaSlobodnihTermina;
        }

        public async Task<List<Model.Jelo>> getJelaIzRezervacije(int rezervacjaId)
        {
            if (rezervacjaId == 0)
            {
                throw new UserException("Rezervacija nije validna");
            }

            var jela = await Context.JeloRezervacija.Include("Jelo").Include("Jelo.JeloRezervacija").Where(x => x.RezervacijaId == rezervacjaId).Select(x => x.Jelo).ToListAsync();


            var result = _mapper.Map<List<Model.Jelo>>(jela);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Jelo", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async Task<Model.JeloRezervacija> GetKolicinuZaJeloRezervaciju(int jeloId, int rezervacijaId)
        {
            if (rezervacijaId == 0)
            {
                throw new UserException("Rezervacija nije validna");
            }


            var result = await Context.JeloRezervacija.Include("Jelo").Include("Jelo.JeloRezervacija").Where(x => x.RezervacijaId == rezervacijaId && x.JeloId==jeloId).SingleOrDefaultAsync();

            return _mapper.Map<Model.JeloRezervacija>(result);
        }

        private ImageHelper imageHelper = new ImageHelper();

        public async Task<Model.JeloRezervacija> DodajJeloURezervaciju(JeloRezervacijaInsertRequest jeloRezervacijaInsertRequest)
        {
            var jelo = await Context.Jelo.FindAsync(jeloRezervacijaInsertRequest.jeloId);
            if (jelo == null)
            {
                throw new UserException("Jelo nije pronadjeno");
            }

            var rezervacija = await Context.Rezervacija.FindAsync(jeloRezervacijaInsertRequest.rezervacijaId);
            if (rezervacija == null)
            {
                throw new UserException("Rezervacija nije pronadjena");
            }

            if (jeloRezervacijaInsertRequest.kolicina < 1)
            {
                throw new UserException("Kolicina nije validna");
            }

            var jeloRezervacija = await Context.JeloRezervacija.Where(x => x.JeloId == jeloRezervacijaInsertRequest.jeloId && x.RezervacijaId == jeloRezervacijaInsertRequest.rezervacijaId).SingleOrDefaultAsync();
            if (jeloRezervacija == null)
            {
                jeloRezervacija = new JeloRezervacija() { JeloId = jeloRezervacijaInsertRequest.jeloId, RezervacijaId = jeloRezervacijaInsertRequest.rezervacijaId, Kolicina = jeloRezervacijaInsertRequest.kolicina };
                await Context.AddAsync(jeloRezervacija);
                await Context.SaveChangesAsync();
            }
            else
            {
                jeloRezervacija.Kolicina += jeloRezervacijaInsertRequest.kolicina;
                await Context.SaveChangesAsync();
            }

            return _mapper.Map<Model.JeloRezervacija>(jeloRezervacija);
        }

        public async Task<Model.JeloRezervacija> UkloniJeloIzRezervacije(JeloRezervacijaInsertRequest jeloRezervacijaInsertRequest)
        {
            var jelo = await Context.Jelo.FindAsync(jeloRezervacijaInsertRequest.jeloId);
            if (jelo == null)
            {
                throw new UserException("Jelo nije pronadjeno");
            }

            var rezervacija = await Context.Rezervacija.FindAsync(jeloRezervacijaInsertRequest.rezervacijaId);
            if (rezervacija == null)
            {
                throw new UserException("Rezervacija nije pronadjena");
            }

            var jeloRezervacija = await Context.JeloRezervacija.Where(x => x.JeloId == jeloRezervacijaInsertRequest.jeloId && x.RezervacijaId == jeloRezervacijaInsertRequest.rezervacijaId).SingleOrDefaultAsync();
            if (jeloRezervacija == null)
            {
                throw new UserException("Jelo nije u rezervaciji.");
            }
            else
            {
                Context.Remove(jeloRezervacija);
                await Context.SaveChangesAsync();
            }

            return _mapper.Map<Model.JeloRezervacija>(jeloRezervacija);
        }

        public async override Task<Model.Rezervacija> Insert(RezervacijaUpsertRequest request)
        {
            if (request.StolId == 0)
            {
                throw new UserException("Morate dodati stol za rezervaciju!");
            }

            if ((request.PocetakRezervacije == null) || (request.PocetakRezervacije < DateTime.Now) || (request.KrajRezervacije == null) || (request.KrajRezervacije < request.PocetakRezervacije))
            {
                throw new UserException("Nije validno vrijeme rezervacije!");
            }

            int klijentId = await Context.Klijent.Include("KorisnickiRacun").Where(x => x.KlijentId == request.KlijentId).Select(x => x.KlijentId).FirstOrDefaultAsync();
            if (klijentId == 0)
            {
                throw new UserException("Korisnik nije pronađen!");
            }

            var rezervacija = _mapper.Map<Rezervacija>(request);

            var loggedInUserUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //rezervacija.KlijentId = await Context.Klijent.Include("KorisnickiRacun").Where(x => x.KorisnickiRacun.KorisnickoIme == loggedInUserUsername).Select(x => x.KlijentId).FirstOrDefaultAsync();
            rezervacija.Status = true;
            rezervacija.Sifra = RandomStringGenerator.GenerateRandomCode(5);
            rezervacija.DatumKreiranja = DateTime.Now;
            rezervacija.DatumIzmjene = DateTime.Now;
            if (request.Placena == null)
            {
                rezervacija.Placena = false;
            }
            if (request.Potvrdjena == null)
            {
                rezervacija.Potvrdjena = false;
            }

            await Context.Rezervacija.AddAsync(rezervacija);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Rezervacija>(rezervacija);
        }

        public async override Task<Model.Rezervacija> Update(int id, RezervacijaUpsertRequest request)
        {
            if (request.StolId == 0)
            {
                throw new UserException("Morate dodati stol za rezervaciju!");
            }

            if (request.PocetakRezervacije == null)
            {
                throw new UserException("Nije validno vrijeme rezervacije!");
            }

            var rezervacija = await Context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                throw new UserException("Rezervacija ne postoji.");
            }

            if (ProvjeriPromjene(rezervacija, request) == false)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");
            }

            await UpdateEntity(rezervacija, request);

            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Rezervacija>(rezervacija);
        }

        public override async Task<bool> Delete(int id)
        {
            var entity = await Context.Rezervacija.Where(x => x.RezervacijaId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Rezervacija nije pronađena!");
            }

            try
            {
                entity.Status = false;
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new UserException("Brisanje nije bilo moguće." + ex.InnerException);
            }
        }

        private bool ProvjeriPromjene(Rezervacija entity, RezervacijaUpsertRequest request)
        {
            if (request.StolId != entity.StolId) return true;
            if (request.PocetakRezervacije != entity.PocetakRezervacije) return true;
            if (request.KrajRezervacije != entity.KrajRezervacije) return true;
            if (request.Placena != entity.Placena) return true;
            if (request.Status != entity.Status) return true;
            if (request.Potvrdjena != entity.Potvrdjena) return true;
            if (request.PotvrdjenaKlijent != entity.PotvrdjenaKlijent) return true;
            if (request.Poruka != entity.Poruka) return true;

            return false;
        }

        private async Task UpdateEntity(Rezervacija entity, RezervacijaUpsertRequest request)
        {

            if (request.StolId != null && request.StolId != entity.StolId) entity.StolId = (int)request.StolId;
            if ((request.PocetakRezervacije != null || request.PocetakRezervacije < DateTime.Now) && request.PocetakRezervacije != entity.PocetakRezervacije) entity.PocetakRezervacije = request.PocetakRezervacije;
            if ((request.KrajRezervacije != null || request.KrajRezervacije < DateTime.Now) && request.KrajRezervacije != entity.KrajRezervacije) entity.KrajRezervacije = request.KrajRezervacije;
            if (request.Placena != null && request.Placena != entity.Placena) entity.Placena = request.Placena;
            if (request.Status != null && request.Status != entity.Status) entity.Status = request.Status;
            if (request.Potvrdjena != null && request.Potvrdjena != entity.Potvrdjena) entity.Potvrdjena = request.Potvrdjena;
            if (request.PotvrdjenaKlijent != null && request.PotvrdjenaKlijent != entity.PotvrdjenaKlijent) entity.PotvrdjenaKlijent = request.PotvrdjenaKlijent;
            if (!string.IsNullOrEmpty(request.Poruka) && request.Poruka != entity.Poruka) entity.Poruka = request.Poruka;

            entity.DatumIzmjene = DateTime.Now;

            await Context.SaveChangesAsync();
        }

    }
}
