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
    public class FavoritController
    {
        private IFavoriteService _service;
        public FavoritController(IFavoriteService service)
        {
            _service = service;
        }

        [HttpPost]
        public Task<Model.Favorit> DodajFavoritJelo(Model.Favorit request)
        {
            return _service.DodajFavoritJelo(request);
        }

        [HttpDelete]
        public Task<Model.Favorit> UkloniFavoritJelo(Model.Favorit request)
        {
            return _service.UkloniFavoritJelo(request);
        }

        [HttpGet]
        public Task<List<Model.Jelo>> GetNajdrazaJelaByKlijentId(int klijentId)
        {
            return _service.GetNajdrazaJelaByKlijentId(klijentId);
        }

        [HttpGet]
        [Route("checkJeloFavorit")]
        public Task<Model.Jelo> CheckIfJeloNajdraze(int klijentId, int jeloId)
        {
            return _service.CheckIfJeloNajdraze(klijentId, jeloId);
        }

    }
}
