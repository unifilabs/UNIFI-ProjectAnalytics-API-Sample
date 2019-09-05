using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Commit {
        [JsonProperty("author")] public string Author { get; set; }

        [JsonProperty("dataId")] public Guid DataId { get; set; }

        [JsonProperty("eventId")] public string EventId { get; set; }

        [JsonProperty("timestamp")] public DateTimeOffset Timestamp { get; set; }
    }
}