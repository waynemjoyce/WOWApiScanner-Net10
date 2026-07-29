using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WOWAuctionApi_Net10.Json_Classes
{
    public class SearchProfiles : JsonBase
    {
        public List<SearchProfile>? Profiles { get; set; }


        public static SearchProfiles Load()
        {
            return SearchProfiles.LoadFromFile(sc.Paths.SearchProfiles);
        }

        public static SearchProfiles LoadFromFile(string fileName)
        {
            var returnRI = JsonSerializer.Deserialize<SearchProfiles>(File.ReadAllText(fileName));
            return returnRI;
        }

        public static SearchProfiles GetFileDefault()
        {
            var returnRI = JsonSerializer.Deserialize<SearchProfiles>(File.ReadAllText($@"{sc.Paths.SearchProfiles}"));
            return returnRI;
        }

        public void Save()
        {
            SaveToFile($@"{sc.Paths.SearchProfiles}");
        }

        public string GetFilePath()
        {
            return $@"{sc.Paths.SearchProfiles}";
        }

    }

    public class SearchProfile : JsonBase
    {
        public string? ProfileName { get; set; }
        public int? SearchMaxG { get; set; }
        public int? WorthAtLeast { get; set; }
        public float? SearchPercentage { get; set; }
        public float? MinSellRate { get; set; }
        public int? IconIndex { get; set; }

        public int? SearchFrequency { get; set; }

        public int? SearchFraction { get; set; }

        public int? ChartFilter { get; set; }

        public long? MinItemLevel { get; set; }
        public long? MaxItemLevel { get; set; }

        public long? MinCharLevel { get; set; }
        public long? MaxCharLevel { get; set; }
        public int? Threshold { get; set; }

        public string? StringFilter { get; set; }

        public int? MainOptions { get; set; }
        public int? Class { get; set; }
        public int? SubClass { get; set; }
        public int? InventoryType { get; set; }
        public int? Quality { get; set; }
        public int? Bonuses { get; set; }
        public bool? MainFilter { get; set; }
        public bool? ClassFilter { get; set; }
        public bool? SubClassFilter { get; set; }
        public bool? InventoryTypeFilter { get; set; }
        public bool? QualityFilter { get; set; }
        public bool? BonusesFilter { get; set; }


        public List<string>? Lists { get; set; }   
        public int? ListOption { get; set; }

    }

}
