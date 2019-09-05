using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class Links
    {
        [JsonProperty("cadLinkTypes")]
        public object[] CadLinkTypes { get; set; }

        [JsonProperty("cadLinks")]
        public object[] CadLinks { get; set; }

        [JsonProperty("revitLinkTypes")]
        public object[] RevitLinkTypes { get; set; }

        [JsonProperty("revitLinks")]
        public object[] RevitLinks { get; set; }
    }
}