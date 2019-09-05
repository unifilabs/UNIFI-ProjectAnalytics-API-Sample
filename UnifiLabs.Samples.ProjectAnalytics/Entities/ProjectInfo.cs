using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class ProjectInfo {
        [JsonProperty("projectName")] public string ProjectName { get; set; }

        [JsonProperty("geolocation")] public string Geolocation { get; set; }

        [JsonProperty("buildingType")] public string BuildingType { get; set; }

        [JsonProperty("buildingArea")] public float BuildingArea { get; set; }

        [JsonProperty("buildingAreaUnits")] public string BuildingAreaUnits { get; set; }

        [JsonProperty("buildingName")] public string BuildingName { get; set; }

        [JsonProperty("fileSize")] public string FileSize { get; set; }

        [JsonProperty("fileSizeBytes")] public long FileSizeBytes { get; set; }

        [JsonProperty("projectUnits")] public string ProjectUnits { get; set; }

        [JsonProperty("modelPath")] public string ModelPath { get; set; }

        [JsonProperty("phases")] public object[] Phases { get; set; }

        [JsonProperty("revisionInfo")] public RevisionInfo RevisionInfo { get; set; }
    }
}