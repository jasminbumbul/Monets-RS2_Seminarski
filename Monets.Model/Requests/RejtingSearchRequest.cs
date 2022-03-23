using System;
using System.Collections.Generic;

namespace Monets.Model.Requests
{
    public partial class RejtingSearchRequest
    {
        public double? Ocjena { get; set; }
        public int? jeloId { get; set; }
        public int klijentId{ get; set; }
        public bool? Status { get; set; }
    }
}
