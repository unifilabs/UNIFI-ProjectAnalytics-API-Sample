using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class ProjectFamilies {
        [JsonProperty("families")] public Family[] Families { get; set; }

        [JsonProperty("familyInstances")] public FamilyInstance[] FamilyInstances { get; set; }

        [JsonProperty("familySymbols")] public Symbol[] FamilySymbols { get; set; }
    }
}