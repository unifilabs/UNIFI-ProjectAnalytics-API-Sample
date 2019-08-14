using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class Parameter
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}