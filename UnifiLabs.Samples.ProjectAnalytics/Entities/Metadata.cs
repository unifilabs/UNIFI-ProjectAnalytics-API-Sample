using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class Metadata
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("collectedFromEvent")]
        public string CollectedFromEvent { get; set; }

        [JsonProperty("saveDuration")]
        public long SaveDuration { get; set; }

        [JsonProperty("syncWithCentralDuration")]
        public double SyncWithCentralDuration { get; set; }

        [JsonProperty("revitProjectIds")]
        public string[] RevitProjectIds { get; set; }
    }
}