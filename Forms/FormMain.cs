
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;
using WOWAuctionApi_Net10.Json_Classes;

namespace WOWAuctionApi_Net10
{
    public partial class FormMain : Form
    {
        public FormCache fc = new FormCache();
        public SearchLogic searchLogic = new SearchLogic();
        public TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        AuctionEvent.AuctionRetrievedEventHandler auctionEventDelegate;

        public FormMain()
        {
            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout(true);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tllNewVersion.Alignment = ToolStripItemAlignment.Right;
            tssMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            tllNewVersion.Text = $".Net Version {Environment.Version}   "
                + $"Application Version {Assembly.GetExecutingAssembly().GetName().Version}";
            auctionEventDelegate = new AuctionEvent.AuctionRetrievedEventHandler(AuctionEvent_AuctionRetrieved);
            
            LoadConfig();
            LoadItemLists();
            fc.UIOptions = UserInterfaceOptions.LoadFromFile();
            RenderUIOptionsControls();
            LoadRealms();
            LoadRegionData();
            LoadSearchProfiles();
            LoadItemCache();
            LoadPetCache();
            
            ListItemsPBSView(false);
            fc.Dictionaries.DeepItemData = DeepItemData.Load();

            fc.BlizzAccessToken = API_Blizzard.GetAccessToken(fc.Config.BlizzClientID, fc.Config.BlizzClientSecret);


            lvRealms.SmallImageList = imgStatus;
            lvItems.SmallImageList = imgProfile48;
            lvItems.LargeImageList = imgProfile48;

            toolStripMain.ImageList = imgToolbar48;
            toolStripMain.Renderer = new ToolStripBlankSeparatorRenderer();
            tslSearchOnSelect.Checked = fc.Config.SearchOnSelectDefault.Value;
            tslNewDataOnly.Checked = fc.Config.NewDataOnlyDefault.Value;

            //If OnlyFirst is set, only check the first X realms and uncheck the rest to speed up loading for users who don't care about all realms
            if (fc.Config.OnlyFirst > 0)
            {
                ToggleRealms();
                Application.DoEvents();
                for (int i = 0; i < fc.Config.OnlyFirst; i++)
                {
                    lvRealms.Items[i].Checked = true;
                }
            }

            SetMainPanelsVisible();
            SetAppColorMode();
            SetDisplayMode(DisplayMode.Auctions);

            SetUpChart(chartTotalAuctions, "Top 5 Realms - Total Items On The Auction House", SeriesChartType.Column);
            SetUpChart(chartTopSearches, "Top 10 Realms - Search Hits For This Search", SeriesChartType.Doughnut);
            SetUpChart(chartTotalValue, "Top 5 Realms - Total Region Market Value For This Search", SeriesChartType.Bar);

            if (fc.Config.WowInteraction.Value)
            {
                fc.WowBuyScript = InteractionScript.LoadFromFile("", "wowahbuy");
                tsbTest.Visible = true;
                tsbRefreshWoWProcesses.Visible = true;
                tsbActivate.Visible = true;
                RefreshWowButtons();
            }

            if (fc.Config.UpdateAllDataOnStart.Value)
            {
                UpdateAllData();
            }

            if (fc.Config.RefreshAuctionsOnStart.Value)
            {
                //RefreshAuctionData();
                LoadAuctionData();
            }
        }

        private void SetMainPanelsVisible()
        {
            pnlLists_Main.Visible = true;
            pnlSearch_Main.Visible = true;
            pnlSearch_Class.Visible = true;
            pnlSearch_Quality.Visible = true;
            pnlSearch_MoreOptions.Visible = true;
            pnlSearch_GlobalOptions.Visible = true;
        }

        private void LoadItemLists()
        {
            lvItems.Items.Clear();
            fc.ItemLists = ItemLists.Load();
            fc.ItemLists.Lists = fc.ItemLists.Lists.OrderBy(list => list.Name).ToList();
            foreach (ItemList itemList in fc.ItemLists.Lists)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = itemList.Name;
                lvi.Tag = itemList;
                lvi.ImageIndex = itemList.IconIndex.Value;
                lvItems.Items.Add(lvi);

                if (itemList.Name == fc.CurrentItemList.Name)
                {
                    lvItems.Items[lvi.Index].Focused = true;
                    lvItems.Items[lvi.Index].Selected = true;
                }
            }


            //If we didn't select a current profile and we have at least 1 item in the list, then select the first one
            if ((lvItems.Items.Count > 0) && (lvItems.SelectedItems.Count == 0))
            {
                lvItems.Items[0].Focused = true;
                lvItems.Items[0].Selected = true;
                ItemList currentList = lvItems.Items[0].Tag as ItemList;
                if (currentList != null)
                {
                    fc.CurrentItemList = currentList;
                }
            }
        }

        private void LoadItemList(ItemList itemList)
        {
            fc.CurrentItemList = itemList;
            picCurrentList.Image = imgProfile48.Images[fc.CurrentItemList.IconIndex.Value];
            lblCurrentList.Text = fc.CurrentItemList.Name;
            itemList.ItemCache.Items = itemList.ItemCache.Items.OrderBy(item => item.Name).ToList();
            RenderItemResults(itemList.ItemCache, lvItemsItemsInList);
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListView listView = sender as ListView;   
            if (listView != null)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                    e.Graphics.DrawString(e.Item.Text, listView.Font, new SolidBrush(Color.Blue), e.Bounds.Location);
                }
                else
                {
                    e.Graphics.DrawString(e.Item.Text, listView.Font, new SolidBrush(Color.Blue), e.Bounds.Location);
                }
            }
        }


        private void RenderUIOptionsControls()
        {
            UIHelper.RenderUIOptionsSet(fc.UIOptions.Main, pnlSearch_Main, fc);
            UIHelper.RenderUIOptionsSet(fc.UIOptions.Class, pnlSearch_Class, fc);
            UIHelper.RenderUIOptionsSet(fc.UIOptions.Quality, pnlSearch_Quality, fc);
            UIHelper.RenderUIOptionsSet(fc.UIOptions.Bonuses, pnlSearch_Bonuses, fc);

            Application.DoEvents();
        }

        private void LoadItemCache()
        {
            fc.Dictionaries.DictionaryItemCache.Clear();
            //fc.Caches.ItemCache = ItemCache.Load();
            fc.Caches.ItemCache = ItemCache.LoadWithRegionItems(fc);
            foreach (CacheItem item in fc.Caches.ItemCache.Items)
            {
                fc.Dictionaries.DictionaryItemCache.Add(item.Id, item);
            }
            UpdateCountLabel(tslDataCountItems, fc.Caches.ItemCache.Items.Count);
        }

        private void LoadPetCache()
        {
            fc.Dictionaries.DictionaryPetCache.Clear();
            fc.Caches.PetCache = PetCache.Load();
            foreach (CachePet pet in fc.Caches.PetCache.Pets)
            {
                fc.Dictionaries.DictionaryPetCache.Add(pet.Id.Value, pet);
            }
            UpdateCountLabel(tslDataCountPets, fc.Caches.PetCache.Pets.Count);
        }



        private void LoadSearchProfiles()
        {
            fc.SearchProfiles = SearchProfiles.Load();
            foreach (SearchProfile profile in fc.SearchProfiles.Profiles)
            {
                if (profile.ProfileName == fc.Config.DefaultSearch)
                {
                    tslCurrentProfile.Text = profile.ProfileName;
                    this.SearchProfileToUI(profile);
                }
            }

            RefreshToolbarSearchButtons();
        }

        private void SetAppColorMode()
        {
            tsbThemeDark.Checked = (Application.ColorMode == SystemColorMode.Dark);
            tsbThemeLight.Checked = !(Application.ColorMode == SystemColorMode.Dark);
        }

        private void SetDisplayMode(DisplayMode displayMode)
        {
            bool auctions = (displayMode == DisplayMode.Auctions);
            fc.DisplayMode = displayMode;
            pnlAuctionData.Visible = auctions;
            pnlLists_Items.Visible = !auctions;
            pnlRealms.Visible = auctions;

            pnlSearch_Main_SubOptions.Visible = auctions;
            pnlSearch_MoreOptions_SubOptions.Visible = auctions;
            pnlSearch_GlobalOptions_SubOptions.Visible = auctions;
            pnlSearch_Bonuses.Visible = auctions;
           
            pnlSearch_List_Buttons.Visible = !auctions;
            pnlSearch_List_Options.Visible = auctions;      

            switch (displayMode)
            {
                case DisplayMode.Auctions:
                default:
                    panelRibbon.BackColor = Color.Brown;
                    tssMain.BackColor = Color.Brown;
                    lblSearchMode.Text = "Auctions Mode";
                    lblSearchList.Text = "List Options For This Search";
                    break;

                case DisplayMode.ItemsLists:
                    panelRibbon.BackColor = Color.SteelBlue;
                    tssMain.BackColor = Color.SteelBlue;
                    lblSearchMode.Text = "Lists Mode";
                    lblSearchList.Text = "Managed My Lists";
                    break;
            }
        }

        private void ChangeColorMode(SystemColorMode colorMode)
        {
            AppSettingsHelper.SetColorMode(colorMode);
            Application.Restart();
        }

        private void LoadConfig()
        {
            fc.Config = Config.LoadFromFile(Paths.Config);
        }

        private Color StringToColor(string hexColor)
        {
            return System.Drawing.ColorTranslator.FromHtml(hexColor);
        }

        private void LoadRealms()
        {
            var items = new List<ListViewItem>();
            foreach (var r in fc.Config.Realms)
            {
                // Create ListViewItem with subitems
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.UseItemStyleForSubItems = false;
                lvi.SubItems.Add(r.RealmName);
                lvi.SubItems[1].BackColor = StringToColor(r.BackColor);
                lvi.SubItems[1].ForeColor = Color.White;
                lvi.SubItems.Add("Stale");
                lvi.SubItems[2].BackColor = StringToColor(r.BackColor);
                lvi.SubItems[2].ForeColor = Color.White;
                lvi.SubItems.Add("0");
                lvi.SubItems[3].BackColor = StringToColor(r.BackColor);
                lvi.SubItems[3].ForeColor = Color.White;

                //Realm status
                //0 Blue = live data not loaded
                //1 Red = loading
                //2 Yellow = old data
                //3 Green = new data

                lvi.ImageIndex = 0;
                lvi.Tag = r;
                lvi.Checked = true;

                items.Add(lvi);
            }

            lvRealms.BeginUpdate();
            lvRealms.Items.Clear(); // Clear existing
            lvRealms.Items.AddRange(items.ToArray()); // Add all at once
            lvRealms.EndUpdate();
        }

        private void tsbRefreshAuctionData_Click(object sender, EventArgs e)
        {
            LoadAuctionData();
        }

        private void LoadAuctionData()
        {
            fc.AllRealmsAuctionTotal = 0;

            if (!fc.LivePoll)
            {
                fc.Lists.TotalAuctionsCount.Clear();
            }

            foreach (Realm r in fc.Config.Realms)
            {
                if (RealmChecked(r.RealmId.Value))
                {
                    Thread ProcessAuctionsThread = new Thread(() => ProcessAuctionsForRealm(r,
                        fc.LivePoll, fc.Config.LivePollInterval.Value, fc.CurrentProfile.Threshold.Value));

                    ProcessAuctionsThread.SetApartmentState(ApartmentState.MTA);
                    ProcessAuctionsThread.Start();
                }
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
            auctionEvent.DoAuctionProcess(fc, realm, newDataThreshholdMinutes, livePoll, livePollIntervalSeconds);
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

        private void WriteRegionData()
        {
            Application.DoEvents();
            fc.DataCount.RegionItems.Old = fc.Dictionaries.RegionItems.Count;
            LogProgressMessage("Writing region data to \\tsm\\tsmdata.json");
            string tsmAccessToken = API_TSM.GetAccessToken(fc.Config.TSMKey, fc.Config.TSMClientID);
            API_TSM.WriteRegionTsmItems(tsmAccessToken);
            LoadRegionData();
            fc.DataCount.RegionItems.Total = fc.Dictionaries.RegionItems.Count;
            fc.DataCount.RegionItems.New = fc.DataCount.RegionItems.Total - fc.DataCount.RegionItems.Old;
            LogProgressMessage($"Completed. {fc.DataCount.RegionItems.Total} total region items, {fc.DataCount.RegionItems.New} new.",
                tssProgress.Maximum);
            Application.DoEvents();
            Thread.Sleep(2000);
        }

        private void SetAuctionData(int realmId, AuctionFileContents afc, string lastModified, Realm realm)
        {
            fc.Lists.TotalAuctionsCount.Add(new RealmCount
            {
                RealmId = realm.RealmId.Value,
                RealmName = realm.RealmName,
                Count = afc.auctions.Count
            });
            fc.Dictionaries.RealmAuctions[realmId] = afc;
            int newStatus = 2;

            try
            {
                DateTime lastModifiedDate = DateTime.Parse(lastModified);
                DateTime thresholdDate = DateTime.Now.AddMinutes(-(int.Parse(this.txtSearchThreshold.Text)));

                if (lastModifiedDate > thresholdDate)
                {
                    newStatus = 3;
                }

                SetRealmStatus(realm, newStatus, lastModified, afc.auctions.Count);
                if (fc.LivePoll)
                {
                    if (
                        RealmChecked(realm.RealmId.Value))
                    {
                        var searchResults = searchLogic.DoAuctionSearch(realm);

                        if (searchResults != null)
                        {
                            RenderSearchResults(searchResults, realm, 1);
                            fc.NumRealmsReturned += 1;

                            fc.Lists.RealmSearchCount.Add(new RealmCount
                            {
                                RealmId = realm.RealmId.Value,
                                RealmName = realm.RealmName,
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

        private void SetRealmStatus(Realm realm, int status, string lastModified, int auctionCount)
        {

            lvRealms.SuspendLayout();
            realm.Status = status;
            realm.NumAuctions = auctionCount;
            //r.NumAuctionColor = GetNumAuctionColor(auctionCount);

            foreach (ListViewItem lvi in lvRealms.Items)
            {
                if (lvi.Tag != null)
                {
                    if (((Realm)lvi.Tag).RealmId == realm.RealmId)
                    {
                        //Realm status
                        //0 Blue = live data not loaded
                        //1 Red = loading
                        //2 Yellow = old data
                        //3 Green = new data

                        lvi.ImageIndex = status;

                        if (lastModified != String.Empty)
                        {
                            lvi.SubItems[2].Text = DateTime.Parse(lastModified).ToString("hh:mm:ss");
                            lvi.SubItems[3].Text = auctionCount.ToString("N0");
                        }
                    }
                }

            }
            lvRealms.ResumeLayout();
        }

        private void tsbWriteRegionData_Click(object sender, EventArgs e)
        {
            WriteRegionData();
        }

        private void tsmThemeClassic_Click(object sender, EventArgs e)
        {
            ChangeColorMode(SystemColorMode.Classic);
        }

        private void tsmThemeDark_Click(object sender, EventArgs e)
        {
            ChangeColorMode(SystemColorMode.Dark);
        }

        private void tsmThemeSystem_Click(object sender, EventArgs e)
        {
            ChangeColorMode(SystemColorMode.System);
        }

        private void LoadRegionData()
        {
            fc.Dictionaries.RegionItems.Clear();
            long itemId;

            List<TsmItem> AllRegionItems = API_TSM.GetRegionTsmItemsFromFile();

            foreach (TsmItem item in AllRegionItems)
            {
                if (item.itemId != null)
                {
                    itemId = item.itemId.Value;
                    if (!fc.Dictionaries.RegionItems.ContainsKey(itemId))
                    {
                        fc.Dictionaries.RegionItems.Add(itemId, item);
                    }
                }
                else if (item.petSpeciesId != null)
                {
                    itemId = item.petSpeciesId.Value;
                    if (!fc.Dictionaries.RegionItems.ContainsKey(itemId))
                    {
                        fc.Dictionaries.RegionItems.Add(itemId, item);
                        itemId = item.petSpeciesId.Value;
                    }
                }
            }
            UpdateCountLabel(tslDataCountRegion, fc.Dictionaries.RegionItems.Count);
        }

        private void UpdateCountLabel(Label countLabel, int count)
        {
            countLabel.Visible = true;
            countLabel.Text = count.ToString();
        }

        private void tsmBuildItemCache_Click(object sender, EventArgs e)
        {
            BuildItemCache();
        }

        private void BuildItemCache()
        {
            if (MsgHelper.Confirm.RebuildCache("item"))
            {
                var (newItems, newCache) = ItemCache.BuildItemCache(tssProgress, tllProgress, fc, false);
                fc.Caches.ItemCache = newCache;
                if (fc.Config.SortCacheOnUpdate.Value)
                {
                    SortItemCache(fc.Config.SortCacheOrderDefault.Value);
                }
                UpdateCountLabel(tslDataCountItems, fc.Caches.ItemCache.Items.Count);
            }
        }

        private void SetItemListFromName(string listName)
        {
            fc.CurrentItemList = fc.ItemLists.Lists.Single(list => list.Name == listName);
        }
        private void SearchProfileToUI(SearchProfile sp)
        {
            this.rbSearchRemoveDuplicates.Checked = (sp.SearchFrequency == 0);
            this.rbSearchShowCheapest.Checked = (sp.SearchFrequency == 1);
            this.rbSearchShowAllItems.Checked = (sp.SearchFrequency == 2);

            this.rbSearch_List_DontUse.Checked = (sp.ListOption == 0);
            this.rbSearch_List_AdditionalCriteria.Checked = (sp.ListOption == 1);
            this.rbSearch_List_OnlyByList.Checked = (sp.ListOption == 2);


            SetItemListFromName(sp.ListName);
            this.lblCurrentList.Text = sp.ListName;
            this.picCurrentList.Image = imgProfile48.Images[fc.CurrentItemList.IconIndex.Value];

            this.txtSearchMaxG.Text = sp.SearchMaxG.Value.ToString();
            this.txtSearchMaxItemLevel.Text = sp.MaxItemLevel.Value.ToString();
            this.txtSearchMinItemLevel.Text = sp.MinItemLevel.Value.ToString();
            this.txtSearchMaxCharLevel.Text = sp.MaxCharLevel.Value.ToString();
            this.txtSearchMinCharLevel.Text = sp.MinCharLevel.Value.ToString();
            this.txtSearchMinSellRate.Text = sp.MinSellRate.Value.ToString();
            this.txtSearchPercentage.Text = sp.SearchPercentage.Value.ToString();
            this.txtSearchWorth.Text = sp.WorthAtLeast.Value.ToString();

            this.txtSearchThreshold.Text = sp.Threshold.Value.ToString();
            this.txtSearchStringFilter.Text = sp.StringFilter;

            UIHelper.SetPanelBitwiseValues(this.pnlSearch_Main, sp.MainOptions.Value);
            UIHelper.SetPanelBitwiseValues(this.pnlSearch_Class, sp.Class.Value);
            UIHelper.SetPanelBitwiseValues(this.pnlSearch_Quality, sp.Quality.Value);
            UIHelper.SetPanelBitwiseValues(this.pnlSearch_Bonuses, sp.Bonuses.Value);

            tslCurrentProfile.Text = sp.ProfileName;
            tslCurrentProfile.Image = imgProfile48.Images[sp.IconIndex.Value];
            ButtonProfileDefault(tsbSearchDefault, (fc.Config.DefaultSearch == sp.ProfileName));

            this.rbSearch_Percentage.Checked = (sp.SearchFraction.Value == 0);
            this.rbSearch_MaxG.Checked = (sp.SearchFraction.Value == 1);
            fc.CurrentProfile = sp;
        }

        private void ButtonProfileDefault(ToolStripButton button1, bool makeDefault)
        {
            if (makeDefault)
            {
                button1.ImageIndex = 260;
                button1.ToolTipText = "This profile is the default";
            }
            else
            {
                button1.ImageIndex = 259;
                button1.ToolTipText = "Click to make this the default profile";
            }
        }

        private void UIToSearchProfile(SearchProfile sp)
        {
            if (this.rbSearchRemoveDuplicates.Checked) { sp.SearchFrequency = 0; }
            if (this.rbSearchShowCheapest.Checked) { sp.SearchFrequency = 1; }
            if (this.rbSearchShowAllItems.Checked) { sp.SearchFrequency = 2; }

            if (this.rbSearch_List_DontUse.Checked) { sp.ListOption = 0; }
            if (this.rbSearch_List_AdditionalCriteria.Checked) { sp.ListOption = 1; }
            if (this.rbSearch_List_OnlyByList.Checked) { sp.ListOption = 2; }

            sp.ListName = lblCurrentList.Text;
            sp.SearchMaxG = int.Parse(this.txtSearchMaxG.Text.Trim());
            sp.MaxItemLevel = int.Parse(this.txtSearchMaxItemLevel.Text.Trim());
            sp.MinItemLevel = int.Parse(this.txtSearchMinItemLevel.Text.Trim());
            sp.MaxCharLevel = int.Parse(this.txtSearchMaxCharLevel.Text.Trim());
            sp.MinCharLevel = int.Parse(this.txtSearchMinCharLevel.Text.Trim());
            sp.WorthAtLeast = int.Parse(this.txtSearchWorth.Text.Trim());
            sp.Threshold = int.Parse(this.txtSearchThreshold.Text.Trim());
            sp.StringFilter = this.txtSearchStringFilter.Text.Trim();

            sp.MinSellRate = float.Parse(this.txtSearchMinSellRate.Text);
            sp.SearchPercentage = float.Parse(this.txtSearchPercentage.Text);
            sp.SearchFraction = (rbSearch_Percentage.Checked) ? 0 : 1;

            sp.MainOptions = GetPanelBitwiseValue(this.pnlSearch_Main);
            sp.Class = GetPanelBitwiseValue(this.pnlSearch_Class);
            sp.Quality = GetPanelBitwiseValue(this.pnlSearch_Quality);
            sp.Bonuses = GetPanelBitwiseValue(this.pnlSearch_Bonuses);
        }

        private int GetPanelBitwiseValue(Panel searchPanel)
        {
            var returnValue = 0;

            var checkedBoxes = searchPanel.Controls.OfType<ToggleSlider>().Where(c => c.Checked);

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                returnValue += checkBox.OptionBit;
            }

            return returnValue;
        }

        private void AddNewToolStripButton(int iconIndex, string profileName, tsbType type, int processId = 0, bool buttonChecked = false)
        {
            ToolStripButton newTSB = new ToolStripButton();

            string strippedName = profileName.Replace(" ", "");

            newTSB.Font = new Font("Calibri", 9F);
            newTSB.ForeColor = Color.White;
            newTSB.Size = new Size(64, 64);
            newTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;

            newTSB.TextAlign = ContentAlignment.BottomCenter;
            newTSB.TextImageRelation = TextImageRelation.ImageAboveText;
            newTSB.Image = imgProfile48.Images[iconIndex];
            newTSB.Checked = buttonChecked;

            if (type == tsbType.tsbWowProcess_)
            {
                newTSB.Name = type.ToString() + processId.ToString();
                newTSB.Click += new EventHandler(this.WowButtonClick);
                newTSB.Alignment = ToolStripItemAlignment.Right;
                newTSB.Tag = processId;
                newTSB.ToolTipText = processId.ToString();
            }
            else
            {
                newTSB.Name = type.ToString() + strippedName;
                newTSB.Click += new EventHandler(this.SearchButtonClick);
                newTSB.Alignment = ToolStripItemAlignment.Left;
                newTSB.Tag = processId;
                newTSB.ToolTipText = profileName;
            }

            toolStripMain.Items.Add(newTSB);

        }

        private void LoadToolbarSearchButtons()
        {
            foreach (SearchProfile profile in fc.SearchProfiles.Profiles)
            {
                AddNewToolStripButton(profile.IconIndex.Value, profile.ProfileName, tsbType.tsbSearch_Quick_);
            }
        }

        private void RefreshToolbarSearchButtons()
        {
            ClearToolbarSearchButtons();
            LoadToolbarSearchButtons();
            HighlightCurrentSearch();
        }

        private void HighlightCurrentSearch()
        {
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbSearch_Quick_, null, fc.CurrentProfile.ProfileName);
            tslCurrentProfile.Text = fc.CurrentProfile.ProfileName;
            tslCurrentProfile.Image = imgProfile48.Images[fc.CurrentProfile.IconIndex.Value];
        }

        private void ClearToolbarSearchButtons()
        {
            IterateToolstripButtons(tsbOp.Remove, tsbFrequency.All, tsbType.tsbSearch_Quick_);
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            var button1 = sender as ToolStripButton;
            if (button1 != null)
            {
                var profileName = button1.ToolTipText;
                if (profileName != null)
                {
                    GetSearch(profileName);
                    HighlightCurrentSearch();
                }
            }
            if (tslSearchOnSelect.Checked)
            {
                Search();
            }
        }

        private void WowButtonClick(object sender, EventArgs e)
        {
            var button1 = sender as ToolStripButton;
            if (button1 != null)
            {
                var processId = button1.Tag as int?;
                if (processId != null)
                {
                    fc.CurrentWoWProcess = processId.Value;
                    IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbWowProcess_, processId.Value);
                }
            }
        }

        private void GetSearch(string profileName)
        {
            SearchProfileToUI(fc.SearchProfiles.Profiles.Single(profile => profile.ProfileName == profileName));
        }

        private void tsbSaveSearch_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.OverwriteProfile())
            {
                UIToSearchProfile(fc.CurrentProfile);
                fc.SearchProfiles.Save();
                RefreshToolbarSearchButtons();
            }
        }

        private void tsbSaveSearchAs_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            //If we are copying as, the copy shouldn't be the default as part of this operation
            var (profileName, iconIndex) = GetProfileDetails(0, fc.CurrentProfile.IconIndex.Value,
                fc.CurrentProfile.ProfileName, "Search Profile");
            if (profileName != null && profileName.Trim() != "")
            {
                CopySearch(profileName, iconIndex, false, false);
            }
        }

        private void btnSearch_TogglesOnOff_Click(object sender, EventArgs e)
        {
            UIHelper.ToggleOnOffClick(sender, e);
        }

        private void tsbSearchDefault_Click(object sender, EventArgs e)
        {
            if (fc.CurrentProfile.ProfileName != fc.Config.DefaultSearch)
            {
                if (MsgHelper.Confirm.DefaultProfile())
                {
                    ChangeDefaultProfile(fc.CurrentProfile.ProfileName);
                    ButtonProfileDefault(tsbSearchDefault, true);
                }
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private bool CheckAllRealmsHaveData()
        {
            foreach (ListViewItem listItem in lvRealms.Items)
            {
                if (listItem == null)
                {
                    return false;
                }
                if (listItem.Checked)
                {
                    int numAuctions = int.Parse(listItem.SubItems[3].Text.Replace(",", ""));

                    if (numAuctions == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void SearchInit()
        {
            switch (fc.DisplayMode)
            {
                case DisplayMode.Auctions:
                default:
                    lvAuctions.Items.Clear();
                    fc.Lists.RealmSearchCount.Clear();
                    break;
                case DisplayMode.ItemsLists:

                    break;
            }


            tllProgress.Text = "Progress";
            tssProgress.Value = 0;
            this.UIToSearchProfile(fc.CurrentProfile);


            searchLogic.Options = new SearchOptions();
            searchLogic.Options.Main = UIHelper.GetPanelCheckedList(pnlSearch_Main);
            searchLogic.Options.Class = UIHelper.GetPanelCheckedList(pnlSearch_Class);
            searchLogic.Options.Quality = UIHelper.GetPanelCheckedList(pnlSearch_Quality);
            searchLogic.Options.Bonuses = UIHelper.GetPanelCheckedList(pnlSearch_Bonuses);

            searchLogic.Options.NewDataOnly = this.tslNewDataOnly.Checked;
            searchLogic.Options.LatestXpac = searchLogic.Options.Main.Contains("Latest Xpac");
            searchLogic.Options.IncludeItems = searchLogic.Options.Main.Contains("Include Items");
            searchLogic.Options.IncludePets = searchLogic.Options.Main.Contains("Include Pets");
            searchLogic.Options.HasSockets = searchLogic.Options.Main.Contains("Socket");
            searchLogic.Options.AtoZ = searchLogic.Options.Main.Contains("A to Z");
            searchLogic.Options.UseStringFilter = (txtSearchStringFilter.Text != "");
            searchLogic.Options.StringFilter = txtSearchStringFilter.Text;

            searchLogic.Options.FixedMaxG = (fc.CurrentProfile.SearchMaxG.Value * 10000);
            searchLogic.Options.FixedWorthAtLeast = (fc.CurrentProfile.WorthAtLeast.Value * 10000);
            searchLogic.Options.FixedSearchPercentage = (fc.CurrentProfile.SearchPercentage.Value / 100);

            if (fc.CurrentProfile.ListOption != 0)
            {
                fc.CurrentItemList.ItemCache.FillItemIds();
            }

            searchLogic.fc = fc;
        }

        private void Search()
        {
            SearchInit();

            switch (fc.DisplayMode)
            {
                case DisplayMode.Auctions:
                default:
                    AuctionsSearch();
                    break;

                case DisplayMode.ItemsLists:
                    ItemsSearch();
                    break;
            }
        }

        private void ItemsSearch()
        {
            lvItemsSearchResults.Items.Clear();
            ItemCache searchResults = searchLogic.DoItemSearch(ItemsAsCacheCopy());
            RenderItemResults(searchResults, lvItemsSearchResults);
        }

        private void RenderItemResults(ItemCache itemCache, ListView viewToRender)
        {
            viewToRender.Items.Clear();
            foreach (var item in itemCache.Items)
            {
                ListViewItem lvi = new ListViewItem(item.Id.ToString());
                lvi.UseItemStyleForSubItems = false;
                lvi.SubItems.Add(item.Name);
                lvi.SubItems[1].ForeColor = UIHelper.GetColorForQuality(item.QualityType, fc);

                TsmItem ritem = null;
                try
                {
                    ritem = fc.Dictionaries.RegionItems.First(regionItem => regionItem.Key == item.Id).Value as TsmItem;
                }
                catch { }


                if (ritem != null)
                {
                    long? marketValue = ritem.marketValue;
                    lvi.SubItems.Add(StrHelper.FormatLongN0(marketValue.Value));
                }
                else
                {
                    lvi.SubItems.Add("0");
                }

                if (viewToRender == lvItemsItemsInList)
                {
                    //Buy price 0 on search
                    lvi.SubItems.Add(item.BuyPrice.ToString());
                }
                else
                {
                    lvi.SubItems.Add("0");
                }
                lvi.SubItems.Add(item.Level.ToString());
                lvi.SubItems.Add(item.ClassName);
                lvi.Tag = item;
                viewToRender.Items.Add(lvi);
            }
        }

        private void AuctionsSearch()
        {

            fc.LivePoll = false;
            if (!CheckAllRealmsHaveData())
            {
                MsgHelper.Error.RealmsNotLoaded();
                return;
            }


            int count = 0;

            foreach (Realm realm in fc.Config.Realms)
            {
                if (RealmChecked(realm.RealmId.Value))
                {
                    if (searchLogic.Options.NewDataOnly == true
                        && realm.Status != 2) { continue; }

                    var searchResults = searchLogic.DoAuctionSearch(realm);

                    if (searchResults != null)
                    {
                        RenderSearchResults(searchResults, realm, count);
                        fc.AllRealmsAuctionTotal += searchResults.Count;
                        fc.Lists.RealmSearchCount.Add(new RealmCount
                        {
                            RealmId = realm.RealmId.Value,
                            RealmName = realm.RealmName,
                            Count = searchResults.Count,
                            TotalValue = searchResults.Sum(r => r.RegionMarket)
                        });
                    }
                    count++;
                }
            }
            RenderPieCharts();

        }

        private void SetUpChart(Chart chart1, String title, SeriesChartType chartType = SeriesChartType.Pie)
        {

            Color mainText;
            if (fc.UIOptions.ColorMode == SystemColorMode.Dark)
            {
                mainText = Color.White;
            }
            else
            {
                mainText = Color.Black;
            }
            chart1.Titles.Add(title);
            chart1.Titles[0].ForeColor = mainText;
            chart1.Titles[0].Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular);
            chart1.Titles[0].Docking = Docking.Top;


            chart1.Series.Clear();
            chart1.Legends.Clear();

            Series taSeries = new Series();
            taSeries.Name = "Series 1";
            taSeries.IsXValueIndexed = true;
            taSeries.ChartType = chartType;
            taSeries.IsValueShownAsLabel = true;
            taSeries.LabelForeColor = mainText;
            taSeries.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular);


            if (chartType == SeriesChartType.Doughnut)
            {
                chart1.Legends.Add("");
                chart1.Legends[0].Alignment = StringAlignment.Near;
                chart1.Legends[0].Docking = Docking.Right;
                chart1.Legends[0].BackColor = Color.Transparent;
                chart1.Legends[0].ForeColor = mainText;
                chart1.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular);
            }
            else if (chartType == SeriesChartType.Bar)
            {
                taSeries.Color = Color.IndianRed;
            }
            else
            {
                taSeries.Color = Color.CornflowerBlue;
            }

            chart1.Series.Add(taSeries);
            chart1.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.BorderSkin.BackColor = Color.Transparent;
            chart1.ChartAreas[0].BorderColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = mainText;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = mainText;
            chart1.Visible = false;
        }

        private void RenderPieCharts()
        {
            //Render Top X Total Value
            RenderChart(fc.Lists.RealmSearchCount, 5, chartTotalValue);

            //Render Top 10 Search Hit Realms
            RenderChart(fc.Lists.RealmSearchCount, 10, chartTopSearches);

            //Render Top 5 Total Auctions
            RenderChart(fc.Lists.TotalAuctionsCount, 5, chartTotalAuctions);
        }

        private void RenderChart(List<RealmCount> originalList, int realmCount, Chart chartToRender)
        {
            chartToRender.Visible = true;
            chartToRender.Series[0].Points.Clear();
            List<RealmCount> sortedList;

            if (chartToRender.Name == "chartTotalValue")
            {
                sortedList = originalList
                    .OrderByDescending(p => p.TotalValue)
                    .Take(realmCount)
                    .ToList();
                int count = 0;
                foreach (var realmInfo in sortedList)
                {
                    count++;
                    if (count > realmCount) { break; }
                    chartToRender.Series[0].Points.AddXY(realmInfo.RealmName, realmInfo.TotalValue / 10000);
                }
            }
            else
            {
                sortedList = originalList
                    .OrderByDescending(p => p.Count)
                    .Take(realmCount)
                    .ToList();
                int count = 0;
                foreach (var realmInfo in sortedList)
                {
                    count++;
                    if (count > realmCount) { break; }
                    chartToRender.Series[0].Points.AddXY(realmInfo.RealmName, realmInfo.Count);
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

                // if (result.ItemId == 244497)
                // {
                //     MessageBox.Show(String.Join(", ", result.OriginalAuction.item.bonus_lists.Select(n => n.ToString())));
                // }

                ListViewItem lvi = new ListViewItem();
                lvi.UseItemStyleForSubItems = false;
                lvi.Text = " ";
                lvi.BackColor = StringToColor(realm.BackColor);
                lvi.Tag = result;
                toolTip = $"{result.ItemId.ToString()}, {StrHelper.FormatLongN0(result.Buyout)}"
                    + $", ItemLevel = ({result.Level.ToString()}) {result.Modifiers} {result.BonusLists}";
                lvi.ToolTipText = toolTip;
                //this.txtDebug.Text += toolTip + "\r\n";

                if (result.Suffix != String.Empty)
                {
                    lvi.SubItems.Add(result.ItemName + " " + result.Suffix);
                }
                else
                {
                    lvi.SubItems.Add(result.ItemName);
                }

                lvi.SubItems[1].ForeColor = UIHelper.GetColorForQuality(result.Quality, fc);

                lvi.SubItems.Add(result.Level.ToString());

                //Color code sale rate
                lvi.SubItems.Add(result.SaleRate.ToString());
                lvi.SubItems[3].ForeColor = GetColorForSellRate(result.SaleRate);

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
                    lvi.SubItems[7].ForeColor = UIHelper.GetColorForQuality(result.Quality, fc);
                }

                lvi.SubItems.Add(LXItem(result.ItemId));
                lvAuctions.Items.Add(lvi);
            }
            lvAuctions.ResumeLayout();
        }

        private string LXItem(long itemid)
        {
            if (itemid > fc.Config.LatestXpacItemId)
            {
                return "Y";
            }
            else
            {
                return " ";
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
            lvi2.BackColor = StringToColor(realm.BackColor);
            lvi2.ForeColor = Color.White;
            lvi2.SubItems.Add(realm.RealmName);
            lvAuctions.Items.Add(lvi2);
        }

        private Color GetColorForSellRate(float sellRate)
        {
            switch (fc.UIOptions.ColorMode)
            {
                case SystemColorMode.Classic:
                    if (sellRate < 0.001) { return Color.DimGray; }
                    else if (sellRate < 0.002) { return Color.DarkRed; }
                    else if (sellRate < 0.010) { return Color.DarkGoldenrod; }
                    else if (sellRate < 0.100) { return Color.MediumBlue; }
                    else { return Color.Green; }
                        ;
                case SystemColorMode.Dark:
                default:
                    if (sellRate < 0.001) { return Color.LightGray; }
                    else if (sellRate < 0.002) { return Color.Red; }
                    else if (sellRate < 0.010) { return Color.Orange; }
                    else if (sellRate < 0.100) { return Color.LightBlue; }
                    else { return Color.LimeGreen; }
                        ;

            }
        }

        private void btnToggleRealms_Click(object sender, EventArgs e)
        {
            ToggleRealms();
        }

        private void ToggleRealms()
        {
            bool newValue = !lvRealms.Items[0].Checked;
            lvRealms.Items.Cast<ListViewItem>().ToList().ForEach(item => item.Checked = newValue);
        }

        private bool RealmChecked(int realmId)
        {
            return (lvRealms.Items
                .Cast<ListViewItem>() // Cast the ListViewItemCollection to IEnumerable<ListViewItem>
                .FirstOrDefault(item =>
                    item.Tag is Realm tagInfo &&
                    tagInfo.RealmId == realmId)).Checked;
        }

        private void tsbThemeLight_Click(object sender, EventArgs e)
        {
            if (Application.ColorMode == SystemColorMode.Dark)
            {
                ChangeColorMode(SystemColorMode.Classic);
            }
        }

        private void tsbThemeDark_Click(object sender, EventArgs e)
        {
            if (Application.ColorMode == SystemColorMode.Classic)
            {
                ChangeColorMode(SystemColorMode.Dark);
            }
        }

        private void tsmBuildPetCache_Click(object sender, EventArgs e)
        {
            BuildPetCache();
        }

        private void BuildPetCache()
        {
            if (MsgHelper.Confirm.RebuildCache("pet"))
            {
                var (newPets, newCache) = PetCache.BuildPetCache(tssProgress, tllProgress, fc, false);
                fc.Caches.PetCache = newCache;
                if (fc.Config.SortCacheOnUpdate.Value)
                {
                    SortPetCache(fc.Config.SortCacheOrderDefault.Value);
                }
                UpdateCountLabel(tslDataCountPets, fc.Caches.PetCache.Pets.Count);
            }
        }

        private void tsmUpdateItemCache_Click(object sender, EventArgs e)
        {
            UpdateItemCache();
        }

        private void UpdateItemCache()
        {
            var (newItems, newCache) = ItemCache.BuildItemCache(tssProgress, tllProgress, fc, true);
            fc.Caches.ItemCache = newCache;
            UpdateCountLabel(tslDataCountItems, fc.Caches.ItemCache.Items.Count);
            fc.DataCount.ItemCache.Total = fc.Caches.ItemCache.Items.Count;
            fc.DataCount.ItemCache.New = newItems;
            LogProgressMessage($"Completed. {fc.DataCount.ItemCache.New} new items. {fc.DataCount.ItemCache.Total} total items in cache.");
            if (fc.Config.SortCacheOnUpdate.Value)
            {
                SortItemCache(fc.Config.SortCacheOrderDefault.Value);
            }
            Thread.Sleep(2000);
        }

        private void tsmUpdatePetCache_Click(object sender, EventArgs e)
        {
            UpdatePetCache();
        }

        private void UpdatePetCache()
        {
            var (newPets, newCache) = PetCache.BuildPetCache(tssProgress, tllProgress, fc, true);
            fc.Caches.PetCache = newCache;
            UpdateCountLabel(tslDataCountPets, fc.Caches.PetCache.Pets.Count);
            fc.DataCount.PetCache.Total = fc.Caches.PetCache.Pets.Count;
            fc.DataCount.PetCache.New = newPets;
            LogProgressMessage($"Completed. {fc.DataCount.PetCache.New} new pets. {fc.DataCount.PetCache.Total} total pets in cache.");
            if (fc.Config.SortCacheOnUpdate.Value)
            {
                SortPetCache(fc.Config.SortCacheOrderDefault.Value);
            }
            Thread.Sleep(2000);
        }

        private void lvAuctions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.ToUpper(e.KeyChar) == (char)Keys.C)
            {
                CopyItemToClipboard();
            }

            if (fc.Config.WowInteraction.Value)
            {
                if (char.ToUpper(e.KeyChar) == (char)Keys.Z)
                {
                    CopyItemToClipboard();
                    fc.WowBuyScript.ProcessScript();
                }
            }
        }

        private void lvAuctions_DoubleClick(object sender, EventArgs e)
        {
            CopyItemToClipboard();
        }


        private void CopyItemToClipboard()
        {
            Clipboard.SetText(lvAuctions.SelectedItems[0].SubItems[1].Text);
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {
            fc.Dictionaries.DeepItemData = DeepItemData.Load();

            DeepItemDataBonus itemBonus = DeepItemData.GetDataForBonus(txtSearchStringFilter.Text, fc.Dictionaries.DeepItemData);
            MessageBox.Show(itemBonus.default_level.ToString());
        }

        private void RefreshWowButtons()
        {
            ClearWoWButtons();
            LoadWowButtons();
        }

        private void LoadWowButtons()
        {
            bool buttonChecked = false;
            int count = 0;
            int foundProcess = 0;
            Process[] wowProcesses = ProcHelper.GetWowProcesses();
            foreach (Process pr in ProcHelper.GetWowProcesses())
            {
                AddNewToolStripButton(0, "", tsbType.tsbWowProcess_, pr.Id);
                if (pr.Id == fc.CurrentWoWProcess)
                {
                    foundProcess = pr.Id;
                }
            }
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbWowProcess_, foundProcess, null, true);
        }

        private enum tsbOp
        {
            Check,
            Remove
        }

        private enum tsbFrequency
        {
            All,
            Single
        }

        private enum tsbType
        {
            tsbSearch_Quick_,
            tsbWowProcess_
        }

        private void IterateToolstripButtons(
            tsbOp operation,
            tsbFrequency frequency,
            tsbType type,
            int? intid = null,
            string? stringId = null,
            bool firstIfNoneFound = false)
        {
            List<ToolStripButton> relevantButtons = new List<ToolStripButton>();
            bool found = false;
            bool match = false;
            for (int i = toolStripMain.Items.Count - 1; i >= 0; i--)
            {
                ToolStripItem item = toolStripMain.Items[i];
                // Check if the item is a ToolStripButton and matches the name pattern
                if ((item is ToolStripButton button) && (item.Name.Contains(type.ToString())))
                {
                    var stripButton = item as ToolStripButton;
                    relevantButtons.Add(stripButton);
                    if (stripButton != null)
                    {
                        match = true;
                        if (frequency == tsbFrequency.Single)
                        {
                            if (intid != null && stripButton.Tag is int buttonIntId && buttonIntId == intid)
                            {
                                found = true;
                            }
                            else if (stringId != null && stripButton.ToolTipText == stringId)
                            {
                                found = true;
                            }
                            else
                            {
                                match = false;
                            }
                        }

                        switch (operation)
                        {
                            case tsbOp.Check:
                                stripButton.Checked = match;
                                if (type == tsbType.tsbWowProcess_)
                                {
                                    fc.CurrentWoWProcess = (int)stripButton.Tag;
                                }
                                break;
                            case tsbOp.Remove:
                                if ((frequency == tsbFrequency.Single && match) || frequency == tsbFrequency.All)
                                {
                                    toolStripMain.Items.Remove(button);
                                }
                                break;
                        }
                    }
                }
            }

            if (frequency == tsbFrequency.Single && !found && firstIfNoneFound && relevantButtons.Count > 0)
            {
                switch (operation)
                {
                    case tsbOp.Check:
                        relevantButtons[0].Checked = true;
                        if (type == tsbType.tsbWowProcess_)
                        {
                            fc.CurrentWoWProcess = (int)relevantButtons[0].Tag;
                        }
                        break;
                    case tsbOp.Remove:
                        toolStripMain.Items.Remove(relevantButtons[0]);
                        break;
                }
            }
        }

        private void ClearWoWButtons()
        {
            IterateToolstripButtons(tsbOp.Remove, tsbFrequency.All, tsbType.tsbWowProcess_);
        }

        private void tsbActivate_Click(object sender, EventArgs e)
        {
            ProcHelper.ActivateApp(fc.CurrentWoWProcess);
        }

        private void tsbRefreshWoWProcesses_Click(object sender, EventArgs e)
        {
            this.RefreshWowButtons();
        }

        private void tsbRenameSearch_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            //If we are renaming this search, and it is currently the default, it should stay the default
            bool newSearchIsDefault = (fc.CurrentProfile.ProfileName == fc.Config.DefaultSearch);
            var (profileName, iconIndex) = GetProfileDetails(1, fc.CurrentProfile.IconIndex.Value,
                fc.CurrentProfile.ProfileName, "Search Profile");

            if (profileName != null && profileName.Trim() != "")
            {
                fc.CurrentProfile.ProfileName = profileName;
                fc.CurrentProfile.IconIndex = iconIndex;
                fc.SearchProfiles.Save();
                RefreshToolbarSearchButtons();
            }
        }

        private SearchProfile GetCopyOfDefault()
        {
            SearchProfile profile = fc.SearchProfiles.Profiles.Single(profile => profile.ProfileName == "[Default]");
            return profile.ShallowCopy();
        }

        private void tsbNewSearch_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = GetProfileDetails(2, 0, "", "Search Profile");
            if (profileName != null && profileName.Trim() != "")
            {
                SearchProfile newProfile = GetCopyOfDefault();
                newProfile.ProfileName = profileName;
                newProfile.IconIndex = iconIndex;
                fc.SearchProfiles.Profiles.Add(newProfile);
                fc.CurrentProfile = newProfile;
                fc.SearchProfiles.Save();
                RefreshToolbarSearchButtons();
                SearchProfileToUI(newProfile);
            }
        }

        private void ChangeDefaultProfile(string newName)
        {
            fc.Config.DefaultSearch = newName;
            fc.Config.Save();
        }

        private void CopySearch(string newName, int newIndex, bool deleteOriginal, bool newSearchIsDefault)
        {

            //If we are deleting the original then if it was the default, the renamed profile should be the default
            if (deleteOriginal)
            {
                DeleteSearchProfile(fc.CurrentProfile);
            }
            if (newSearchIsDefault)
            {
                ChangeDefaultProfile(newName);
            }
            GlobalSearchStuff(newName, newIndex);

            /*
            SearchProfile sp = new SearchProfile();
            UIToSearchProfile(sp);
            sp.ProfileName = newName;
            sp.IconIndex = newIndex;
            sp.IsDefault = false;
            sp.Save();

            RefreshToolbarSearchButtons();
            cache.CurrentProfile = sp;
            SearchProfileToUI(sp);
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbSearch_Quick_, null, newName);
            */

        }

        private void GlobalSearchStuff(string newName, int newIndex)
        {
            SearchProfile sp = new SearchProfile();
            UIToSearchProfile(sp);
            sp.ProfileName = newName;
            sp.IconIndex = newIndex;
            fc.SearchProfiles.Save();

            LoadSearchProfiles();
            fc.CurrentProfile = sp;
            SearchProfileToUI(sp);
            tslCurrentProfile.Text = fc.CurrentProfile.ProfileName;
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbSearch_Quick_, null, newName);
        }


        private (string profileName, int iconIndex) GetProfileDetails(
            int searchType, int startingIndex, string startingProfileName, string itemTitle)
        {
            string title;

            switch (searchType)
            {
                case 0: default: title = "Save Current {itemTitle} As"; break;
                case 1: title = $"Rename Current {itemTitle}"; break;
                case 2: title = $"New {itemTitle}"; break;
            }

            FormSaveProfileDialog saveDlg = new FormSaveProfileDialog(title,
                startingProfileName, searchType, startingIndex, this.imgProfile48);
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                return (saveDlg.ProfileName, saveDlg.ImageIndex);
            }

            return ("", 0);
        }

        private bool CheckIfDefaultProfileForDelete()
        {
            if (fc.CurrentProfile.ProfileName == "[Default]")
            {
                MsgHelper.Error.CannotDeleteDefault();
                return true;
            }
            return false;
        }

        private void DeleteSearchProfile(SearchProfile profile)
        {
                fc.SearchProfiles.Profiles.Remove(profile);
        }

        private void tsbDeleteSearch_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            if (MsgHelper.Confirm.DeleteProfile())
            {
                //If this was the default profile we need to make the [Default] the default profile
                if (fc.CurrentProfile.ProfileName == fc.Config.DefaultSearch)
                {
                    ChangeDefaultProfile("[Default]");
                }

                DeleteSearchProfile(fc.CurrentProfile);
                LoadSearchProfiles();
            }
        }

        private void tsmSortItemCacheAsc_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.SortCache("item", "ascending")) { SortItemCache(SortDirection.Ascending); }
        }

        private void tsmSortItemCacheDesc_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.SortCache("item", "descending")) { SortItemCache(SortDirection.Descending); }
        }

        private void tsmSortPetCacheAsc_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.SortCache("pet", "ascending")) { SortPetCache(SortDirection.Ascending); }
        }

        private void tsmSortPetCacheDesc_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.SortCache("pet", "descending")) { SortPetCache(SortDirection.Descending); }
        }

        private void SortItemCache(SortDirection direction = SortDirection.Ascending)
        {
            fc.Caches.ItemCache.SortAndSave(direction);
        }
        private void SortPetCache(SortDirection direction = SortDirection.Ascending)
        {
            fc.Caches.PetCache.SortAndSave(direction);
        }
        private void tsbUpdateAllData_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.UpdateAllData())
            {
                UpdateAllData();
            }
        }

        private void UpdateAllData()
        {
            fc.DataCount = new DataCount();
            Application.DoEvents();
            WriteRegionData();
            Application.DoEvents();
            UpdateItemCache();
            Application.DoEvents();
            UpdatePetCache();
            Application.DoEvents();
            LogProgressMessage(
                $"Region Items {fc.DataCount.RegionItems.New} new ({fc.DataCount.RegionItems.Total}). " +
                $"Item Cache {fc.DataCount.ItemCache.New} new ({fc.DataCount.ItemCache.Total}). " +
                $"Pet Cache {fc.DataCount.PetCache.New} new ({fc.DataCount.PetCache.Total}). "
                );
        }

        private void LogProgressMessage(string message = "", int progressCount = -1)
        {
            Application.DoEvents();
            if (message != "")
            {
                this.tllProgress.Text = message;
            }
            if (progressCount > -1)
            {
                this.tssProgress.Value = progressCount;
            }
        }

        private void tsbLivePoll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature disabled at the moment due to stability issues. Sorry!");
            //DoLivePoll();
        }

        private void DoLivePoll()
        {
            fc.LivePoll = true;
            SearchInit();
            LoadAuctionData();
        }

        private void tslModeAuctions_Click(object sender, EventArgs e)
        {
            SetDisplayMode(DisplayMode.Auctions);
        }

        private void tslModeLists_Click(object sender, EventArgs e)
        {
            SetDisplayMode(DisplayMode.ItemsLists);
        }

        private void lvItemsItemsInList_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the dragged items
            List<ListViewItem> draggedItems = (List<ListViewItem>)e.Data.GetData(typeof(List<ListViewItem>));

            // Get the destination ListView control
            ListView destinationListView = (ListView)sender;

            // You might need to capture the source ListView reference during the ItemDrag event
            // for correct removal. A common way is to store a reference or retrieve it from the 
            // original sender of the DoDragDrop call (e.g., via a private field).

            // Add items to the destination ListView
            foreach (ListViewItem item in draggedItems)
            {
                // ListViewItem can only belong to one ListView. You must clone or move it.
                // To *move* it, remove from source first (handled below). To *copy*, clone it.
                // The code below implements a MOVE operation.

                // First, ensure the item is not already in the destination list
                if (!destinationListView.Items.Contains(item))
                {
                    // Remove from the original source ListView (assuming you have a reference to it)
                    // If you are using a move operation, the source list needs to be updated.
                    // A common pattern is to identify the source ListView via an intermediary variable 
                    // or ensure both listviews are accessible in scope.

                    // A simple approach if they are on the same Form:
                    if (item.ListView != null)
                    {
                        item.ListView.Items.Remove(item); // Remove from old parent
                    }

                    destinationListView.Items.Add(item); // Add to new parent
                    SaveItems();
                }
            }
        }

        private void lvItemsItemsInList_ItemDrag(object sender, ItemDragEventArgs e)
        {

        }

        private void lvItemsSearchResults_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Create a list to hold all selected items
            List<ListViewItem> itemsToDrag = new List<ListViewItem>();

            // Add the item that initiated the drag
            itemsToDrag.Add((ListViewItem)e.Item);

            // Optionally, add any other selected items not already added
            foreach (ListViewItem selectedItem in lvItemsSearchResults.SelectedItems)
            {
                if (!itemsToDrag.Contains(selectedItem))
                {
                    itemsToDrag.Add(selectedItem);
                }
            }

            // Pass the collection of items to the DoDragDrop method
            // Use DragDropEffects.Move or DragDropEffects.Copy as desired
            lvItemsSearchResults.DoDragDrop(itemsToDrag, DragDropEffects.Move);
        }

        private void lvItemsItemsInList_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a List<ListViewItem>
            if (e.Data.GetDataPresent(typeof(List<ListViewItem>)))
            {
                e.Effect = DragDropEffects.Move; // Indicate a move operation is allowed
            }
            else
            {
                e.Effect = DragDropEffects.None; // Deny the drop operation
            }
        }

        private void btnItemListSave_Click(object sender, EventArgs e)
        {
            SaveItems();
        }

        private void SaveItems()
        {
            fc.CurrentItemList.ItemCache.Items.Clear();

            foreach (ListViewItem lvi in lvItemsItemsInList.Items)
            {
                CacheItem item = lvi.Tag as CacheItem;
                if (item != null)
                {
                    fc.CurrentItemList.ItemCache.AddItem(item);
                }
            }
            fc.ItemLists.Save();
        }

        private ItemCache ItemsAsCacheCopy()
        {
            ItemCache copyCache = new ItemCache();

            foreach (ListViewItem lvi in lvItemsItemsInList.Items)
            {
                CacheItem item = lvi.Tag as CacheItem;
                if (item != null)
                {
                    copyCache.AddItem(item);
                }
            }

            return copyCache;
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                ItemList list = lvItems.SelectedItems[0].Tag as ItemList;
                if (list != null)
                {
                    LoadItemList(list);
                }
            }
        }

        private void btnItemListEdit_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = GetProfileDetails(1, fc.CurrentItemList.IconIndex.Value,
                    fc.CurrentItemList.Name, "Item List");
            if (profileName != null && profileName.Trim() != "")
            {
                fc.CurrentItemList.Name = profileName;
                fc.CurrentItemList.IconIndex = iconIndex;
                fc.ItemLists.Save();
                LoadItemLists();
            }
        }

        private void btnItemListSaveAs_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = GetProfileDetails(0, fc.CurrentItemList.IconIndex.Value,
                fc.CurrentItemList.Name + "@ (Copy)", "Item List");
            if (profileName != null && profileName.Trim() != "")
            {
                ItemList newList = new ItemList();

                newList.Name = profileName;
                newList.IconIndex = iconIndex;
                newList.ItemCache = new ItemCache();
                foreach (CacheItem item in fc.CurrentItemList.ItemCache.Items)
                {
                    newList.ItemCache.AddItem(item);
                }
                fc.ItemLists.AddList(newList);
                fc.CurrentItemList = newList;
                fc.ItemLists.Save();
                LoadItemLists();
            }
        }

        private void btnItemListNew_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = GetProfileDetails(2, 0, "(New List)", "Item List");
            if (profileName != null && profileName.Trim() != "")
            {
                ItemList newList = new ItemList();

                newList.Name = profileName;
                newList.IconIndex = iconIndex;
                fc.ItemLists.AddList(newList);
                fc.CurrentItemList = newList;
                fc.ItemLists.Save();
                LoadItemLists();
            }
        }

        private void btnItemListDelete_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.DeleteItemList())
            {
                fc.ItemLists.Lists.Remove(fc.CurrentItemList);
                fc.ItemLists.Save();
                LoadItemLists();
            }
        }

        private void lvItemsItemsInList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                // Ensure the event isn't handled by default ListView logic if needed
                // e.Handled = true; 

                // Iterate through all selected items and remove them
                foreach (ListViewItem selectedItem in lvItemsItemsInList.SelectedItems)
                {
                    lvItemsItemsInList.Items.Remove(selectedItem);
                }
                SaveItems();
            }
        }

        private void btnItemListSearchView_Click(object sender, EventArgs e)
        {
            ListItemsPBSView(false);
        }

        private void btnItemsListPBSView_Click(object sender, EventArgs e)
        {
            ListItemsPBSView(true);
        }

        private void ListItemsPBSView(bool pbs)
        {
            lblItemsSearchLabel.Visible = !pbs;
            pnlItemsSearchPBS.Visible = pbs;
            lvItemsSearchResults.Visible = !pbs;
        }

        private void btnItemsSearchCopyExport_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtItemsSearchPBSExport.Text);
        }

        private void btnItemsExportToPBS_Click(object sender, EventArgs e)
        {
            ListItemsPBSView(true);
            txtItemsSearchPBSExport.Text = fc.CurrentItemList.Name;
            txtItemsSearchPBSKeys.Text = "";

            foreach (ListViewItem lvi in lvItemsItemsInList.Items)
            {
                CacheItem item = lvi.Tag as CacheItem;
                if (item != null)
                {
                    txtItemsSearchPBSExport.Text += $"^\"{item.Name}\";;0;0;0;0;0;0;0;{item.BuyPrice};;";
                    txtItemsSearchPBSKeys.Text += $"\"{item.Id} 0 1 0\",\r\n";
                }
            }
        }

        private void btnItemListPBSUpdateSelected_Click(object sender, EventArgs e)
        {
            UpdateBuyPrice(BuyPriceSelectType.Selected);
        }

        private void UpdateBuyPrice(BuyPriceSelectType updateType)
        {
            int buyPriceValue = int.Parse(txtItemsSearchPBSValue.Text);
            txtItemsSearchPBSValue.Text = buyPriceValue.ToString();

            if (updateType == BuyPriceSelectType.Selected)
            {
                foreach (ListViewItem lvi in lvItemsItemsInList.SelectedItems)
                {
                    UpdateBuyPriceListItem(lvi, buyPriceValue);
                }
            }
            else
            {
                foreach (ListViewItem lvi in lvItemsItemsInList.Items)
                {
                    if ((updateType == BuyPriceSelectType.ZeroValue) && (!(lvi.SubItems[3].Text == "0")))
                    {
                        continue;
                    }
                    UpdateBuyPriceListItem(lvi, buyPriceValue);
                }
            }

        }

        private void UpdateBuyPriceListItem(ListViewItem lvi, int pbsValue)
        {
            CacheItem cacheItem = lvi.Tag as CacheItem;
            if (cacheItem != null)
            {
                lvi.SubItems[3].Text = pbsValue.ToString();
                cacheItem.BuyPrice = pbsValue;
                SaveItems();
            }
        }

        private void btnItemListPBSUpdateAll_Click(object sender, EventArgs e)
        {
            UpdateBuyPrice(BuyPriceSelectType.All);
        }

        private void btnItemListPBSUpdateZeroValue_Click(object sender, EventArgs e)
        {
            UpdateBuyPrice(BuyPriceSelectType.ZeroValue);
        }

        private void btnsbtnItemsSearchCopyKeys_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtItemsSearchPBSKeys.Text);
        }

        private void btnRefreshAuctionsTotal_Click(object sender, EventArgs e)
        {

        }

        public enum BuyPriceSelectType
        {
            Selected,
            All,
            ZeroValue
        }
    }
}
