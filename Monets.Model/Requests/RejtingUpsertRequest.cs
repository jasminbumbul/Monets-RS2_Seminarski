using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Monets.Model.Requests
{
    public partial class RejtingUpsertRequest
    {
        public double Ocjena { get; set; }
        public int JeloId { get; set; }
        [JsonIgnore]
        public int KlijentId { get; set; }
    }
}
