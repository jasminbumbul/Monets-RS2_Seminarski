using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Jelo
    {
        public Jelo()
        {
            JeloMeni = new HashSet<JeloMeni>();
            JeloRezervacija = new HashSet<JeloRezervacija>();
            Rejting = new HashSet<Rejting>();
        }

        public int JeloId { get; set; }
        public string NazivJela { get; set; }
        public int? VrijemeIzradeUminutama { get; set; }
        public double? Cijena { get; set; }
        public int? KategorijaId { get; set; }
        public string SlikaPutanja { get; set; }
        public bool Status { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<JeloMeni> JeloMeni { get; set; }
        public virtual ICollection<JeloRezervacija> JeloRezervacija { get; set; }
        public virtual ICollection<Rejting> Rejting { get; set; }
    }
}
