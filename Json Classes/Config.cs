
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

        public int? OnlyFirst { get; set; }

        public long? LatestXpacItemId { get; set; }

        public bool? RefreshAuctionsOnStart { get; set; }

        public bool? WowInteraction { get; set; }

        public List<Realm>? Realms { get; set; }


        public static Config LoadFromFile(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new ColorConverter() }
            };
            var returnRI = JsonSerializer.Deserialize<Config>(System.IO.File.ReadAllText(fileName), options);
            return returnRI;
        }

        public void Save()
        {
            SaveToFile(Paths.Config);
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

        public string? RealmName { get; set; }

        public int? RealmId { get; set; }

        public string? BackColor { get; set; }
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
