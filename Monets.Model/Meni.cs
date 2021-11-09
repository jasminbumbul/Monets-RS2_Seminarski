using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Model
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
        //public List<int>Jela{ get; set; }
    }
}
