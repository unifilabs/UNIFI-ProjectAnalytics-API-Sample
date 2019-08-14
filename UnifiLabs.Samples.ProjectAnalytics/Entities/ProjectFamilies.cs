using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class ProjectFamilies
    {
        [JsonProperty("families")]
        public Family[] Families { get; set; }

        [JsonProperty("familyInstances")]
        public FamilyInstance[] FamilyInstances { get; set; }

        [JsonProperty("familySymbols")]
        public Symbol[] FamilySymbols { get; set; }
    }
}