using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class ItemCache : CacheBase
    {
        public List<Item> Items { get; set; }

        [JsonIgnore]
        public List<long> ItemIds = new List<long>();

        public ItemCache()
        {
            Items = new List<Item>();
        }
        public void FillItemIds()
        {
            ItemIds.Clear();

            foreach (Item it in Items)
            {
                ItemIds.Add(it.Id);
            }
        }

        public void AddItem(Item itemToAdd)
        {
            Items.Add(itemToAdd);
        }

        public void Save()
        {
            SaveToFile(Paths.ItemCache);
        }

        public void SaveAsNewlyAdded(SortDirection direction = SortDirection.Ascending)
        {
            Sort(direction);
            SaveToFile($@"{Paths.ItemCachePath}newlyadded-{DateTime.Now.ToString("-yyyyMMdd_mmss")}.json");
        }

        public void Sort(SortDirection direction)
        {
            switch (direction)
            {
                case SortDirection.Ascending: default:
                    this.Items = this.Items.OrderBy(item => item.Id).ToList();
                    break;
                case SortDirection.Descending:
                    this.Items = this.Items.OrderByDescending(item => item.Id).ToList();
                    break;
            }

        }

        public void SortAndSave(SortDirection direction = SortDirection.Ascending)
        {
            Sort(direction);
            this.Save();
        }


        public static ItemCache Load()
        {
            return ItemCache.LoadFromFile(Paths.ItemCache);
        }

        public static ItemCache LoadFromFile(string fileName)
        {
            string items = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<ItemCache>(items);
        }


        public static void BackupItemCache()
        {

        }
        public static (int newItems, ItemCache newCache) BuildItemCache(
            ToolStripProgressBar tspCache,
            Label lblCache,
            FormCache formCache,
            bool updateOnly)
        {
            BackupItemCache();

            string itemName;
            int count = 0;
            int hundredCount = 0;
            int addedCount = 0;
            int regionCount = formCache.Dictionaries.RegionItems.Count;
            tspCache.Maximum = regionCount;

            ItemCache itemCache = new ItemCache();
            ItemCache newlyAddedCache = new ItemCache();

            if (updateOnly)
            {
                itemCache = ItemCache.Load();
                itemCache.FillItemIds();
            }
            else
            {
                itemCache.Items = new List<Item>();
                itemCache.Items.Clear();
            }

            foreach (KeyValuePair<long, TsmItem> item in formCache.Dictionaries.RegionItems)
            {
                count++;
                hundredCount++;

                if (hundredCount > 100)
                {
                    hundredCount = 0;
                    tspCache.Value = count;
                    lblCache.Text = $"Updating item cache from region items, processed: {count}";
                    Application.DoEvents();
                }

                try
                {
                    if (((updateOnly) && (!(itemCache.ItemIds.Contains(item.Key))))
                        || (!updateOnly))
                    {
                        
                        BlizzItem bi = API_Blizzard.GetBlizzItemFromItemId(formCache.BlizzAccessToken, item.Key);

                        if (bi != null)
                        {
                            itemName = bi.name;

                            Item item1 = new Item();
                            item1.Id = item.Key;
                            item1.Name = itemName;
                            if (bi.item_class != null)
                            {
                                item1.ClassName = bi.item_class.name;
                                item1.ClassId = bi.item_class.id.Value;
                            }

                            if (bi.item_subclass != null)
                            {
                                item1.SubClassName = bi.item_subclass.name;
                                item1.SubClassId = bi.item_subclass.id.Value;
                            }

                            if (bi.quality != null)
                            {
                                item1.QualityType = bi.quality.type;
                            }

                            if (bi.inventory_type != null)
                            {
                                item1.InventoryType = bi.inventory_type.type;
                            }

                            item1.Level = bi.level.Value;
                            item1.RequiredLevel = bi.required_level.Value;

                            itemCache.AddItem(item1);
                            if (updateOnly)
                            {
                                newlyAddedCache.AddItem(item1); 
                            }
                            addedCount += 1;
                        }
                    }
                }
                catch
                { }

            }

            itemCache.Save();
            if (updateOnly && newlyAddedCache.Items.Count > 0)
            {
                newlyAddedCache.SaveAsNewlyAdded(formCache.Config.SortCacheOrderDefault.Value);
            }
            tspCache.Value = tspCache.Maximum;
            Application.DoEvents();
            return (addedCount, itemCache);
        }
    }
    public class Item
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ClassName { get; set; }
        public int ClassId { get; set; }
        public string? SubClassName { get; set; }
        public int SubClassId { get; set; }
        public string? QualityType { get; set; }
        public string? InventoryType { get; set; }
        public string? BindingType { get; set; }
        public long Level { get; set; }
        public long RequiredLevel { get; set; }
    }
}
