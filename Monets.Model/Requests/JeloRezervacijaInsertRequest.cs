using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class JeloRezervacijaInsertRequest
    {
        public int jeloId { get; set; }
        public int rezervacijaId { get; set; }
        public int kolicina { get; set; }
    }
}
