using System;
using System.Collections.Generic;

namespace Monets.Api.Database
{
    public class Uposlenik
    {
        public Uposlenik()
        {
            UposlenikUloga = new HashSet<UposlenikUloga>();
        }

        public int UposlenikId { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public bool? Status { get; set; }
        public int GradId { get; set; }
        public int KorisnickiRacunId { get; set; }
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual ICollection<UposlenikUloga> UposlenikUloga { get; set; }
    }
}