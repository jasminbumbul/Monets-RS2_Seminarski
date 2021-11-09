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

namespace Monets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezervacijaController : BaseCRUDController<Model.Rezervacija, RezervacijaSearchRequest, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        private IRezervacijaService _service;
        public RezervacijaController(IRezervacijaService service) : base(service)
        {
            _service = service;
        }

    }
}
