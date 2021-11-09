using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Model
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public string Sifra { get; set; }
        public bool Potvrdjena { get; set; }
        public bool Placena { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public string Poruka { get; set; }
        public int StolId { get; set; }
        public int KlijentId { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual Stol Stol { get; set; }
        public virtual ICollection<JeloRezervacija> JeloRezervacija { get; set; }
    }
}
