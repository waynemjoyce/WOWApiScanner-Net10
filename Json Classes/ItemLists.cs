using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WOWAuctionApi_Net10
{
    public class ItemLists : JsonBase
    {
        public List<ItemList>? Lists { get; set; }

        public ItemLists()
        {
            Lists = new List<ItemList>();        
        }

        public void AddList(ItemList itemList)
        {
            Lists.Add(itemList);
        }

        public void Save()
        {
            SaveToFile(Paths.ItemLists);
        }

        public ItemList? GetListByName(string listName)
        {
            foreach (ItemList loopList in Lists)
            {
                if (loopList.Name == listName)
                {
                    return loopList;
                }
            }
            return null;
        }

        public static ItemLists Load()
        {
            return ItemLists.LoadFromFile(Paths.ItemLists);
        }

        public static ItemLists LoadFromFile(string fileName)
        {
            string items = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<ItemLists>(items);
        }
    }

    public class ItemList
    {
        public string? Name { get; set; }
        public int? IconIndex { get; set; }

        public ItemCache? ItemCache { get; set; }

        public ItemList()
        {
            ItemCache = new ItemCache();    
        }
    }
}