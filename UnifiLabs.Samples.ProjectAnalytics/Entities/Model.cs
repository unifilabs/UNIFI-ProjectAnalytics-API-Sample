using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities
{
    public class Model
    {
        [JsonProperty("modelId")]
        public Guid ModelId { get; set; }

        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("centralPath")]
        public string CentralPath { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("ignored")]
        public bool Ignored { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }
    }

}
