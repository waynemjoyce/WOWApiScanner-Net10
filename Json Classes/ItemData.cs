using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WOWAuctionApi_Net10
{
    public class ItemData : JsonBase
    {
        public List<long> MidnightItemIds { get; set; }

        public static ItemData Load()
        {
            return ItemData.LoadFromFile(sc.Paths.ItemData);
        }

        public static ItemData LoadFromFile(string fileName)
        {
            string itemData = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<ItemData>(itemData);
        }

    }
}
