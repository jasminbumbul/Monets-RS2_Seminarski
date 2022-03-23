using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class RezervacijaUpsertRequest
    {
        public DateTime PocetakRezervacije { get; set; }
        public DateTime KrajRezervacije { get; set; }
        public bool? Placena { get; set; }
        public int? StolId { get; set; }
        public bool? Potvrdjena { get; set; }
        public bool? PotvrdjenaKlijent { get; set; }
        public bool? OnlinePlacanje { get; set; }
        public string Poruka { get; set; }
        public int KlijentId { get; set; }
        public bool Status{ get; set; }
    }
}
