using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IFavoriteService
    {
        public Task<Model.Favorit> DodajFavoritJelo(Model.Favorit request);
        public Task<Model.Favorit> UkloniFavoritJelo(Model.Favorit request);
        public Task<List<Model.Jelo>> GetNajdrazaJelaByKlijentId(int klijentId);
        public Task<Model.Jelo> CheckIfJeloNajdraze(int klijentId, int jeloId);
    }
}