using System;
using System.Collections.Generic;
using System.Text;

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
    }

    public class SmartAuction
    {
        public TsmItem SmartRegionItem { get; set; }
        public Auction SmartAuctionItem { get; set; }
        public Item SmartCachedItem { get; set; }
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
    }

    public class AuctionModifiers
    {
        public long type { get; set; }
        public long value { get; set; }
    }
}
