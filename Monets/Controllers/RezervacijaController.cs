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
    public class RezervacijaController : BaseCRUDController<Model.Rezervacija, RezervacijaSearchRequest, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        private IRezervacijaService _service;
        public RezervacijaController(IRezervacijaService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetReservationsForDate")]
        public async Task<List<Rezervacija>> GetReservationsForDate(DateTime date, int stolId)
        {
            return await _service.GetReservationsForDate(date, stolId);
        }

        [HttpGet]
        [Route("GetFreeTimesForDate")]
        public async Task<List<SlobodnoVrijeme>> GetFreeTimesForDate(DateTime date, int stolId)
        {
            return await _service.GetFreeTimesForDate(date, stolId);
        }

        [HttpGet]
        [Route("GetFreeEndTimesForDate")]
        public async Task<List<SlobodnoVrijeme>> GetFreeEndTimesForDate(DateTime date, int stolId)
        {
            return await _service.GetFreeEndTimesForDate(date, stolId);
        }

        [HttpGet]
        [Route("GetJelaIzRezervacije")]
        public async Task<List<Model.Jelo>> getJelaIzRezervacije(int rezervacijaId)
        {
            return await _service.getJelaIzRezervacije(rezervacijaId);
        }


        [HttpPost]
        [Route("DodajJeloURezervaciju")]
        public async Task<Model.JeloRezervacija> DodajJeloURezervaciju(JeloRezervacijaInsertRequest jeloRezervacijaInsertRequest)
        {
            return await _service.DodajJeloURezervaciju(jeloRezervacijaInsertRequest);
        }

        [HttpPost]
        [Route("UkloniJeloIzRezervacije")]
        public async Task<Model.JeloRezervacija> UkloniJeloIzRezervacije(JeloRezervacijaInsertRequest jeloRezervacijaInsertRequest)
        {
            return await _service.UkloniJeloIzRezervacije(jeloRezervacijaInsertRequest);
        }

        [HttpGet]
        [Route("GetKolicinuZaJeloRezervaciju")]
        public async Task<Model.JeloRezervacija> GetKolicinuZaJeloRezervaciju(int jeloId, int rezervacijaId)
        {
            return await _service.GetKolicinuZaJeloRezervaciju(jeloId, rezervacijaId);
        }


    }
}
