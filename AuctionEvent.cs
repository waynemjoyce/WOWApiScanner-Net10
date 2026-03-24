using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace WOWAuctionApi_Net10
{
    public class AuctionEvent
    {
        public event AuctionRetrievedEventHandler? AuctionRetrieved;

        public delegate void AuctionRetrievedEventHandler(object sender, AuctionEventArgs e);

        protected virtual void OnAuctionRetrieved(AuctionEventArgs e)
        {
            AuctionRetrievedEventHandler handler = AuctionRetrieved;
            handler?.Invoke(this, e);
        }

        public void DoAuctionProcess(
            FormCache fc,
            Realm realm,
            int newDataThreshholdMinutes,
            bool livePoll, 
            int livePollIntervalSeconds)
        {
            HttpStatusCode statusCode = new HttpStatusCode();
            string lastModified = String.Empty;
            AuctionFileContents afc;
            

            //Process the auction
            afc = API_Blizzard.GetAuctionsFromAPI(fc.BlizzAccessToken, realm, out statusCode, out lastModified);

            
            DateTime lastModifiedTime = DateTime.Parse(lastModified);

            bool pastModified = (DateTime.Now - lastModifiedTime > TimeSpan.FromMinutes(newDataThreshholdMinutes));

            if (livePoll)
            {
                if (pastModified)
                {
                    // It was more than X minutes ago - old data so re-poll
                    Thread.Sleep(livePollIntervalSeconds);
                    DoAuctionProcess(fc, realm, newDataThreshholdMinutes, livePoll, livePollIntervalSeconds);
                }
            }

            realm.OldData = pastModified;

            if ((afc != null) && (afc.auctions != null))
            {
                for (int i = afc.auctions.Count - 1; i >= 0; i--)
                {
                    var auction = afc.auctions[i];

                    // You can safely modify the list here, e.g., numbers.RemoveAt(i);
                    if ((auction == null) || auction.item == null)
                    {
                        afc.auctions.RemoveAt(i); ;
                        continue;
                    }
                    if (auction.item.pet_species_id > 0)
                    {
                        auction.item.isPet = true;
                        fc.Dictionaries.RegionItems.TryGetValue(auction.item.pet_species_id, out auction.item.regionItem);
                        fc.Dictionaries.DictionaryPetCache.TryGetValue(auction.item.pet_species_id, out auction.item.cachePet);
                        if (auction.item.cachePet == null || auction.item.regionItem == null)
                        {
                            afc.auctions.RemoveAt(i);
                            continue;
                        }
                        auction.item.quality = SearchLogic.GetQualityTypeFromNumber(auction.item.pet_quality_id);
                        auction.auctionitemName = auction.item.cachePet.Name;
                    }
                    else
                    {
                        auction.item.isPet = false;
                        fc.Dictionaries.RegionItems.TryGetValue(auction.item.id, out auction.item.regionItem);
                        fc.Dictionaries.DictionaryItemCache.TryGetValue(auction.item.id, out auction.item.cacheItem);
                        if (auction.item.cacheItem == null || auction.item.regionItem == null)
                        {
                            afc.auctions.RemoveAt(i); ;
                            continue;
                        }
                        auction.item.quality = auction.item.cacheItem.QualityType;
                        auction.item.itemLevel = auction.item.cacheItem.Level;
                        auction.auctionitemName = auction.item.cacheItem.Name;
                    }

                    SearchLogic.ModifyItemLevel(auction, fc);
                }

                //Preload the realm auctions with the cacheItem and tsmItem
                foreach (var auction in afc.auctions)
                {

                }

                //Raise an event once we're done
                AuctionEventArgs aucArgs = new AuctionEventArgs();
                aucArgs.Auctions = afc;
                aucArgs.RealmId = realm.RealmId.Value;
                aucArgs.StatusCode = statusCode;
                aucArgs.LastModified = lastModified;
                aucArgs.RealmObject = realm;
                realm.LastModified = lastModified;

                //OnAuctionRetrieved(aucArgs);
                AuctionRetrieved?.Invoke(this, aucArgs);  
            }
        }
    }

    public class AuctionEventArgs : EventArgs
    {
        public int RealmId { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public AuctionFileContents Auctions { get; set; }

        public Realm RealmObject { get; set; }

        public string LastModified { get; set; }
    }
}
