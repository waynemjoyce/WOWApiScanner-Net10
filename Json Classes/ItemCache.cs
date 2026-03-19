using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class ItemCache : JsonBase
    {
        public List<Item> Items { get; set; }

        [JsonIgnore]
        public List<long> ItemIds = new List<long>();

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
        public static void BuildItemCache(
            ToolStripProgressBar tspCache,
            Label lblCache,
            Dictionary<long, TsmItem> regionItems,
            string accessToken,
            bool updateOnly)
        {
            Cursor.Current = Cursors.WaitCursor;
            BackupItemCache();

            string itemName;
            int count = 0;
            int hundredCount = 0;
            int addedCount = 0;
            int regionCount = regionItems.Count;
            tspCache.Maximum = regionCount;

            ItemCache ic = new ItemCache();

            if (updateOnly)
            {
                ic = ItemCache.Load();
                ic.FillItemIds();
            }
            else
            {
                ic.Items = new List<Item>();
                ic.Items.Clear();
            }

            foreach (KeyValuePair<long, TsmItem> item in regionItems)
            {
                count++;
                hundredCount++;

                if (hundredCount > 100)
                {
                    hundredCount = 0;
                    tspCache.Value = count;
                    lblCache.Text = "Count: " + count.ToString();
                    Application.DoEvents();
                }

                try
                {
                    if (((updateOnly) && (!(ic.ItemIds.Contains(item.Key))))
                        || (!updateOnly))
                    {
                        addedCount += 1;
                        BlizzItem bi = API_Blizzard.GetBlizzItemFromItemId(accessToken, item.Key);

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

                            ic.AddItem(item1);
                        }
                    }
                }
                catch
                { }

            }

            ic.Save();
            BackupItemCache();
            tspCache.Value = tspCache.Maximum;
            Application.DoEvents();
            lblCache.Text = "Completed. " + count.ToString() + " items scanned, " + addedCount.ToString() + " new items added.";
            Cursor.Current = Cursors.Default;
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
