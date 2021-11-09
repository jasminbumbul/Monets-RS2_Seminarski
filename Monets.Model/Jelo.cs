using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Monets.Model
{
    public class Jelo
    {
        public int JeloId { get; set; }
        public string NazivJela { get; set; }
        public int? VrijemeIzradeUminutama { get; set; }
        public double? Cijena { get; set; }
        public int? KategorijaId { get; set; }
        public string SlikaPutanja { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public byte[] Slika { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<JeloRezervacija> JeloRezervacija { get; set; }
    }
}
