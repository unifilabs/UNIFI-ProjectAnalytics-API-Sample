using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Revision {
        [JsonProperty("BaseFileVersions")] public BaseFileVersion[] BaseFileVersions { get; set; }

        [JsonProperty("Created")] public string Created { get; set; }

        [JsonProperty("FileRevisionId")] public Guid FileRevisionId { get; set; }

        [JsonProperty("FillPatternType")] public object FillPatternType { get; set; }

        [JsonProperty("MaterialClass")] public object MaterialClass { get; set; }

        [JsonProperty("Notes")] public string Notes { get; set; }

        [JsonProperty("RevisionNumber")] public long RevisionNumber { get; set; }

        [JsonProperty("Status")] public long Status { get; set; }

        [JsonProperty("Username")] public string Username { get; set; }
    }
}