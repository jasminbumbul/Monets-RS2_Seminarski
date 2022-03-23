using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Jelo = new HashSet<Jelo>();
        }

        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        public string SlikaPutanja { get; set; }

        public virtual ICollection<Jelo> Jelo { get; set; }
    }
}
