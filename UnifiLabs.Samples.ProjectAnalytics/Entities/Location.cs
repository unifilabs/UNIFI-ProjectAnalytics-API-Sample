using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class Location
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("z")]
        public long Z { get; set; }
    }
}