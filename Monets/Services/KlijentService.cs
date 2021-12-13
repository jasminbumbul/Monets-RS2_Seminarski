using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Helper;
using Monets.Api.Interfaces;
using Monets.API.Helpers;
using Monets.Model;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class KlijentService : BaseCRUDService<Model.Klijent, Database.Klijent, KlijentSearchRequest, KlijentInsertRequest, KlijentUpdateRequest>, IKlijentService
    {
        private ImageHelper imageHelper = new ImageHelper();

        public KlijentService(MonetsContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override async Task<List<Model.Klijent>> Get(KlijentSearchRequest request = null)
        {
            var query = Context.Klijent.Include("KorisnickiRacun").AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.KorisnickiRacun.Ime.Contains(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.KorisnickiRacun.Prezime.Contains(request.Prezime));
            }

            if (request.Status)
            {
                query = query.Where(s => s.Status == true);
            }

            var list = await query.ToListAsync();

            var result = _mapper.Map<List<Model.Klijent>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async override Task<Model.Klijent> GetById(int id)
        {
            var entity = await Context.Klijent.Include("KorisnickiRacun").Where(s => s.KlijentId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Klijent nije pronađen!");
            }

            var result = _mapper.Map<Model.Klijent>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async override Task<Model.Klijent> Insert(KlijentInsertRequest request)
        {
            if (request.Lozinka != request.LozinkaPotrvda)
                throw new UserException("Lozinke se ne podudaraju!");

            if (await ProvjeriDaLiPostoji(request))
            {
                throw new UserException($"Klijent {request.Ime} {request.Prezime}, rođen ( {request.DatumRodjenja.ToString("dd/MM/yyyy")} ) je već dodan!");
            }

            if (await KorisnickoImeZauzeto(request.KorisnickoIme))
            {
                throw new UserException("Korisničko ime je zauzeto!");
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
            
            if(request.Slika!= null && request.SlikaPutanja!=null)
            {
                racun.SlikaPutanja = await imageHelper.InsertImage("KorisnickiRacun", racun.KorisnickiRacunId, request.SlikaPutanja, request.Slika);
            }

            var klijent = _mapper.Map<Database.Klijent>(request);
            klijent.KorisnickiRacunId = racun.KorisnickiRacunId;
            klijent.Status = true;

            await Context.Klijent.AddAsync(klijent);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Klijent>(klijent);
        }

        public async override Task<Model.Klijent> Update(int id, KlijentUpdateRequest request)
        {
            var entity = await Context.Klijent.Include("KorisnickiRacun").Where(s => s.KlijentId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Klijent nije pronađen!");
            }

            if (request.Lozinka != null && request.LozinkaPotrvda != null)
                if (request.Lozinka != request.LozinkaPotrvda)
                    throw new UserException("Lozinke se ne podudaraju!");

            if (request.KorisnickoIme != entity.KorisnickiRacun.KorisnickoIme && await KorisnickoImeZauzeto(request.KorisnickoIme) == true)
            {
                throw new UserException("Korisničko ime je zauzeto");
            }

            if (ProvjeriPromjene(entity, request) == false)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");

            }
            await UpdateEntity(entity, request);
            var result = _mapper.Map<Model.Klijent>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public override async Task<bool> Delete(int id)
        {
            var entity = await Context.Klijent.Include("KorisnickiRacun").Where(s => s.KlijentId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Klijent nije pronađen!");
            }

            try
            {

                entity.KorisnickiRacun.Status = false;
                entity.Status = false;
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new UserException("Brisanje nije bilo moguće." + ex.InnerException);
            }
        }


        private async Task UpdateEntity(Database.Klijent entity, KlijentUpdateRequest request)
        {

            if (request.Ime != null && request.Ime != entity.KorisnickiRacun.Ime) entity.KorisnickiRacun.Ime = request.Ime;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiRacun.Prezime) entity.KorisnickiRacun.Prezime = request.Prezime;
            if (request.KorisnickoIme != null && request.KorisnickoIme != entity.KorisnickiRacun.KorisnickoIme) entity.KorisnickiRacun.KorisnickoIme = request.KorisnickoIme;
            if (request.Email != null && request.Email != entity.KorisnickiRacun.Email) entity.KorisnickiRacun.Email = request.Email;
            if (request.DatumRodjenja != null && request.DatumRodjenja != entity.KorisnickiRacun.DatumRodjenja) entity.KorisnickiRacun.DatumRodjenja = request.DatumRodjenja;
            if (request.Status != null && request.Status != entity.Status) entity.Status = request.Status;
            if (request.GradId != 0 && request.GradId != entity.GradId) entity.GradId = request.GradId;
            if (request.Telefon != null && request.Telefon != entity.KorisnickiRacun.Telefon) entity.KorisnickiRacun.Telefon = request.Telefon;
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
            return await Context.KorisnickiRacun.AnyAsync(x => x.KorisnickoIme == korisnickoIme);
        }

        public async Task<bool> ProvjeriDaLiPostoji(KlijentInsertRequest request)
        {
            return await Context.Klijent.AnyAsync(s => s.KorisnickiRacun.Ime == request.Ime && s.KorisnickiRacun.Prezime == request.Prezime && s.KorisnickiRacun.DatumRodjenja == request.DatumRodjenja && s.Status == true);
        }

        private bool ProvjeriPromjene(Database.Klijent entity, KlijentUpdateRequest request)
        {
            if (request.Ime != entity.KorisnickiRacun.Ime) return true;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiRacun.Prezime) return true;
            if (request.Email != entity.KorisnickiRacun.Email) return true;
            if (request.KorisnickoIme != entity.KorisnickiRacun.KorisnickoIme) return true;
            if (request.DatumRodjenja != entity.KorisnickiRacun.DatumRodjenja) return true;
            if (request.Status != entity.Status) return true;
            if (request.GradId != entity.GradId) return true;
            if (request.Telefon != entity.KorisnickiRacun.Telefon) return true;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiRacun.SlikaPutanja) return true;
            if (request.Lozinka != null && request.LozinkaPotrvda != null && request.Lozinka.Length > 0 && request.LozinkaPotrvda.Length > 0) return true;

            return false;
        }

        public async Task<Model.Klijent> Login(AuthenticationRequest request)
        {
            var user = await Context.Klijent.Include("KorisnickiRacun").FirstOrDefaultAsync(s => s.KorisnickiRacun.KorisnickoIme == request.KorisnickoIme);

            if (user == null)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");
            }

            if (user.KorisnickiRacun.Status == false)
            {
                throw new UserException("Korisnički račun je deaktiviran.");

            }

            var newHash = HashGenerator.GenerateHash(user.KorisnickiRacun.LozinkaSalt, request.Lozinka);

            if (newHash != user.KorisnickiRacun.LozinkaHash)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");

            }

            var result = _mapper.Map<Model.Klijent>(user);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiRacun", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }
    }
}
