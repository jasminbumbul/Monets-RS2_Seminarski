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
    [Route("api/[controller]")]
    [Authorize]
    public class JeloRezervacijaController
    {
        private IJeloRezervacijaService _service;
        public JeloRezervacijaController(IJeloRezervacijaService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<List<Model.JeloRezervacija>> Get()
        {
            return _service.Get();
        }
    }
}
