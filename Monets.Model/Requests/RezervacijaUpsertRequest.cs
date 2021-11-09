using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class RezervacijaUpsertRequest
    {
        public DateTime DatumRezervacije{ get; set; }
        public bool? Placena { get; set; }
        public int? StolId { get; set; }
        public bool? Potvrdjena { get; set; }
        public string Poruka { get; set; }
    }
}
