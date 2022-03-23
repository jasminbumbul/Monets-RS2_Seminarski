using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class KategorijaUpsertRequest
    {
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        public string SlikaPutanja { get; set; }
    }
}
