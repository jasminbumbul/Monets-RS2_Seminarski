using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Klijent
    {
        public Klijent()
        {
            Favorit = new HashSet<Favorit>();
            Rejting = new HashSet<Rejting>();
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int KlijentId { get; set; }
        public bool? Status { get; set; }
        public int KorisnickiRacunId { get; set; }
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        public virtual ICollection<Favorit> Favorit { get; set; }
        public virtual ICollection<Rejting> Rejting { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
