using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Favorit
    {
        public int FavoritId { get; set; }
        public int? JeloId { get; set; }
        public int? KlijentId { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Klijent Klijent { get; set; }
    }
}
