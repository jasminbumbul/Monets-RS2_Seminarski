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
using Microsoft.AspNetCore.Authorization;

namespace Monets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RejtingController : BaseCRUDController<Model.Rejting, RejtingSearchRequest, RejtingUpsertRequest, RejtingUpsertRequest>
    {
        private IRejtingService _service;
        public RejtingController(IRejtingService service) : base(service)
        {
            _service = service;
        }


        [Route("GetUkupanRejtingZaJelo")]
        [HttpGet]
        public async Task<double> GetUkupanRejtingZaJelo(int jeloId)
        {
            return await _service.GetUkupanRejtingZaJelo(jeloId);
        }

    }
}
