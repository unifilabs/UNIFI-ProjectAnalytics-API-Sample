using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Symbol {
        [JsonProperty("typeParameters")] public Parameter[] TypeParameters { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("elementId")] public long ElementId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("worksetId")] public string WorksetId { get; set; }

        [JsonProperty("levelId")] public string LevelId { get; set; }

        [JsonProperty("hasPhases")] public bool HasPhases { get; set; }

        [JsonProperty("createdPhaseId")] public string CreatedPhaseId { get; set; }

        [JsonProperty("demolishedPhaseId")] public string DemolishedPhaseId { get; set; }
    }
}