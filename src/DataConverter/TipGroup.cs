// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using rest_api.Models;
//
//    var tipGroup = TipGroup.FromJson(jsonString);

namespace DataConverter
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TipGroup
    {
        [JsonProperty("groupId", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupId { get; set; }

        [JsonProperty("groupName", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupName { get; set; }

        [JsonProperty("groupPriority", NullValueHandling = NullValueHandling.Ignore)]
        public long? GroupPriority { get; set; }

        [JsonProperty("tips", NullValueHandling = NullValueHandling.Ignore)]
        public List<Tip> Tips { get; set; }
    }

    public partial class Tip
    {
        [JsonProperty("tipId", NullValueHandling = NullValueHandling.Ignore)]
        public string TipId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; set; }
    }

    public partial class TipGroup
    {
        public static TipGroup FromJson(string json) => JsonConvert.DeserializeObject<TipGroup>(json, rest_api.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TipGroup self) => JsonConvert.SerializeObject(self, rest_api.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
