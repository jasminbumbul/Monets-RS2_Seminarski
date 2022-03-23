using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Monets.Model
{
    public partial class Favorit
    {
        [JsonIgnore]
        public int FavoritId{ get; set; }
        public int JeloId{ get; set; }
        public int KlijentId { get; set; }
        public byte[] Slika { get; set; }

    }
}
