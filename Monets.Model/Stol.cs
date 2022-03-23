using System;
using System.Collections.Generic;

namespace Monets.Model
{
    public class Stol
    {
        //public Stol()
        //{
        //    RezervacijaStol = new HashSet<RezervacijaStol>();
        //}

        public int StolId { get; set; }
        public string NazivStola { get; set; }
        public int BrojMjesta { get; set; }

        //public virtual ICollection<RezervacijaStol> RezervacijaStol { get; set; }
    }
}
