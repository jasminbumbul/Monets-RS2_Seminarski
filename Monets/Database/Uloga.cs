using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            UposlenikUloga = new HashSet<UposlenikUloga>();
        }

        public int UlogaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<UposlenikUloga> UposlenikUloga { get; set; }
    }
}
