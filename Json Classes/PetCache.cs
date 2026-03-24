
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class PetCache : CacheBase
    {
        public List<CachePet> Pets { get; set; }

        [JsonIgnore]
        public List<long> PetIds = new List<long>();

        public PetCache()
        {
            Pets = new List<CachePet>();
        }

        public void FillPetIds()
        {
            PetIds.Clear();

            foreach (CachePet pet in Pets)
            {
                PetIds.Add(pet.Id.Value);
            }
        }

        public void AddPet(CachePet petToAdd)
        {
            Pets.Add(petToAdd);
        }

        public void Save()
        {
            SaveToFile(Paths.PetCache);
        }
        public void SaveAsNewlyAdded(SortDirection direction = SortDirection.Ascending)
        {
            Sort(direction);
            SaveToFile($@"{Paths.Json}\newlyadded\newlyadded-pets-{DateTime.Now.ToString("-yyyyMMdd_hhmmss")}.json");
        }

        public void SaveAsNewFile(string fileName)
        {
            SaveToFile($@"{Paths.Json}{fileName}.json");
        }

        public void Sort(SortDirection direction)
        {
            switch (direction)
            {
                case SortDirection.Ascending:
                default:
                    this.Pets = this.Pets.OrderBy(pet => pet.Id).ToList();
                    break;
                case SortDirection.Descending:
                    this.Pets = this.Pets.OrderByDescending(pet => pet.Id).ToList();
                    break;
            }

        }

        public void SortAndSave(SortDirection direction = SortDirection.Ascending)
        {
            Sort(direction);
            this.Save();
        }


        public static PetCache Load()
        {
            return PetCache.LoadFromFile(Paths.PetCache);
        }

        public static PetCache LoadFromFile(string fileName)
        {
            string items = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<PetCache>(items);
        }

        public static PetCache LoadFromJson(string json)
        {
            return JsonSerializer.Deserialize<PetCache>(json);
        }

        public static void BackupPetCache()
        {

        }
        public static (int newPets, PetCache newCache) BuildPetCache(
            ToolStripProgressBar tspCache,
            ToolStripStatusLabel lblCache,
            FormCache formCache,
            bool updateOnly)
        {
            BackupPetCache();

            int count = 0;
            int hundredCount = 0;
            int addedCount = 0;

            Dictionary<long, TsmItem> localRegionItems = formCache.Dictionaries.RegionItems
                .Where(item => item.Value.petSpeciesId == null).ToDictionary();
            int regionCount = localRegionItems.Count;
            tspCache.Maximum = regionCount;

            PetCache petCache = new PetCache();
            PetCache newlyAddedCache = new PetCache();

            if (updateOnly)
            {
                petCache = PetCache.Load();
                petCache.FillPetIds();
            }
            else
            {
                petCache.Pets = new List<CachePet>();
                petCache.Pets.Clear();
            }

            foreach (KeyValuePair<long, TsmItem> item in localRegionItems)
            {
                count++;
                hundredCount++;

                if (hundredCount > 100)
                {
                    hundredCount = 0;
                    tspCache.Value = count;
                    lblCache.Text = $"Updating pet cache from region items, processed: {count}";
                    Application.DoEvents();
                }

                try
                {
                    if (((updateOnly) && (!(petCache.PetIds.Contains(item.Key))))
                        || (!updateOnly))
                    {

                        BlizzPet blizzPet = API_Blizzard.GetBlizzPetFromItemId(formCache.BlizzAccessToken, item.Key);

                        if (blizzPet != null)
                        {
                            if (updateOnly)
                            {
                                tspCache.Value = count;
                                Application.DoEvents();
                            }

                            CachePet pet1 = new CachePet();
                            pet1.Id = item.Key;
                            pet1.Name = blizzPet.name;
                            pet1.IsTradable = blizzPet.is_tradable;
                            pet1.IsCapturable = blizzPet.is_capturable;
                            pet1.IsHordeOnly = blizzPet.is_horde_only;
                            pet1.IsAllianceOnly = blizzPet.is_alliance_only;
                            pet1.IsBattlePet = blizzPet.is_battlepet;
                            pet1.BattlePetType = blizzPet.battle_pet_type.name;
                            pet1.Description = blizzPet.description;
                            pet1.RegionItem = item.Value;

                            petCache.AddPet(pet1);
                            if (updateOnly)
                            {
                                newlyAddedCache.AddPet(pet1);
                            }
                            addedCount += 1;
                        }
                    }
                }
                catch
                { }

            }

            petCache.Save();
            if (updateOnly && newlyAddedCache.Pets.Count > 0)
            {
                newlyAddedCache.SaveAsNewlyAdded(formCache.Config.SortCacheOrderDefault.Value);
            }
            BackupPetCache();
            tspCache.Value = tspCache.Maximum;
            Application.DoEvents();
            return (addedCount, petCache);
        }
    }
    public class CachePet
    {
        public long? Id { get; set; }
        
        public string? Name { get; set; }

        public string? BattlePetType { get; set; }

        public bool? IsTradable { get; set; }

        public bool? IsBattlePet { get; set; }

        public bool? IsCapturable { get; set; }

        public bool? IsAllianceOnly { get; set; }

        public bool? IsHordeOnly { get; set; }

        public string? Description { get; set; }

        public string? Source { get; set; }
        [JsonIgnore]
        public TsmItem RegionItem = new TsmItem();
    }
}
