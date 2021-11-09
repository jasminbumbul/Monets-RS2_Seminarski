using System.Collections.Generic;

namespace Monets.Api.Database
{
    public class Grad
    {
        public Grad()
        {
            Uposlenici = new HashSet<Uposlenik>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Uposlenik> Uposlenici { get; set; }
    }
}