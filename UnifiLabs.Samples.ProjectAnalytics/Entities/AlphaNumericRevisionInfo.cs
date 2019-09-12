using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class AlphaNumericRevisionInfo {
        [JsonProperty("prefix")] public string Prefix { get; set; }

        [JsonProperty("suffix")] public string Suffix { get; set; }

        [JsonProperty("sequence")] public string[] Sequence { get; set; }
    }
}