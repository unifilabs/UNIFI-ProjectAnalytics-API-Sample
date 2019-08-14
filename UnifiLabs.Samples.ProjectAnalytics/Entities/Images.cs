using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class Images
    {
        [JsonProperty("imageTypes")]
        public object[] ImageTypes { get; set; }

        [JsonProperty("imageInstances")]
        public object[] ImageInstances { get; set; }
    }
}