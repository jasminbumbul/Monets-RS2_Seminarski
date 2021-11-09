using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Interfaces;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class StolService : BaseCRUDService<Model.Stol, Database.Stol, StolSearchRequest, StolUpsertRequest, StolUpsertRequest>, IStolService
    {
        public StolService(MonetsContext context, IMapper mapper) : base(context, mapper)
        {}

        public async override Task<List<Model.Stol>> Get(StolSearchRequest search)
        {
            var entity = Context.Stol.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.NazivStola))
            {
                entity = entity.Where(x => x.NazivStola.Contains(search.NazivStola));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.Stol>>(list);
        }

        public async override Task<Model.Stol> Insert(StolUpsertRequest request)
        {
            if (request.BrojMjesta < 1)
            {
                throw new UserException("Broj mjesta za stolom mora biti veći od 0");
            }

            if (request.NazivStola.Length < 3)
            {
                throw new UserException("Naziv stola nije validan");
            }

            var stol = _mapper.Map<Stol>(request);
            await Context.Stol.AddAsync(stol);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Stol>(stol);
        }

        public async override Task<Model.Stol> Update(int id, StolUpsertRequest request)
        {
            if (request.BrojMjesta < 1)
            {
                throw new UserException("Broj mjesta za stolom mora biti veći od 0");
            }

            if (request.NazivStola.Length < 3)
            {
                throw new UserException("Naziv stola nije validan");
            }

            var listaStolova = await Context.Stol.Select(x => x.StolId).Distinct().ToListAsync();

            if (!listaStolova.Contains(id))
            {
                throw new UserException("Stol sa unesenim id-em ne postoji.");
            }

            var stol = await Context .Stol.Where(x => x.StolId == id).SingleOrDefaultAsync();

            stol.NazivStola = request.NazivStola;
            stol.BrojMjesta = request.BrojMjesta;

            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Stol>(stol);
        }
    }
}
