using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class Commit
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("dataId")]
        public Guid DataId { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
