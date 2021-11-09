using System;
using System.Collections.Generic;

namespace Monets.Api.Database
{
    public class Klijent
    {
        public Klijent()
        {
            Rezervacije = new HashSet<Rezervacija>();
            Rejtinzi = new HashSet<Rejting>();
        }

        public int KlijentId { get; set; }
        public bool? Status { get; set; }
        public int KorisnickiRacunId { get; set; }

        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        public virtual ICollection<Rezervacija> Rezervacije { get; set; }
        public virtual ICollection<Rejting> Rejtinzi { get; set; }

    }
}