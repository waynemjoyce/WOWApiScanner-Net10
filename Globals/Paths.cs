using System;
using System.Collections.Generic;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class Paths
    {
        public static string CurrentDirectory = Directory.GetCurrentDirectory();
        public static string Json = CurrentDirectory + @"\json\";
        public static string Config = Json + "config.json";
        public static string TsmRegionData = Json + @"tsm\tsmdata.json";
        public static string TsmRegionDataBackup = Json + @"tsm\tsmdata_backup_DDD.json";
        public static string AuctionData = Json + @"auctiondata\";
        public static string ItemCache = Json + @"itemcache\itemcache.json";
        public static string PetCache = Json + @"petcache\petcache.json";
        public static string SearchProfile = Json + @"searchprofiles\";
        public static string UIOptions = Json + @"uioptions\";
        public static string InteractionScripts = Json + @"interactionscripts\";
    }
}
