using Microsoft.AspNetCore.Mvc;
using Monets.Api.Services;
using Monets.Model;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Monets.Api.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Monets.Api.Controllers
{
    [ApiController]
    public class EmailController
    {
        private IEmailService _service;
        public EmailController(IEmailService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Klijent")]
        [Route("api/VerifyEmail")]
        [HttpGet]
        public void VerifikujEmail(string GUID)
        {
            _service.VerifikujEmail(GUID);
        }

        [Route("api/SendConfirmationEmail")]
        [HttpPost]
        public void PosaljiKonfirmacijskiMail(int klijentId)
        {
            _service.SendConfirmationEmail(klijentId);
        }

        [Route("api/SendPasswordResetEmail")]
        [HttpPost]
        public void PosaljiPasswordResetMail(string email)
        {
            _service.SendPasswordResetEmail(email);
        }
    }
}
