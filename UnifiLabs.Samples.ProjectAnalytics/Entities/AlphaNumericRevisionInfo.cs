using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class AlphaNumericRevisionInfo
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("sequence")]
        public string[] Sequence { get; set; }
    }
}