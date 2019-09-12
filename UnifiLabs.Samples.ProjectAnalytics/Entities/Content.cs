using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Content {
        // Pass values from Manufacturer and Model parameters to object
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        [JsonProperty("ActiveRevisionId")] public Guid ActiveRevisionId { get; set; }

        [JsonProperty("AggregateRating")] public object AggregateRating { get; set; }

        [JsonProperty("ApprovalStatus")] public long ApprovalStatus { get; set; }

        [JsonProperty("ApprovedRevisionId")] public Guid ApprovedRevisionId { get; set; }

        [JsonProperty("Brands")] public object[] Brands { get; set; }

        [JsonProperty("Category")] public string Category { get; set; }

        [JsonProperty("Channels")] public object[] Channels { get; set; }

        [JsonProperty("CreatedDate")] public string CreatedDate { get; set; }

        [JsonProperty("CreatorUsername")] public string CreatorUsername { get; set; }

        [JsonProperty("CurrentRevisionId")] public Guid CurrentRevisionId { get; set; }

        [JsonProperty("Downloads")] public long Downloads { get; set; }

        public List<string> FamilyTypes { get; set; }

        [JsonProperty("Favorites")] public object[] Favorites { get; set; }

        [JsonProperty("FileImageBytes")] public object FileImageBytes { get; set; }

        [JsonProperty("FileType")] public long FileType { get; set; }

        [JsonProperty("Filename")] public string Filename { get; set; }

        [JsonProperty("FillPatternType")] public object FillPatternType { get; set; }

        [JsonProperty("HasCustomPreviewImage")]
        public bool HasCustomPreviewImage { get; set; }

        [JsonProperty("HasTypeCatalog")] public bool HasTypeCatalog { get; set; }

        [JsonProperty("LastModifiedDate")] public string LastModifiedDate { get; set; }

        [JsonProperty("Libraries")] public Library[] Libraries { get; set; }

        [JsonProperty("LocalPath")] public object LocalPath { get; set; }

        [JsonProperty("MaterialClass")] public object MaterialClass { get; set; }

        [JsonProperty("MeasurementSystem")] public long MeasurementSystem { get; set; }

        [JsonProperty("Measurements")] public object[] Measurements { get; set; }

        [JsonProperty("NextRevisionNumber")] public object NextRevisionNumber { get; set; }

        [JsonProperty("OriginalDateAdded")] public string OriginalDateAdded { get; set; }

        [JsonProperty("ParseStatus")] public long ParseStatus { get; set; }

        [JsonProperty("PreviewImageUrl")] public string PreviewImageUrl { get; set; }

        [JsonProperty("Ratings")] public object[] Ratings { get; set; }

        [JsonProperty("RepositoryFileId")] public Guid RepositoryFileId { get; set; }

        [JsonProperty("RepositoryNumber")] public object RepositoryNumber { get; set; }

        [JsonProperty("RevisionNumber")] public object RevisionNumber { get; set; }

        [JsonProperty("Revisions")] public Revision[] Revisions { get; set; }

        [JsonProperty("RevitYear")] public long RevitYear { get; set; }

        [JsonProperty("Size")] public long Size { get; set; }

        [JsonProperty("Tags")] public Tag[] Tags { get; set; }

        [JsonProperty("Title")] public string Title { get; set; }

        [JsonProperty("TypeCatalogBytes")] public object TypeCatalogBytes { get; set; }

        [JsonProperty("UserRating")] public long UserRating { get; set; }

        [JsonProperty("Parameters")] public Parameter[] Parameters { get; set; }
    }
}