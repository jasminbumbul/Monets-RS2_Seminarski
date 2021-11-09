using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IUposlenikService : ICRUDService<Model.Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikUpdateRequest>
    {
        Task<Model.Uposlenik> Login(AuthenticationRequest request);
    }
}
