using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Transakcija
    {
        public int TransakcijaId { get; set; }
        public string Šifra { get; set; }
        public int? RezervacijaId { get; set; }
        public int? KorisnikId { get; set; }
        public DateTime? Datum { get; set; }

        public virtual KorisnickiRacun Korisnik { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
