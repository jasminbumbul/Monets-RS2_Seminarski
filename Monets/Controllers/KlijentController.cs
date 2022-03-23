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
using System.Text.Json.Serialization;

namespace Monets.Api.Controllers
{
    [Authorize]
    public class KlijentController : BaseCRUDController<Model.Klijent, KlijentSearchRequest, KlijentInsertRequest, KlijentUpdateRequest>
    {
        private readonly IKlijentService service;
        public KlijentController(IKlijentService service) : base(service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Klijent")]
        [Consumes("application/json")]
        [HttpPost("Login")]
        public async Task<Model.Klijent> Login(AuthenticationRequest request)
        {
            return await service.Login(request);
        }

        [Authorize(Roles = "Klijent")]
        [HttpPut("UpdatePassword")]
        public async Task UpdatePassword(Model.Requests.UpdatePasswordModel passwordModel)
        {
            await service.UpdatePassword(passwordModel);
        }

        [HttpPut("ProvjeraKoda")]
        public async Task ProvjeraKoda(Model.Requests.UpdatePasswordModel passwordModel)
        {
            await service.ProvjeraKoda(passwordModel);
        }

    }
}
