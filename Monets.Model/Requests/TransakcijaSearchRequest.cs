using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class TransakcijaSearchRequest
    {
        public string Sifra { get; set; }
        public bool? Status { get; set; }
        public int KlijentId { get; set; }
    }
}
