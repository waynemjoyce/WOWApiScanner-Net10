using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WOWAuctionApi_Net10
{
    public class DeepItemData : JsonBase
    {
        public static Dictionary<string, DeepItemDataBonus> Load()
        {
            string items = File.ReadAllText(Paths.DeepItemData);
            return JsonSerializer.Deserialize<Dictionary<string, DeepItemDataBonus>>(items);
        }

        public static DeepItemDataBonus GetDataForBonus(string key, Dictionary<string, DeepItemDataBonus> dict)
        {
            DeepItemDataBonus returnVal;
            dict.TryGetValue(key, out returnVal);
            return returnVal;
        }

    }

    public class DeepItemDataBonus
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
