using System;
using System.Collections.Generic;

namespace Monets.Model.Requests
{
    public partial class RejtingUpsertRequest
    {
        public double Ocjena { get; set; }
        public int JeloId { get; set; }
        public int KlijentId { get; set; }
    }
}
