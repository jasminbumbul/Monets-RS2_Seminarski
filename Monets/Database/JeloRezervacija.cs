using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class JeloRezervacija
    {
        public int JeloRezervacijaId { get; set; }
        public int JeloId { get; set; }
        public int RezervacijaId { get; set; }
        public int Kolicina { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
