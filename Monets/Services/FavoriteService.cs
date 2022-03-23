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
    public class FavoriteService : IFavoriteService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private MonetsContext context;
        private IMapper mapper;
        private ImageHelper imageHelper = new ImageHelper();

        public FavoriteService(MonetsContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<Model.Favorit> DodajFavoritJelo(Model.Favorit request)
        {
            var klijent = context.Klijent.Find(request.KlijentId);

            if (klijent == null)
            {
                throw new UserException("Klijent ne postoji.");
            }

            var jelo = context.Jelo.Find(request.JeloId);

            if (jelo==null)
            {
                throw new UserException("Jelo ne postoji");
            }

            var favoriti = context.Favorit.Where(x => x.KlijentId == request.KlijentId && x.JeloId == request.JeloId).ToList();
            if(favoriti.Count> 0)
            {
                return mapper.Map<Model.Favorit>(favoriti.First());
            }

            var favorit = mapper.Map<Favorit>(request);

            await context.Favorit.AddAsync(favorit);
            await context.SaveChangesAsync();

            return mapper.Map<Model.Favorit>(favorit);
        }

        public async Task<Model.Favorit> UkloniFavoritJelo(Model.Favorit request)
        {
            var favorit = context.Favorit.Where(x=> x.KlijentId==request.KlijentId && x.JeloId==request.JeloId).FirstOrDefault();
            if(favorit == null)
            {
                throw new UserException("Favorit jelo ne postoji");
            }

            context.Favorit.Remove(favorit);
            await context.SaveChangesAsync();

            return mapper.Map<Model.Favorit>(favorit);
        }

        public async Task<List<Model.Jelo>> GetNajdrazaJelaByKlijentId(int klijentId)
        {
            if (klijentId == 0)
            {
                throw new UserException("Klijent nije validan");
            }

            var jela = context.Favorit.Include("Jelo").Where(x => x.KlijentId == klijentId).Select(x => x.Jelo).ToList();

            var result = mapper.Map<List<Model.Jelo>>(jela);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Jelo", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async Task<Model.Jelo> CheckIfJeloNajdraze(int klijentId, int jeloId)
        {
            if (klijentId == 0)
            {
                throw new UserException("Klijent nije validan");
            }

            if (jeloId == 0)
            {
                throw new UserException("Jelo nije validno");
            }

            var jelo = context.Favorit.Include("Jelo").Where(x => x.KlijentId == klijentId & x.JeloId==jeloId).Select(x => x.Jelo).FirstOrDefault();

            if(jelo != null)
            {
                return mapper.Map<Model.Jelo>(jelo);
            }
            else
            {
                return null;
            }

        }

    }
}
