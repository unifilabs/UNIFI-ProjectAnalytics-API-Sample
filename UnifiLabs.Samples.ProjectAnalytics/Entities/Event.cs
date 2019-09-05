using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Event {
        [JsonProperty("signedUrl")] public Uri Url { get; set; }

        [JsonProperty("metadata")] public Metadata Metadata { get; set; }

        [JsonProperty("data")] public Data Data { get; set; }

        [JsonProperty("collectionTime")] public DateTimeOffset CollectionTime { get; set; }

        [JsonProperty("dataType")] public string DataType { get; set; }

        [JsonProperty("dataId")] public string DataId { get; set; }

        [JsonProperty("unifiCoreVersion")] public string UnifiCoreVersion { get; set; }
    }
}