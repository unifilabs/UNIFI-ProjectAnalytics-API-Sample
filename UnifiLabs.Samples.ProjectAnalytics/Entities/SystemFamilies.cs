using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class SystemFamilies
    {
        [JsonProperty("systemTypes")]
        public Family[] SystemTypes { get; set; }

        [JsonProperty("systemTypeInstances")]
        public FamilyInstance[] SystemTypeInstances { get; set; }
    }
}