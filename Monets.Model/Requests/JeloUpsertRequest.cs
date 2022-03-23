using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class JeloUpsertRequest
    {
        public string NazivJela { get; set; }
        public string OpisJela { get; set; }
        public int VrijemeIzradeUminutama { get; set; }
        public double Cijena { get; set; }
        public int KategorijaId { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
    }
}
