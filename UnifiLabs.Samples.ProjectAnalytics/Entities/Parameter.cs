using System;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Parameter {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("TypeName")] public string TypeName { get; set; }

        [JsonProperty("ParameterType")] public long ParameterType { get; set; }

        [JsonProperty("StorageType")] public long StorageType { get; set; }

        [JsonProperty("DisplayUnitType")] public long? DisplayUnitType { get; set; }

        [JsonProperty("IsDeterminedByFormula")]
        public bool IsDeterminedByFormula { get; set; }

        [JsonProperty("GUID")] public string Guid { get; set; }

        [JsonProperty("CanAssignFormula")] public bool CanAssignFormula { get; set; }

        [JsonProperty("IsBaseVersion")] public bool IsBaseVersion { get; set; }

        [JsonProperty("FamilyCategory")] public string FamilyCategory { get; set; }

        [JsonProperty("FileVersionId")] public Guid FileVersionId { get; set; }

        [JsonProperty("Name")] public string Name { get; set; }

        [JsonProperty("BuiltInParameter")] public long BuiltInParameter { get; set; }

        [JsonProperty("RevitYear")] public long RevitYear { get; set; }

        [JsonProperty("IsReporting")] public bool IsReporting { get; set; }

        [JsonProperty("FileRevisionId")] public Guid FileRevisionId { get; set; }

        [JsonProperty("ParameterGroup")] public long ParameterGroup { get; set; }

        [JsonProperty("Visible")] public bool Visible { get; set; }

        [JsonProperty("Value")] public string Value { get; set; }

        [JsonProperty("FileId")] public Guid FileId { get; set; }

        [JsonProperty("NumericValue")] public string NumericValue { get; set; }

        [JsonProperty("SetByTypeCatalog")] public bool SetByTypeCatalog { get; set; }

        [JsonProperty("IsReadOnly")] public bool IsReadOnly { get; set; }

        [JsonProperty("ElementId")] public long ElementId { get; set; }

        [JsonProperty("IsInstance")] public bool IsInstance { get; set; }
    }
}