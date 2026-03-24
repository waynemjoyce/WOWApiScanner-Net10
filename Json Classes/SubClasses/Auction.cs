using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WOWAuctionApi_Net10
{
    public class AuctionFileContents
    {
        public List<Auction> auctions { get; set; }
    }

    public class Auction
    {
        public int id { get; set; } // This is the item's ID
        public long buyout { get; set; } // This is the buyout price in silver now?
        public AuctionItem item { get; set; }
        [JsonIgnore]
        public string auctionitemName = "";        
    }

    public class SmartAuction
    {
        public TsmItem SmartRegionItem { get; set; }
        public Auction SmartAuctionItem { get; set; }
        public CacheItem SmartCachedItem { get; set; }
        public System.Drawing.Color SmartRowColor { get; set; }
    }

    public class AuctionItem
    {
        public long id { get; set; }
        public List<AuctionModifiers> modifiers { get; set; }
        public List<long> bonus_lists { get; set; }

        public long pet_breed_id { get; set; }
        public long pet_level { get; set; }
        public long pet_quality_id { get; set; }
        public long pet_species_id { get; set; }


        //Json Ignore
        [JsonIgnore]
        public TsmItem regionItem;
        [JsonIgnore]
        public CacheItem cacheItem;
        [JsonIgnore]
        public CachePet cachePet;

        [JsonIgnore]
        public string quality;

        [JsonIgnore]
        public bool isPet;
        [JsonIgnore]
        public long itemLevel;
    }

    public class AuctionModifiers
    {
        public long type { get; set; }
        public long value { get; set; }
    }
}
