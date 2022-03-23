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
using Monets.API.Helpers;
using System.IO;

namespace Monets.Api.Services
{
    public class JeloRezervacijaService : IJeloRezervacijaService
    {
        private MonetsContext Context;
        private IMapper _mapper;

        public JeloRezervacijaService(MonetsContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this.Context = context;
        }

        public async Task<List<Model.JeloRezervacija>> Get()    
        {
            var listaJeloRezervacija = await Context.Set<Database.JeloRezervacija>().Include("Jelo.Kategorija").Include("Rezervacija").ToListAsync();

            return _mapper.Map<List<Model.JeloRezervacija>>(listaJeloRezervacija);
        }
    }
}
