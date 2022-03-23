using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IEmailService
    {
        public void VerifikujEmail(string guid);
        public void SendConfirmationEmail(int korisnikId);
        public void SendPasswordResetEmail(string email);
    }
}