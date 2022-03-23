using System;
using System.Collections.Generic;

namespace Monets.Model.Requests
{
    public class RezervacijaSearchRequest
    {
        public string Sifra { get; set; }
        public bool? Status { get; set; }
        public int KlijentId { get; set; }
        public bool PotvrdjenaKlijent { get; set; }
    }
}
