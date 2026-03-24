using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class SearchLogic
    {
        public SearchOptions Options = new SearchOptions();
        public FormCache fc = new FormCache();

        //Searches items from an item cache rather than auctions
        public ItemCache DoItemSearch(ItemCache itemsAsCacheCopy)
        {
            //Get a copy of the current items in the list so we don't get items we already have
            ItemCache copyCache = itemsAsCacheCopy;

            //HashSet for efficient lookup.
            HashSet<long> itemIdsInList = new HashSet<long>(copyCache.Items.Select(item => item.Id));

            ItemCache searchResults = new ItemCache();
            searchResults.Items = fc.Caches.ItemCache.Items
                //Quality
                .Where(item => Options.Quality.Contains(item.QualityType))
                //Item Class
                .Where(item => Options.Class.Contains(item.ClassName))
                //Character required level
                .Where(item => item.RequiredLevel >= fc.CurrentProfile.MinCharLevel && item.RequiredLevel <= fc.CurrentProfile.MaxCharLevel)
                //Item level
                .Where(item => item.Level >= fc.CurrentProfile.MinItemLevel && item.Level <= fc.CurrentProfile.MaxItemLevel)
                //Worth at least
                .Where(item => Options.FixedWorthAtLeast == -1 || (Options.FixedWorthAtLeast > -1
                    && (item.RegionItem.marketValue >= Options.FixedWorthAtLeast)))
                //Minimum sell rate
                .Where(item => fc.CurrentProfile.MinSellRate == -1 ||
                    (item.RegionItem.saleRate <= fc.CurrentProfile.MinSellRate))
                //Latest xpac only
                .Where(item => Options.LatestXpac == false
                    || (Options.LatestXpac == true && item.Id >= fc.Config.LatestXpacItemId))
                //Filter only an items we don't already have in the list
                .Where(item => !itemIdsInList.Contains(item.Id))
                //String filter
                .Where(item => Options.UseStringFilter == false
                    || (Options.UseStringFilter == true
                    && item.Name.Contains(Options.StringFilter, StringComparison.OrdinalIgnoreCase)))
                //Apply auctions cap
                .Take(fc.Config.AuctionsCap.Value)
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
            List<Auction> auctions = fc.Dictionaries.RealmAuctions[realm.RealmId.Value].auctions;

            if (fc.CurrentProfile.ListOption != 0)
            {
                auctions = auctions
                    .Where(auction => fc.CurrentItemList.ItemCache.ItemIds.Contains(auction.item.id))
                    .ToList();
            }

            if (fc.CurrentProfile.ListOption == 2)
            {
                auctions = auctions
                    .Where(auction =>
                        ((fc.CurrentItemList.ItemCache.Items.Single(
                            item => item.Id == auction.item.id).BuyPrice * 10000) >=
                            auction.buyout))
                    .Take(fc.Config.AuctionsCap.Value)
                    .ToList(); 
            }
            else
            {
                auctions = auctions
                     //Include pets / items and check for nulls
                     .Where(auction => (Options.IncludePets && auction.item.isPet) ||
                         (Options.IncludeItems && !auction.item.isPet))

                     //Sell rate
                     .Where(auction => auction.item.regionItem.saleRate > fc.CurrentProfile.MinSellRate)
                     //Quality
                     .Where(auction => Options.Quality.Contains(auction.item.quality))
                     //Class - include if it's a pet OR it's an item and item class matches
                     .Where(auction => auction.item.isPet || (!auction.item.isPet)
                         && Options.Class.Contains(auction.item.cacheItem.ClassName))
                     //Item level
                     .Where(auction => (auction.item.itemLevel >= fc.CurrentProfile.MinItemLevel)
                         && (auction.item.itemLevel <= fc.CurrentProfile.MaxItemLevel))
                     //Minimum sell rate
                     .Where(auction => fc.CurrentProfile.MinSellRate == -1 ||
                         (auction.item.regionItem.saleRate >= fc.CurrentProfile.MinSellRate))
                     //Worth at least
                     .Where(auction => Options.FixedWorthAtLeast == -1 || (Options.FixedWorthAtLeast > -1
                         && (auction.item.regionItem.marketValue >= Options.FixedWorthAtLeast)))
                     //Latest xpac
                     .Where(auction => Options.LatestXpac == false
                         || (Options.LatestXpac == true && auction.item.id >= fc.Config.LatestXpacItemId))
                     //Percentage or Max G
                     .Where(auction =>
                         (fc.CurrentProfile.SearchFraction == 0
                         && ((auction.buyout < (auction.item.regionItem.marketValue * Options.FixedSearchPercentage)))
                         ||
                         (fc.CurrentProfile.SearchFraction == 1
                         && (auction.buyout < Options.FixedMaxG)))
                         )
                     //String filter
                     .Where(auction => Options.UseStringFilter == false
                         || (Options.UseStringFilter == true
                         && auction.auctionitemName.Contains(Options.StringFilter, StringComparison.OrdinalIgnoreCase)))
                     .Take(fc.Config.AuctionsCap.Value)
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

            if (fc.CurrentProfile.SearchFrequency == 1)
            {
                refinedResults = searchResults
                    .GroupBy(p => p.ItemId)                         // Group by the property value (Id)
                    .Select(g => g.OrderBy(p => p.Buyout).First())  // Select the object with the lowest buyout from each group
                    .ToList();
            }

            //0 = Remove duplicates
            if (fc.CurrentProfile.SearchFrequency == 0)
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

        public static void ModifyItemLevel(Auction auction, FormCache fc)
        {
            if (auction.item.bonus_lists != null)
            {
                foreach (long bonus in auction.item.bonus_lists)
                {
                    DeepItemDataBonus deepItemDataBonus;
                    fc.Dictionaries.DeepItemData.TryGetValue(bonus.ToString(), out deepItemDataBonus);

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

        private void ModifyItemLevelOld(Auction auction, ItemProps itemProps, FormCache fc)
        {
            if (auction.item.bonus_lists != null)
            {
                foreach (long bonus in auction.item.bonus_lists)
                {
                    DeepItemDataBonus deepItemDataBonus;
                    fc.Dictionaries.DeepItemData.TryGetValue(bonus.ToString(), out deepItemDataBonus);

                    if (deepItemDataBonus != null)
                    {
                        if ((deepItemDataBonus.content_tuning_key != null)
                            && deepItemDataBonus.content_tuning_key == "scaling_config")
                        {
                            if (deepItemDataBonus.default_level != null)
                            {
                                itemProps.Level = deepItemDataBonus.default_level.Value;
                            }
                        }
                    }
                }
            }
        }

        private void SetPetProps(Auction auction, ItemProps itemProps)
        {
            itemProps.IsPet = true;
            itemProps.ItemName = itemProps.CachedPet.Name;
            itemProps.MarketValue = itemProps.RegionItem.marketValue.Value;
            itemProps.SaleRate = itemProps.RegionItem.saleRate.Value;
            itemProps.Quality = SearchLogic.GetQualityTypeFromNumber(auction.item.pet_quality_id);
            itemProps.Class = "Battle Pet";
            itemProps.SubClass = itemProps.CachedPet.BattlePetType;
            itemProps.ItemId = auction.item.pet_species_id;
            itemProps.AuctionID = "P" + auction.item.pet_species_id.ToString();
            itemProps.SubClass = itemProps.CachedPet.BattlePetType;
            itemProps.Level = auction.item.pet_level;
        }

        private void SetItemProps(Auction auction, ItemProps itemProps)
        {
            itemProps.IsPet = false;
            itemProps.ItemName = itemProps.CachedItem.Name;
            itemProps.MarketValue = itemProps.RegionItem.marketValue.Value;
            itemProps.SaleRate = itemProps.RegionItem.saleRate.Value;
            itemProps.Quality = itemProps.CachedItem.QualityType;
            itemProps.Class = itemProps.CachedItem.ClassName;
            itemProps.ItemId = auction.item.id;
            itemProps.AuctionID = "S" + auction.item.id.ToString();
            itemProps.SubClass = itemProps.CachedItem.SubClassName;
            itemProps.Level = itemProps.CachedItem.Level;
            itemProps.CharLevel = itemProps.CachedItem.RequiredLevel;

            if (auction.item.modifiers != null)
            {
                itemProps.Modifiers += "MODS: ";
                foreach (AuctionModifiers am in auction.item.modifiers)
                {
                    itemProps.Modifiers += $"type = {am.type.ToString()}, value = {am.value.ToString()} | ";
                }
            }

            if (auction.item.bonus_lists != null)
            {
                itemProps.BonusLists += "BONUSES: ";
                foreach (long bonus in auction.item.bonus_lists)
                {
                    itemProps.BonusLists += bonus.ToString() + " | ";
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
            //result.Suffix = itemProps.Suffix;
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

        private SearchResult GetSearchResult(Auction auction, Realm realm, ItemProps itemProps)
        {
            SearchResult result = new SearchResult();

            result.AuctionId = itemProps.AuctionID;
            result.RealmId = realm.RealmId.Value;
            result.RealmName = realm.RealmName;
            result.Buyout = auction.buyout;
            result.RegionMarket = itemProps.MarketValue;
            result.ItemId = auction.item.id;
            result.PetId = auction.item.pet_species_id;
            result.PetLevel = auction.item.pet_level;
            result.NumAuctions = realm.NumAuctions;
            result.ItemName = itemProps.ItemName;
            result.Quality = itemProps.Quality;
            result.Class = itemProps.Class;
            result.SubClass = itemProps.SubClass;
            result.SaleRate = itemProps.SaleRate;
            result.Level = itemProps.Level;
            result.Suffix = itemProps.Suffix;
            result.OriginalAuction = auction;
            result.Modifiers = itemProps.Modifiers;
            result.BonusLists = itemProps.BonusLists;     

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
        public string StringFilter;
        public long FixedMaxG = 0;
        public long FixedWorthAtLeast = 0;
        public float FixedSearchPercentage = 0;

        public List<string> Main;
        public List<string> Class;
        public List<string> Quality;
        public List<string> Bonuses;
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


/*
 * 
        public List<SearchResult> SearchRealmOld(Realm realm)
        {
            var searchResults = new List<SearchResult>();
            int count = 0;

            
            List<Auction> auctions = fc.Dictionaries.RealmAuctions[realm.RealmId.Value].auctions;

            if (ItemInList(Options.Main, "Latest Xpac"))
            {
                auctions = auctions
                    .Where(auction => auction.item.id > fc.Config.LatestXpacItemId)
                    .ToList();
            }


            foreach (var auction in auctions)
            {
                var itemProps = new ItemProps();
                                
                itemProps.IsMatch = false;
                itemProps.CachedItem = null;
                itemProps.Suffix = String.Empty;

                if (auction.item.pet_species_id > 0)
                {
                    if (!ItemInList(Options.Main, "Include Pets") ) { continue; }
                    fc.Dictionaries.RegionItems.TryGetValue(auction.item.pet_species_id, out itemProps.RegionItem);
                    fc.Dictionaries.DictionaryPetCache.TryGetValue(auction.item.pet_species_id, out itemProps.CachedPet);
                    if (itemProps.RegionItem == null || itemProps.CachedPet == null) { continue; }
                    SetPetProps(auction, itemProps);
                }
                else
                {
                    if (!ItemInList(Options.Main, "Include Items")) { continue; }
                    fc.Dictionaries.RegionItems.TryGetValue(auction.item.id, out itemProps.RegionItem);
                    fc.Dictionaries.DictionaryItemCache.TryGetValue(auction.item.id, out itemProps.CachedItem);
                    if (itemProps.RegionItem == null || itemProps.CachedItem == null) { continue; }
                    SetItemProps(auction, itemProps);
                }

                //STRING FILTER
                if ((fc.CurrentProfile.StringFilter.Trim() != "") && (!(itemProps.ItemName.ToUpper().Contains(fc.CurrentProfile.StringFilter.ToUpper())))) { continue; }


                //QUALITY
                if (!ItemInList(Options.Quality, itemProps.Quality)) { continue; }

                //CLASS
                if ((!itemProps.IsPet) && (!ItemInList(Options.Class, itemProps.Class))) { continue; }

                //CHECK CHAR REQUIRED LEVEL
                if (!itemProps.IsPet)
                {
                    if ((itemProps.CharLevel <= fc.CurrentProfile.MinCharLevel) || 
                        (itemProps.CharLevel >= fc.CurrentProfile.MaxCharLevel)) { continue; }
                }

    
                //CHECK VALUES
                //0 - Percentage
                if ((fc.CurrentProfile.SearchFraction == 0)
                    && (((itemProps.MarketValue * this.Options.FixedSearchPercentage) < auction.buyout)
                    || (this.Options.FixedWorthAtLeast > itemProps.MarketValue))) { continue; }

                //1 - Max G
                if ((fc.CurrentProfile.SearchFraction == 1)
                    && ((this.Options.FixedMaxG < auction.buyout)
                    || (this.Options.FixedWorthAtLeast > itemProps.MarketValue))) { continue; }

                //SELL RATE
                if ((fc.CurrentProfile.MinSellRate > -1) && (itemProps.SaleRate < fc.CurrentProfile.MinSellRate)) { continue; }

                //WORTH AT LEAST
                if ((Options.FixedWorthAtLeast > -1) && (itemProps.MarketValue < Options.FixedWorthAtLeast)) { continue; }

                //CHECK BONUSES SUCH AS SPEED, LEECH, AVOIDANCE ETC
                //We only want to exclude this item if
                //- Our search options has one or more bonuses
                //- The bonus_list for the item isn't null
                //- It has 1 or more items in it and isn't empty
                //- One or more of our bonuses are not in the list of the item's bonuses 

                if (Options.Bonuses.Count > 0)
                {
                    if ((auction.item.bonus_lists == null) ||
                    (auction.item.bonus_lists.Count == 0) ||
                    (BonusExclude(auction, itemProps))
                    ) { continue; }

                }

                if (itemProps.Class == "Armor" || itemProps.Class == "Weapon")
                {
                    ModifyItemLevelOld(auction, itemProps, fc);

                    //CHECK ITEM LEVEL
                    if ((itemProps.Level <= fc.CurrentProfile.MinItemLevel) ||
                        (itemProps.Level >= fc.CurrentProfile.MaxItemLevel)) { continue; }
                }
                count++;

                //Populate search result and add it to the list
                searchResults.Add(GetSearchResult(auction, realm, itemProps));
                
            }

            searchResults = SortResults(searchResults);
            return searchResults;
        }
 * 
 * 
        private bool BonusExclude(Auction auction, ItemProps itemProps)
        {
            //We know our bonus list has more than 1 item
            //And the item's bonus list isn't null and has more than 1 item
            //So every time in our bonus list, must be in the item's bonus list
            //As soon as we find one that isn't, then return true to exclude this item
            foreach (string bonus in Options.Bonuses)
            {
                bool itemHasThisBonus = auction.item.bonus_lists.Contains(long.Parse(bonus));

                if (!itemHasThisBonus)
                {
                    return true;
                }
            }
            return false;
        }

        private void ProcessBonuses(Auction auction, ItemProps itemProps)
        {

            //Need to check, and if necessary, modify the item level
            if (auction.item.bonus_lists != null)
            {
                itemProps.Suffix = "";
                foreach (long bonus in auction.item.bonus_lists)
                {
                    if (bonus > 1371 && bonus < 1600)
                    {
                        itemProps.ItemLevelModifier = (bonus - 1472);
                    }
                    else if (bonus >= 1676 && bonus <= 1717)
                    {
                        if (bonus >= 1676 && bonus <= 1682)
                        {
                            itemProps.Suffix = "of the Quickblade";
                        }
                        else if (bonus >= 1683 && bonus <= 1689)
                        {
                            itemProps.Suffix = "of the Peerless";
                        }
                        else if (bonus >= 1690 && bonus <= 1696)
                        {
                            itemProps.Suffix = "of the Fireflash";
                        }
                        else if (bonus >= 1697 && bonus <= 1703)
                        {
                            itemProps.Suffix = "of the Feverflare";
                        }
                        else if (bonus >= 1704 && bonus <= 1710)
                        {
                            itemProps.Suffix = "of the Aurora";
                        }
                        else if (bonus >= 1711 && bonus <= 1717)
                        {
                            itemProps.Suffix = "of the Harmonious";
                        }

                    }
                }
            }

            //Adjust item level by the modifier if there was one
            if (itemProps.ItemLevelModifier != 0)
            {
                itemProps.Level += itemProps.ItemLevelModifier;
            }
        }

        private bool ItemInList(List<string> list, string item)
        {
            return list.Contains(item);
        }
 */