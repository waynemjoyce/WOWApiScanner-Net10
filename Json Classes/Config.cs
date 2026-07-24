
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class Config : JsonBase
    {
        public string? BlizzClientID { get; set; }
        public string? BlizzClientSecret { get; set; }
        public string? TSMKey { get; set; }
        public string? TSMClientID { get; set; }
        public string? DefaultSearch { get; set; }

        public string? GlobalKeyboardHookChar { get; set; } 
        public int? OnlyFirst { get; set; }
        public long? LatestXpacItemId { get; set; }
        public SortDirection? SortCacheOrderDefault { get; set; }
        public int? ConfigChecks { get; set; }

        public int? LivePollInterval { get; set; }
        public int? AuctionsCap { get; set; }
        public int? ItemsSearchCap { get; set; }
        public int? Threshold { get; set; }
        public int? ChartMarketValue { get; set; }
        public int? ChartSearchHits { get; set; }
        public int? ChartTotalAuctions { get; set; }
        public List<Realm>? Realms { get; set; }

        [JsonIgnore]
        public bool SortCacheOnUpdate = false;
        [JsonIgnore]
        public bool UpdateAllDataOnStart = false;
        [JsonIgnore]
        public bool NewDataOnlyDefault = false;
        [JsonIgnore]
        public bool SearchOnSelectDefault = false;
        [JsonIgnore]
        public bool RefreshAuctionsOnStart = false;
        [JsonIgnore]
        public bool WowInteraction = false;
        [JsonIgnore]
        public bool DisplayInactiveRealms = false;
        [JsonIgnore]
        public bool FlagFirstWithStockUpdate = false;

        public static Config LoadFromFile(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new ColorConverter(), new JsonStringEnumConverter() }
            };
            var returnRI = JsonSerializer.Deserialize<Config>(System.IO.File.ReadAllText(fileName), options);
            return returnRI;
        }

        public void Save()
        {
            Realms = Realms.OrderBy(r => r.RealmName).ToList(); 
            SaveToFile(sc.Paths.Config);
        }
    }


    public class Realm
    {
        [JsonIgnore]
        public int Status = 0;
        [JsonIgnore]
        public string LastModified = String.Empty;
        [JsonIgnore]
        public int NumAuctions = 0;
        [JsonIgnore]
        public bool OldData = false;

        public string? RealmName { get; set; }

        public int? RealmId { get; set; }

        public string? BackColor { get; set; }

        public bool? Flagged { get; set; }

        public int? RealmFlags { get; set; }

        public int? Stock { get; set; }

        public bool? Active { get; set; }

        public string? Area { get; set; }
    }

    public class ColorConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ColorTranslator.FromHtml(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ColorTranslator.ToHtml(value));
        }
    }

}
