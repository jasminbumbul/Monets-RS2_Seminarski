using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Monets.Model
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public string Sifra { get; set; }
        public bool Potvrdjena { get; set; }
        public bool PotvrdjenaKlijent { get; set; }
        public bool Placena { get; set; }
        public bool Status { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime PocetakRezervacije { get; set; }
        public DateTime KrajRezervacije { get; set; }
        public string Poruka { get; set; }
        public int StolId { get; set; }
        public int KlijentId { get; set; }
        public bool OnlinePlacanje { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual Stol Stol { get; set; }
        public virtual ICollection<JeloRezervacija> JeloRezervacija { get; set; }

        [JsonIgnore]
        public string ImePrezimeKlijenta
        {
            get { return Klijent.ImePrezimeKlijenta; }
        }

    }
}
