using Microsoft.AspNetCore.Http;
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
    public class KategorijaController : BaseCRUDController<Model.Kategorija,KategorijaSearchRequest,KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        private IKategorijaService _service;

        public KategorijaController(IKategorijaService service) : base(service)
        {
            _service = service;
        }
    }
}
