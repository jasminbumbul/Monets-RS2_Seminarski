using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Model
{
    public partial class Rejting
    {
        public int RejtingId { get; set; }
        public double? Ocjena { get; set; }
        public int? JeloId { get; set; }
        public int KorisnikId { get; set; }

        //public virtual Jelo Jelo { get; set; }
    }
}
