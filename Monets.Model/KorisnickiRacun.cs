using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model
{
    public partial class KorisnickiRacun
    {
        public int KorisnickiRacunId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool? Status { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }

        public virtual Uposlenik Uposlenik { get; set; }
        public virtual Klijent Klijent { get; set; }

        [JsonIgnore]
        public string ImePrezime
        {
            get { return Ime + " " + Prezime; }
        }
    }
}
