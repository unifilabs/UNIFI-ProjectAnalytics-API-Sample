using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class Revision
    {
        [JsonProperty("revisionDate")]
        public string RevisionDate { get; set; }

        [JsonProperty("revisionNumber")]
        public int RevisionNumber { get; set; }

        [JsonProperty("issued")]
        public bool Issued { get; set; }

        [JsonProperty("issuedBy")]
        public string IssuedBy { get; set; }

        [JsonProperty("issuedTo")]
        public string IssuedTo { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sequenceNumber")]
        public long SequenceNumber { get; set; }

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