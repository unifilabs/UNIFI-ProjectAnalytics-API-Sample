using System;
using Newtonsoft.Json;

namespace ContentManagement.Entities {
    public partial class Tag {
        [JsonProperty("RepositoryNumber")]
        public long RepositoryNumber { get; set; }

        [JsonProperty("TagId")]
        public Guid TagId { get; set; }

        [JsonProperty("TagString")]
        public string TagString { get; set; }
    }
}
