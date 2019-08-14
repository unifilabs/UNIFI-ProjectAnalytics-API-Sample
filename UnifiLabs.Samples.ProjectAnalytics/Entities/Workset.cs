using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class Workset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("worksetId")]
        public string WorksetId { get; set; }
    }
}