using Microsoft.AspNetCore.Mvc;
using Monets.Api.Services;
using Monets.Model;
using Monets.Model.Requests;
using Monets.Services;
using System;
using Monets.Api.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeniController : BaseCRUDController<Model.Meni, MeniSearchRequest, MeniUpsertRequest, MeniUpsertRequest>
    {
        private readonly IMeniService _service;
        public MeniController(IMeniService service) : base(service)
        {
            _service = service;
        }
    }
}
