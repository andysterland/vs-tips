// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using rest_api.Models;
//
//    var tip = Tip.FromJson(jsonString);

namespace rest_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [DebuggerDisplay("{Name,nq}")]
    public partial class Tip
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("markdown", NullValueHandling = NullValueHandling.Ignore)]
        public string Markdown { get; set; }

        [JsonProperty("VSMinVer", NullValueHandling = NullValueHandling.Ignore)]
        public string VsMinVer { get; set; }

        [JsonProperty("VSMaxVer", NullValueHandling = NullValueHandling.Ignore)]
        public string VsMaxVer { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        [JsonProperty("moreInfoUri", NullValueHandling = NullValueHandling.Ignore)]
        public string MoreInfoUri { get; set; }

        [JsonProperty("gifUri", NullValueHandling = NullValueHandling.Ignore)]
        public string GifUri { get; set; }

        [JsonProperty("videoUri", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoUri { get; set; }

        [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Keys { get; set; }

        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("imgBase64", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageBase64 { get; set; }
    }

    public partial class Tip
    {
        public static Tip FromJson(string json) => JsonConvert.DeserializeObject<Tip>(json, rest_api.Models.Converter.Settings);        
    }

    public static class Serialize
    {
        public static string ToJson(this Tip self) => JsonConvert.SerializeObject(self, rest_api.Models.Converter.Settings);
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
            Formatting = Formatting.Indented
        };
    }
}
