using System;
using System.Collections.Generic;

#nullable disable

namespace Monets.Model.Requests
{
    public partial class RejtingSearchRequest
    {
        public double? Ocjena { get; set; }
        public int? jeloId { get; set; }
        public bool? Status { get; set; }
    }
}
