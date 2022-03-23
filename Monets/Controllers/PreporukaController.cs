using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monets.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PreporukaController : ControllerBase
    {
        private readonly IPreporukaService _service;

        public PreporukaController(IPreporukaService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<List<Model.Jelo>> Preporuka(int id)
        {
            return await _service.Preporuka(id);
        }
    }
}
