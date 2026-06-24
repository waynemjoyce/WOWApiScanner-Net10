
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms.DataVisualization.Charting;
using WOWAuctionApi_Net10.Forms;
using WOWAuctionApi_Net10.Json_Classes;
using static System.Windows.Forms.Design.AxImporter;
using static WOWAuctionApi_Net10.UserInterfaceOptions;

namespace WOWAuctionApi_Net10
{
    public partial class FormMain : Form
    {
        public TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        public GlobalKeyboardHook gkh;

        AuctionEvent.AuctionRetrievedEventHandler auctionEventDelegate;

        public FormMain()
        {
            this.DoubleBuffered = true;
            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout(true);
        }

        private void PopulateGKHList()
        {
            List<string> fileNames = Directory.EnumerateFiles($"{sc.Paths.InteractionScripts}/gkh")
                                  .Select(Path.GetFileNameWithoutExtension)
                                  .ToList();
            this.tscGKHList.Items.Clear();
            foreach (string gkhFile in fileNames)
            {
                tscGKHList.Items.Add(gkhFile);
            }
            if (tscGKHList.Items.Count > 0)
            {
                tscGKHList.SelectedIndex = 0;
            }
        }

        private void gkh_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void gkh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.tsbAllowGKH.Checked)
            {
                //Power keys scripts must start PK - this is to avoid accidentally running a main looping
                //script since this is NOT in its own thread and we can't terminate it with ALT+c
                string fileName = $@"{sc.Paths.InteractionScripts}gkh\{tscGKHList.SelectedItem}.json";      
                InteractionScript gkhAction = InteractionScript.LoadFromFile(fileName);
                gkhAction.ProcessScript();
            }

            e.Handled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tllNewVersion.Alignment = ToolStripItemAlignment.Right;
            tssMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            tllNewVersion.Text = $".Net Version {Environment.Version}   "
                + $"Application Version {Assembly.GetExecutingAssembly().GetName().Version}";

            SetupOptionsPanels();
            sc.UIOptions = UserInterfaceOptions.LoadFromFile();
            LoadConfig();
            itemListOptions1.LoadItemLists();
            RenderUIOptionsControls();
            LoadSearchProfiles();
            realmOptions1.LoadRealms();
            LoadRegionData();
            LoadItemCache();
            LoadPetCache();
            PopulateGKHList();

            sc.Dictionaries.CrypticBonuses = CrypticBonuses.Load();
            sc.ItemData = ItemData.Load();
            sc.BlizzAccessToken = API_Blizzard.GetAccessToken(sc.Config.BlizzClientID, sc.Config.BlizzClientSecret);

            realmOptions1.SmallImageList = imgStatus;

            toolStripMain.ImageList = imgToolbar48;
            toolStripMain.Renderer = new ToolStripBlankSeparatorRenderer();
            globalOptions1.SearchOnSelect = sc.Config.SearchOnSelectDefault;
            globalOptions1.NewDataOnly = sc.Config.NewDataOnlyDefault;

            realmOptions1.CheckOnlyFirst();

            SetMainPanelsVisible();
            SetAppColorMode();
            SetDisplayMode(DisplayMode.Auctions);

            auctionsView1.InitAuctionsView(realmOptions1, globalOptions1);

            charts1.SetUpCharts();

            if (sc.Config.WowInteraction)
            {
                sc.WowBuyScript = InteractionScript.LoadFromFile("", "wowahbuy");
                tsbTest.Visible = true;
                tsbRefreshWoWProcesses.Visible = true;
                tsbActivate.Visible = true;
                tsbWoWInteraction.Visible = true;
                RefreshWowButtons();
            }

            if (sc.Config.UpdateAllDataOnStart)
            {
                UpdateAllData();
            }

            if (sc.Config.RefreshAuctionsOnStart)
            {
                auctionsView1.LoadAuctionData();
            }
        }

        private void SetupOptionsPanels()
        {
            itemListOptions1.ProfileImageList = imgProfile48;
        }

        private void SetMainPanelsVisible()
        {
            mainOptions1.Visible = true;
            itemClassOptions1.Visible = true;
            qualityOptions1.Visible = true;
            bonusOptions1.Visible = true;
            moreOptions1.Visible = true;
            globalOptions1.Visible = true;
            realmOptions1.Visible = true;
            itemListOptions1.Visible = true;
            charts1.Visible = true;
            auctionsView1.Visible = true;
        }

        private void LoadItemList(ItemList itemList)
        {
            sc.CurrentItemList = itemList;
            itemList.ItemCache.Items = itemList.ItemCache.Items.OrderBy(item => item.Name).ToList();
            RenderItemResults(itemList.ItemCache, lvItemsItemsInList);
            pbsExport1.ItemListToPBS(lvItemsItemsInList);
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
            UIHelper.RenderUIOptionsSet(sc.UIOptions.OptionSets.Single(set => set.SetName == "Main"), mainOptions1);
            UIHelper.RenderUIOptionsSet(sc.UIOptions.OptionSets.Single(set => set.SetName == "Class"), itemClassOptions1);
            UIHelper.RenderUIOptionsSet(sc.UIOptions.OptionSets.Single(set => set.SetName == "Quality"), qualityOptions1);
            UIHelper.RenderUIOptionsSet(sc.UIOptions.OptionSets.Single(set => set.SetName == "Bonuses"), bonusOptions1);

            Application.DoEvents();
        }

        private void LoadItemCache()
        {
            sc.Dictionaries.DictionaryItemCache.Clear();
            sc.Caches.ItemCache = ItemCache.LoadWithRegionItems();
            foreach (CacheItem item in sc.Caches.ItemCache.Items)
            {
                sc.Dictionaries.DictionaryItemCache.Add(item.Id, item);
            }
            UpdateCountLabel(tslDataCountItems, sc.Caches.ItemCache.Items.Count);
        }

        private void LoadPetCache()
        {
            sc.Dictionaries.DictionaryPetCache.Clear();
            sc.Caches.PetCache = PetCache.Load();
            foreach (CachePet pet in sc.Caches.PetCache.Pets)
            {
                sc.Dictionaries.DictionaryPetCache.Add(pet.Id.Value, pet);
            }
            UpdateCountLabel(tslDataCountPets, sc.Caches.PetCache.Pets.Count);
        }



        private void LoadSearchProfiles()
        {
            sc.SearchProfiles = SearchProfiles.Load();
            foreach (SearchProfile profile in sc.SearchProfiles.Profiles)
            {
                if (profile.ProfileName == sc.Config.DefaultSearch)
                {
                    tslCurrentProfile.Text = profile.ProfileName;
                    sc.CurrentProfile = profile;
                    SearchProfileToUI();
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
            sc.DisplayMode = displayMode;
            pnlAuctionData.Visible = auctions;

            realmOptions1.Visible = auctions;

            mainOptions1.ShowSuboptions = auctions;
            bonusOptions1.Visible = auctions;
            moreOptions1.ShowSuboptions = auctions;
            globalOptions1.ShowSuboptions = auctions;
            itemListOptions1.SetDisplayMode(displayMode);
            pbsExport1.Visible = !auctions;
            pnlLists_Items.Visible = !auctions;

            switch (displayMode)
            {
                case DisplayMode.Auctions:
                default:
                    panelRibbon.BackColor = Color.Brown;
                    tssMain.BackColor = Color.Brown;
                    lblSearchMode.Text = "Auctions Mode";
                    itemListOptions1.SetListItems();
                    break;

                case DisplayMode.ItemsLists:
                    panelRibbon.BackColor = Color.SteelBlue;
                    tssMain.BackColor = Color.SteelBlue;
                    lblSearchMode.Text = "Lists Mode";
                    itemListOptions1.SetListItems(0);
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
            sc.Config = Config.LoadFromFile(sc.Paths.Config);

            List<int> checkOptions = UIHelper.GetIntsFromBitwise(sc.Config.ConfigChecks.Value);
            OptionSet configOptions = sc.UIOptions.OptionSets.Single(set => set.SetName == "Config");

            ToggleOption tc;
            tc = configOptions.ToggleOptions.Single(tog => tog.Name == "Search On Select Default");
            sc.Config.SearchOnSelectDefault = checkOptions.Contains(tc.Id.Value);
            tc = configOptions.ToggleOptions.Single(tog => tog.Name == "New Data Only Default");
            sc.Config.NewDataOnlyDefault = checkOptions.Contains(tc.Id.Value);
            tc = configOptions.ToggleOptions.Single(tog => tog.Name == "Sort Cache On Update");
            sc.Config.SortCacheOnUpdate = checkOptions.Contains(tc.Id.Value);
            tc = configOptions.ToggleOptions.Single(tog => tog.Name == "Update All Data On Start");
            sc.Config.UpdateAllDataOnStart = checkOptions.Contains(tc.Id.Value);
            tc = configOptions.ToggleOptions.Single(tog => tog.Name == "Refresh Auctions On Start");
            sc.Config.RefreshAuctionsOnStart = checkOptions.Contains(tc.Id.Value);
            tc = configOptions.ToggleOptions.Single(tog => tog.Name == "WOW Interaction Enabled");
            sc.Config.WowInteraction = checkOptions.Contains(tc.Id.Value);
        }
        private void tsbRefreshAuctionData_Click(object sender, EventArgs e)
        {
            auctionsView1.LoadAuctionData();
        }

        private void WriteRegionData()
        {
            Application.DoEvents();
            sc.DataCount.RegionItems.Old = sc.Dictionaries.RegionItems.Count;
            LogProgressMessage("Writing region data to \\tsm\\tsmdata.json");
            string tsmAccessToken = API_TSM.GetAccessToken(sc.Config.TSMKey, sc.Config.TSMClientID);
            API_TSM.WriteRegionTsmItems(tsmAccessToken);
            LoadRegionData();
            sc.DataCount.RegionItems.Total = sc.Dictionaries.RegionItems.Count;
            sc.DataCount.RegionItems.New = sc.DataCount.RegionItems.Total - sc.DataCount.RegionItems.Old;
            LogProgressMessage($"Completed. {sc.DataCount.RegionItems.Total} total region items, {sc.DataCount.RegionItems.New} new.",
                tssProgress.Maximum);
            Application.DoEvents();
            Thread.Sleep(2000);
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
            sc.Dictionaries.RegionItems.Clear();
            long itemId;

            List<TsmItem> AllRegionItems = API_TSM.GetRegionTsmItemsFromFile();

            foreach (TsmItem item in AllRegionItems)
            {
                if (item.itemId != null)
                {
                    itemId = item.itemId.Value;
                    if (!sc.Dictionaries.RegionItems.ContainsKey(itemId))
                    {
                        sc.Dictionaries.RegionItems.Add(itemId, item);
                    }
                }
                else if (item.petSpeciesId != null)
                {
                    itemId = item.petSpeciesId.Value;
                    if (!sc.Dictionaries.RegionItems.ContainsKey(itemId))
                    {
                        sc.Dictionaries.RegionItems.Add(itemId, item);
                        itemId = item.petSpeciesId.Value;
                    }
                }
            }
            UpdateCountLabel(tslDataCountRegion, sc.Dictionaries.RegionItems.Count);
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
                var (newItems, newCache) = ItemCache.BuildItemCache(tssProgress, tllProgress, false);
                sc.Caches.ItemCache = newCache;
                if (sc.Config.SortCacheOnUpdate)
                {
                    SortItemCache(sc.Config.SortCacheOrderDefault.Value);
                }
                UpdateCountLabel(tslDataCountItems, sc.Caches.ItemCache.Items.Count);
            }
        }


        private void SearchProfileToUI()
        {
            mainOptions1.ProfileToUI();
            itemClassOptions1.ProfileToUI();
            qualityOptions1.ProfileToUI();
            bonusOptions1.ProfileToUI();
            moreOptions1.ProfileToUI();
            itemListOptions1.ProfileToUI();

            tslCurrentProfile.Text = sc.CurrentProfile.ProfileName;
            tslCurrentProfile.Image = imgProfile48.Images[sc.CurrentProfile.IconIndex.Value];
            ButtonProfileDefault(tsbSearchDefault, (sc.Config.DefaultSearch == sc.CurrentProfile.ProfileName));
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

        private void UIToSearchProfile()
        {
            mainOptions1.UIToProfile();
            itemClassOptions1.UIToProfile();
            qualityOptions1.UIToProfile();
            bonusOptions1.UIToProfile();
            moreOptions1.UIToProfile();
            itemListOptions1.UIToProfile();
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
            foreach (SearchProfile profile in sc.SearchProfiles.Profiles)
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
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbSearch_Quick_, null, sc.CurrentProfile.ProfileName);
            tslCurrentProfile.Text = sc.CurrentProfile.ProfileName;
            tslCurrentProfile.Image = imgProfile48.Images[sc.CurrentProfile.IconIndex.Value];
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
            if (globalOptions1.SearchOnSelect)
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
                    sc.CurrentWoWProcess = processId.Value;
                    IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbWowProcess_, processId.Value);
                }
            }
        }

        private void GetSearch(string profileName)
        {
            sc.CurrentProfile = sc.SearchProfiles.Profiles.Single(profile => profile.ProfileName == profileName);
            SearchProfileToUI();
        }

        private void tsbSaveSearch_Click(object sender, EventArgs e)
        {
            if (MsgHelper.Confirm.OverwriteProfile())
            {
                UIToSearchProfile();
                sc.SearchProfiles.Save();
                RefreshToolbarSearchButtons();
            }
        }

        private void tsbSaveSearchAs_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            //If we are copying as, the copy shouldn't be the default as part of this operation
            var (profileName, iconIndex) = UIHelper.GetProfileDetails(0, sc.CurrentProfile.IconIndex.Value,
                sc.CurrentProfile.ProfileName, "Search Profile", this.imgProfile48);
            if (profileName != null && profileName.Trim() != "")
            {
                AddNewProfile(sc.CurrentProfile.ShallowCopy(), profileName, iconIndex);
            }
        }

        private void btnSearch_TogglesOnOff_Click(object sender, EventArgs e)
        {
            UIHelper.ToggleOnOffClick(sender, e);
        }

        private void tsbSearchDefault_Click(object sender, EventArgs e)
        {
            if (sc.CurrentProfile.ProfileName != sc.Config.DefaultSearch)
            {
                if (MsgHelper.Confirm.DefaultProfile())
                {
                    ChangeDefaultProfile(sc.CurrentProfile.ProfileName);
                    ButtonProfileDefault(tsbSearchDefault, true);
                }
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchInit()
        {
            switch (sc.DisplayMode)
            {
                case DisplayMode.Auctions:
                default:
                    auctionsView1.ClearAuctions();
                    sc.Lists.RealmSearchCount.Clear();
                    break;
                case DisplayMode.ItemsLists:

                    break;
            }


            tllProgress.Text = "Progress";
            tssProgress.Value = 0;
            this.UIToSearchProfile();


            sc.SearchLogic.Options = new SearchOptions();
            sc.SearchLogic.Options.Main = UIHelper.GetControlCheckedList(mainOptions1);
            sc.SearchLogic.Options.Class = UIHelper.GetControlCheckedList(itemClassOptions1);
            sc.SearchLogic.Options.Quality = UIHelper.GetControlCheckedList(qualityOptions1);
            sc.SearchLogic.Options.Bonuses = UIHelper.GetControlCheckedList(bonusOptions1);

            sc.SearchLogic.Options.NewDataOnly = globalOptions1.NewDataOnly;
            sc.SearchLogic.Options.LatestXpac = sc.SearchLogic.Options.Main.Contains("Latest Xpac");
            sc.SearchLogic.Options.IncludeItems = sc.SearchLogic.Options.Main.Contains("Include Items");
            sc.SearchLogic.Options.IncludePets = sc.SearchLogic.Options.Main.Contains("Include Pets");
            sc.SearchLogic.Options.HasSockets = sc.SearchLogic.Options.Main.Contains("Socket");
            sc.SearchLogic.Options.AtoZ = sc.SearchLogic.Options.Main.Contains("A to Z");
            sc.SearchLogic.Options.IncludeBuyout = sc.SearchLogic.Options.Main.Contains("Include Buyout");
            sc.SearchLogic.Options.IncludeBid = sc.SearchLogic.Options.Main.Contains("Include Bid");
            sc.SearchLogic.Options.UseStringFilter = (sc.CurrentProfile.StringFilter != "");
            sc.SearchLogic.Options.StringFilter = sc.CurrentProfile.StringFilter;

            sc.SearchLogic.Options.FixedMaxG = (sc.CurrentProfile.SearchMaxG.Value * 10000);
            sc.SearchLogic.Options.FixedWorthAtLeast = (sc.CurrentProfile.WorthAtLeast.Value * 10000);
            sc.SearchLogic.Options.FixedSearchPercentage = (sc.CurrentProfile.SearchPercentage.Value / 100);

            if (sc.CurrentProfile.ListOption != 0)
            {
                sc.SearchLogic.Options.CombinedSearchCache = GetCacheOfSearchLists();
            }
        }

        private ItemCache GetCacheOfSearchLists()
        {
            ItemCache newCache = new ItemCache();

            foreach (string listName in sc.CurrentProfile.Lists)
            {

                ItemList list = GetItemListByName(listName);
                newCache.Items.AddRange(list.ItemCache.Items);

            }

            newCache.Items = newCache.Items.DistinctBy(item => item.Id).ToList();
            newCache.FillItemIds();

            return newCache;
        }

        private ItemList GetItemListByName(string listName)
        {
            return sc.ItemLists.Lists.Single(list => list.Name == listName);
        }

        private void Search()
        {
            SearchInit();

            switch (sc.DisplayMode)
            {
                case DisplayMode.Auctions:
                default:
                    auctionsView1.AuctionsSearch(charts1);
                    break;

                case DisplayMode.ItemsLists:
                    ItemsSearch();
                    break;
            }
        }

        private void ItemsSearch()
        {
            lvItemsSearchResults.Items.Clear();
            ItemCache searchResults = sc.SearchLogic.DoItemSearch(ItemsAsCacheCopy());
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
                lvi.SubItems[1].ForeColor = UIHelper.GetColorForQuality(item.QualityType);

                TsmItem ritem = null;
                try
                {
                    ritem = sc.Dictionaries.RegionItems.First(regionItem => regionItem.Key == item.Id).Value as TsmItem;
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
                var (newPets, newCache) = PetCache.BuildPetCache(tssProgress, tllProgress, false);
                sc.Caches.PetCache = newCache;
                if (sc.Config.SortCacheOnUpdate)
                {
                    SortPetCache(sc.Config.SortCacheOrderDefault.Value);
                }
                UpdateCountLabel(tslDataCountPets, sc.Caches.PetCache.Pets.Count);
            }
        }

        private void tsmUpdateItemCache_Click(object sender, EventArgs e)
        {
            UpdateItemCache();
        }

        private void UpdateItemCache()
        {
            var (newItems, newCache) = ItemCache.BuildItemCache(tssProgress, tllProgress, true);
            sc.Caches.ItemCache = newCache;
            UpdateCountLabel(tslDataCountItems, sc.Caches.ItemCache.Items.Count);
            sc.DataCount.ItemCache.Total = sc.Caches.ItemCache.Items.Count;
            sc.DataCount.ItemCache.New = newItems;
            LogProgressMessage($"Completed. {sc.DataCount.ItemCache.New} new items. {sc.DataCount.ItemCache.Total} total items in cache.");
            if (sc.Config.SortCacheOnUpdate)
            {
                SortItemCache(sc.Config.SortCacheOrderDefault.Value);
            }
            Thread.Sleep(2000);
        }

        private void tsmUpdatePetCache_Click(object sender, EventArgs e)
        {
            UpdatePetCache();
        }

        private void UpdatePetCache()
        {
            var (newPets, newCache) = PetCache.BuildPetCache(tssProgress, tllProgress, true);
            sc.Caches.PetCache = newCache;
            UpdateCountLabel(tslDataCountPets, sc.Caches.PetCache.Pets.Count);
            sc.DataCount.PetCache.Total = sc.Caches.PetCache.Pets.Count;
            sc.DataCount.PetCache.New = newPets;
            LogProgressMessage($"Completed. {sc.DataCount.PetCache.New} new pets. {sc.DataCount.PetCache.Total} total pets in cache.");
            if (sc.Config.SortCacheOnUpdate)
            {
                SortPetCache(sc.Config.SortCacheOrderDefault.Value);
            }
            Thread.Sleep(2000);
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {
            FormBlank1 frm = new FormBlank1();
            frm.ShowDialog();

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
                AddNewToolStripButton(950, "", tsbType.tsbWowProcess_, pr.Id);
                if (pr.Id == sc.CurrentWoWProcess)
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
                                    sc.CurrentWoWProcess = (int)stripButton.Tag;
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
                            sc.CurrentWoWProcess = (int)relevantButtons[0].Tag;
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
            ProcHelper.ActivateApp(sc.CurrentWoWProcess);
        }

        private void tsbRefreshWoWProcesses_Click(object sender, EventArgs e)
        {
            this.RefreshWowButtons();
        }

        private void tsbRenameSearch_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            //If we are renaming this search, and it is currently the default, it should stay the default
            bool newSearchIsDefault = (sc.CurrentProfile.ProfileName == sc.Config.DefaultSearch);
            var (profileName, iconIndex) = UIHelper.GetProfileDetails(1, sc.CurrentProfile.IconIndex.Value,
                sc.CurrentProfile.ProfileName, "Search Profile", this.imgProfile48);

            if (profileName != null && profileName.Trim() != "")
            {
                sc.CurrentProfile.ProfileName = profileName;
                sc.CurrentProfile.IconIndex = iconIndex;
                sc.SearchProfiles.Save();
                RefreshToolbarSearchButtons();
            }
        }

        private SearchProfile GetCopyOfDefault()
        {
            SearchProfile profile = sc.SearchProfiles.Profiles.Single(profile => profile.ProfileName == "[Default]");
            return profile.ShallowCopy();
        }

        private void tsbNewSearch_Click(object sender, EventArgs e)
        {
            var (profileName, iconIndex) = UIHelper.GetProfileDetails(2, 0, "", "Search Profile", this.imgProfile48);
            if (profileName != null && profileName.Trim() != "")
            {
                AddNewProfile(GetCopyOfDefault(), profileName, iconIndex);
            }
        }

        private void AddNewProfile(SearchProfile profile, string profileName, int iconIndex)
        {
            profile.ProfileName = profileName;
            profile.IconIndex = iconIndex;
            sc.SearchProfiles.Profiles.Add(profile);
            sc.CurrentProfile = profile;
            sc.SearchProfiles.Save();
            RefreshToolbarSearchButtons();
            SearchProfileToUI();
        }

        private void ChangeDefaultProfile(string newName)
        {
            sc.Config.DefaultSearch = newName;
            sc.Config.Save();
        }

        private bool CheckIfDefaultProfileForDelete()
        {
            if (sc.CurrentProfile.ProfileName == "[Default]")
            {
                MsgHelper.Error.CannotDeleteDefault();
                return true;
            }
            return false;
        }

        private void DeleteSearchProfile(SearchProfile profile)
        {
            sc.SearchProfiles.Profiles.Remove(profile);
            sc.SearchProfiles.Save();
        }

        private void tsbDeleteSearch_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            if (MsgHelper.Confirm.DeleteProfile())
            {
                //If this was the default profile we need to make the [Default] the default profile
                if (sc.CurrentProfile.ProfileName == sc.Config.DefaultSearch)
                {
                    ChangeDefaultProfile("[Default]");
                }

                DeleteSearchProfile(sc.CurrentProfile);
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
            sc.Caches.ItemCache.SortAndSave(direction);
        }
        private void SortPetCache(SortDirection direction = SortDirection.Ascending)
        {
            sc.Caches.PetCache.SortAndSave(direction);
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
            sc.DataCount = new DataCount();
            Application.DoEvents();
            WriteRegionData();
            Application.DoEvents();
            UpdateItemCache();
            Application.DoEvents();
            UpdatePetCache();
            Application.DoEvents();
            LogProgressMessage(
                $"Region Items {sc.DataCount.RegionItems.New} new ({sc.DataCount.RegionItems.Total}). " +
                $"Item Cache {sc.DataCount.ItemCache.New} new ({sc.DataCount.ItemCache.Total}). " +
                $"Pet Cache {sc.DataCount.PetCache.New} new ({sc.DataCount.PetCache.Total}). "
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
            sc.LivePoll = true;
            SearchInit();
            auctionsView1.LoadAuctionData();
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


        private void SaveItems()
        {
            sc.CurrentItemList.ItemCache.Items.Clear();

            foreach (ListViewItem lvi in lvItemsItemsInList.Items)
            {
                CacheItem item = lvi.Tag as CacheItem;
                if (item != null)
                {
                    sc.CurrentItemList.ItemCache.AddItem(item);
                }
            }
            sc.ItemLists.Save();
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
            else if (e.KeyCode == Keys.A && e.Control)
            {
                // Select all items in the ListView
                foreach (ListViewItem item in lvItemsItemsInList.Items)
                {
                    item.Selected = true;
                }
                e.Handled = true; // Mark the event as handled to prevent further processing if necessary
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

        private void lvItemsSearchResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                // Select all items in the ListView
                foreach (ListViewItem item in lvItemsSearchResults.Items)
                {
                    item.Selected = true;
                }
                e.Handled = true; // Mark the event as handled to prevent further processing if necessary
            }
        }

        private void itemListOptions1_SelectedChanged(object sender, ItemListEventArgs e)
        {
            LoadItemList(e.ItemList);
            sc.CurrentItemList = e.ItemList;
        }

        private void tsbPreferences_Click(object sender, EventArgs e)
        {
            UIHelper.ShowPreferences(null);
        }


        private void tsbWoWInteraction_Click(object sender, EventArgs e)
        {
            FormMouseTest frmWow = new FormMouseTest();
            frmWow.ShowDialog();


        }

        private void moreOptions1_FilterStringEnterPressed(object sender, EventArgs e)
        {
            Search();
        }

        private Keys KeysFromString(string keyString)
        {
            // The second parameter 'true' ignores case sensitivity
            if (Enum.TryParse<Keys>(keyString, true, out Keys result))
            {
                // Successfully parsed
                return result;   
            }
            else
            {
                // Handle invalid key string
                return Keys.Space;
            }
        }

        private void tsbAllowGKH_Click(object sender, EventArgs e)
        {
            if (tsbAllowGKH.Checked)
            {
                gkh = new GlobalKeyboardHook();
                gkh.HookedKeys.Add(KeysFromString(sc.Config.GlobalKeyboardHookChar));
                gkh.KeyDown += new System.Windows.Forms.KeyEventHandler(gkh_KeyDown);
                gkh.KeyUp += new System.Windows.Forms.KeyEventHandler(gkh_KeyUp);
            }
            else
            {
                gkh.unhook();
            }   
        }

        public enum BuyPriceSelectType
        {
            Selected,
            All,
            ZeroValue
        }
    }
}
