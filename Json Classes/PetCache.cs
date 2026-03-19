
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class PetCache : JsonBase
    {
        public List<Pet> Pets { get; set; }

        [JsonIgnore]
        public List<long> PetIds = new List<long>();

        public void FillPetIds()
        {
            PetIds.Clear();

            foreach (Pet pet in Pets)
            {
                PetIds.Add(pet.Id.Value);
            }
        }

        public void AddPet(Pet petToAdd)
        {
            Pets.Add(petToAdd);
        }

        public void Save()
        {
            SaveToFile(Paths.PetCache);
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
        public static void BuildPetCache(
            ToolStripProgressBar tspCache,
            Label lblCache,
            Dictionary<long, TsmItem> regionPets,
            string accessToken,
            bool updateOnly)
        {
            Cursor.Current = Cursors.WaitCursor;
            BackupPetCache();

            string itemName;
            int count = 0;
            int hundredCount = 0;
            int addedCount = 0;
            int regionCount = regionPets.Count;
            tspCache.Maximum = regionCount;

            PetCache petCache = new PetCache();

            if (updateOnly)
            {
                petCache = PetCache.Load();
                petCache.FillPetIds();
            }
            else
            {
                petCache.Pets = new List<Pet>();
                petCache.Pets.Clear();
            }

            foreach (KeyValuePair<long, TsmItem> item in regionPets)
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
                    if (((updateOnly) && (!(petCache.PetIds.Contains(item.Key))))
                        || (!updateOnly))
                    {
                        addedCount += 1;
                        BlizzPet blizzPet = API_Blizzard.GetBlizzPetFromItemId(accessToken, item.Key);

                        if (blizzPet != null)
                        {
                            if (updateOnly)
                            {
                                tspCache.Value = count;
                                Application.DoEvents();
                            }

                            Pet pet1 = new Pet();
                            pet1.Id = item.Key;
                            pet1.Name = blizzPet.name;
                            pet1.IsTradable = blizzPet.is_tradable;
                            pet1.IsCapturable = blizzPet.is_capturable;
                            pet1.IsHordeOnly = blizzPet.is_horde_only;
                            pet1.IsAllianceOnly = blizzPet.is_alliance_only;
                            pet1.IsBattlePet = blizzPet.is_battlepet;
                            pet1.BattlePetType = blizzPet.battle_pet_type.name;
                            pet1.Description = blizzPet.description;

                            petCache.AddPet(pet1);
                        }
                    }
                }
                catch
                { }

            }

            petCache.Save();
            BackupPetCache();
            tspCache.Value = tspCache.Maximum;
            Application.DoEvents();
            lblCache.Text = "Completed. " + count.ToString() + " items scanned, " + addedCount.ToString() + " new pets added.";
            Cursor.Current = Cursors.Default;
        }
    }
    public class Pet
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
    }
}
