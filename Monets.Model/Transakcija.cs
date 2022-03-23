using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Monets.Model
{
    public class Transakcija
    {
        public int TransakcijaId { get; set; }
        public string Sifra { get; set; }
        public int? RezervacijaId { get; set; }
        public int? KorisnikId { get; set; }
        public DateTime? Datum { get; set; }
        public double Iznos { get; set; }

        public virtual KorisnickiRacun Korisnik { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
