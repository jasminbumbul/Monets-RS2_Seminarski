using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class Rejting
    {
        public int RejtingId { get; set; }
        public double? Ocjena { get; set; }
        public int JeloId { get; set; }
        public int KlijentId { get; set; }
        public bool Status { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Klijent Klijent{ get; set; }

    }
}
