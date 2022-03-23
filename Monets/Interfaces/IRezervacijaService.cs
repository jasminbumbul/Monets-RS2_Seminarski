using Monets.Model;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IRezervacijaService : ICRUDService<Model.Rezervacija,RezervacijaSearchRequest,RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        public Task<List<Rezervacija>> GetReservationsForDate(DateTime date, int stolId);
        public Task<List<SlobodnoVrijeme>> GetFreeTimesForDate(DateTime date, int stolId);
        public Task<List<Model.SlobodnoVrijeme>> GetFreeEndTimesForDate(DateTime date, int stolId);
        public Task<List<Model.Jelo>> getJelaIzRezervacije(int rezervacjaId);
        public Task<Model.JeloRezervacija> DodajJeloURezervaciju(JeloRezervacijaInsertRequest jeloRezervacijaInsertRequest);
        public Task<Model.JeloRezervacija> UkloniJeloIzRezervacije(JeloRezervacijaInsertRequest jeloRezervacijaInsertRequest);
        public Task<Model.JeloRezervacija> GetKolicinuZaJeloRezervaciju(int jeloId, int rezervacijaId);
    }
}