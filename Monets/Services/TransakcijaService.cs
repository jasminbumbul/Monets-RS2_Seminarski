using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;
using Monets.Api.Filters;
using Monets.Api.Helper;
using Monets.Api.Interfaces;
using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class TransakcijaService : ITransakcijaService
    {
        public MonetsContext Context { get; set; }
        protected readonly IMapper _mapper;
        public TransakcijaService(MonetsContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public List<Model.Transakcija> Get(TransakcijaSearchRequest request = null)
        {
            var query = Context.Transakcija.Include("Rezervacija").Include("Korisnik.Klijent").AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Sifra))
            {
                query = query.Where(s => s.Sifra.Contains(request.Sifra));
            }

            if (request.KlijentId!=0)
            {
                query = query.Where(s => s.Korisnik.Klijent.KlijentId==request.KlijentId);
            }

            if (request.Status==true || request.Status==null)
            {
                query = query.Where(s => s.Status == true);
            }
            else if(request.Status==false)
            {
                query = query.Where(s => s.Status == false || s.Status == true);
            }


            var list = query.ToList();

           var result =  _mapper.Map<List<Model.Transakcija>>(list);

            return result;
        }

        public Model.Transakcija GetById(int id)
        {
            var entity = Context.Transakcija.Where(x => x.TransakcijaId == id).SingleOrDefault();

            if (entity == null)
            {
                throw new UserException("Transakcija nije pronađena!");
            }

            return _mapper.Map<Model.Transakcija>(entity);
        }

        public Model.Transakcija Insert(Model.Transakcija request)
        {
            if (request == null)
            {
                throw new UserException("Request nije validan");
            }

            var korisnickiRacunId = Context.Klijent.Include("KorisnickiRacun").Where(x => x.KlijentId == request.KorisnikId).Select(x => x.KorisnickiRacun.KorisnickiRacunId).SingleOrDefault();
            request.KorisnikId = korisnickiRacunId;
            var transakcija = _mapper.Map<Database.Transakcija>(request);
            transakcija.Sifra = RandomStringGenerator.GenerateRandomCode(6);
            transakcija.Status = true;
            transakcija.Datum = DateTime.Now;
            Context.Add(transakcija);
            Context.SaveChanges();

            return _mapper.Map<Model.Transakcija>(transakcija);
        }

        public bool Delete(int id)
        {
            var entity =  Context.Transakcija.Where(x => x.TransakcijaId == id).SingleOrDefault();

            if (entity == null)
            {
                throw new UserException("Transakcija nije pronađena!");
            }

            try
            {
                entity.Status = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new UserException("Greška prilikom brisanja transakcije." + ex.InnerException);
            }
        }
    }
}
