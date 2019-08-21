using System;
using Newtonsoft.Json;

namespace ContentManagement.Entities {
    public partial class Library {
        [JsonProperty("AccessibleUserGroups")]
        public object[] AccessibleUserGroups { get; set; }

        [JsonProperty("AccessibleUsers")]
        public object[] AccessibleUsers { get; set; }

        [JsonProperty("AdminUserGroups")]
        public object[] AdminUserGroups { get; set; }

        [JsonProperty("AdminUsers")]
        public object[] AdminUsers { get; set; }

        [JsonProperty("CompanyId")]
        public Guid CompanyId { get; set; }

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("IsProtected")]
        public bool IsProtected { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("LibraryId")]
        private Guid LibraryId {
            set { Id = value; }
        }

        [JsonProperty("LibraryType")]
        public long LibraryType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Name")]
        private string Name2 {
            set { Name = value; }
        }

        [JsonProperty("RepositoryId")]
        public Guid RepositoryId { get; set; }
    }
}