using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Workset {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("worksetId")] public string WorksetId { get; set; }
    }
}