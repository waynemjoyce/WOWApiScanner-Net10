using System;
using System.Collections.Generic;
using System.Text;
using WOWAuctionApi_Net10.Json_Classes;

namespace WOWAuctionApi_Net10
{
    public static class sc
    {
        public static GlobalCacheDirectories Dictionaries = new GlobalCacheDirectories();
        public static GlobalCacheCaches Caches = new GlobalCacheCaches();
        public static GlobalCacheLists Lists = new GlobalCacheLists();

        public static ItemLists ItemLists = new ItemLists();
        public static SearchProfiles SearchProfiles = new SearchProfiles();
        public static SearchProfile CurrentProfile = new SearchProfile();
        public static ItemList CurrentItemList = new ItemList();
        public static ItemData ItemData = new ItemData();

        public static UserInterfaceOptions UIOptions = new UserInterfaceOptions();
        public static DataCount DataCount = new DataCount();
        public static InteractionScript WowBuyScript = new InteractionScript();
        public static InteractionScript WowBuyScript_Slow = new InteractionScript();
        public static Config Config = new Config();
        public static RealmData RealmData = new RealmData();
        public static SearchLogic SearchLogic = new SearchLogic();

        public static string BlizzAccessToken = "";
        public static int CurrentWoWProcess = 0;
        public static bool LivePoll = false;
        public static DisplayMode DisplayMode = DisplayMode.Auctions;

        public static long AllRealmsAuctionTotal = 0;
        public static long NumRealmsReturned = 0;

        public static class ImageLists
        {
            public static ImageList ImgProfile48 = new ImageList();
            public static ImageList ImgToolbar48 = new ImageList();
            public static ImageList ImgColorMode = new ImageList();
            public static ImageList ImgStatus = new ImageList();
        }

        public static class Paths
        {
            public static string CurrentDirectory = Directory.GetCurrentDirectory();
            public static string Json = CurrentDirectory + @"\json\";

            public static string Config = $@"{Json}config.json";
            public static string RealmData = $@"{Json}realmdata.json";
            public static string RealmDataBackup = $@"{Json}\realmdatabackup\realmdata.json";
            public static string ItemCache = $@"{Json}itemcache.json";
            public static string PetCache = $@"{Json}petcache.json";
            public static string UIOptions = $@"{Json}uioptions.json";
            public static string TsmRegionData = $@"{Json}tsmdata.json";
            public static string ItemLists = $@"{Json}itemlists.json";
            public static string CrypticBonuses = $@"{Json}crypticbonuses.json";
            public static string SearchProfiles = $@"{Json}searchprofiles.json";
            public static string ItemData = $@"{Json}itemdata.json";

            public static string SearchProfile = $@"{Json}searchprofiles\";
            public static string InteractionScripts = $@"{Json}interactionscripts\";
        }
    }

    public class GlobalCacheLists
    {
        public List<RealmCount> TotalAuctionsCount = new List<RealmCount>();
        public List<RealmCount> RealmSearchCount = new List<RealmCount>();
    }
    public class GlobalCacheCaches
    {
        public ItemCache ItemCache = new ItemCache();
        public PetCache PetCache = new PetCache();
    }

    public class GlobalCacheDirectories
    {
        public Dictionary<string, CrypticBonus> CrypticBonuses = new Dictionary<string, CrypticBonus>();
        public Dictionary<int, AuctionFileContents> RealmAuctions = new Dictionary<int, AuctionFileContents>();
        public Dictionary<long, TsmItem> RegionItems = new Dictionary<long, TsmItem>();
        public SortedDictionary<long, CacheItem> DictionaryItemCache = new SortedDictionary<long, CacheItem>();
        public SortedDictionary<long, CachePet> DictionaryPetCache = new SortedDictionary<long, CachePet>();
    }
}
