using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class AuthenticationRequest
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
