﻿using System;
using Newtonsoft.Json;

namespace ProjectAnalytics.Entities
{
    public partial class NumericRevisionInfo
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("startNumber")]
        public long StartNumber { get; set; }
    }
}