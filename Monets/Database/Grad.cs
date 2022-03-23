using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Klijent = new HashSet<Klijent>();
            Uposlenik = new HashSet<Uposlenik>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Klijent> Klijent { get; set; }
        public virtual ICollection<Uposlenik> Uposlenik { get; set; }
    }
}
