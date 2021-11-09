using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
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
    public class RejtingService : BaseCRUDService<Model.Rejting, Database.Rejting, RejtingSearchRequest, RejtingUpsertRequest, RejtingUpsertRequest>, IRejtingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RejtingService(MonetsContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async override Task<List<Model.Rejting>> Get(RejtingSearchRequest search = null)
        {
            var entity = Context.Rejting.AsQueryable();

            if (search?.Ocjena > 0)
            {
                entity = entity.Where(x => x.Ocjena == search.Ocjena);
            }

            if (search?.jeloId > 0)
            {
                entity = entity.Where(x => x.JeloId == search.jeloId);
            }

            if(search?.Status==true)
            {
                entity = entity.Where(x => x.Status == true);
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.Rejting>>(list);
        }

        public async override Task<Model.Rejting> Insert(RejtingUpsertRequest request)
        {
            var loggedInUserUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.KlijentId = await Context.Klijent.Include("KorisnickiRacun").Where(x => x.KorisnickiRacun.KorisnickoIme== loggedInUserUsername).Select(x => x.KlijentId).FirstOrDefaultAsync();

            if (request.Ocjena < 0 || request.Ocjena > 5)
            {
                throw new UserException("Ocjena nije validna(mora biti između 0-5).");
            }

            var listaJela = await Context.Jelo.Select(x => x.JeloId).ToListAsync();

            if (!listaJela.Contains((int)request.JeloId))
            {
                throw new UserException("Jelo za koje pokušavate dodati rejting ne postoji.");
            }

            var rejting = _mapper.Map<Rejting>(request);
            await Context.Rejting.AddAsync(rejting);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Rejting>(rejting);
        }

        public async override Task<Model.Rejting> Update(int id, RejtingUpsertRequest request)
        {
            var rejting = await Context.Rejting.Where(x => x.RejtingId == id).SingleOrDefaultAsync();
            if (rejting==null)
            {
                throw new UserException("Rejting ne postoji.");
            }

            if (request.Ocjena < 0 || request.Ocjena > 5)
            {
                throw new UserException("Ocjena nije validna(mora biti između 0-5).");
            }

            var loggedInUserUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.KlijentId = await Context.Klijent.Include("KorisnickiRacun").Where(x => x.KorisnickiRacun.KorisnickoIme == loggedInUserUsername).Select(x => x.KlijentId).FirstOrDefaultAsync();

            var listaJela = await Context.Jelo.ToListAsync();

            var jelo = await Context.Jelo.FindAsync(request.JeloId);
            if (!listaJela.Contains(jelo))
            {
                throw new UserException("Jelo za koje pokušavate dodati rejting ne postoji.");
            }

            rejting = _mapper.Map<Rejting>(request);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Rejting>(rejting);
        }

        public override async Task<bool> Delete(int id)
        {
            var entity = await Context.Rejting.Where(x=> x.RejtingId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Rejting nije pronađen!");
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
    }
}
