using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Images {
        [JsonProperty("imageTypes")] public object[] ImageTypes { get; set; }

        [JsonProperty("imageInstances")] public object[] ImageInstances { get; set; }
    }
}