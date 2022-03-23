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
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Monets.Api.Services
{
    public class EmailService : IEmailService
    {
        private MonetsContext context;
        private IMapper mapper;

        public EmailService(MonetsContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void VerifikujEmail(string guid)
        {
            if (String.IsNullOrEmpty(guid))
            {
                throw new UserException("Guid nije validan");
            }

            var korisnickiRacun = context.KorisnickiRacun.Where(x => x.Guid == guid).FirstOrDefault();
            var korisnik = context.Klijent.Where(x=> x.KorisnickiRacunId == korisnickiRacun.KorisnickiRacunId).FirstOrDefault();

            if (korisnik != null)
            {
                korisnickiRacun.EmailVerified = true;
                context.SaveChanges();
            }
            else
            {
                throw new UserException("Korisnik nije validan");
            }
        }

        public async void SendConfirmationEmail(int korisnikId)
        {
            var korisnik = context.Klijent.Where(x => x.KlijentId == korisnikId).FirstOrDefault();
            if (korisnik == null)
            {
                throw new UserException("Korisnik nije validan");
            }

            var korisnickiRacun = context.KorisnickiRacun.Where(x => x.KorisnickiRacunId==korisnik.KorisnickiRacunId).FirstOrDefault();

            String link = $"http://localhost:5010/api/VerifyEmail?GUID={korisnickiRacun.Guid}";

            var body = "<p>{0}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(korisnickiRacun.Email));
            message.From = new MailAddress("ekorpa.business@gmail.com");
            message.Subject = "Verifikacija e-maila";
            message.Body = string.Format($"<a href='{link}'>Potvrdite email klikom na ovaj link<a><\\\\br>(link mora biti http) Vaš Monets");

            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "ekorpa.business@gmail.com",
                    Password = "Mostar2020!"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }

        }

        public async void SendPasswordResetEmail(string email)
        {
            var korisnik = context.Klijent.Include("KorisnickiRacun").Where(x => x.KorisnickiRacun.Email.Equals(email)).FirstOrDefault();
            if (korisnik == null)
            {
                throw new UserException("Korisnik nije validan");
            }

            string randomCode;

            TimeSpan ts = DateTime.Now - korisnik.KorisnickiRacun.PassCodeCreated;
            if (ts.TotalMinutes > 5)
            {
                randomCode = RandomStringGenerator.GenerateRandomCode(6);
            }
            else
            {
                randomCode = korisnik.KorisnickiRacun.PassCode;
            }

            korisnik.KorisnickiRacun.PassCode = randomCode;
            korisnik.KorisnickiRacun.PassCodeCreated = DateTime.Now;
            context.SaveChanges();

            var body = "<p>{0}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("ekorpa.business@gmail.com");
            message.Subject = "Reset passworda";
            message.Body = string.Format($"Kod za reset passworda je: {randomCode}<\\br>Kod ističe za 5 minuta.<\\br>Vaš Monets");

            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "ekorpa.business@gmail.com",
                    Password = "Mostar2020!"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
