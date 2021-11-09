using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class UposlenikService : BaseCRUDService<Model.Uposlenik, Database.Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikUpdateRequest>, IUposlenikService
    {
        private ImageHelper imageHelper = new ImageHelper();
        
        public UposlenikService(MonetsContext context, IMapper mapper) : base(context, mapper)
        {}

        public async Task<Model.Uposlenik> Login(AuthenticationRequest request)
        {
            var user = await Context.Uposlenik.Include("UposlenikUloga.Uloga").Include("KorisnickiRacun").FirstOrDefaultAsync(x => x.KorisnickiRacun.KorisnickoIme == request.KorisnickoIme);

            if (user == null)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");
            }

            if (user.KorisnickiRacun.Status == false)
            {
                throw new UserException("Korisnički nalog je deaktiviran.");

            }

            var newHash = HashGenerator.GenerateHash(user.KorisnickiRacun.LozinkaSalt, request.Lozinka);

            if (newHash != user.KorisnickiRacun.LozinkaHash)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");

            }

            return _mapper.Map<Model.Uposlenik>(user);
        }


        public override async Task<List<Model.Uposlenik>> Get(UposlenikSearchRequest request = null)
        {
            var query = Context.Uposlenik.Include("KorisnickiRacun").Include("UposlenikUloga.Uloga").AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(s => s.KorisnickiRacun.Ime.Contains(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(s => s.KorisnickiRacun.Prezime.Contains(request.Prezime));
            }

            if (request.Status)
            {
                query = query.Where(s => s.Status == true);
            }
            else
            {
                query = query.Where(s => s.Status == false || s.Status==true || s.Status==null);
            }


            var list = await query.ToListAsync();

            var result = _mapper.Map<List<Model.Uposlenik>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async override Task<Model.Uposlenik> GetById(int id)
        {
            var entity = await Context.Uposlenik.Include("Grad").Include("KorisnickiRacun").Include("UposlenikUloga.Uloga").Where(x=> x.UposlenikId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Uposlenik nije pronađen!");
            }

            var result = _mapper.Map<Model.Uposlenik>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async override Task<Model.Uposlenik> Insert(UposlenikInsertRequest request)
        {
            if (request.Lozinka != request.LozinkaPotrvda)
                throw new UserException("Lozinke se ne podudaraju!");

            if (await ProvjeriDaLiPostoji(request))
            {
                throw new UserException($"Uposlenik {request.Ime} {request.Prezime}, rođen ( {request.DatumRodjenja.ToString("dd/MM/yyyy")} ) je već dodan!");
            }

            if (await KorisnickoImeZauzeto(request.KorisnickoIme))
            {
                throw new UserException("Korisničko ime je zauzeto!");
            }

            if (request.GradId == 0)
            {
                throw new UserException("GradId nije ispravan!");
            }

            var salt = HashGenerator.GenerateSalt();
            var hash = HashGenerator.GenerateHash(salt, request.Lozinka);

            var racun = _mapper.Map<Database.KorisnickiRacun>(request);

            racun.LozinkaSalt = salt;
            racun.LozinkaHash = hash;
            racun.DatumIzmjene = DateTime.Now;
            racun.DatumKreiranja = DateTime.Now;

            await Context.KorisnickiRacun.AddAsync(racun);
            await Context.SaveChangesAsync();

            if(request.SlikaPutanja!=null && request.Slika!=null)
            {
                racun.SlikaPutanja = await imageHelper.InsertImage("KorisnickiRacun", racun.KorisnickiRacunId, request.SlikaPutanja, request.Slika);
            }

            var uposlenik = _mapper.Map<Database.Uposlenik>(request);
            uposlenik.KorisnickiRacunId = racun.KorisnickiRacunId;
            uposlenik.DatumZaposlenja = DateTime.Now;
            uposlenik.Status = true;

            await Context.Uposlenik.AddAsync(uposlenik);
            await Context.SaveChangesAsync();

            foreach (var uloga in request.Uloge)
            {
                await Context.UposlenikUloga.AddAsync(new UposlenikUloga()
                {
                    DatumIzmjene = DateTime.Now,
                    UposlenikId = uposlenik.UposlenikId,
                    UlogaId = uloga
                });
            }

            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Uposlenik>(uposlenik);
        }

        public async override Task<Model.Uposlenik> Update(int id, UposlenikUpdateRequest request)
        {
            var entity = await Context.Uposlenik.Include("Grad").Include("KorisnickiRacun").Include("UposlenikUloga.Uloga").Where(x => x.UposlenikId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Uposlenik nije pronađen!");
            }

            if (request.KorisnickoIme != entity.KorisnickiRacun.KorisnickoIme && await KorisnickoImeZauzeto(request.KorisnickoIme) == true)
            {
                throw new UserException("Korisničko ime je zauzeto");
            }

            if (request.Lozinka != null && request.LozinkaPotrvda != null)
                if (request.Lozinka != request.LozinkaPotrvda)
                    throw new UserException("Lozinke se ne podudaraju!");


            if (ProvjeriPromjene(entity, request) == false && ProvjeriPromjeneUloga(entity, request) == true)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");
            }

            await UpdateEntity(entity, request);

            if (ProvjeriPromjeneUloga(entity, request) == false)
            {
                if (await ProvjeriAdministratore(entity, request))
                {
                    throw new UserException("Uklanjanje uloge administrator nije moguće jer je uposlenik posljednji sa tom ulogom u sistemu.");
                }
                foreach (var item in entity.UposlenikUloga)
                {
                    Context.UposlenikUloga.Remove(item);
                }

                await Context.SaveChangesAsync();

                foreach (var uloga in request.Uloge)
                {
                    await Context.UposlenikUloga.AddAsync(new UposlenikUloga()
                    {
                        DatumIzmjene = DateTime.Now,
                        UposlenikId = entity.UposlenikId,
                        UlogaId = uloga
                    });
                }

                await Context.SaveChangesAsync();

            }
            return _mapper.Map<Model.Uposlenik>(entity);
        }

        public async override Task<bool> Delete(int id)
        {
            var entity = await Context.Uposlenik.Include("Grad").Include("KorisnickiRacun").Where(x => x.UposlenikId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Korisnik nije pronađen!");
            }

            try
            {
                var uloge = Context.UposlenikUloga.Where(x => x.UposlenikId == entity.UposlenikId);

                if (await uloge.AnyAsync(s => s.Uloga.Naziv == "Administrator"))
                    throw new UserException("Nije moguće deaktivirati uposlenika sa ulogom administrator.");

                entity.KorisnickiRacun.Status = false;
                entity.Status = false;
                await Context.SaveChangesAsync();
                //return _mapper.Map<Model.Uposlenik>(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new UserException("Greška prilikom brisanja accounta." + ex.InnerException);
            }
        }

        private async Task UpdateEntity(Uposlenik entity, UposlenikUpdateRequest request)
        {

            if (request.Ime != null && request.Ime != entity.KorisnickiRacun.Ime) entity.KorisnickiRacun.Ime = request.Ime;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiRacun.Prezime) entity.KorisnickiRacun.Prezime = request.Prezime;
            if (request.DatumRodjenja != null && request.DatumRodjenja != entity.KorisnickiRacun.DatumRodjenja) entity.KorisnickiRacun.DatumRodjenja = request.DatumRodjenja;
            if (request.DatumZaposlenja != null && request.DatumZaposlenja != entity.DatumZaposlenja) entity.DatumZaposlenja = request.DatumRodjenja;
            if (request.Email != null && request.Email != entity.KorisnickiRacun.Email) entity.KorisnickiRacun.Email = request.Email;
            if (request.Telefon != null && request.Telefon != entity.KorisnickiRacun.Telefon) entity.KorisnickiRacun.Telefon = request.Telefon;
            if (request.KorisnickoIme != null && request.KorisnickoIme != entity.KorisnickiRacun.KorisnickoIme) entity.KorisnickiRacun.KorisnickoIme = request.KorisnickoIme;
            if (request.GradId != 0 && request.GradId!= entity.GradId) entity.GradId = request.GradId;
            if (request.Status != null && request.Status != entity.Status) entity.Status = request.Status;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiRacun.SlikaPutanja) entity.KorisnickiRacun.SlikaPutanja = await imageHelper.ReplaceImage("KorisnickiRacun", entity.KorisnickiRacunId, entity.KorisnickiRacun.SlikaPutanja, request.SlikaPutanja, request.Slika);
            if (request.Lozinka != null && request.LozinkaPotrvda != null && request.Lozinka.Length > 0 && request.LozinkaPotrvda.Length > 0 && request.Lozinka == request.LozinkaPotrvda)
            {
                var salt = HashGenerator.GenerateSalt();
                var hash = HashGenerator.GenerateHash(salt, request.Lozinka);

                entity.KorisnickiRacun.LozinkaSalt = salt;
                entity.KorisnickiRacun.LozinkaHash = hash;
            }

            entity.KorisnickiRacun.DatumIzmjene = DateTime.Now;

            await Context.SaveChangesAsync();
        }

        public async Task<bool> KorisnickoImeZauzeto(string korisnickoIme)
        {
            return await Context.KorisnickiRacun.AnyAsync(s => s.KorisnickoIme == korisnickoIme && s.Status==true);
        }

        public async Task<bool> ProvjeriDaLiPostoji(UposlenikInsertRequest request)
        {
            return await Context.Uposlenik.AnyAsync(x => x.KorisnickiRacun.Ime == request.Ime && x.KorisnickiRacun.Prezime == request.Prezime && x.KorisnickiRacun.DatumRodjenja == request.DatumRodjenja && x.Status == true);
        }

        private bool ProvjeriPromjene(Uposlenik entity, UposlenikUpdateRequest request)
        {
            if (request.Ime != entity.KorisnickiRacun.Ime) return true;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiRacun.Prezime) return true;
            if (request.DatumRodjenja != entity.KorisnickiRacun.DatumRodjenja) return true;
            if (request.DatumZaposlenja != entity.DatumZaposlenja) return true;
            if (request.Email != entity.KorisnickiRacun.Email) return true;
            if (request.Telefon != entity.KorisnickiRacun.Telefon) return true;
            if (request.KorisnickoIme != entity.KorisnickiRacun.KorisnickoIme) return true;
            if (request.Status != entity.Status) return true;
            if (request.GradId != entity.GradId) return true;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiRacun.SlikaPutanja) return true;
            if (request.Lozinka != null && request.LozinkaPotrvda != null && request.Lozinka.Length > 0 && request.LozinkaPotrvda.Length > 0) return true;

            return false;
        }

        private bool ProvjeriPromjeneUloga(Database.Uposlenik entity, UposlenikUpdateRequest request)
        {
            var list = entity.UposlenikUloga.Select(x => x.UlogaId).ToList();
            var list2 = request.Uloge.ToList();
            
            var inListButNotInList2 = list.Except(list2);
            var inList2ButNotInList = list2.Except(list);

            return !inListButNotInList2.Any() && !inList2ButNotInList.Any();
        }

        private async Task<bool> ProvjeriAdministratore(Database.Uposlenik entity, UposlenikUpdateRequest request)
        {
            var administratorUloga = entity.UposlenikUloga.Any(s => s.Uloga.Naziv == "Administrator");

            if (administratorUloga != false)
            {
                var brojAdministratora = await Context.UposlenikUloga.Where(s => s.Uposlenik.Status == true && s.Uloga.Naziv == "Administrator").CountAsync();

                var ulogaAdministrator = await Context.Uloga.Where(s => s.Naziv == "Administrator").SingleOrDefaultAsync();

                int brojac = 0;

                foreach (var uloga in request.Uloge)
                {
                    if (uloga == ulogaAdministrator.UlogaId)
                        brojac++;
                }

                if (brojac == 0 && brojAdministratora == 1)
                    return true;
            }

            return false;
        }
    }
}
