using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class Location
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("z")]
        public long Z { get; set; }
    }
}