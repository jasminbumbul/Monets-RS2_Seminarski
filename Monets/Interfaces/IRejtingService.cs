using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IRejtingService : ICRUDService<Model.Rejting,RejtingSearchRequest,RejtingUpsertRequest,RejtingUpsertRequest>
    {
        public Task<double> GetUkupanRejtingZaJelo(int jeloId);
    }
}
