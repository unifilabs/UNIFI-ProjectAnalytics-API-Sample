using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProjectAnalytics.Entities
{
    public partial class Event
    {
        [JsonProperty("signedUrl")]
        public Uri Url { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("collectionTime")]
        public DateTimeOffset CollectionTime { get; set; }

        [JsonProperty("dataType")]
        public string DataType { get; set; }

        [JsonProperty("dataId")]
        public string DataId { get; set; }

        [JsonProperty("unifiCoreVersion")]
        public string UnifiCoreVersion { get; set; }
    }
}
