using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Monets.Model
{
    public partial class JeloMeni
    {
        [JsonIgnore]
        public int JeloId { get; set; }
        [JsonIgnore]
        public int MeniId { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Meni Meni { get; set; }
    }
}
