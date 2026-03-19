using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Text.Json;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WOWAuctionApi_Net10
{
    public partial class FormMain : Form
    {
        public Config apiConfig;
        public Dictionary<int, AuctionFileContents> RealmAuctions = new Dictionary<int, AuctionFileContents>();
        public Dictionary<long, TsmItem> RegionItems = new Dictionary<long, TsmItem>();
        public Dictionary<long, TsmItem> RegionPets = new Dictionary<long, TsmItem>();
        public SortedDictionary<long, Item> DictionaryItemCache = new SortedDictionary<long, Item>();
        public SortedDictionary<long, Pet> DictionaryPetCache = new SortedDictionary<long, Pet>();
        public SearchProfile CurrentProfile = new SearchProfile();
        public SearchLogic searchLogic = new SearchLogic();
        public string blizzAccessToken;
        public bool darkMode = true;
        public TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        public UserInterfaceOptions UIOptions = new UserInterfaceOptions();

        public List<RealmCount> totalAuctionsCount = new List<RealmCount>();
        public List<RealmCount> realmSearchCount = new List<RealmCount>();
        public int currentWoWProcess = 0;

        public InteractionScript wowBuy;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadConfig();
            UIOptions = UserInterfaceOptions.LoadFromFile();
            RenderUIOptionsControls();
            LoadRealms();
            LoadRegionItems();
            LoadSearchProfiles();
            LoadItemCache();
            LoadPetCache();

            blizzAccessToken = API_Blizzard.GetAccessToken(apiConfig.BlizzClientID, apiConfig.BlizzClientSecret);

            SetAppColorMode();
            lvRealms.SmallImageList = imgStatus;

            toolStripMain.ImageList = imgToolbar48;
            toolStripMain.Renderer = new ToolStripBlankSeparatorRenderer();

            //If OnlyFirst is set, only check the first X realms and uncheck the rest to speed up loading for users who don't care about all realms
            if (apiConfig.OnlyFirst > 0)
            {
                ToggleRealms();
                Application.DoEvents();
                for (int i = 0; i < apiConfig.OnlyFirst; i++)
                {
                    lvRealms.Items[i].Checked = true;
                }
            }

            SetUpChart(chartTotalAuctions, "Top 5 Realms - Total Items On The Auction House", SeriesChartType.Column);
            SetUpChart(chartTopSearches, "Top 10 Realms - Search Hits For This Search", SeriesChartType.Doughnut);
            SetUpChart(chartTotalValue, "Top 5 Realms - Total Region Market Value For This Search", SeriesChartType.Bar);

            if (apiConfig.WowInteraction.Value)
            {
                wowBuy = InteractionScript.LoadFromFile("", "wowahbuy");
                tsbTest.Visible = true;
                tsbRefreshWoWProcesses.Visible = true;
                tsbActivate.Visible = true;
                RefreshWowButtons();
            }

            if (apiConfig.RefreshAuctionsOnStart.Value)
            {
                RefreshAuctionData();
            }
        }

        private void RenderUIOptionsControls()
        {
            RenderUIOptionsSet(UIOptions.Main, pnlSearch_Main);
            RenderUIOptionsSet(UIOptions.Class, pnlSearch_Class);
            RenderUIOptionsSet(UIOptions.Quality, pnlSearch_Quality);

            Application.DoEvents();
        }

        private void RenderUIOptionsSet(List<ToggleOption> optionList, Panel searchPanel)
        {
            int x = UIOptions.Toggle.XStart;
            int y = UIOptions.Toggle.YStart;
            int count = 0;
            foreach (var option in optionList)
            {
                count++;
                RenderUIOptionsControl(option, searchPanel, x, y);
                y += UIOptions.Toggle.YRowOffset;
                if (count >= UIOptions.Toggle.TogsPerColumn)
                {
                    count = 0;
                    y = UIOptions.Toggle.YStart;
                    x += UIOptions.Toggle.XColumnOffset;
                }
            }
        }

        private void RenderUIOptionsControl(ToggleOption togOption, Panel searchPanel, int renderX, int renderY)
        {
            var newToggle = new ToggleSlider();
            Color backColor;
            Color togColor;
            if (UIOptions.ColorMode == SystemColorMode.Dark)
            {
                backColor = Color.FromName(togOption.BackColorDark);
                togColor = Color.FromName(togOption.ToggleColorDark);
            }
            else
            {
                backColor = Color.FromName(togOption.BackColorLight);
                togColor = Color.FromName(togOption.ToggleColorLight);
            }

            newToggle.Checked = true;
            newToggle.CheckState = CheckState.Checked;
            newToggle.Location = new Point(renderX, renderY);
            newToggle.Size = new Size(UIOptions.Toggle.Width, UIOptions.Toggle.Height);
            newToggle.UseVisualStyleBackColor = true;

            newToggle.OptionValue = togOption.Name;
            newToggle.OptionBit = togOption.Id.Value;
            newToggle.Name = "tsl_" + searchPanel.Name + togOption.Name.Replace(" ", "");

            newToggle.OnBackColor = backColor;
            newToggle.OnToggleColor = togColor;
            newToggle.OffBackColor = Color.Gray;
            newToggle.OffToggleColor = Color.Gainsboro;

            searchPanel.Controls.Add(newToggle);

            var newLabel = new System.Windows.Forms.Label();

            newLabel.AutoSize = true;
            newLabel.Font = this.Font;
            newLabel.ForeColor = backColor;
            newLabel.Location = new Point(renderX + UIOptions.Toggle.XLabelGap, renderY);
            newLabel.Name = "lbl_" + searchPanel.Name + togOption.Name.Replace(" ", "");
            newLabel.Text = textInfo.ToTitleCase(togOption.Name.ToLower());

            searchPanel.Controls.Add(newLabel);

        }

        private void LoadItemCache()
        {
            DictionaryItemCache.Clear();
            ItemCache itemCache = ItemCache.Load();
            foreach (Item item in itemCache.Items)
            {
                DictionaryItemCache.Add(item.Id, item);
            }
        }

        private void LoadPetCache()
        {
            DictionaryPetCache.Clear();
            PetCache petCache = PetCache.Load();
            foreach (Pet pet in petCache.Pets)
            {
                DictionaryPetCache.Add(pet.Id.Value, pet);
            }
        }



        private void LoadSearchProfiles()
        {
            cboSearchProfile.Items.Clear();
            foreach (var file in Directory.EnumerateFiles(Paths.SearchProfile))
            {
                var sp = SearchProfile.LoadFromFile(file);
                if (sp != null)
                {
                    cboSearchProfile.Items.Add(sp.ProfileName);
                    if (sp.ProfileName == apiConfig.DefaultSearch)
                    {
                        cboSearchProfile.Text = sp.ProfileName;
                        this.SearchProfileToUI(sp);
                    }
                }
            }

            RefreshToolbarSearchButtons();
        }

        private void SetAppColorMode()
        {
            tsbThemeDark.Checked = (Application.ColorMode == SystemColorMode.Dark);
            tsbThemeLight.Checked = !(Application.ColorMode == SystemColorMode.Dark);
        }

        private void ChangeColorMode(SystemColorMode colorMode)
        {
            //if (MessageBox.Show("Do you want to change the color mode to "
            //    + colorMode.ToString() + "? This will require and application restart.", "Color Mode", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            HelpAppSettings.SetColorMode(colorMode);
            Application.Restart();
            //}
        }

        private void LoadConfig()
        {
            apiConfig = Config.LoadFromFile(Paths.Config);
        }

        private Color StringToColor(string hexColor)
        {
            return System.Drawing.ColorTranslator.FromHtml(hexColor);
        }

        private void LoadRealms()
        {
            var items = new List<ListViewItem>();
            foreach (var r in apiConfig.Realms)
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
            RefreshAuctionData();
        }

        private void RefreshAuctionData()
        {
            totalAuctionsCount.Clear();
            foreach (Realm r in apiConfig.Realms)
            {
                if (RealmChecked(r.RealmId.Value))
                {
                    AuctionEventInfo result = Task.Run(() => API_Blizzard.GetAuctionsFromAPI(blizzAccessToken, r)).Result;
                    SetAuctionData(r.RealmId.Value, result.Auctions, result.LastModified, r);
                    totalAuctionsCount.Add(new RealmCount { RealmId = r.RealmId.Value, RealmName = r.RealmName, Count = result.Auctions.auctions.Count });
                }
            }
        }

        private void WriteRegionData()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            //BackupRegionData();
            string tsmAccessToken = API_TSM.GetAccessToken(apiConfig.TSMKey, apiConfig.TSMClientID);
            API_TSM.WriteRegionTsmItems(tsmAccessToken);
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            MessageBox.Show("Region items updated");
        }


        private void SetAuctionData(int realmId, AuctionFileContents afc, string lastModified, Realm r)
        {
            RealmAuctions[realmId] = afc;
            int newStatus = 2;
            //We are on a worker thread at this point - we need to somehow marshall this request back to UI thread 
            //or get UI thread to read the date on the file or something

            try
            {
                DateTime lastModifiedDate = DateTime.Parse(lastModified);
                DateTime thresholdDate = DateTime.Now.AddMinutes(-(int.Parse(this.txtSearchThreshold.Text)));

                if (lastModifiedDate > thresholdDate)
                {
                    newStatus = 3;
                }

                SetRealmStatus(realmId, newStatus, lastModified, afc.auctions.Count);
                //RefreshThreadCount();
            }
            catch
            {
                //SetRealmStatus(connectedRealmId, 1, "ERROR", 0);
            }
        }

        private void SetRealmStatus(int connectedRealmId, int status, string lastModified, int auctionCount)
        {
            Realm r = apiConfig.Realms.First(realm => realm.RealmId == connectedRealmId);

            lvRealms.SuspendLayout();
            r.Status = status;
            r.NumAuctions = auctionCount;
            //r.NumAuctionColor = GetNumAuctionColor(auctionCount);

            foreach (ListViewItem lvi in lvRealms.Items)
            {
                if (lvi.Tag != null)
                {
                    if (((Realm)lvi.Tag).RealmId == connectedRealmId)
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
                            lvi.SubItems[3].Text = auctionCount.ToString();
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

        private void LoadRegionItems()
        {
            RegionItems.Clear();
            RegionPets.Clear();
            long itemId;

            List<TsmItem> AllRegionItems = API_TSM.GetRegionTsmItemsFromFile();

            foreach (TsmItem item in AllRegionItems)
            {
                if (item.itemId != null)
                {
                    itemId = item.itemId.Value;
                    if (!RegionItems.ContainsKey(itemId))
                    {
                        RegionItems.Add(itemId, item);
                    }
                }
                else if (item.petSpeciesId != null)
                {
                    itemId = item.petSpeciesId.Value;
                    if (!RegionPets.ContainsKey(itemId))
                    {
                        RegionPets.Add(itemId, item);
                        itemId = item.petSpeciesId.Value;
                    }
                }
            }
        }

        private void tsmBuildItemCache_Click(object sender, EventArgs e)
        {
            ItemCache.BuildItemCache(tspProgress, lblStatus, this.RegionItems, this.blizzAccessToken, false);
        }

        private void cboSearchProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchProfile sp = SearchProfile.LoadFromFile(Paths.SearchProfile + @"\" + cboSearchProfile.Text + ".json");
            SearchProfileToUI(sp);
            HighlightCurrentSearch();
        }

        private void SearchProfileToUI(SearchProfile sp)
        {
            this.rbSearchRemoveDuplicates.Checked = (sp.SearchFrequency == 0);
            this.rbSearchShowCheapest.Checked = (sp.SearchFrequency == 1);
            this.rbSearchShowAllItems.Checked = (sp.SearchFrequency == 2);

            this.txtSearchMaxG.Text = sp.SearchMaxG.Value.ToString();
            this.txtSearchMaxItemLevel.Text = sp.MaxItemLevel.Value.ToString();
            this.txtSearchMinItemLevel.Text = sp.MinItemLevel.Value.ToString();

            this.txtSearchMinSellRate.Text = sp.MinSellRate.Value.ToString();
            this.txtSearchPercentage.Text = sp.SearchPercentage.Value.ToString();
            this.txtSearchWorth.Text = sp.WorthAtLeast.Value.ToString();

            this.txtSearchThreshold.Text = sp.Threshold.Value.ToString();
            this.txtSearchStringFilter.Text = sp.StringFilter;

            SetPanelBitwiseValues(this.pnlSearch_Main, sp.MainOptions.Value);
            SetPanelBitwiseValues(this.pnlSearch_Class, sp.Class.Value);
            SetPanelBitwiseValues(this.pnlSearch_Quality, sp.Quality.Value);

            this.cboSearchProfile.Text = sp.ProfileName;
            this.tsInToolbar.Checked = sp.InToolbar.Value;

            ButtonProfileDefault(tsbSearchDefault, (apiConfig.DefaultSearch == sp.ProfileName));

            this.rbSearch_Percentage.Checked = (sp.SearchFraction.Value == 0);
            this.rbSearch_MaxG.Checked = (sp.SearchFraction.Value == 1);

            lblIconIndex.Text = sp.IconIndex.Value.ToString();
            picSearchProfile.Image = imgToolbar48.Images[sp.IconIndex.Value];
            this.tslQuickSearches.Text = "Quick Searches---- > Current Profile: " + sp.ProfileName;
            CurrentProfile = sp;
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

            sp.SearchMaxG = int.Parse(this.txtSearchMaxG.Text);
            sp.MaxItemLevel = int.Parse(this.txtSearchMaxItemLevel.Text);
            sp.MinItemLevel = int.Parse(this.txtSearchMinItemLevel.Text);
            sp.WorthAtLeast = int.Parse(this.txtSearchWorth.Text);
            sp.Threshold = int.Parse(this.txtSearchThreshold.Text);
            sp.StringFilter = this.txtSearchStringFilter.Text;

            sp.MinSellRate = float.Parse(this.txtSearchMinSellRate.Text);
            sp.SearchPercentage = float.Parse(this.txtSearchPercentage.Text);
            sp.SearchFraction = (rbSearch_Percentage.Checked) ? 0 : 1;

            sp.MainOptions = GetPanelBitwiseValue(this.pnlSearch_Main);
            sp.Class = GetPanelBitwiseValue(this.pnlSearch_Class);
            sp.Quality = GetPanelBitwiseValue(this.pnlSearch_Quality);

            sp.InToolbar = this.tsInToolbar.Checked;
            sp.IconIndex = int.Parse(lblIconIndex.Text);
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

        private List<string> GetPanelCheckedList(Panel searchPanel)
        {
            var returnValue = new List<string>();

            var checkedBoxes = searchPanel.Controls.OfType<ToggleSlider>().Where(c => c.Checked);

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                returnValue.Add(checkBox.OptionValue);
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
            newTSB.ImageIndex = iconIndex;
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
            foreach (var file in Directory.EnumerateFiles(Paths.SearchProfile))
            {
                var sp = SearchProfile.LoadFromFile(file);
                if (sp != null)
                {
                    if (sp.InToolbar.Value)
                    {

                        if (apiConfig.DefaultSearch == sp.ProfileName)
                        {
                            CurrentProfile = sp;
                        }
                        AddNewToolStripButton(sp.IconIndex.Value, sp.ProfileName, tsbType.tsbSearch_Quick_);
                    }
                }
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
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbSearch_Quick_, null, CurrentProfile.ProfileName);
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
            Search();
        }

        private void WowButtonClick(object sender, EventArgs e)
        {
            var button1 = sender as ToolStripButton;
            if (button1 != null)
            {
                var processId = button1.Tag as int?;
                if (processId != null)
                {
                    currentWoWProcess = processId.Value;
                    IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbWowProcess_, processId.Value);
                }
            }
        }

        private void GetSearch(string profileName)
        {
            SearchProfile sp = SearchProfile.LoadFromFile(Paths.SearchProfile + @"\" + profileName + ".json");
            SearchProfileToUI(sp);
        }

        private void SetPanelBitwiseValues(Panel searchPanel, int bitwiseValue)
        {
            var checkedBoxes = searchPanel.Controls.OfType<ToggleSlider>();

            foreach (ToggleSlider checkBox in checkedBoxes)
            {
                checkBox.Checked = ((bitwiseValue & checkBox.OptionBit) != 0);
            }
        }

        private void tsbSaveSearch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to overwrite the current search profile?", 
                "Save Search Profile", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UIToSearchProfile(CurrentProfile);
                CurrentProfile.Save();
                RefreshToolbarSearchButtons();
            }
        }

        private void tsbSaveSearchAs_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            //If we are copying as, the copy shouldn't be the default as part of this operation
            var (profileName, iconIndex) = GetSearchDetails(0);
            if (profileName != null && profileName.Trim() != "")
            {
                CopySearch(profileName, iconIndex, false, false);
            }
        }

        private void btnSearch_TogglesOnOff_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                var hostPanel = clickedButton.Parent as Panel;
                if (hostPanel != null)
                {
                    var checkedBoxes = hostPanel.Controls.OfType<ToggleSlider>();
                    bool toggleValue = !(checkedBoxes.First().Checked);
                    foreach (CheckBox checkBox in checkedBoxes)
                    {
                        checkBox.Checked = toggleValue;
                    }
                }
            }
        }

        private void tsbSearchDefault_Click(object sender, EventArgs e)
        {
            if (CurrentProfile.ProfileName != apiConfig.DefaultSearch)
            {
                if (MessageBox.Show("Do you want to make this the default search profile?", "Default Search Profile", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ChangeDefaultProfile(CurrentProfile.ProfileName);
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
                    int numAuctions = int.Parse(listItem.SubItems[3].Text);

                    if (numAuctions == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Search()
        {
            if (!CheckAllRealmsHaveData())
            {
                MessageBox.Show("One or more of your realms has not yet its data loaded. "
                    + "\n\nPlease click the refresh button in the top left corner and wait for "
                    + "all chosen realms' data to load before searching", "Please load data", MessageBoxButtons.OK);
                return;
            }


            lvAuctions.Items.Clear();
            lblStatus.Text = "Progress";
            tspProgress.Value = 0;
            this.UIToSearchProfile(CurrentProfile);
            int count = 0;

            realmSearchCount.Clear();

            searchLogic.Options = new SearchOptions();
            searchLogic.Options.Main = GetPanelCheckedList(pnlSearch_Main);
            searchLogic.Options.Class = GetPanelCheckedList(pnlSearch_Class);
            searchLogic.Options.Quality = GetPanelCheckedList(pnlSearch_Quality);

            searchLogic.FixedMaxG = (CurrentProfile.SearchMaxG.Value * 10000);
            searchLogic.FixedWorthAtLeast = (CurrentProfile.WorthAtLeast.Value * 10000);
            searchLogic.FixedSearchPercentage = (CurrentProfile.SearchPercentage.Value / 100);

            foreach (Realm realm in apiConfig.Realms)
            {
                if (RealmChecked(realm.RealmId.Value))
                {
                    var searchResults = (
                        searchLogic.SearchRealm(
                            realm,
                            CurrentProfile,
                            RealmAuctions[realm.RealmId.Value],
                            RegionItems,
                            RegionPets,
                            DictionaryItemCache,
                            DictionaryPetCache,
                            apiConfig));

                    if (searchResults != null)
                    {
                        RenderSearchResults(searchResults, realm, count);
                        realmSearchCount.Add(new RealmCount
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
            if (UIOptions.ColorMode == SystemColorMode.Dark)
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
            RenderChart(realmSearchCount, 5, chartTotalValue);

            //Render Top 10 Search Hit Realms
            RenderChart(realmSearchCount, 10, chartTopSearches);

            //Render Top 5 Total Auctions
            RenderChart(totalAuctionsCount, 5, chartTotalAuctions);
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
                lvi.BackColor = StringToColor(realm.BackColor);
                lvi.Tag = result;
                lvi.ToolTipText = result.ItemId.ToString() + " ItemLevel = (" + result.Level.ToString() + ") "
                    + result.Modifiers + " " + result.BonusLists;

                if (result.Suffix != String.Empty)
                {
                    lvi.SubItems.Add(result.ItemName + " " + result.Suffix);
                }
                else
                {
                    lvi.SubItems.Add(result.ItemName);
                }

                lvi.SubItems[1].ForeColor = GetColorForQuality(result.Quality);

                lvi.SubItems.Add(result.Level.ToString());

                //Color code sale rate
                lvi.SubItems.Add(result.SaleRate.ToString());
                lvi.SubItems[3].ForeColor = GetColorForSellRate(result.SaleRate);

                lvi.SubItems.Add(actualPercentage.ToString("0.##") + "%");

                lvi.SubItems.Add(HelpString.FormatItemPrice(result.Buyout)); //Buyout $
                lvi.SubItems.Add(HelpString.FormatItemPrice(result.RegionMarket)); //Region $

                lvi.SubItems.Add(result.PetLevel.ToString()); //Pet Level
                if (result.PetLevel > 0)
                {
                    lvi.SubItems[6].ForeColor = GetColorForQuality(result.Quality);
                }

                lvi.SubItems.Add(LXItem(result.ItemId));
                lvAuctions.Items.Add(lvi);
            }
            lvAuctions.ResumeLayout();
        }

        private string LXItem(long itemid)
        {
            if (itemid > apiConfig.LatestXpacItemId)
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
        private Color GetColorForQuality(string quality)
        {
            switch (UIOptions.ColorMode)
            {
                case SystemColorMode.Classic:
                    switch (quality)
                    {
                        case "UNCOMMON": default: return Color.DarkGreen;
                        case "RARE": return Color.MidnightBlue;
                        case "EPIC": return Color.DarkViolet;
                        case "POOR": return Color.DimGray;
                        case "COMMON": return Color.DarkGray;
                        case "LEGENDARY": return Color.Chocolate;
                        case "ARTIFACT": return Color.Tan;
                    }
                case SystemColorMode.Dark:
                default:

                    switch (quality)
                    {
                        case "UNCOMMON": default: return Color.LimeGreen;
                        case "RARE": return Color.CornflowerBlue;
                        case "EPIC": return Color.MediumOrchid;
                        case "POOR": return Color.DarkGray;
                        case "COMMON": return Color.White;
                        case "LEGENDARY": return Color.Orange;
                        case "ARTIFACT": return Color.Tan;
                    }

            }
        }

        private Color GetColorForSellRate(float sellRate)
        {
            switch (UIOptions.ColorMode)
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

        private void btnChangeIcon_Click(object sender, EventArgs e)
        {
            FormChoseIconDlg frm = new FormChoseIconDlg(this.imgToolbar48);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int imageIndex = frm.SelectedImageIndex;
                lblIconIndex.Text = imageIndex.ToString();
                picSearchProfile.Image = imgToolbar48.Images[imageIndex];
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
            PetCache.BuildPetCache(tspProgress, lblStatus, this.RegionPets, this.blizzAccessToken, false);
        }

        private void tsmUpdateItemCache_Click(object sender, EventArgs e)
        {
            ItemCache.BuildItemCache(tspProgress, lblStatus, this.RegionItems, this.blizzAccessToken, true);
        }

        private void tsmUpdatePetCache_Click(object sender, EventArgs e)
        {
            PetCache.BuildPetCache(tspProgress, lblStatus, this.RegionPets, this.blizzAccessToken, true);
        }

        private void lvAuctions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.ToUpper(e.KeyChar) == (char)Keys.C)
            {
                CopyItemToClipboard();
            }

            if (apiConfig.WowInteraction.Value)
            {
                if (char.ToUpper(e.KeyChar) == (char)Keys.Z)
                {
                    CopyItemToClipboard();
                    wowBuy.ProcessScript();
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
            FormMouseTest frm = new FormMouseTest();
            frm.ProcessId = currentWoWProcess;
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
            Process[] wowProcesses = HelpProc.GetWowProcesses();
            foreach (Process pr in HelpProc.GetWowProcesses())
            {
                AddNewToolStripButton(94, "", tsbType.tsbWowProcess_, pr.Id);
                if (pr.Id == currentWoWProcess)
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
                                    currentWoWProcess = (int)stripButton.Tag;
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
                            currentWoWProcess = (int)relevantButtons[0].Tag;
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
            HelpProc.ActivateApp(currentWoWProcess);
        }

        private void tsbRefreshWoWProcesses_Click(object sender, EventArgs e)
        {
            this.RefreshWowButtons();
        }

        private void tsbRenameSearch_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return; }

            //If we are renaming this search, and it is currently the default, it should stay the default
            bool newSearchIsDefault = (CurrentProfile.ProfileName == apiConfig.DefaultSearch);
            var (profileName, iconIndex) = GetSearchDetails(1);
            if (profileName != null && profileName.Trim() != "")
            {
                CopySearch(profileName, iconIndex, true, newSearchIsDefault);
            }
        }

        private void tsbNewSearch_Click(object sender, EventArgs e)
        {   
            var (profileName, iconIndex) = GetSearchDetails(2);
            if (profileName != null && profileName.Trim() != "")
            {
                //New search should not be the default
                GlobalSearchStuff(profileName, iconIndex);
            }
        }

        private void ChangeDefaultProfile(string newName)
        {
            apiConfig.DefaultSearch = newName;
            apiConfig.Save();
        }

        private void CopySearch(string newName, int newIndex, bool deleteOriginal, bool newSearchIsDefault)
        {

            //If we are deleting the original then if it was the default, the renamed profile should be the default
            if (deleteOriginal)
            {
                File.Delete(CurrentProfile.GetFilePath());
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
            CurrentProfile = sp;
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
            sp.Save();

            LoadSearchProfiles();
            CurrentProfile = sp;
            SearchProfileToUI(sp);
            cboSearchProfile.Text = CurrentProfile.ProfileName;
            IterateToolstripButtons(tsbOp.Check, tsbFrequency.Single, tsbType.tsbSearch_Quick_, null, newName);
        }

        private (string profileName, int iconIndex) GetSearchDetails(int searchType)
        {
            string title;
            int startingIndex;
            string startingProfileName;

            switch (searchType)
            {
                case 0: default:
                    title = "Save Current Search As";
                    startingIndex = CurrentProfile.IconIndex.Value;
                    startingProfileName = CurrentProfile.ProfileName;
                    break;
                case 1:
                    title = "Rename Current Search";
                    startingIndex = CurrentProfile.IconIndex.Value;
                    startingProfileName = CurrentProfile.ProfileName;
                    break;
                case 2:
                    title = "New Search";
                    startingIndex = 0;
                    startingProfileName = "";
                    break;
            }

            FormSaveSearchDlg saveDlg = new FormSaveSearchDlg(title,
                startingProfileName, searchType, startingIndex, this.imgToolbar48);
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                return (saveDlg.ProfileName, saveDlg.ImageIndex);
            }

            return ("", 0);
        }
        private bool CheckIfDefaultProfileForDelete()
        {
            if (CurrentProfile.ProfileName == "[Default]")
            {
                MessageBox.Show("Please note you can't delete or rename the [Default] profile, "
                    + "since this is the model profile against which all new profiles are based.",
                    "Cannot Delete Default Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void tsbDeleteSearch_Click(object sender, EventArgs e)
        {
            if (CheckIfDefaultProfileForDelete()) { return;  }

            if (MessageBox.Show("Are you sure you want to delete the currently selected Search Profile?", 
                "Delete Search Profile Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                //If this was the default profile we need to make the [Default] the default profile
                if (CurrentProfile.ProfileName == apiConfig.DefaultSearch)
                {
                    ChangeDefaultProfile("[Default]");
                }

                File.Delete(CurrentProfile.GetFilePath());
                LoadSearchProfiles();
            }
        }
    }
}
