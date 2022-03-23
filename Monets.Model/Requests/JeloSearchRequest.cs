using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class JeloSearchRequest
    {
        public string Naziv { get; set; }
        public int JeloId { get; set; }
        public int KategorijaId { get; set; }
    }
}
