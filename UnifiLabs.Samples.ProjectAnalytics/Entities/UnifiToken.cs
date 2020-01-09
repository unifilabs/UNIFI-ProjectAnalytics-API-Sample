using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class UnifiToken
    {
        [JsonProperty("apiKey")] public string APIKey { get; set; }
        [JsonProperty("type")] public string AccessType { get; set; }
    }
}
