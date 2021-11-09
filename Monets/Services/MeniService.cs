using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
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
    public class MeniService : BaseCRUDService<Model.Meni, Meni, MeniSearchRequest, MeniUpsertRequest, MeniUpsertRequest>, IMeniService
    {
        private ImageHelper imageHelper = new ImageHelper();

        public MeniService(MonetsContext context, IMapper mapper) : base(context, mapper)
        {}

        public async override Task<List<Model.Meni>> Get(MeniSearchRequest search = null)
        {
            var entity = Context.Meni.Include("JeloMeni.Jelo.Kategorija").Include("JeloMeni.Jelo").AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.Contains(search.Naziv));
            }

            var list = await entity.ToListAsync();
            var returnLista = _mapper.Map<List<Model.Meni>>(list);


            foreach (var item in returnLista)
            {
                foreach (var jelo in item.JeloMeni)
                {
                    var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Jelo", $"{jelo.Jelo.SlikaPutanja}");
                    jelo.Jelo.Slika = await imageHelper.FindImage(directory);
                }
            }

            return returnLista;
        }

        public async override Task<Model.Meni> GetById(int id)
        {
            var entity = await Context.Meni.Include("JeloMeni.Jelo.Kategorija").Include("JeloMeni.Jelo").Where(x => x.MeniId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Meni sa traženim id-om nije pronađen!");
            }

            var result = _mapper.Map<Model.Meni>(entity);

            return result;
        }

        public async override Task<Model.Meni> Insert(MeniUpsertRequest request)
        {
            if (request.Cijena < 0)
            {
                throw new UserException("Cijena nije validna");
            }

            if (request.Naziv.Length < 3)
            {
                throw new UserException("Naziv jela nije validan");
            }

            var meni = _mapper.Map<Meni>(request);
            await Context.Meni.AddAsync(meni);
            await Context.SaveChangesAsync();

            foreach (var jeloId in request.Jela)
            {
                await Context.JeloMeni.AddAsync(new JeloMeni()
                {
                    JeloId=jeloId,
                    MeniId=meni.MeniId
                });
            }
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Meni>(meni);
        }

        public async override Task<Model.Meni> Update(int id, MeniUpsertRequest request)
        {
            if (request.Cijena < 0)
            {
                throw new UserException("Cijena nije validna");
            }

            if (request.Naziv.Length < 3)
            {
                throw new UserException("Naziv jela nije validan");
            }

            var listaMenija = await Context.Meni.Select(x => x.MeniId).Distinct().ToListAsync();

            if (!listaMenija.Contains(id))
            {
                throw new UserException("Meni sa unesenim id-em ne postoji.");
            }

            var meni = await Context.Meni.Include("JeloMeni.Jelo").Where(x => x.MeniId == id).SingleOrDefaultAsync();

            meni.Naziv = request.Naziv;
            meni.Cijena = request.Cijena;

            await Context.SaveChangesAsync();

            List<int> trenutnaJela = Context.JeloMeni.Where(x => x.MeniId==meni.MeniId).Select(x => (int)x.JeloId).ToList();
            if (!request.Jela.SequenceEqual(trenutnaJela))
            {
                var trenutnaMeniJela = Context.JeloMeni.Where(x => x.MeniId == meni.MeniId).ToList();
                foreach (var meniJelo in trenutnaMeniJela)
                {
                    Context.Remove(meniJelo);
                }

                foreach (var jelo in request.Jela)
                {
                    JeloMeni jeloMeni = new JeloMeni();
                    jeloMeni.JeloId = jelo;
                    jeloMeni.MeniId = meni.MeniId;

                    Context.JeloMeni.Add(jeloMeni);
                }
                await Context.SaveChangesAsync();
            }

            return _mapper.Map<Model.Meni>(meni);
        }
    }
}
