using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class SearchProfile : JsonBase
    {
        public string? ProfileName { get; set; }
        public bool? InToolbar { get; set; }

        public int? SearchMaxG { get; set; }
        public int? WorthAtLeast { get; set; }
        public float? SearchPercentage { get; set; }
        public float? MinSellRate { get; set; }
        public int? IconIndex { get; set; }

        public int? SearchFrequency { get; set; }

        public int? SearchFraction { get; set; }

        public long? MinItemLevel { get; set; }
        public long? MaxItemLevel { get; set; }
        public int? Threshold { get; set; }

        public string? StringFilter { get; set; }

        public int? MainOptions { get; set; }
        public int? Class { get; set; }
        public int? Quality { get; set; }

        public static SearchProfile LoadFromFile(string fileName)
        {
            var returnRI = JsonSerializer.Deserialize<SearchProfile>(System.IO.File.ReadAllText(fileName));
            return returnRI;
        }

        public static SearchProfile GetFileDefault()
        {
            var returnRI = JsonSerializer.Deserialize<SearchProfile>(System.IO.File.ReadAllText($@"{Paths.SearchProfile}\[Default].json"));
            return returnRI;
        }

        public void Save()
        {
            SaveToFile($@"{Paths.SearchProfile}\{ProfileName}.json");
        }

        public string GetFilePath()
        {
            return $@"{Paths.SearchProfile}\{ProfileName}.json";
        }
    }
}
