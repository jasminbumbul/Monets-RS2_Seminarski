using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Services
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T,TSearch> where T : class where TDb : class where TSearch : class
    {
        public MonetsContext Context { get; set; }
        protected readonly IMapper _mapper;

        public BaseReadService(MonetsContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public virtual async Task<List<T>> Get(TSearch search = null)
        {
            var list = await Context.Set<TDb>().ToListAsync();

            return _mapper.Map<List<T>>(list);
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await Context.Set<TDb>().FindAsync(id);

            if (entity == null)
                throw new UserException(typeof(TDb).Name + " nije pronađen.");

            return _mapper.Map<T>(entity);
        }
    }
}
