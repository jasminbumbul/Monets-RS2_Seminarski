using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Api.Database
{
    public partial class JeloMeni
    {
        public int JeloMeniId { get; set; }
        public int? JeloId { get; set; }
        public int? MeniId { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Meni Meni { get; set; }
    }
}
