using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            JeloRezervacija = new HashSet<JeloRezervacija>();
            Transakcija = new HashSet<Transakcija>();
        }

        public int RezervacijaId { get; set; }
        public string Sifra { get; set; }
        public bool? Potvrdjena { get; set; }
        public bool? Placena { get; set; }
        public bool? Status { get; set; }
        public string Poruka { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int StolId { get; set; }
        public int KlijentId { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual Stol Stol { get; set; }
        public virtual ICollection<JeloRezervacija> JeloRezervacija { get; set; }
        public virtual ICollection<Transakcija> Transakcija { get; set; }
    }
}
