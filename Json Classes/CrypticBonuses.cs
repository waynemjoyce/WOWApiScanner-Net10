using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WOWAuctionApi_Net10
{
    public class CrypticBonuses : JsonBase
    {
        public static Dictionary<string, CrypticBonus> Load()
        {
            string items = File.ReadAllText(sc.Paths.CrypticBonuses);
            return JsonSerializer.Deserialize<Dictionary<string, CrypticBonus>>(items);
        }

        public static CrypticBonus GetDataForBonus(string key, Dictionary<string, CrypticBonus> dict)
        {
            CrypticBonus returnVal;
            dict.TryGetValue(key, out returnVal);
            return returnVal;
        }

    }

    public class CrypticBonus
    {
        public string? op {  get; set; }
        public long? curve_id { get; set; }
        public long? offset { get; set; }
        public string? midnight { get; set; }    
        public long? priority { get; set; } 
        public long? default_level {  get; set; }
        public string? content_tuning_key { get; set; }
        public long? sort_priority { get; set; }

    }
}
