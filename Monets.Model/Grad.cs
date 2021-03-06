using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model
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
