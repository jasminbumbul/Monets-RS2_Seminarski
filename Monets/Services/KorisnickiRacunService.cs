using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Interfaces;
using Monets.Api.Database;
using Monets.Model;
using Monets.Model.Requests;
using Monets.Api.Filters;
using Monets.Api.Helper;

namespace Monets.Api.Services
{
    public class KorisnickiRacunService : IKorisnickiRacun
    {
        private readonly MonetsContext _context;
        private readonly IMapper _mapper;

        public KorisnickiRacunService(MonetsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthKorisnickiRacun> Login(AuthenticationRequest request)
        {
            var user = await _context.KorisnickiRacun.Include("Uposlenik.UposlenikUloga.Uloga").Include("Klijent").FirstOrDefaultAsync(x => x.KorisnickoIme == request.KorisnickoIme);

            if (user == null)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");
            }

            var newHash = HashGenerator.GenerateHash(user.LozinkaSalt, request.Lozinka);

            if (newHash != user.LozinkaHash)
            {
                throw new UserException("Pogrešno korisničko ime ili lozinka");

            }
            return _mapper.Map<AuthKorisnickiRacun>(user);
        }
    }
}
