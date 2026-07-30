using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class SearchLogic
    {
        public SearchOptions Options = new SearchOptions();

        //Searches items from an item cache rather than auctions
        public ItemCache DoItemSearch(ItemCache itemsAsCacheCopy)
        {
            //Get a copy of the current items in the list so we don't get items we already have
            ItemCache copyCache = itemsAsCacheCopy;

            //HashSet for efficient lookup.
            HashSet<long> itemIdsInList = new HashSet<long>(copyCache.Items.Select(item => item.Id));

            ItemCache searchResults = new ItemCache();
            searchResults.Items = sc.Caches.ItemCache.Items
                //Quality
                .Where(item => Options.Quality.Contains(item.QualityType))
                //Item Class
                .Where(item => Options.Class.Contains(item.ClassName))
                //Character required level
                .Where(item => item.RequiredLevel >= sc.CurrentProfile.MinCharLevel && item.RequiredLevel <= sc.CurrentProfile.MaxCharLevel)
                //Item level
                .Where(item => item.Level >= sc.CurrentProfile.MinItemLevel && item.Level <= sc.CurrentProfile.MaxItemLevel)
                //Worth at least
                .Where(item => Options.FixedWorthAtLeast == -1 || (Options.FixedWorthAtLeast > -1
                    && (item.RegionItem.marketValue >= Options.FixedWorthAtLeast)))
                //Minimum sell rate
                .Where(item => sc.CurrentProfile.MinSellRate == -1 ||
                    (item.RegionItem.saleRate <= sc.CurrentProfile.MinSellRate))
                //Latest xpac only
                .Where(item => Options.LatestXpac == false
                    || (Options.LatestXpac == true && item.Id >= sc.Config.LatestXpacItemId)
                    || (Options.LatestXpac == true && sc.ItemData.MidnightItemIds.Contains(item.Id)))
                //Filter only an items we don't already have in the list
                .Where(item => !itemIdsInList.Contains(item.Id))
                //String filter
                .Where(item => Options.UseStringFilter == false
                    || (Options.UseStringFilter == true
                    && item.Name.Contains(Options.StringFilter, StringComparison.OrdinalIgnoreCase)))
                //Apply items search cap
                .Take(sc.Config.ItemsSearchCap.Value)
                .ToList();

            if (Options.AtoZ)
            {
                searchResults.Items = searchResults.Items.OrderBy(item => item.Name).ToList();
            }

            return searchResults;
        }

        //Search realm auction results
        public List<SearchResult> DoAuctionSearch(Realm realm)
        {
            var searchResults = new List<SearchResult>();
            List<Auction> auctions = sc.Dictionaries.RealmAuctions[realm.RealmId.Value].auctions;

            //Get blocked item cache
            //Do not add items which are in the blocked list
            ItemCache blockedListCache = sc.ItemLists.GetListByName("SYS.BLOCKED").ItemCache;
            blockedListCache.FillItemIds();

            
            
            if (sc.CurrentProfile.ListOption != 0)
            {
                auctions = auctions
                    .Where(auction => Options.CombinedSearchCache.ItemIds.Contains(auction.item.id))
                    .ToList();
            }

            if (sc.CurrentProfile.ListOption == 2)
            {
                auctions = auctions
                    .Where(auction =>
                        ((Options.CombinedSearchCache.Items.Single(
                            item => item.Id == auction.item.id).BuyPrice * 10000) >=
                            auction.buyout))
                    .Take(sc.Config.AuctionsCap.Value)
                    .ToList(); 
            }
            else
            {
                if (sc.CurrentProfile.MainFilter.Value)
                {
                    auctions = auctions

                    //Latest xpac
                    .Where(auction => Options.LatestXpac == false
                        || (Options.LatestXpac == true && auction.item.id >= sc.Config.LatestXpacItemId))

                    //Include pets and items as desired
                    .Where(auction => (Options.IncludePets && auction.item.isPet) ||
                        (Options.IncludeItems && !auction.item.isPet))

                    //Bid only or buyout only
                    .Where(
                        (auction =>
                            (auction.buyout == 0 && Options.IncludeBid == true)
                        ||
                            (auction.buyout > 0 && Options.IncludeBuyout == true)
                        ))

                    //Item level
                    .Where(auction => (auction.item.itemLevel >= sc.CurrentProfile.MinItemLevel)
                        && (auction.item.itemLevel <= sc.CurrentProfile.MaxItemLevel))

                    //Char level
                    .Where(auction =>
                       (auction.item.cacheItem != null) &&
                         ((auction.item.cacheItem.RequiredLevel >= sc.CurrentProfile.MinCharLevel)
                         && (auction.item.cacheItem.RequiredLevel <= sc.CurrentProfile.MaxCharLevel)))

                    //Worth at least
                    .Where(auction => Options.FixedWorthAtLeast == -1 || (Options.FixedWorthAtLeast > -1
                        && (auction.item.regionItem.marketValue >= Options.FixedWorthAtLeast)))

                    //Minimum sell rate
                    .Where(auction => sc.CurrentProfile.MinSellRate == -1 ||
                        (auction.item.regionItem.saleRate >= sc.CurrentProfile.MinSellRate))

                    //Sell rate
                    .Where(auction => auction.item.regionItem.saleRate > sc.CurrentProfile.MinSellRate)

                    //Percentage or Max G
                    .Where(auction =>
                        (sc.CurrentProfile.SearchFraction == 0
                        && ((auction.buyout < (auction.item.regionItem.marketValue * Options.FixedSearchPercentage)))
                        ||
                        (sc.CurrentProfile.SearchFraction == 1
                        && (auction.buyout < Options.FixedMaxG)))
                        )

                    .ToList();
                }


                auctions = auctions

                    //Class - include if it's a pet OR it's an item and item class matches
                    .Where(auction => 
                        auction.item.isPet ||
                        !sc.CurrentProfile.ClassFilter.Value ||
                        Options.Class.Contains(auction.item.cacheItem.ClassName))

                    //Sub Class - include if it's a pet OR it's an item and sub class matches
                    .Where(auction =>
                        auction.item.isPet ||
                        !sc.CurrentProfile.SubClassFilter.Value ||
                        Options.SubClass.Contains(auction.item.cacheItem.SubClassName))

                    //Inventory Type - include if it's a pet OR it's an item and inventory type matches
                    .Where(auction =>
                        auction.item.isPet ||
                        !sc.CurrentProfile.InventoryTypeFilter.Value ||
                        Options.InventoryType.Contains(auction.item.cacheItem.InventoryType))

                    //Quality
                    .Where(auction =>
                        auction.item.isPet ||
                        !sc.CurrentProfile.QualityFilter.Value ||
                        Options.Quality.Contains(auction.item.quality))

                    //Bonuses
                    .Where(auction =>
                        auction.item.isPet ||
                        !sc.CurrentProfile.BonusesFilter.Value ||
                        Options.Bonuses.All(b => auction.item.bonus_lists?.Contains(b) == true))

                    //String filter
                    .Where(auction => Options.UseStringFilter == false
                        || (Options.UseStringFilter == true
                        && auction.auctionitemName.Contains(Options.StringFilter, StringComparison.OrdinalIgnoreCase)))

                    //Remove any items from the blocked list
                    .Where(auction => !blockedListCache.ItemIds.Contains(auction.item.id))
                         //String filter
                       //bool allExist = subset.All(superset.Contains);

                         .Take(sc.Config.AuctionsCap.Value)
                         .ToList();
            }

 


            foreach (var auction in auctions)
            {
                searchResults.Add(GetSearchNewResult(auction, realm));
            }

            searchResults = SortResults(searchResults);
            return searchResults;
        }
        
        public List<SearchResult> SortResults(List<SearchResult> searchResults)
        {
            //Need to sort frequency options

            //2 = Show all - default, if we do nothing we are doing this already

            //1 = Show cheapest
            List<SearchResult> refinedResults = searchResults;

            if (sc.CurrentProfile.SearchFrequency == 1)
            {
                refinedResults = searchResults
                    .GroupBy(p => p.ItemId)                         // Group by the property value (Id)
                    .Select(g => g.OrderBy(p => p.Buyout).First())  // Select the object with the lowest buyout from each group
                    .ToList();
            }

            //0 = Remove duplicates
            if (sc.CurrentProfile.SearchFrequency == 0)
            {
                refinedResults = searchResults
                    .GroupBy(p => p.ItemId)         // Group by the property value (Id)
                    .Where(g => g.Count() == 1)     // Filter groups where the count is exactly one
                    .Select(g => g.First())         // Select the object from the single-item group
                    .ToList();
            }

            if (Options.AtoZ)
            {
                refinedResults = refinedResults.OrderBy(x => x.ItemName).ToList();
            }

            return refinedResults;
        }

        public static void ModifyItemLevel(Auction auction)
        {
            if (auction.item.bonus_lists != null)
            {
                foreach (long bonus in auction.item.bonus_lists)
                {
                    CrypticBonus deepItemDataBonus;
                    sc.Dictionaries.CrypticBonuses.TryGetValue(bonus.ToString(), out deepItemDataBonus);

                    if (deepItemDataBonus != null)
                    {
                        if ((deepItemDataBonus.content_tuning_key != null)
                            && deepItemDataBonus.content_tuning_key == "scaling_config")
                        {
                            if (deepItemDataBonus.default_level != null && deepItemDataBonus.default_level != 0)
                            {
                                auction.item.itemLevel = deepItemDataBonus.default_level.Value;
                            }
                        }
                    }
                }
            }
        }

        public static string GetQualityTypeFromNumber(long number)
        {
            switch (number)
            {
                case 0: default: return "POOR";
                case 1: return "COMMON";
                case 2: return "UNCOMMON";
                case 3: return "RARE";
                case 4: return "EPIC";
                case 5: return "LEGENDARY";
                case 6: return "ARTIFACT";
            }
        }

        private SearchResult GetSearchNewResult(Auction auction, Realm realm)
        {
            SearchResult result = new SearchResult();

            if (auction.item.isPet)
            {
                result.Class = "Battle Pet";
                result.SubClass = auction.item.cachePet.BattlePetType;
                result.ItemName = auction.item.cachePet.Name;
            }
            else
            {
                result.Class = auction.item.cacheItem.ClassName;
                result.SubClass = auction.item.cacheItem.SubClassName;
                result.ItemName = auction.item.cacheItem.Name;
            }

            
            //"S" + auction.item.id.ToString();
            result.RealmId = realm.RealmId.Value;
            result.RealmName = realm.RealmName;
            result.Buyout = auction.buyout;
            result.RegionMarket = auction.item.regionItem.marketValue.Value;
            result.ItemId = auction.item.id;
            result.PetId = auction.item.pet_species_id;
            result.PetLevel = auction.item.pet_level;
            result.NumAuctions = realm.NumAuctions;
            result.Quality = auction.item.quality;
            result.SaleRate = auction.item.regionItem.saleRate.Value;
            result.Level = auction.item.itemLevel;

            if (auction.item.cacheItem != null)
            {
                result.CharLevel = auction.item.cacheItem.RequiredLevel;
            }

            result.OriginalAuction = auction;
            if (auction.item.modifiers != null)
            {
                result.Modifiers += "MODS: ";
                foreach (AuctionModifiers am in auction.item.modifiers)
                {
                    result.Modifiers += $"type = {am.type.ToString()}, value = {am.value.ToString()} | ";
                }
            }

            if (auction.item.bonus_lists != null)
            {
                result.BonusLists += "BONUSES: ";
                foreach (long bonus in auction.item.bonus_lists)
                {
                    result.BonusLists += bonus.ToString() + " | ";
                }
            }

            return result;
        }
    }

    public class SearchOptions
    {
        public bool NewDataOnly;
        public bool LatestXpac;
        public bool IncludeItems;
        public bool IncludePets;
        public bool HasSockets;
        public bool AtoZ;
        public bool UseStringFilter;
        public bool IncludeBuyout;
        public bool IncludeBid;
        public string StringFilter;
        public long FixedMaxG = 0;
        public long FixedWorthAtLeast = 0;
        public float FixedSearchPercentage = 0;

        public List<string> Main;
        public List<string> Class;
        public List<string> Quality;
        public List<long> Bonuses;
        public List<string> InventoryType;
        public List<string> SubClass;

        public ItemCache CombinedSearchCache = new ItemCache();
    }

    public class ItemProps
    {

        public TsmItem RegionItem;
        public CacheItem CachedItem;
        public CachePet CachedPet;

        public long ItemId;
        public string ItemName = "";
        public string Quality = "";
        public string Class = "";
        public string SubClass = "";
        public string AuctionID = "";
        public float SaleRate = 0.01f;
        public long MarketValue = 0;
        public long Level = 0;
        public long CharLevel = 0;
        public string Suffix = "";
        public bool IsMatch = false;
        public bool IsPet = false;
        public long ItemLevelModifier = 0;
        public string BonusLists = "";
        public string Modifiers = "";
    }


    public class SearchResult
    {
        public string AuctionId;
        public long RealmId;
        public string RealmName;
        public long Buyout;
        public long RegionMarket;
        public long ItemId;
        public int NumAuctions;
        public Color NumAuctionColor;
        public string ItemName;
        public string Quality;
        public string Class;
        public string SubClass;
        public float SaleRate;
        public System.Drawing.Color RowColor;
        public long PetId = 0;
        public long PetLevel = 0;
        public string Modifiers = String.Empty;
        public string BonusLists = String.Empty;
        public long Level = 0;
        public long CharLevel = 0;
        public string Suffix = String.Empty;
        public Auction OriginalAuction = new Auction();
    }

    public class SearchCount
    {
        public string AuctionId;
        public int Count;
        public long Cheapest;
        public SearchResult Result;
    }
}
