using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Monets.Api.Interfaces;
using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Monets.Api.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IKorisnickiRacun korisnickiRacunService;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IKorisnickiRacun korisnickiRacunService) : base(options, logger, encoder, clock)
        {
            this.korisnickiRacunService = korisnickiRacunService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            Model.AuthKorisnickiRacun user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(":");
                var username = credentials[0];
                var password = credentials[1];

                var request = new AuthenticationRequest() { KorisnickoIme = username, Lozinka = password };

                user = await korisnickiRacunService.Login(request);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Pogrešan username ili password!");

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.KorisnickoIme),
                new Claim(ClaimTypes.Name, user.Ime),
                new Claim(ClaimTypes.Surname, user.Prezime),
            };

            if (user.Uposlenik != null)
            {
                foreach (var role in user.Uposlenik.UposlenikUloga)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Uloga.Naziv));
                }
            }

            if (user.Klijent != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Klijent"));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
