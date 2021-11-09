using AutoMapper;
using Monets.Api.Filters;
using Monets.Api.Database;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Interfaces;

namespace Monets.Api.Services
{
    public class KategorijaService : BaseCRUDService<Model.Kategorija, Database.Kategorija, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest>, IKategorijaService
    {
        public KategorijaService(MonetsContext context, IMapper mapper) : base(context, mapper)
        {}

        public async override Task<List<Model.Kategorija>> Get(KategorijaSearchRequest search = null)
        {
            var entity = Context.Set<Database.Kategorija>().AsQueryable();

            if (!String.IsNullOrEmpty(search?.NazivKategorije))
            {
                entity = entity.Where(x => x.Naziv.Contains(search.NazivKategorije));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.Kategorija>>(list);
        }

        public async override Task<bool> Delete(int id)
        {
            var kategorijeUJelima = await Context.Jelo.Select(x => x.KategorijaId).Distinct().ToListAsync();
            var kategorija = Context.Kategorija.Find(id);

            if (kategorija == null)
            {
                throw new UserException("Kategorija sa unesem id-om ne postoji!");
            }

            if (kategorijeUJelima.Contains(id))
            {
                throw new UserException("Nije moguće obrisati kategoriju koja se koristi u nekom jelu.");
            }

            return await base.Delete(id);
        }

    }
}
