using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Meni
    {
        public Meni()
        {
            JeloMeni = new HashSet<JeloMeni>();
        }

        public int MeniId { get; set; }
        public string Naziv { get; set; }
        public double? Cijena { get; set; }

        public virtual ICollection<JeloMeni> JeloMeni { get; set; }
    }
}
