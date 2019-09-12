using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class BaseFileVersion {
        [JsonProperty("FileVersionId")] public Guid FileVersionId { get; set; }

        [JsonProperty("FillPatternType")] public object FillPatternType { get; set; }

        [JsonProperty("IsBaseVersion")] public bool IsBaseVersion { get; set; }

        [JsonProperty("MaterialClass")] public object MaterialClass { get; set; }

        [JsonProperty("OriginalFilename")] public string OriginalFilename { get; set; }

        [JsonProperty("RepositoryNumber")] public long RepositoryNumber { get; set; }

        [JsonProperty("RevitYear")] public long RevitYear { get; set; }
    }
}