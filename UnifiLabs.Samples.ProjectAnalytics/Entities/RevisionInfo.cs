using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class RevisionInfo
    {
        [JsonProperty("alphaNumericRevisionInfo")]
        public AlphaNumericRevisionInfo AlphaNumericRevisionInfo { get; set; }

        [JsonProperty("numericRevisionInfo")]
        public NumericRevisionInfo NumericRevisionInfo { get; set; }

        [JsonProperty("numberingStyle")]
        public string NumberingStyle { get; set; }

        [JsonProperty("revisionCloudSpacing")]
        public double RevisionCloudSpacing { get; set; }

        [JsonProperty("isAcceptableCloudSpacing")]
        public bool IsAcceptableCloudSpacing { get; set; }

        [JsonProperty("revisions")]
        public Revision[] Revisions { get; set; }
    }
}