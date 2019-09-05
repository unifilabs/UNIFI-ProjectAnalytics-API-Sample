using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class NumericRevisionInfo {
        [JsonProperty("prefix")] public string Prefix { get; set; }

        [JsonProperty("suffix")] public string Suffix { get; set; }

        [JsonProperty("startNumber")] public long StartNumber { get; set; }
    }
}