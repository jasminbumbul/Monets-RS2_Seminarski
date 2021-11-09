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
using Monets.Api.Database;

namespace Monets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradController : BaseReadController<Model.Grad, object>
    {
        public GradController(IReadService<Model.Grad, object> service)
            : base(service)
        {
        }
    }
}
