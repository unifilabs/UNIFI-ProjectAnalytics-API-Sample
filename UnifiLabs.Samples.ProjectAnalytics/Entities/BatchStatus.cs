using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class BatchStatus {
        [JsonProperty("resultDetails")]
        public string ResultDetails { get; set; }

        [JsonProperty("TotalFiles")]
        public long TotalFiles { get; set; }

        [JsonProperty("OkFiles")]
        public long OkFiles { get; set; }

        [JsonProperty("PendingFiles")]
        public long PendingFiles { get; set; }

        [JsonProperty("FailedFiles")]
        public long FailedFiles { get; set; }

        [JsonProperty("TotalOperations")]
        public long TotalOperations { get; set; }

        [JsonProperty("CompletedOperations")]
        public long CompletedOperations { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
