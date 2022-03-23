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
    [Route("api/[controller]")]
    [ApiController]
    public class UposlenikController : BaseCRUDController<Model.Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikUpdateRequest>
    {
        private readonly IUposlenikService service;
        public UposlenikController(IUposlenikService service) : base(service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin, Uposlenik")]
        [HttpPost("Login")]
        public async Task<Model.Uposlenik> Login(AuthenticationRequest request)
        {
            return await service.Login(request);
        }

    }
}
