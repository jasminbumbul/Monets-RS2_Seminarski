using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Model.Requests
{
    public class KlijentSearchRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Status { get; set; }
    }
}
