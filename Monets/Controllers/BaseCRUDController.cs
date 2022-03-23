using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monets.Api.Interfaces;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public async Task<T> Insert([FromBody] TInsert request)
        {
            return await _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public async Task<T> Update(int id, [FromBody] TUpdate request)
        {
            return await _crudService.Update(id, request);
        }

        [Authorize(Roles = "Admin, Uposlenik")]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _crudService.Delete(id);
        }
    }
}
