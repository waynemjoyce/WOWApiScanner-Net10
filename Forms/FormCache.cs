using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class FormCache
    {
        public FormCacheDictionaries Dictionaries = new FormCacheDictionaries();
        public FormCacheCaches Caches = new FormCacheCaches();  
        public FormCacheLists Lists = new FormCacheLists(); 

        public UserInterfaceOptions UIOptions = new UserInterfaceOptions();
        public DataCount DataCount = new DataCount();
        public SearchProfile CurrentProfile = new SearchProfile();
        public InteractionScript WowBuyScript = new InteractionScript();
        public Config Config = new Config();

        public string BlizzAccessToken = "";
        public int CurrentWoWProcess = 0;

    }

    public class FormCacheLists
    {
        public List<RealmCount> TotalAuctionsCount = new List<RealmCount>();
        public List<RealmCount> RealmSearchCount = new List<RealmCount>();
    }
    public class FormCacheCaches
    {
        public ItemCache ItemCache = new ItemCache();
        public PetCache PetCache = new PetCache();
    }

    public class FormCacheDictionaries
    {
        public Dictionary<int, AuctionFileContents> RealmAuctions = new Dictionary<int, AuctionFileContents>();
        public Dictionary<long, TsmItem> RegionItems = new Dictionary<long, TsmItem>();
        public Dictionary<long, TsmItem> RegionPets = new Dictionary<long, TsmItem>();
        public SortedDictionary<long, Item> DictionaryItemCache = new SortedDictionary<long, Item>();
        public SortedDictionary<long, Pet> DictionaryPetCache = new SortedDictionary<long, Pet>();
    }
}
