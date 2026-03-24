using System;
using System.Collections.Generic;
using System.Text;
using WOWAuctionApi_Net10.Json_Classes;

namespace WOWAuctionApi_Net10
{
    public class FormCache
    {
        public FormCacheDictionaries Dictionaries = new FormCacheDictionaries();
        public FormCacheCaches Caches = new FormCacheCaches();  
        public FormCacheLists Lists = new FormCacheLists(); 

        public ItemLists ItemLists = new ItemLists();
        public SearchProfiles SearchProfiles = new SearchProfiles();
        public SearchProfile CurrentProfile = new SearchProfile();
        public ItemList CurrentItemList = new ItemList();            

        public UserInterfaceOptions UIOptions = new UserInterfaceOptions();
        public DataCount DataCount = new DataCount();
        public InteractionScript WowBuyScript = new InteractionScript();
        public Config Config = new Config();

        public string BlizzAccessToken = "";
        public int CurrentWoWProcess = 0;
        public bool LivePoll = false;
        public DisplayMode DisplayMode = DisplayMode.Auctions;

        public long AllRealmsAuctionTotal = 0;
        public long NumRealmsReturned = 0;
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
        public Dictionary<string, DeepItemDataBonus> DeepItemData = new Dictionary<string, DeepItemDataBonus>();
        public Dictionary<int, AuctionFileContents> RealmAuctions = new Dictionary<int, AuctionFileContents>();
        public Dictionary<long, TsmItem> RegionItems = new Dictionary<long, TsmItem>();
        public SortedDictionary<long, CacheItem> DictionaryItemCache = new SortedDictionary<long, CacheItem>();
        public SortedDictionary<long, CachePet> DictionaryPetCache = new SortedDictionary<long, CachePet>();
    }
}
