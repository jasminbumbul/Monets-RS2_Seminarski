using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class MeniUpsertRequest
    {
        public string Naziv { get; set; }
        public double? Cijena { get; set; }
        public List<int> Jela { get; set; } = new List<int>();

    }
}
