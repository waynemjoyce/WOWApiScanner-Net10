using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class Paths
    {
        public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public static string Json = CurrentDirectory + @"\json\";

        public static string Config = $@"{Json}config.json";
        public static string ItemCache = $@"{Json}itemcache.json";
        public static string PetCache = $@"{Json}petcache.json";
        public static string UIOptions = $@"{Json}uioptions.json";
        public static string TsmRegionData = $@"{Json}tsmdata.json";
        public static string ItemLists = $@"{Json}itemlists.json";
        public static string DeepItemData = $@"{Json}deepitemdata.json";
        public static string SearchProfiles = $@"{Json}searchprofiles.json";

        public static string SearchProfile = $@"{Json}searchprofiles\";
        public static string InteractionScripts = $@"{Json}interactionscripts\";
    }
}
