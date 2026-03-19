using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public class SearchLogic
    {
        public SearchOptions Options = new SearchOptions();
        public long FixedMaxG = 0;
        public long FixedWorthAtLeast = 0;
        public float FixedSearchPercentage = 0;

        public List<SearchResult> SearchRealm(
            Realm realm, 
            SearchProfile searchProfile, 
            AuctionFileContents auctionFileContents,
            Dictionary<long, TsmItem> regionItems,
            Dictionary<long, TsmItem> regionPets,
            SortedDictionary<long, Item> dictionaryItemCache,
            SortedDictionary<long, Pet> dictionaryPetCache,
            Config apiConfig)
        {
            var searchResults = new List<SearchResult>();
            int count = 0;

            foreach(var auction in auctionFileContents.auctions)
            {
                var itemProps = new ItemProps();
                                
                itemProps.IsMatch = false;
                itemProps.CachedItem = null;
                itemProps.Suffix = String.Empty;

                if (auction.item.pet_species_id > 0)
                {
                    if (!ItemInList(Options.Main, "Include Pets") ) { continue; }   
                    regionPets.TryGetValue(auction.item.pet_species_id, out itemProps.RegionItem);
                    dictionaryPetCache.TryGetValue(auction.item.pet_species_id, out itemProps.CachedPet);
                    if (itemProps.RegionItem == null || itemProps.CachedPet == null) { continue; }
                    SetPetProps(auction, itemProps);
                }
                else
                {
                    if (!ItemInList(Options.Main, "Include Items")) { continue; }
                    regionItems.TryGetValue(auction.item.id, out itemProps.RegionItem);
                    dictionaryItemCache.TryGetValue(auction.item.id, out itemProps.CachedItem);
                    if (itemProps.RegionItem == null || itemProps.CachedItem == null) { continue; }
                    SetItemProps(auction, itemProps);
                }

                //LATEST XPAC ONLY
                if (ItemInList(Options.Main, "Only Latest Xpac") && (itemProps.ItemId < apiConfig.LatestXpacItemId)) { continue; }

                //QUALITY
                if (!ItemInList(Options.Quality, itemProps.Quality)) { continue; }

                //CLASS
                if ((!itemProps.IsPet) && (!ItemInList(Options.Class, itemProps.Class))) { continue; }

                //SELL RATE
                if ((searchProfile.MinSellRate > -1) && (itemProps.SaleRate < searchProfile.MinSellRate)) { continue; }

                //SIFT THROUGH BONUSES, AND MODIFY ITEM LEVEL IF NEEDED
                ProcessBonuses(auction, itemProps);

                //CHECK ITEM LEVEL
                if ((itemProps.Level <= searchProfile.MinItemLevel) || (itemProps.Level >= searchProfile.MaxItemLevel)) { continue; }

                //STRING FILTER
                if ((searchProfile.StringFilter.Trim() != "") && (!(itemProps.ItemName.ToUpper().Contains(searchProfile.StringFilter.ToUpper())))) { continue; }  

                //CHECK VALUES
                //0 - Percentage
                if ((searchProfile.SearchFraction == 0)
                    && (((itemProps.MarketValue * this.FixedSearchPercentage) < auction.buyout)
                    || (this.FixedWorthAtLeast > itemProps.MarketValue))) { continue; }

                //1 - Max G
                if ((searchProfile.SearchFraction == 1)
                    && ((this.FixedMaxG < auction.buyout)
                    || (this.FixedWorthAtLeast > itemProps.MarketValue))) { continue; }

                count++;
                //if (count > 25) { break; }

                //Populate search result and add it to the list
                searchResults.Add(GetSearchResult(auction, realm, itemProps));
                
            }

            //Need to sort frequency options

            //2 = Show all - default, if we do nothing we are doing this already

            //1 = Show cheapest
            if (searchProfile.SearchFrequency == 1)
            {
                List<SearchResult> refinedResults = searchResults
                    .GroupBy(p => p.ItemId)                         // Group by the property value (Id)
                    .Select(g => g.OrderBy(p => p.Buyout).First())  // Select the object with the lowest buyout from each group
                    .ToList();
                searchResults = refinedResults;
            }

            //0 = Remove duplicates
            if (searchProfile.SearchFrequency == 0)
            {
                List<SearchResult> refinedResults = searchResults
                    .GroupBy(p => p.ItemId)         // Group by the property value (Id)
                    .Where(g => g.Count() == 1)     // Filter groups where the count is exactly one
                    .Select(g => g.First())         // Select the object from the single-item group
                    .ToList();
                searchResults = refinedResults;
            }

            //If A to Z select then order
            if (ItemInList(Options.Main, "A to Z")) { searchResults = searchResults.OrderBy(x => x.ItemName).ToList(); }

            return searchResults;
        }

        private void SetPetProps(Auction auction, ItemProps itemProps)
        {
            itemProps.IsPet = true;
            itemProps.ItemName = itemProps.CachedPet.Name;
            itemProps.MarketValue = itemProps.RegionItem.marketValue.Value;
            itemProps.SaleRate = itemProps.RegionItem.saleRate.Value;
            itemProps.Quality = GetQualityTypeFromNumber(auction.item.pet_quality_id);
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
        }


        private string GetQualityTypeFromNumber(long number)
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

            return result;
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
    }

    public class SearchOptions
    {
        public List<string> Main;
        public List<string> Class;
        public List<string> Quality;
    }

    public class ItemProps
    {

        public TsmItem RegionItem;
        public Item CachedItem;
        public Pet CachedPet;

        public long ItemId;
        public string ItemName = "";
        public string Quality = "";
        public string Class = "";
        public string SubClass = "";
        public string AuctionID = "";
        public float SaleRate = 0.01f;
        public long MarketValue = 0;
        public long Level = 0;
        public string Suffix = "";
        public bool IsMatch = false;
        public bool IsPet = false;
        public long ItemLevelModifier = 0;
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
    }

    public class SearchCount
    {
        public string AuctionId;
        public int Count;
        public long Cheapest;
        public SearchResult Result;
    }
}
