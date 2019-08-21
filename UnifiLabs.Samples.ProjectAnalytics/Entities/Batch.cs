using System;
using Newtonsoft.Json;

namespace ContentManagement.Entities {
    public partial class Batch {
        //[JsonProperty("Summary")]
        //public Summary Summary { get; set; }

        [JsonProperty("Details")]
        public object[] Details { get; set; }

        //[JsonProperty("FileStatus")]
        //public FileStatus[] FileStatus { get; set; }

        [JsonProperty("BatchId")]
        public Guid BatchId { get; set; }
    }
}
