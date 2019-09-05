using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class Family
    {
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("revisionId")]
        public string RevisionId { get; set; }

        // The symbols array is a list of symbol IDs
        [JsonProperty("symbols", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Symbols { get; set; }

        [JsonProperty("isInPlace", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInPlace { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("elementId")]
        public long ElementId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("worksetId")]
        public string WorksetId { get; set; }

        [JsonProperty("levelId")]
        public string LevelId { get; set; }

        [JsonProperty("hasPhases")]
        public bool HasPhases { get; set; }

        [JsonProperty("createdPhaseId")]
        public string CreatedPhaseId { get; set; }

        [JsonProperty("demolishedPhaseId")]
        public string DemolishedPhaseId { get; set; }

        [JsonProperty("familyName", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Parameter[] Parameters { get; set; }
    }
}