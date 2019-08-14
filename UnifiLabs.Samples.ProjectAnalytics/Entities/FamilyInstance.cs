using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class FamilyInstance
    {
        [JsonProperty("familyId", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyId { get; set; }

        // The typeId property of a familyInstance is the ID of a familySymbol, so a second property for clarity.
        [JsonProperty("typeId")]
        public string TypeId { get; set; }
        public string FamilySymbolId
        {
            get { return TypeId; }
            set { TypeId = value; }
        }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Location Location { get; set; }

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
    }
}