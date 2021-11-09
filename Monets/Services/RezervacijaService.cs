using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Helper;
using Monets.Api.Interfaces;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
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
            var entity = Context.Rezervacija.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Sifra))
            {
                entity = entity.Where(x => x.Sifra.Contains(search.Sifra));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.Rezervacija>>(list);
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

        public async override Task<Model.Rezervacija> Insert(RezervacijaUpsertRequest request)
        {
            if (request.StolId == 0)
            {
                throw new UserException("Morate dodati stol za rezervaciju!"); 
            }
            
            if (request.DatumRezervacije == null || request.DatumRezervacije< DateTime.Now)
            {
                throw new UserException("Nije validno vrijeme rezervacije!");
            }

            var rezervacija = _mapper.Map<Rezervacija>(request);

            var loggedInUserUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            rezervacija.KlijentId = await Context.Klijent.Include("KorisnickiRacun").Where(x => x.KorisnickiRacun.KorisnickoIme == loggedInUserUsername).Select(x => x.KlijentId).FirstOrDefaultAsync();
            rezervacija.Sifra = RandomStringGenerator.GenerateRandomCode(5);
            rezervacija.DatumKreiranja = DateTime.Now;
            rezervacija.DatumIzmjene = DateTime.Now;
            if(request.Placena==null)
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

            if (request.DatumRezervacije == null)
            {
                throw new UserException("Nije validno vrijeme rezervacije!");
            }

            var rezervacija = await Context.Rezervacija.FindAsync(id);
            if(rezervacija==null)
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
            if (request.DatumRezervacije != entity.DatumRezervacije) return true;
            if (request.Placena != entity.Placena) return true;
            if (request.Potvrdjena != entity.Potvrdjena) return true;
            if (request.Poruka != entity.Poruka) return true;

            return false;
        }

        private async Task UpdateEntity(Rezervacija entity, RezervacijaUpsertRequest request)
        {

            if (request.StolId != null && request.StolId != entity.StolId) entity.StolId = (int)request.StolId;
            if ((request.DatumRezervacije != null || request.DatumRezervacije < DateTime.Now) && request.DatumRezervacije != entity.DatumRezervacije) entity.DatumRezervacije = request.DatumRezervacije;
            if (request.Placena != null && request.Placena != entity.Placena) entity.Placena = request.Placena;
            if (request.Potvrdjena != null && request.Potvrdjena != entity.Potvrdjena) entity.Potvrdjena = request.Potvrdjena;
            if (!string.IsNullOrEmpty(request.Poruka) && request.Poruka != entity.Poruka) entity.Poruka = request.Poruka;

            entity.DatumIzmjene = DateTime.Now;

            await Context.SaveChangesAsync();
        }

    }
}
