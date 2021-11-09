using AutoMapper;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Services
{
    public class BaseCRUDService<T, TDb, TSearch,TInsert, TUpdate> : BaseReadService<T,TDb,TSearch>, ICRUDService<T,TSearch,TInsert,TUpdate> where T : class where TDb : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(MonetsContext context, IMapper mapper):base(context, mapper)
        {
        }

        public virtual async Task<T> Insert(TInsert request)
        {
            var entity = _mapper.Map<TDb>(request);

            await Context.Set<TDb>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public virtual async Task<T> Update(int id, TUpdate request)
        {
            var entity = await Context.Set<TDb>().FindAsync(id);

            Context.Set<TDb>().Attach(entity);
            Context.Set<TDb>().Update(entity);

            _mapper.Map(request, entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await Context.Set<TDb>().FindAsync(id);

            if (entity == null)
                throw new UserException(typeof(TDb).Name + " nije pronađen.");

            Context.Remove(entity);
            await Context.SaveChangesAsync();

            return true;
        }
    }
}
