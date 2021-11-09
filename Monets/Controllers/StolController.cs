using Microsoft.AspNetCore.Mvc;
using Monets.Api.Services;
using Monets.Model;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using Monets.Api.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StolController : BaseCRUDController<Model.Stol, StolSearchRequest, StolUpsertRequest, StolUpsertRequest>
    {
        private IStolService _service;
        public StolController(IStolService service) : base(service)
        {
            _service = service;
        }
    }
}
