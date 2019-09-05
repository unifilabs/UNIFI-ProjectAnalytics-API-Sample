using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class SystemFamilies
    {
        [JsonProperty("systemTypes")]
        public Family[] SystemTypes { get; set; }

        [JsonProperty("systemTypeInstances")]
        public FamilyInstance[] SystemTypeInstances { get; set; }
    }
}