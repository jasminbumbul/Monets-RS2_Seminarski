using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IKorisnickiRacun
    {
        Task<Model.AuthKorisnickiRacun> Login(AuthenticationRequest request);
    }
}
