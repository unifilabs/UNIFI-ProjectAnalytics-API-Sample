using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class Project
    {
        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("analytics")]
        public bool Analytics { get; set; }

        [JsonProperty("phase")]
        public string Phase { get; set; }

        [JsonProperty("designPhase")]
        public string DesignPhase { get; set; }

        [JsonProperty("officeLocationId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OfficeLocationId { get; set; }

        [JsonProperty("pins")]
        public Pins Pins { get; set; }

        [JsonProperty("modelIds")]
        public Guid[] ModelIds { get; set; }
    }

    public class Pins
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
