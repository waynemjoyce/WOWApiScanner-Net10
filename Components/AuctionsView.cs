using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{

    public partial class AuctionsView : ComponentBase
    {
        private AuctionEvent.AuctionRetrievedEventHandler auctionEventDelegate;
        private ContextMenuStrip mnuAuctions;

        private RealmOptions realmOptions { get; set; }
        private GlobalOptions globalOptions { get; set; }

        public AuctionsView()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            mnuAuctions = new ContextMenuStrip();
            ToolStripMenuItem blockedListItem = new ToolStripMenuItem("Add to blocked list");
            blockedListItem.Click += new EventHandler(BlockedListItem_Click);
            mnuAuctions.Items.Add(blockedListItem);
            lvAuctions.ContextMenuStrip = mnuAuctions;
        }


        private void BlockedListItem_Click(object sender, EventArgs e)
        {
            SearchResult result = (SearchResult)lvAuctions.SelectedItems[0].Tag;
            CacheItem c = sc.Caches.ItemCache.Items.Single<CacheItem>(i => i.Id == result.ItemId);

            ItemCache blockedListCache = sc.ItemLists.GetListByName("SYS.BLOCKED").ItemCache;
            blockedListCache.Items.Add(c);
            sc.ItemLists.Save();

            for (int i = lvAuctions.Items.Count - 1; i >= 0; i--)
            {
                SearchResult loopResult = lvAuctions.Items[i].Tag as SearchResult;

                if (loopResult != null && loopResult.ItemId == result.ItemId)
                {
                    lvAuctions.Items.RemoveAt(i);
                    break;
                }
            }
        }

        public void InitAuctionsView(RealmOptions rOptions, GlobalOptions gOptions)
        {
            realmOptions = rOptions;
            globalOptions = gOptions;
            auctionEventDelegate = new AuctionEvent.AuctionRetrievedEventHandler(AuctionEvent_AuctionRetrieved);
        }

        public void CopyClipText()
        {
            Clipboard.SetText(lvAuctions.SelectedItems[0].SubItems[1].Text);
        }

        public class SearchResultCount
        {
            public List<SearchResult> SearchResults = new List<SearchResult>();
            public Realm Realm = new Realm();
            public int Count = 0;
        }

        public void AuctionsSearch(Charts chartsComponent, List<Realm> searchRealms)
        {
            lvAuctions.Items.Clear();
            List<SearchResultCount> searchResultCounts = new List<SearchResultCount>();

            sc.LivePoll = false;
            if (!realmOptions.CheckAllRealmsHaveData())
            {
                MsgHelper.Error.RealmsNotLoaded();
                return;
            }

            int count = 0;

            switch (sc.CurrentProfile.ChartFilter)
            {
                case 0:
                default:
                    chartsComponent.ChartFilter = "";
                    break;
                case 1:
                    chartsComponent.ChartFilter = "chartTotalValue";
                    break;
                case 2:
                    chartsComponent.ChartFilter = "chartTopSearches";
                    break;
                case 3:
                    chartsComponent.ChartFilter = "chartTotalAuctions";
                    break;

            }


            foreach (ListViewItem lvi in realmOptions.CheckedItems)
            {
                if (lvi.Tag != null)
                {
                    Realm realm = lvi.Tag as Realm;
                    if (realm != null && searchRealms.Contains(realm))
                    {
                        if (sc.SearchLogic.Options.NewDataOnly == true
                            && realm.Status != 2) { continue; }

                        var searchResults = sc.SearchLogic.DoAuctionSearch(realm);

                        if (searchResults != null)
                        {
                            if (chartsComponent.ChartFilter == "")
                            {
                                RenderSearchResults(searchResults, realm, count);
                            }
                            else
                            {
                                searchResultCounts.Add(new SearchResultCount
                                {
                                    SearchResults = searchResults,
                                    Realm = realm,
                                    Count = count
                                });
                            }

                            sc.AllRealmsAuctionTotal += searchResults.Count;
                            sc.Lists.RealmSearchCount.Add(new RealmCount
                            {
                                Realm = realm,
                                Count = searchResults.Count,
                                TotalValue = searchResults.Sum(r => r.RegionMarket)
                            });
                        }
                        count++;
                    }
                }
            }

            chartsComponent.RenderCharts();

            if (chartsComponent.ChartFilter != "")
            {
                foreach (Realm r in chartsComponent.ShownRealms)
                {   
                    if (searchRealms.Contains(r))
                    {
                        SearchResultCount src = searchResultCounts.Single(s => s.Realm.RealmId == r.RealmId);
                        RenderSearchResults(src.SearchResults, src.Realm, src.Count);
                    }
                }
            }
        }

        private void RenderSearchResults(
            List<SearchResult> searchResults,
            Realm realm,
            int count)
        {
            lvAuctions.SuspendLayout();
            string currentRealm = "";
            string toolTip = "";

            foreach (SearchResult result in searchResults)
            {
                if (currentRealm != result.RealmName)
                {
                    currentRealm = result.RealmName;
                    AddBlankSearchItem(realm, count);
                }
                float actualPercentage = (((float)result.Buyout / (float)result.RegionMarket) * 100);

                ListViewItem lvi = new ListViewItem();
                lvi.UseItemStyleForSubItems = false;
                lvi.Text = " ";
                lvi.BackColor = UIHelper.StringToColor(realm.BackColor);
                lvi.Tag = result;
                toolTip = $"{result.ItemId.ToString()}, {StrHelper.FormatLongN0(result.Buyout)}"
                    + $", ItemLevel = ({result.Level.ToString()}) {result.Modifiers} {result.BonusLists}";
                lvi.ToolTipText = toolTip;

                if (result.Suffix != String.Empty)
                {
                    lvi.SubItems.Add(result.ItemName + " " + result.Suffix);
                }
                else
                {
                    lvi.SubItems.Add(result.ItemName);
                }

                lvi.SubItems[1].ForeColor = UIHelper.GetColorForQuality(result.Quality);

                lvi.SubItems.Add(result.Level.ToString());
                lvi.SubItems.Add(result.CharLevel.ToString()); //Char level needs to go here

                //Color code sale rate
                lvi.SubItems.Add(result.SaleRate.ToString());
                lvi.SubItems[4].ForeColor = UIHelper.GetColorForSellRate(result.SaleRate);

                if (actualPercentage > 999.99f)
                {
                    actualPercentage = 999.99f;
                }
                lvi.SubItems.Add(actualPercentage.ToString("0.##") + "%");

                lvi.SubItems.Add(StrHelper.FormatLongN0(result.Buyout)); //Buyout $
                lvi.SubItems.Add(StrHelper.FormatLongN0(result.RegionMarket)); //Region $

                lvi.SubItems.Add(result.PetLevel.ToString()); //Pet Level
                if (result.PetLevel > 0)
                {
                    lvi.SubItems[8].ForeColor = UIHelper.GetColorForQuality(result.Quality);
                }

                //lvi.SubItems.Add((sc.ItemData.MidnightItemIds.Contains(result.ItemId)) ? "Y" : "");

                lvi.SubItems.Add((result.ItemId >= sc.Config.LatestXpacItemId) ? "Y" : "");
                lvAuctions.Items.Add(lvi);
            }
            lvAuctions.ResumeLayout();
        }

        public void ClearAuctions()
        {
            lvAuctions.Items.Clear();
        }

        private void SetAuctionData(int realmId, AuctionFileContents afc, string lastModified, Realm realm)
        {
            sc.Lists.TotalAuctionsCount.Add(new RealmCount
            {
                Realm = realm,
                Count = afc.auctions.Count
            });
            sc.Dictionaries.RealmAuctions[realmId] = afc;
            int newStatus = 2;

            try
            {
                DateTime lastModifiedDate = DateTime.Parse(lastModified);
                DateTime thresholdDate = DateTime.Now.AddMinutes(-globalOptions.Threshold);

                if (lastModifiedDate > thresholdDate)
                {
                    newStatus = 3;
                }

                realmOptions.SetRealmStatus(realm, newStatus, lastModified, afc.auctions.Count);
                if (sc.LivePoll)
                {
                    if (
                        realmOptions.RealmChecked(realm.RealmId.Value))
                    {
                        var searchResults = sc.SearchLogic.DoAuctionSearch(realm);

                        if (searchResults != null)
                        {
                            RenderSearchResults(searchResults, realm, 1);
                            sc.NumRealmsReturned += 1;

                            sc.Lists.RealmSearchCount.Add(new RealmCount
                            {
                                Realm = realm,
                                Count = searchResults.Count,
                                TotalValue = searchResults.Sum(r => r.RegionMarket)
                            });
                        }
                    }
                }
            }
            catch
            {
                //SetRealmStatus(connectedRealmId, 1, "ERROR", 0);
            }
        }


        private void ProcessAuctionsForRealm(
            Realm realm,
            bool livePoll = false,
            int livePollIntervalSeconds = 5,
            int newDataThreshholdMinutes = 20)
        {
            AuctionEvent auctionEvent = new AuctionEvent();
            auctionEvent.AuctionRetrieved += AuctionEvent_AuctionRetrieved;
            auctionEvent.DoAuctionProcess(realm, newDataThreshholdMinutes, livePoll, livePollIntervalSeconds);
        }

        private void AuctionEvent_AuctionRetrieved(object sender, AuctionEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(auctionEventDelegate, sender, e);
            }
            else
            {
                this.SetAuctionData(e.RealmId, e.Auctions, e.LastModified, e.RealmObject);
            }
        }

        public void LoadAuctionData()
        {
            sc.AllRealmsAuctionTotal = 0;

            if (!sc.LivePoll)
            {
                sc.Lists.TotalAuctionsCount.Clear();
            }

            foreach (Realm r in sc.Config.Realms)
            {
                if (realmOptions.RealmChecked(r.RealmId.Value))
                {
                    Thread ProcessAuctionsThread = new Thread(() => ProcessAuctionsForRealm(r,
                        sc.LivePoll, sc.Config.LivePollInterval.Value, sc.Config.Threshold.Value));

                    ProcessAuctionsThread.SetApartmentState(ApartmentState.MTA);
                    ProcessAuctionsThread.Start();
                }
            }
        }
        private void AddBlankSearchItem(Realm realm, int count)
        {
            if (count > 0)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = " ";
                lvAuctions.Items.Add(lvi);
            }

            ListViewItem lvi2 = new ListViewItem();
            lvi2.BackColor = UIHelper.StringToColor(realm.BackColor);
            lvi2.ForeColor = Color.White;
            lvi2.SubItems.Add(realm.RealmName);
            lvAuctions.Items.Add(lvi2);
        }

        private void lvAuctions_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
                if (char.ToUpper(e.KeyChar) == (char)Keys.C)
                {
                    CopyClipText();
                }

                if (sc.Config.WowInteraction)
                {
                    if (char.ToUpper(e.KeyChar) == (char)Keys.Z)
                    {
                        CopyClipText();
                        sc.WowBuyScript.ProcessScript();
                    }
                    else if (char.ToUpper(e.KeyChar) == (char)Keys.X)
                    {
                        CopyClipText();
                        sc.WowBuyScript_Slow.ProcessScript();
                    }
                }
    */
        }

        private void lvAuctions_DoubleClick(object sender, EventArgs e)
        {
            CopyClipText();
        }

        private void lvAuctions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                CopyClipText();
            }

            if (sc.Config.WowInteraction)
            {
                if (e.KeyCode == Keys.Z)
                {
                    CopyClipText();
                    sc.WowBuyScript.ProcessScript();
                }
                else if (e.KeyCode == Keys.X)
                {
                    CopyClipText();
                    sc.WowBuyScript_Slow.ProcessScript();
                }
            }

            e.SuppressKeyPress = true; // Prevents the Windows ding sound
        }
    }

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
            Realm realm,
            int newDataThreshholdMinutes,
            bool livePoll,
            int livePollIntervalSeconds)
        {
            HttpStatusCode statusCode = new HttpStatusCode();
            string lastModified = String.Empty;
            AuctionFileContents afc;


            //Process the auction
            afc = API_Blizzard.GetAuctionsFromAPI(sc.BlizzAccessToken, realm, out statusCode, out lastModified);


            DateTime lastModifiedTime = DateTime.Parse(lastModified);
            bool pastModified = (DateTime.Now - lastModifiedTime > TimeSpan.FromMinutes(newDataThreshholdMinutes));

            if (livePoll)
            {
                if (pastModified)
                {
                    // It was more than X minutes ago - old data so re-poll
                    Thread.Sleep(livePollIntervalSeconds);
                    DoAuctionProcess(realm, newDataThreshholdMinutes, livePoll, livePollIntervalSeconds);
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
                        sc.Dictionaries.RegionItems.TryGetValue(auction.item.pet_species_id, out auction.item.regionItem);
                        sc.Dictionaries.DictionaryPetCache.TryGetValue(auction.item.pet_species_id, out auction.item.cachePet);
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
                        sc.Dictionaries.RegionItems.TryGetValue(auction.item.id, out auction.item.regionItem);
                        sc.Dictionaries.DictionaryItemCache.TryGetValue(auction.item.id, out auction.item.cacheItem);
                        if (auction.item.cacheItem == null || auction.item.regionItem == null)
                        {
                            afc.auctions.RemoveAt(i); ;
                            continue;
                        }
                        auction.item.quality = auction.item.cacheItem.QualityType;
                        auction.item.itemLevel = auction.item.cacheItem.Level;
                        auction.auctionitemName = auction.item.cacheItem.Name;
                    }

                    SearchLogic.ModifyItemLevel(auction);
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
