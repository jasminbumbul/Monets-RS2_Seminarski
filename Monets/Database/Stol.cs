using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Stol
    {
        public Stol()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int StolId { get; set; }
        public string NazivStola { get; set; }
        public int BrojMjesta { get; set; }

        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
