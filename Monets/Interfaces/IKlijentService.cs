using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IKlijentService : ICRUDService<Model.Klijent, KlijentSearchRequest, KlijentInsertRequest, KlijentUpdateRequest>
    {
        public Task<Model.Klijent> Login(AuthenticationRequest request);
    }
}
