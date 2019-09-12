using Newtonsoft.Json;

namespace UnifiLabs.Samples.ProjectAnalytics.Entities {
    public class Data {
        [JsonProperty("projectGuid")] public string ProjectGuid { get; set; }

        [JsonProperty("sharedParameterFile")] public string SharedParameterFile { get; set; }

        [JsonProperty("projectInfo")] public ProjectInfo ProjectInfo { get; set; }

        [JsonProperty("areas")] public object[] Areas { get; set; }

        [JsonProperty("links")] public Links Links { get; set; }

        [JsonProperty("images")] public Images Images { get; set; }

        [JsonProperty("projectFamilies")] public ProjectFamilies ProjectFamilies { get; set; }

        [JsonProperty("systemFamilies")] public SystemFamilies SystemFamilies { get; set; }

        [JsonProperty("draftingViews")] public object[] DraftingViews { get; set; }

        [JsonProperty("schedules")] public object[] Schedules { get; set; }

        [JsonProperty("sheets")] public object[] Sheets { get; set; }

        [JsonProperty("planRegions")] public object[] PlanRegions { get; set; }

        [JsonProperty("rooms")] public object[] Rooms { get; set; }

        [JsonProperty("spaces")] public object[] Spaces { get; set; }

        [JsonProperty("levels")] public Level[] Levels { get; set; }

        [JsonProperty("worksets")] public Workset[] Worksets { get; set; }

        [JsonProperty("warnings")] public object[] Warnings { get; set; }
    }
}