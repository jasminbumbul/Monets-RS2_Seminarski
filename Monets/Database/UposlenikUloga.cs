using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class UposlenikUloga
    {
        public int UposlenikUlogaId { get; set; }
        public int UposlenikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime? DatumIzmjene { get; set; }

        public virtual Uloga Uloga { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
    }
}
