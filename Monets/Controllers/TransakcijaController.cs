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
    [Authorize]
    public class TransakcijaController
    {
        private readonly ITransakcijaService service;
        public TransakcijaController(ITransakcijaService service) 
        {
            this.service = service;
        }

        [HttpGet]
        public List<Model.Transakcija> Get([FromQuery] TransakcijaSearchRequest request)
        {
            return service.Get(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Model.Transakcija GetById(int id)
        {
            return  service.GetById(id);
        }

        [HttpPost]
        public Model.Transakcija Insert(Model.Transakcija request)
        {
            return service.Insert(request);
        }

        [Authorize(Roles = "Admin, Uposlenik")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return  service.Delete(id);
        }
    }
}
