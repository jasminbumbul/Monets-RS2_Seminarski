using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monets.Api.Interfaces;
using Monets.Api.Services;
using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class JeloController: BaseCRUDController<Model.Jelo,JeloSearchRequest,JeloUpsertRequest,JeloUpsertRequest>
    {
        private IJeloService _service;
        public JeloController(IJeloService service):base(service)
        {
            _service = service;
        }

        [Route("getPreporucenoJelo")]
        [HttpGet]
        public async Task<int> GetPreporucenoJelo(int klijentId)
        {
            return await _service.GetPreporucenoJelo(klijentId);
        }
    }
}
