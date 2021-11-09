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
    //[Authorize]
    public class KlijentController : BaseCRUDController<Model.Klijent, KlijentSearchRequest, KlijentInsertRequest, KlijentUpdateRequest>
    {
        private readonly IKlijentService service;
        public KlijentController(IKlijentService service) : base(service)
        {
            this.service = service;
        }

        //[Authorize(Roles = "Klijent")]
        [HttpPost("Login")]
        public async Task<Model.Klijent> Login(AuthenticationRequest request)
        {
            return await service.Login(request);
        }
    }
}
