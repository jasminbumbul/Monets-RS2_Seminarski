using System;
using System.Collections.Generic;

namespace Monets.Model
{
    public class Uposlenik
    {
        public Uposlenik()
        {
            UposlenikUloga = new HashSet<UposlenikUloga>();
        }
        public int UposlenikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool? Status { get; set; }
        public string SlikaPutanja { get; set; }
        public int GradId { get; set; }

        public byte[] Slika { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual ICollection<UposlenikUloga> UposlenikUloga { get; set; }
    }
}
