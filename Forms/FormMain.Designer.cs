namespace WOWAuctionApi_Net10
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lvRealms = new ListView();
            colRealms_S = new ColumnHeader();
            colRealms_RealmName = new ColumnHeader();
            colRealms_LastModified = new ColumnHeader();
            colRealms_Auctions = new ColumnHeader();
            toolStripMain = new ToolStrip();
            tsbRefreshAuctionData = new ToolStripButton();
            tsbSearch = new ToolStripButton();
            tsSep1 = new ToolStripSeparator();
            tsbSaveSearch = new ToolStripButton();
            tsbSaveSearchAs = new ToolStripButton();
            tsbRenameSearch = new ToolStripButton();
            tsbNewSearch = new ToolStripButton();
            tsbDeleteSearch = new ToolStripButton();
            tsbSearchDefault = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbUpdateAllData = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            tsbWriteRegionData = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            tsddItemCache = new ToolStripDropDownButton();
            tsmUpdateItemCache = new ToolStripMenuItem();
            tsmSortItemCacheAsc = new ToolStripMenuItem();
            tsmSortItemCacheDesc = new ToolStripMenuItem();
            tsmBuildItemCache = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            tsddPets = new ToolStripDropDownButton();
            tsmUpdatePetCache = new ToolStripMenuItem();
            tsmSortPetCacheAsc = new ToolStripMenuItem();
            tsmSortPetCacheDesc = new ToolStripMenuItem();
            tsmBuildPetCache = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbThemeLight = new ToolStripButton();
            tsbThemeDark = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tspProgress = new ToolStripProgressBar();
            toolStripSeparator4 = new ToolStripSeparator();
            tsbTest = new ToolStripButton();
            tsbRefreshWoWProcesses = new ToolStripButton();
            tsbActivate = new ToolStripButton();
            imgStatus = new ImageList(components);
            imgColorMode = new ImageList(components);
            lvAuctions = new ListView();
            colSide = new ColumnHeader();
            colItemName = new ColumnHeader();
            colLevel = new ColumnHeader();
            colSaleRate = new ColumnHeader();
            colPerc = new ColumnHeader();
            colBuyout = new ColumnHeader();
            colRegion = new ColumnHeader();
            colPetLv = new ColumnHeader();
            colLatestXpac = new ColumnHeader();
            panel1 = new Panel();
            lblIconIndex = new Label();
            btnChangeIcon = new Button();
            picSearchProfile = new PictureBox();
            label11 = new Label();
            tsInToolbar = new ToggleSlider();
            label10 = new Label();
            cboSearchProfile = new ComboBox();
            imgToolbar48 = new ImageList(components);
            pnlSearch_Main = new Panel();
            label1 = new Label();
            txtSearchStringFilter = new TextBox();
            button3 = new Button();
            label14 = new Label();
            label42 = new Label();
            label41 = new Label();
            label40 = new Label();
            label39 = new Label();
            txtSearchMaxItemLevel = new TextBox();
            rbSearch_MaxG = new RadioButton();
            rbSearch_Percentage = new RadioButton();
            txtSearchMinSellRate = new TextBox();
            txtSearchMinItemLevel = new TextBox();
            txtSearchWorth = new TextBox();
            txtSearchMaxG = new TextBox();
            txtSearchPercentage = new TextBox();
            txtSearchThreshold = new TextBox();
            panelSearch_Frequency = new Panel();
            rbSearchShowAllItems = new RadioButton();
            rbSearchShowCheapest = new RadioButton();
            rbSearchRemoveDuplicates = new RadioButton();
            pnlSearch_Class = new Panel();
            button2 = new Button();
            label12 = new Label();
            pnlSearch_Quality = new Panel();
            btnSearch_Quality_OnOff = new Button();
            label13 = new Label();
            panel2 = new Panel();
            tslVersion = new Label();
            tslDataCountPets = new Label();
            tslDataCountItems = new Label();
            tslDataCountRegion = new Label();
            tslQuickSearches = new Label();
            lblProgress = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            btnToggleRealms = new Button();
            chartTotalAuctions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTopSearches = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTotalValue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            toolStripMain.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchProfile).BeginInit();
            pnlSearch_Main.SuspendLayout();
            panelSearch_Frequency.SuspendLayout();
            pnlSearch_Class.SuspendLayout();
            pnlSearch_Quality.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTotalAuctions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTopSearches).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTotalValue).BeginInit();
            SuspendLayout();
            // 
            // lvRealms
            // 
            lvRealms.BackColor = SystemColors.ControlLight;
            lvRealms.CheckBoxes = true;
            lvRealms.Columns.AddRange(new ColumnHeader[] { colRealms_S, colRealms_RealmName, colRealms_LastModified, colRealms_Auctions });
            lvRealms.Font = new Font("Segoe UI", 9F);
            lvRealms.Location = new Point(39, 516);
            lvRealms.Name = "lvRealms";
            lvRealms.Size = new Size(636, 1490);
            lvRealms.TabIndex = 0;
            lvRealms.UseCompatibleStateImageBehavior = false;
            lvRealms.View = View.Details;
            // 
            // colRealms_S
            // 
            colRealms_S.Text = "";
            colRealms_S.Width = 70;
            // 
            // colRealms_RealmName
            // 
            colRealms_RealmName.Text = "Realm Name";
            colRealms_RealmName.Width = 200;
            // 
            // colRealms_LastModified
            // 
            colRealms_LastModified.Text = "Modified";
            colRealms_LastModified.Width = 200;
            // 
            // colRealms_Auctions
            // 
            colRealms_Auctions.Text = "#";
            colRealms_Auctions.Width = 120;
            // 
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new Size(48, 48);
            toolStripMain.Items.AddRange(new ToolStripItem[] { tsbRefreshAuctionData, tsbSearch, tsSep1, tsbSaveSearch, tsbSaveSearchAs, tsbRenameSearch, tsbNewSearch, tsbDeleteSearch, tsbSearchDefault, toolStripSeparator1, tsbUpdateAllData, toolStripSeparator7, tsbWriteRegionData, toolStripSeparator5, tsddItemCache, toolStripSeparator6, tsddPets, toolStripSeparator2, tsbThemeLight, tsbThemeDark, toolStripSeparator3, tspProgress, toolStripSeparator4, tsbTest, tsbRefreshWoWProcesses, tsbActivate });
            toolStripMain.Location = new Point(0, 0);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.RenderMode = ToolStripRenderMode.Professional;
            toolStripMain.Size = new Size(3808, 58);
            toolStripMain.TabIndex = 5;
            toolStripMain.Text = "toolStripMain";
            // 
            // tsbRefreshAuctionData
            // 
            tsbRefreshAuctionData.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRefreshAuctionData.Image = (Image)resources.GetObject("tsbRefreshAuctionData.Image");
            tsbRefreshAuctionData.ImageTransparentColor = Color.Magenta;
            tsbRefreshAuctionData.Name = "tsbRefreshAuctionData";
            tsbRefreshAuctionData.Size = new Size(52, 52);
            tsbRefreshAuctionData.Text = "Refresh Auction Data";
            tsbRefreshAuctionData.Click += tsbRefreshAuctionData_Click;
            // 
            // tsbSearch
            // 
            tsbSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSearch.Image = (Image)resources.GetObject("tsbSearch.Image");
            tsbSearch.ImageTransparentColor = Color.Magenta;
            tsbSearch.Name = "tsbSearch";
            tsbSearch.Size = new Size(52, 52);
            tsbSearch.Text = "Search";
            tsbSearch.Click += tsbSearch_Click;
            // 
            // tsSep1
            // 
            tsSep1.AutoSize = false;
            tsSep1.Name = "tsSep1";
            tsSep1.Size = new Size(60, 58);
            // 
            // tsbSaveSearch
            // 
            tsbSaveSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSaveSearch.Image = (Image)resources.GetObject("tsbSaveSearch.Image");
            tsbSaveSearch.ImageTransparentColor = Color.Magenta;
            tsbSaveSearch.Name = "tsbSaveSearch";
            tsbSaveSearch.Size = new Size(52, 52);
            tsbSaveSearch.Text = "Save Current Search";
            tsbSaveSearch.Click += tsbSaveSearch_Click;
            // 
            // tsbSaveSearchAs
            // 
            tsbSaveSearchAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSaveSearchAs.Image = (Image)resources.GetObject("tsbSaveSearchAs.Image");
            tsbSaveSearchAs.ImageTransparentColor = Color.Magenta;
            tsbSaveSearchAs.Name = "tsbSaveSearchAs";
            tsbSaveSearchAs.Size = new Size(52, 52);
            tsbSaveSearchAs.Text = "Save Current Search As ...";
            tsbSaveSearchAs.Click += tsbSaveSearchAs_Click;
            // 
            // tsbRenameSearch
            // 
            tsbRenameSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRenameSearch.Image = (Image)resources.GetObject("tsbRenameSearch.Image");
            tsbRenameSearch.ImageTransparentColor = Color.Magenta;
            tsbRenameSearch.Name = "tsbRenameSearch";
            tsbRenameSearch.Size = new Size(52, 52);
            tsbRenameSearch.ToolTipText = "Rename Search Profile";
            tsbRenameSearch.Click += tsbRenameSearch_Click;
            // 
            // tsbNewSearch
            // 
            tsbNewSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNewSearch.Image = (Image)resources.GetObject("tsbNewSearch.Image");
            tsbNewSearch.ImageTransparentColor = Color.Magenta;
            tsbNewSearch.Name = "tsbNewSearch";
            tsbNewSearch.Size = new Size(52, 52);
            tsbNewSearch.ToolTipText = "New Search Profile";
            tsbNewSearch.Click += tsbNewSearch_Click;
            // 
            // tsbDeleteSearch
            // 
            tsbDeleteSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeleteSearch.Image = (Image)resources.GetObject("tsbDeleteSearch.Image");
            tsbDeleteSearch.ImageTransparentColor = Color.Magenta;
            tsbDeleteSearch.Name = "tsbDeleteSearch";
            tsbDeleteSearch.Size = new Size(52, 52);
            tsbDeleteSearch.ToolTipText = "Delete Search";
            tsbDeleteSearch.Click += tsbDeleteSearch_Click;
            // 
            // tsbSearchDefault
            // 
            tsbSearchDefault.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSearchDefault.Image = (Image)resources.GetObject("tsbSearchDefault.Image");
            tsbSearchDefault.ImageTransparentColor = Color.Magenta;
            tsbSearchDefault.Name = "tsbSearchDefault";
            tsbSearchDefault.Size = new Size(52, 52);
            tsbSearchDefault.ToolTipText = "Make Search Default";
            tsbSearchDefault.Click += tsbSearchDefault_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.AutoSize = false;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(60, 58);
            // 
            // tsbUpdateAllData
            // 
            tsbUpdateAllData.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbUpdateAllData.Image = (Image)resources.GetObject("tsbUpdateAllData.Image");
            tsbUpdateAllData.ImageTransparentColor = Color.Magenta;
            tsbUpdateAllData.Name = "tsbUpdateAllData";
            tsbUpdateAllData.Size = new Size(52, 52);
            tsbUpdateAllData.Text = "Update All Data";
            tsbUpdateAllData.Click += tsbUpdateAllData_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.AutoSize = false;
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(70, 58);
            // 
            // tsbWriteRegionData
            // 
            tsbWriteRegionData.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbWriteRegionData.Image = (Image)resources.GetObject("tsbWriteRegionData.Image");
            tsbWriteRegionData.ImageTransparentColor = Color.Magenta;
            tsbWriteRegionData.Name = "tsbWriteRegionData";
            tsbWriteRegionData.Size = new Size(52, 52);
            tsbWriteRegionData.Text = "tsbWriteRegionData";
            tsbWriteRegionData.ToolTipText = "Write Region Data";
            tsbWriteRegionData.Click += tsbWriteRegionData_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.AutoSize = false;
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(30, 58);
            // 
            // tsddItemCache
            // 
            tsddItemCache.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsddItemCache.DropDownItems.AddRange(new ToolStripItem[] { tsmUpdateItemCache, tsmSortItemCacheAsc, tsmSortItemCacheDesc, tsmBuildItemCache });
            tsddItemCache.Image = (Image)resources.GetObject("tsddItemCache.Image");
            tsddItemCache.ImageTransparentColor = Color.Magenta;
            tsddItemCache.Name = "tsddItemCache";
            tsddItemCache.Size = new Size(70, 52);
            tsddItemCache.Text = "Item Cache";
            tsddItemCache.ToolTipText = "Item Cache";
            // 
            // tsmUpdateItemCache
            // 
            tsmUpdateItemCache.Image = (Image)resources.GetObject("tsmUpdateItemCache.Image");
            tsmUpdateItemCache.Name = "tsmUpdateItemCache";
            tsmUpdateItemCache.Size = new Size(354, 44);
            tsmUpdateItemCache.Text = "Update Item Cache";
            tsmUpdateItemCache.Click += tsmUpdateItemCache_Click;
            // 
            // tsmSortItemCacheAsc
            // 
            tsmSortItemCacheAsc.Image = (Image)resources.GetObject("tsmSortItemCacheAsc.Image");
            tsmSortItemCacheAsc.Name = "tsmSortItemCacheAsc";
            tsmSortItemCacheAsc.Size = new Size(354, 44);
            tsmSortItemCacheAsc.Text = "Sort (Asc)";
            tsmSortItemCacheAsc.ToolTipText = "Sort (Asc)";
            tsmSortItemCacheAsc.Click += tsmSortItemCacheAsc_Click;
            // 
            // tsmSortItemCacheDesc
            // 
            tsmSortItemCacheDesc.Image = (Image)resources.GetObject("tsmSortItemCacheDesc.Image");
            tsmSortItemCacheDesc.Name = "tsmSortItemCacheDesc";
            tsmSortItemCacheDesc.Size = new Size(354, 44);
            tsmSortItemCacheDesc.Text = "Sort (Desc)";
            tsmSortItemCacheDesc.Click += tsmSortItemCacheDesc_Click;
            // 
            // tsmBuildItemCache
            // 
            tsmBuildItemCache.Image = (Image)resources.GetObject("tsmBuildItemCache.Image");
            tsmBuildItemCache.Name = "tsmBuildItemCache";
            tsmBuildItemCache.Size = new Size(354, 44);
            tsmBuildItemCache.Text = "Rebuild Item Cache";
            tsmBuildItemCache.Click += tsmBuildItemCache_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.AutoSize = false;
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(10, 58);
            // 
            // tsddPets
            // 
            tsddPets.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsddPets.DropDownItems.AddRange(new ToolStripItem[] { tsmUpdatePetCache, tsmSortPetCacheAsc, tsmSortPetCacheDesc, tsmBuildPetCache });
            tsddPets.Image = (Image)resources.GetObject("tsddPets.Image");
            tsddPets.ImageTransparentColor = Color.Magenta;
            tsddPets.Name = "tsddPets";
            tsddPets.Size = new Size(70, 52);
            tsddPets.Text = "Pet Cache";
            tsddPets.ToolTipText = "Pet Cache";
            // 
            // tsmUpdatePetCache
            // 
            tsmUpdatePetCache.Image = (Image)resources.GetObject("tsmUpdatePetCache.Image");
            tsmUpdatePetCache.Name = "tsmUpdatePetCache";
            tsmUpdatePetCache.Size = new Size(339, 44);
            tsmUpdatePetCache.Text = "Update Pet Cache";
            tsmUpdatePetCache.Click += tsmUpdatePetCache_Click;
            // 
            // tsmSortPetCacheAsc
            // 
            tsmSortPetCacheAsc.Image = (Image)resources.GetObject("tsmSortPetCacheAsc.Image");
            tsmSortPetCacheAsc.Name = "tsmSortPetCacheAsc";
            tsmSortPetCacheAsc.Size = new Size(339, 44);
            tsmSortPetCacheAsc.Text = "Sort (Asc)";
            tsmSortPetCacheAsc.ToolTipText = "Sort (Asc)";
            tsmSortPetCacheAsc.Click += tsmSortPetCacheAsc_Click;
            // 
            // tsmSortPetCacheDesc
            // 
            tsmSortPetCacheDesc.Image = (Image)resources.GetObject("tsmSortPetCacheDesc.Image");
            tsmSortPetCacheDesc.Name = "tsmSortPetCacheDesc";
            tsmSortPetCacheDesc.Size = new Size(339, 44);
            tsmSortPetCacheDesc.Text = "Sort (Desc)";
            tsmSortPetCacheDesc.Click += tsmSortPetCacheDesc_Click;
            // 
            // tsmBuildPetCache
            // 
            tsmBuildPetCache.Image = (Image)resources.GetObject("tsmBuildPetCache.Image");
            tsmBuildPetCache.Name = "tsmBuildPetCache";
            tsmBuildPetCache.Size = new Size(339, 44);
            tsmBuildPetCache.Text = "Rebuild Pet Cache";
            tsmBuildPetCache.Click += tsmBuildPetCache_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.AutoSize = false;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(60, 58);
            // 
            // tsbThemeLight
            // 
            tsbThemeLight.Checked = true;
            tsbThemeLight.CheckState = CheckState.Checked;
            tsbThemeLight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbThemeLight.Image = (Image)resources.GetObject("tsbThemeLight.Image");
            tsbThemeLight.ImageTransparentColor = Color.Magenta;
            tsbThemeLight.Name = "tsbThemeLight";
            tsbThemeLight.Size = new Size(52, 52);
            tsbThemeLight.ToolTipText = "Light Theme";
            tsbThemeLight.Click += tsbThemeLight_Click;
            // 
            // tsbThemeDark
            // 
            tsbThemeDark.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbThemeDark.Image = (Image)resources.GetObject("tsbThemeDark.Image");
            tsbThemeDark.ImageTransparentColor = Color.Magenta;
            tsbThemeDark.Name = "tsbThemeDark";
            tsbThemeDark.Size = new Size(52, 52);
            tsbThemeDark.Text = "tsbDarkTheme";
            tsbThemeDark.ToolTipText = "Dark Theme";
            tsbThemeDark.Click += tsbThemeDark_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.AutoSize = false;
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(60, 58);
            // 
            // tspProgress
            // 
            tspProgress.AutoSize = false;
            tspProgress.Name = "tspProgress";
            tspProgress.Size = new Size(1300, 32);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.AutoSize = false;
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(60, 58);
            // 
            // tsbTest
            // 
            tsbTest.Alignment = ToolStripItemAlignment.Right;
            tsbTest.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbTest.Image = (Image)resources.GetObject("tsbTest.Image");
            tsbTest.ImageTransparentColor = Color.Magenta;
            tsbTest.Name = "tsbTest";
            tsbTest.Size = new Size(52, 52);
            tsbTest.Text = "Testing";
            tsbTest.Visible = false;
            tsbTest.Click += tsbTest_Click;
            // 
            // tsbRefreshWoWProcesses
            // 
            tsbRefreshWoWProcesses.Alignment = ToolStripItemAlignment.Right;
            tsbRefreshWoWProcesses.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRefreshWoWProcesses.Image = (Image)resources.GetObject("tsbRefreshWoWProcesses.Image");
            tsbRefreshWoWProcesses.ImageTransparentColor = Color.Magenta;
            tsbRefreshWoWProcesses.Name = "tsbRefreshWoWProcesses";
            tsbRefreshWoWProcesses.Size = new Size(52, 52);
            tsbRefreshWoWProcesses.Text = "Refresh Wow Processes";
            tsbRefreshWoWProcesses.Visible = false;
            tsbRefreshWoWProcesses.Click += tsbRefreshWoWProcesses_Click;
            // 
            // tsbActivate
            // 
            tsbActivate.Alignment = ToolStripItemAlignment.Right;
            tsbActivate.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbActivate.Image = (Image)resources.GetObject("tsbActivate.Image");
            tsbActivate.ImageTransparentColor = Color.Magenta;
            tsbActivate.Name = "tsbActivate";
            tsbActivate.Size = new Size(52, 52);
            tsbActivate.Text = "Testing";
            tsbActivate.Visible = false;
            tsbActivate.Click += tsbActivate_Click;
            // 
            // imgStatus
            // 
            imgStatus.ColorDepth = ColorDepth.Depth32Bit;
            imgStatus.ImageStream = (ImageListStreamer)resources.GetObject("imgStatus.ImageStream");
            imgStatus.TransparentColor = Color.Transparent;
            imgStatus.Images.SetKeyName(0, "0009=u=nav_plain_blue.png");
            imgStatus.Images.SetKeyName(1, "0034=u=nav_plain_red.png");
            imgStatus.Images.SetKeyName(2, "0007=u=nav_plain_yellow.png");
            imgStatus.Images.SetKeyName(3, "0033=u=nav_plain_green.png");
            // 
            // imgColorMode
            // 
            imgColorMode.ColorDepth = ColorDepth.Depth32Bit;
            imgColorMode.ImageStream = (ImageListStreamer)resources.GetObject("imgColorMode.ImageStream");
            imgColorMode.TransparentColor = Color.Transparent;
            imgColorMode.Images.SetKeyName(0, "window_sidebar.png");
            imgColorMode.Images.SetKeyName(1, "moon_half.png");
            imgColorMode.Images.SetKeyName(2, "sun.png");
            // 
            // lvAuctions
            // 
            lvAuctions.BackColor = SystemColors.Control;
            lvAuctions.Columns.AddRange(new ColumnHeader[] { colSide, colItemName, colLevel, colSaleRate, colPerc, colBuyout, colRegion, colPetLv, colLatestXpac });
            lvAuctions.Font = new Font("Segoe UI", 9F);
            lvAuctions.FullRowSelect = true;
            lvAuctions.Location = new Point(717, 516);
            lvAuctions.Name = "lvAuctions";
            lvAuctions.Size = new Size(1733, 1490);
            lvAuctions.TabIndex = 100;
            lvAuctions.UseCompatibleStateImageBehavior = false;
            lvAuctions.View = View.Details;
            lvAuctions.DoubleClick += lvAuctions_DoubleClick;
            lvAuctions.KeyPress += lvAuctions_KeyPress;
            // 
            // colSide
            // 
            colSide.Text = "";
            colSide.Width = 40;
            // 
            // colItemName
            // 
            colItemName.Text = "Item Name";
            colItemName.Width = 700;
            // 
            // colLevel
            // 
            colLevel.Text = "Level";
            colLevel.Width = 100;
            // 
            // colSaleRate
            // 
            colSaleRate.Text = "Sale Rate";
            colSaleRate.Width = 120;
            // 
            // colPerc
            // 
            colPerc.Text = "%";
            colPerc.Width = 120;
            // 
            // colBuyout
            // 
            colBuyout.Text = "Buyout";
            colBuyout.Width = 170;
            // 
            // colRegion
            // 
            colRegion.Text = "Region";
            colRegion.Width = 170;
            // 
            // colPetLv
            // 
            colPetLv.Text = "Pet Level";
            colPetLv.Width = 120;
            // 
            // colLatestXpac
            // 
            colLatestXpac.Text = "Latest Xpac";
            colLatestXpac.Width = 150;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblIconIndex);
            panel1.Controls.Add(btnChangeIcon);
            panel1.Controls.Add(picSearchProfile);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(tsInToolbar);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cboSearchProfile);
            panel1.Location = new Point(39, 148);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 330);
            panel1.TabIndex = 101;
            // 
            // lblIconIndex
            // 
            lblIconIndex.AutoSize = true;
            lblIconIndex.Location = new Point(92, 195);
            lblIconIndex.Name = "lblIconIndex";
            lblIconIndex.Size = new Size(27, 32);
            lblIconIndex.TabIndex = 133;
            lblIconIndex.Text = "0";
            // 
            // btnChangeIcon
            // 
            btnChangeIcon.Location = new Point(30, 248);
            btnChangeIcon.Name = "btnChangeIcon";
            btnChangeIcon.Size = new Size(245, 46);
            btnChangeIcon.TabIndex = 132;
            btnChangeIcon.Text = "Change Icon";
            btnChangeIcon.UseVisualStyleBackColor = true;
            btnChangeIcon.Click += btnChangeIcon_Click;
            // 
            // picSearchProfile
            // 
            picSearchProfile.Location = new Point(30, 187);
            picSearchProfile.Name = "picSearchProfile";
            picSearchProfile.Size = new Size(48, 48);
            picSearchProfile.TabIndex = 130;
            picSearchProfile.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.ForeColor = Color.DarkOrchid;
            label11.Location = new Point(92, 120);
            label11.Name = "label11";
            label11.Size = new Size(120, 32);
            label11.TabIndex = 129;
            label11.Text = "In Toolbar";
            // 
            // tsInToolbar
            // 
            tsInToolbar.Checked = true;
            tsInToolbar.CheckState = CheckState.Checked;
            tsInToolbar.ForeColor = Color.LimeGreen;
            tsInToolbar.Location = new Point(30, 121);
            tsInToolbar.MinimumSize = new Size(45, 22);
            tsInToolbar.Name = "tsInToolbar";
            tsInToolbar.OffBackColor = Color.Gray;
            tsInToolbar.OffToggleColor = Color.Gainsboro;
            tsInToolbar.OnBackColor = Color.DarkOrchid;
            tsInToolbar.OnToggleColor = Color.Honeydew;
            tsInToolbar.OptionBit = 0;
            tsInToolbar.OptionValue = "";
            tsInToolbar.Size = new Size(60, 32);
            tsInToolbar.TabIndex = 128;
            tsInToolbar.Tag = "256";
            tsInToolbar.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.BackColor = SystemColors.ControlDark;
            label10.Dock = DockStyle.Top;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(300, 40);
            label10.TabIndex = 127;
            label10.Text = "  Search Profile";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboSearchProfile
            // 
            cboSearchProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchProfile.FormattingEnabled = true;
            cboSearchProfile.Location = new Point(30, 59);
            cboSearchProfile.Name = "cboSearchProfile";
            cboSearchProfile.Size = new Size(245, 40);
            cboSearchProfile.TabIndex = 99;
            cboSearchProfile.SelectedIndexChanged += cboSearchProfile_SelectedIndexChanged;
            // 
            // imgToolbar48
            // 
            imgToolbar48.ColorDepth = ColorDepth.Depth32Bit;
            imgToolbar48.ImageStream = (ImageListStreamer)resources.GetObject("imgToolbar48.ImageStream");
            imgToolbar48.TransparentColor = Color.Transparent;
            imgToolbar48.Images.SetKeyName(0, "0000=unknown.png");
            imgToolbar48.Images.SetKeyName(1, "0001=u=target3.png");
            imgToolbar48.Images.SetKeyName(2, "0002=u=mail_ok.png");
            imgToolbar48.Images.SetKeyName(3, "0003=u=delete.png");
            imgToolbar48.Images.SetKeyName(4, "0004=u=keyboard_key.png");
            imgToolbar48.Images.SetKeyName(5, "0005=u=mouse.png");
            imgToolbar48.Images.SetKeyName(6, "0006=u=monitor_preferences.png");
            imgToolbar48.Images.SetKeyName(7, "0007=u=nav_plain_yellow.png");
            imgToolbar48.Images.SetKeyName(8, "0008=u=cup.png");
            imgToolbar48.Images.SetKeyName(9, "0009=u=nav_plain_blue.png");
            imgToolbar48.Images.SetKeyName(10, "0010=u=media_play_green.png");
            imgToolbar48.Images.SetKeyName(11, "0011=u=earth.png");
            imgToolbar48.Images.SetKeyName(12, "0012=u=lock2.png");
            imgToolbar48.Images.SetKeyName(13, "0013=b=dire maul.png");
            imgToolbar48.Images.SetKeyName(14, "0014=b=hellfire ramparts.png");
            imgToolbar48.Images.SetKeyName(15, "0015=b=hyperspawn.png");
            imgToolbar48.Images.SetKeyName(16, "0016=b=iron docks.png");
            imgToolbar48.Images.SetKeyName(17, "0017=b=magisters terrace.png");
            imgToolbar48.Images.SetKeyName(18, "0018=b=scarlet monastery.png");
            imgToolbar48.Images.SetKeyName(19, "0019=b=scholomance.png");
            imgToolbar48.Images.SetKeyName(20, "0020=b=stratholme.png");
            imgToolbar48.Images.SetKeyName(21, "0021=b=uldaman.png");
            imgToolbar48.Images.SetKeyName(22, "0022=b=zul farrak.png");
            imgToolbar48.Images.SetKeyName(23, "0023=a=arrow_up_green.png");
            imgToolbar48.Images.SetKeyName(24, "0024=a=arrow_left_green.png");
            imgToolbar48.Images.SetKeyName(25, "0025=a=arrow_right_green.png");
            imgToolbar48.Images.SetKeyName(26, "0026=a=arrow_down_green.png");
            imgToolbar48.Images.SetKeyName(27, "0027=a=arrow_left_red.png");
            imgToolbar48.Images.SetKeyName(28, "0028=a=arrow_right_red.png");
            imgToolbar48.Images.SetKeyName(29, "0029=a=arrow_down_red.png");
            imgToolbar48.Images.SetKeyName(30, "0030=a=arrow_up_left_blue.png");
            imgToolbar48.Images.SetKeyName(31, "0031=a=arrow_up_right_blue.png");
            imgToolbar48.Images.SetKeyName(32, "0032=u=console_ok.png");
            imgToolbar48.Images.SetKeyName(33, "0033=u=nav_plain_green.png");
            imgToolbar48.Images.SetKeyName(34, "0034=u=nav_plain_red.png");
            imgToolbar48.Images.SetKeyName(35, "0035=u=about.png");
            imgToolbar48.Images.SetKeyName(36, "0036=u=books.png");
            imgToolbar48.Images.SetKeyName(37, "0037=u=breakpoint_new.png");
            imgToolbar48.Images.SetKeyName(38, "0038=u=calendar_1.png");
            imgToolbar48.Images.SetKeyName(39, "0039=u=data_up.png");
            imgToolbar48.Images.SetKeyName(40, "0040=u=disk_blue.png");
            imgToolbar48.Images.SetKeyName(41, "0041=u=edit.png");
            imgToolbar48.Images.SetKeyName(42, "0042=u=folder.png");
            imgToolbar48.Images.SetKeyName(43, "0043=u=icon.png");
            imgToolbar48.Images.SetKeyName(44, "0044=u=palette.png");
            imgToolbar48.Images.SetKeyName(45, "0045=u=pencil.png");
            imgToolbar48.Images.SetKeyName(46, "0046=u=photo_scenery.png");
            imgToolbar48.Images.SetKeyName(47, "0047=u=refresh.png");
            imgToolbar48.Images.SetKeyName(48, "0048=u=robot.png");
            imgToolbar48.Images.SetKeyName(49, "0049=u=wrench.png");
            imgToolbar48.Images.SetKeyName(50, "0050=a=ability_druid_catform.png");
            imgToolbar48.Images.SetKeyName(51, "0051=a=ability_druid_dash_orange.png");
            imgToolbar48.Images.SetKeyName(52, "0052=a=ability_druid_travelform.png");
            imgToolbar48.Images.SetKeyName(53, "0053=a=ability_hunter_beastsoothe.png");
            imgToolbar48.Images.SetKeyName(54, "0054=a=ability_racial_bearform.png");
            imgToolbar48.Images.SetKeyName(55, "0055=a=alarmclock_pause.png");
            imgToolbar48.Images.SetKeyName(56, "0056=a=cubes.png");
            imgToolbar48.Images.SetKeyName(57, "0057=a=inv_misc_coin_02.png");
            imgToolbar48.Images.SetKeyName(58, "0058=a=inv_misc_monsterclaw_03.png");
            imgToolbar48.Images.SetKeyName(59, "0059=a=inv_misc_selfiecamera_01.png");
            imgToolbar48.Images.SetKeyName(60, "0060=a=keyboard_key.png");
            imgToolbar48.Images.SetKeyName(61, "0061=a=monitor_preferences.png");
            imgToolbar48.Images.SetKeyName(62, "0062=a=recycle.png");
            imgToolbar48.Images.SetKeyName(63, "0063=a=spell_arcane_teleportstormwind.png");
            imgToolbar48.Images.SetKeyName(64, "0064=a=spell_druid_stampedingroar_cat.png");
            imgToolbar48.Images.SetKeyName(65, "0065=a=spell_nature_starfall.png");
            imgToolbar48.Images.SetKeyName(66, "0066=a=vendor.png");
            imgToolbar48.Images.SetKeyName(67, "0067=u=colors.png");
            imgToolbar48.Images.SetKeyName(68, "0068=u=colorwheel.png");
            imgToolbar48.Images.SetKeyName(69, "0069=u=checkbox.png");
            imgToolbar48.Images.SetKeyName(70, "0070=u=cubes_blue_add.png");
            imgToolbar48.Images.SetKeyName(71, "0071=u=folder_cubes.png");
            imgToolbar48.Images.SetKeyName(72, "0072=u=note_new.png");
            imgToolbar48.Images.SetKeyName(73, "0073=u=note_ok.png");
            imgToolbar48.Images.SetKeyName(74, "0074=u=postage_stamp.png");
            imgToolbar48.Images.SetKeyName(75, "0075=u=shut_down.png");
            imgToolbar48.Images.SetKeyName(76, "0076=u=text_tree.png");
            imgToolbar48.Images.SetKeyName(77, "0077=u=tree.png");
            imgToolbar48.Images.SetKeyName(78, "0078=u=window_split_hor.png");
            imgToolbar48.Images.SetKeyName(79, "0079=u=window_split_ver.png");
            imgToolbar48.Images.SetKeyName(80, "0080=u=data_disk.png");
            imgToolbar48.Images.SetKeyName(81, "0081=u=disk_green.png");
            imgToolbar48.Images.SetKeyName(82, "0082=u=disk_yellow.png");
            imgToolbar48.Images.SetKeyName(83, "0083=u=disks.png");
            imgToolbar48.Images.SetKeyName(84, "0084=u=font.png");
            imgToolbar48.Images.SetKeyName(85, "0085=b=deadmines.png");
            imgToolbar48.Images.SetKeyName(86, "0086=u=note_add.png");
            imgToolbar48.Images.SetKeyName(87, "0087=u=note_delete.png");
            imgToolbar48.Images.SetKeyName(88, "0088=u=note_edit.png");
            imgToolbar48.Images.SetKeyName(89, "0089=u=note_error.png");
            imgToolbar48.Images.SetKeyName(90, "0090=u=clock.png");
            imgToolbar48.Images.SetKeyName(91, "0091=u=keyboard_key_clock.png");
            imgToolbar48.Images.SetKeyName(92, "0092=u=users4.png");
            imgToolbar48.Images.SetKeyName(93, "0093=u=code_csharp.png");
            imgToolbar48.Images.SetKeyName(94, "0094=u=wow1.png");
            imgToolbar48.Images.SetKeyName(95, "0095=u=window.png");
            imgToolbar48.Images.SetKeyName(96, "0096=u=window_black.png");
            imgToolbar48.Images.SetKeyName(97, "0097=u=window_colors.png");
            imgToolbar48.Images.SetKeyName(98, "0098=u=window_colors2.png");
            imgToolbar48.Images.SetKeyName(99, "0099=u=window_delete.png");
            imgToolbar48.Images.SetKeyName(100, "0100=u=window_dialog.png");
            imgToolbar48.Images.SetKeyName(101, "0101=u=window_edit.png");
            imgToolbar48.Images.SetKeyName(102, "0102=u=window_equalizer.png");
            imgToolbar48.Images.SetKeyName(103, "0103=u=window_font.png");
            imgToolbar48.Images.SetKeyName(104, "0104=u=window_gear.png");
            imgToolbar48.Images.SetKeyName(105, "0105=u=window_height.png");
            imgToolbar48.Images.SetKeyName(106, "0106=u=window_new.png");
            imgToolbar48.Images.SetKeyName(107, "0107=u=window_oscillograph.png");
            imgToolbar48.Images.SetKeyName(108, "0108=u=window_sidebar.png");
            imgToolbar48.Images.SetKeyName(109, "0109=u=window_size.png");
            imgToolbar48.Images.SetKeyName(110, "0110=u=window_split_hor.png");
            imgToolbar48.Images.SetKeyName(111, "0111=u=window_split_ver.png");
            imgToolbar48.Images.SetKeyName(112, "0112=u=window_sidebar.png");
            imgToolbar48.Images.SetKeyName(113, "0113=u=window_star.png");
            imgToolbar48.Images.SetKeyName(114, "0114=u=window_width.png");
            imgToolbar48.Images.SetKeyName(115, "0115=u=windows.png");
            imgToolbar48.Images.SetKeyName(116, "0116=u=window_ok.png");
            imgToolbar48.Images.SetKeyName(117, "0117=u=window_preferences.png");
            imgToolbar48.Images.SetKeyName(118, "0118=u=window_test_card.png");
            imgToolbar48.Images.SetKeyName(119, "0119=u=calculator1.png");
            imgToolbar48.Images.SetKeyName(120, "0120=u=calculator2.png");
            imgToolbar48.Images.SetKeyName(121, "0121=u=document_edit.png");
            imgToolbar48.Images.SetKeyName(122, "0122=u=replace2.png");
            imgToolbar48.Images.SetKeyName(123, "0123=u=selection_replace.png");
            imgToolbar48.Images.SetKeyName(124, "0124=p=users_family.png");
            imgToolbar48.Images.SetKeyName(125, "0125=p=users1.png");
            imgToolbar48.Images.SetKeyName(126, "0126=p=users2.png");
            imgToolbar48.Images.SetKeyName(127, "0127=p=users3.png");
            imgToolbar48.Images.SetKeyName(128, "0128=p=users4.png");
            imgToolbar48.Images.SetKeyName(129, "0129=p=angel.png");
            imgToolbar48.Images.SetKeyName(130, "0130=p=astrologer.png");
            imgToolbar48.Images.SetKeyName(131, "0131=p=businessman.png");
            imgToolbar48.Images.SetKeyName(132, "0132=p=businessman2.png");
            imgToolbar48.Images.SetKeyName(133, "0133=p=doctor.png");
            imgToolbar48.Images.SetKeyName(134, "0134=p=dude1.png");
            imgToolbar48.Images.SetKeyName(135, "0135=p=dude2.png");
            imgToolbar48.Images.SetKeyName(136, "0136=p=dude3.png");
            imgToolbar48.Images.SetKeyName(137, "0137=p=dude4.png");
            imgToolbar48.Images.SetKeyName(138, "0138=p=dude5.png");
            imgToolbar48.Images.SetKeyName(139, "0139=p=dude6.png");
            imgToolbar48.Images.SetKeyName(140, "0140=p=genius.png");
            imgToolbar48.Images.SetKeyName(141, "0141=p=graduate.png");
            imgToolbar48.Images.SetKeyName(142, "0142=p=guard.png");
            imgToolbar48.Images.SetKeyName(143, "0143=p=holmes.png");
            imgToolbar48.Images.SetKeyName(144, "0144=p=knight.png");
            imgToolbar48.Images.SetKeyName(145, "0145=p=knight2.png");
            imgToolbar48.Images.SetKeyName(146, "0146=p=magician.png");
            imgToolbar48.Images.SetKeyName(147, "0147=p=nurse1.png");
            imgToolbar48.Images.SetKeyName(148, "0148=p=nurse2.png");
            imgToolbar48.Images.SetKeyName(149, "0149=p=pastor.png");
            imgToolbar48.Images.SetKeyName(150, "0150=p=pilot1.png");
            imgToolbar48.Images.SetKeyName(151, "0151=p=pilot2.png");
            imgToolbar48.Images.SetKeyName(152, "0152=p=policeman_bobby.png");
            imgToolbar48.Images.SetKeyName(153, "0153=p=policeman_german.png");
            imgToolbar48.Images.SetKeyName(154, "0154=p=policeman_usa.png");
            imgToolbar48.Images.SetKeyName(155, "0155=p=pontifex.png");
            imgToolbar48.Images.SetKeyName(156, "0156=p=robber.png");
            imgToolbar48.Images.SetKeyName(157, "0157=p=schoolboy.png");
            imgToolbar48.Images.SetKeyName(158, "0158=p=scientist.png");
            imgToolbar48.Images.SetKeyName(159, "0159=p=security_agent.png");
            imgToolbar48.Images.SetKeyName(160, "0160=p=senior_citizen1.png");
            imgToolbar48.Images.SetKeyName(161, "0161=p=senior_citizen2.png");
            imgToolbar48.Images.SetKeyName(162, "0162=p=spy.png");
            imgToolbar48.Images.SetKeyName(163, "0163=p=surgeon1.png");
            imgToolbar48.Images.SetKeyName(164, "0164=p=surgeon2.png");
            imgToolbar48.Images.SetKeyName(165, "0165=p=user1.png");
            imgToolbar48.Images.SetKeyName(166, "0166=p=user2.png");
            imgToolbar48.Images.SetKeyName(167, "0167=p=user3.png");
            imgToolbar48.Images.SetKeyName(168, "0168=p=user_headphones.png");
            imgToolbar48.Images.SetKeyName(169, "0169=p=user_headset.png");
            imgToolbar48.Images.SetKeyName(170, "0170=p=woman1.png");
            imgToolbar48.Images.SetKeyName(171, "0171=p=woman2.png");
            imgToolbar48.Images.SetKeyName(172, "0172=p=woman3.png");
            imgToolbar48.Images.SetKeyName(173, "0173=p=woman4.png");
            imgToolbar48.Images.SetKeyName(174, "0174=p=worker.png");
            imgToolbar48.Images.SetKeyName(175, "0175=p=worker2.png");
            imgToolbar48.Images.SetKeyName(176, "0176=p=users3_add.png");
            imgToolbar48.Images.SetKeyName(177, "0177=u=star_yellow.png");
            imgToolbar48.Images.SetKeyName(178, "0178=p=users3_delete.png");
            imgToolbar48.Images.SetKeyName(179, "0179=p=users3_edit.png");
            imgToolbar48.Images.SetKeyName(180, "0180=p=users3_preferences.png");
            imgToolbar48.Images.SetKeyName(181, "0181=u=note.png");
            imgToolbar48.Images.SetKeyName(182, "0182=u=message.png");
            imgToolbar48.Images.SetKeyName(183, "0183=u=application_view_gallery.png");
            imgToolbar48.Images.SetKeyName(184, "0184=u=application_view_icons.png");
            imgToolbar48.Images.SetKeyName(185, "0185=u=application_view_tile.png");
            imgToolbar48.Images.SetKeyName(186, "0186=u=application_view_list.png");
            imgToolbar48.Images.SetKeyName(187, "0187=u=application_view_detail.png");
            imgToolbar48.Images.SetKeyName(188, "0188=u=pictures.png");
            imgToolbar48.Images.SetKeyName(189, "0189=u=apple16.png");
            imgToolbar48.Images.SetKeyName(190, "0190=u=apple24.png");
            imgToolbar48.Images.SetKeyName(191, "0191=u=apple32.png");
            imgToolbar48.Images.SetKeyName(192, "0192=u=apple48.png");
            imgToolbar48.Images.SetKeyName(193, "0193=u=back.png");
            imgToolbar48.Images.SetKeyName(194, "0194=u=front.png");
            imgToolbar48.Images.SetKeyName(195, "0195=u=information2.png");
            imgToolbar48.Images.SetKeyName(196, "0196=u=server.png");
            imgToolbar48.Images.SetKeyName(197, "0197=u=horde.png");
            imgToolbar48.Images.SetKeyName(198, "0198=u=alliance.png");
            imgToolbar48.Images.SetKeyName(199, "0199=u=text_align_left.png");
            imgToolbar48.Images.SetKeyName(200, "0200=u=text_code_colored.png");
            imgToolbar48.Images.SetKeyName(201, "0201=u=text_view.png");
            imgToolbar48.Images.SetKeyName(202, "0202=u=element_next.png");
            imgToolbar48.Images.SetKeyName(203, "0203=u=element_stop.png");
            imgToolbar48.Images.SetKeyName(204, "0204=u=elements_selection.png");
            imgToolbar48.Images.SetKeyName(205, "0205=u=elements1.png");
            imgToolbar48.Images.SetKeyName(206, "0206=u=elements2.png");
            imgToolbar48.Images.SetKeyName(207, "0207=u=user1_time.png");
            imgToolbar48.Images.SetKeyName(208, "0208=b=razorfen kraul.png");
            imgToolbar48.Images.SetKeyName(209, "0209=u=cubes_blue_delete.png");
            imgToolbar48.Images.SetKeyName(210, "0210=u=cubes_blue_edit.png");
            imgToolbar48.Images.SetKeyName(211, "0211=b=blackrock depths.png");
            imgToolbar48.Images.SetKeyName(212, "0212=b=gnomeregan.png");
            imgToolbar48.Images.SetKeyName(213, "0213=b=maraudon.png");
            imgToolbar48.Images.SetKeyName(214, "0214=b=razorfen downs.png");
            imgToolbar48.Images.SetKeyName(215, "0215=b=wailing caverns.png");
            imgToolbar48.Images.SetKeyName(216, "0216=b=blackfathom deeps.png");
            imgToolbar48.Images.SetKeyName(217, "0217=b=sunken temple.png");
            imgToolbar48.Images.SetKeyName(218, "0218=u=videocamera.png");
            imgToolbar48.Images.SetKeyName(219, "0219=u=window_logon.png");
            imgToolbar48.Images.SetKeyName(220, "0220=b=lower blackrock spire.png");
            imgToolbar48.Images.SetKeyName(221, "0221=BLANK_ICON.png");
            imgToolbar48.Images.SetKeyName(222, "0222=b=ahn'kahet.png");
            imgToolbar48.Images.SetKeyName(223, "0223=b=mana tombs.png");
            imgToolbar48.Images.SetKeyName(224, "0224=b=shadowfang keep.png");
            imgToolbar48.Images.SetKeyName(225, "bird.png");
            imgToolbar48.Images.SetKeyName(226, "cubes.png");
            imgToolbar48.Images.SetKeyName(227, "cubes_blue.png");
            imgToolbar48.Images.SetKeyName(228, "cubes_blue_add.png");
            imgToolbar48.Images.SetKeyName(229, "cubes_green.png");
            imgToolbar48.Images.SetKeyName(230, "cubes_red.png");
            imgToolbar48.Images.SetKeyName(231, "cubes_yellow.png");
            imgToolbar48.Images.SetKeyName(232, "database_upload.png");
            imgToolbar48.Images.SetKeyName(233, "dollar_coin.png");
            imgToolbar48.Images.SetKeyName(234, "edit_page.png");
            imgToolbar48.Images.SetKeyName(235, "flash_yellow_edit.png");
            imgToolbar48.Images.SetKeyName(236, "floppy_disk.png");
            imgToolbar48.Images.SetKeyName(237, "floppy_disk_blue.png");
            imgToolbar48.Images.SetKeyName(238, "floppy_disk_delete.png");
            imgToolbar48.Images.SetKeyName(239, "folder_cubes.png");
            imgToolbar48.Images.SetKeyName(240, "form_blue_edit.png");
            imgToolbar48.Images.SetKeyName(241, "form_green_edit.png");
            imgToolbar48.Images.SetKeyName(242, "form_yellow_edit.png");
            imgToolbar48.Images.SetKeyName(243, "moon_half.png");
            imgToolbar48.Images.SetKeyName(244, "nav_refresh_blue.png");
            imgToolbar48.Images.SetKeyName(245, "nav_refresh_yellow.png");
            imgToolbar48.Images.SetKeyName(246, "palette.png");
            imgToolbar48.Images.SetKeyName(247, "refresh.png");
            imgToolbar48.Images.SetKeyName(248, "refresh_page.png");
            imgToolbar48.Images.SetKeyName(249, "replace2.png");
            imgToolbar48.Images.SetKeyName(250, "save.png");
            imgToolbar48.Images.SetKeyName(251, "save_as.png");
            imgToolbar48.Images.SetKeyName(252, "search.png");
            imgToolbar48.Images.SetKeyName(253, "shopping_cart.png");
            imgToolbar48.Images.SetKeyName(254, "sort_az_descending.png");
            imgToolbar48.Images.SetKeyName(255, "sun.png");
            imgToolbar48.Images.SetKeyName(256, "text_tree.png");
            imgToolbar48.Images.SetKeyName(257, "tools.png");
            imgToolbar48.Images.SetKeyName(258, "window_sidebar.png");
            imgToolbar48.Images.SetKeyName(259, "star_empty.png");
            imgToolbar48.Images.SetKeyName(260, "star_full.png");
            // 
            // pnlSearch_Main
            // 
            pnlSearch_Main.BackColor = SystemColors.ControlLight;
            pnlSearch_Main.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch_Main.Controls.Add(label1);
            pnlSearch_Main.Controls.Add(txtSearchStringFilter);
            pnlSearch_Main.Controls.Add(button3);
            pnlSearch_Main.Controls.Add(label14);
            pnlSearch_Main.Controls.Add(label42);
            pnlSearch_Main.Controls.Add(label41);
            pnlSearch_Main.Controls.Add(label40);
            pnlSearch_Main.Controls.Add(label39);
            pnlSearch_Main.Controls.Add(txtSearchMaxItemLevel);
            pnlSearch_Main.Controls.Add(rbSearch_MaxG);
            pnlSearch_Main.Controls.Add(rbSearch_Percentage);
            pnlSearch_Main.Controls.Add(txtSearchMinSellRate);
            pnlSearch_Main.Controls.Add(txtSearchMinItemLevel);
            pnlSearch_Main.Controls.Add(txtSearchWorth);
            pnlSearch_Main.Controls.Add(txtSearchMaxG);
            pnlSearch_Main.Controls.Add(txtSearchPercentage);
            pnlSearch_Main.Controls.Add(txtSearchThreshold);
            pnlSearch_Main.Controls.Add(panelSearch_Frequency);
            pnlSearch_Main.Location = new Point(391, 148);
            pnlSearch_Main.Name = "pnlSearch_Main";
            pnlSearch_Main.Size = new Size(953, 330);
            pnlSearch_Main.TabIndex = 104;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(675, 230);
            label1.Name = "label1";
            label1.Size = new Size(136, 32);
            label1.TabIndex = 130;
            label1.Text = "String Filter";
            // 
            // txtSearchStringFilter
            // 
            txtSearchStringFilter.Location = new Point(675, 273);
            txtSearchStringFilter.Name = "txtSearchStringFilter";
            txtSearchStringFilter.Size = new Size(261, 39);
            txtSearchStringFilter.TabIndex = 129;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDark;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(2, 2);
            button3.Name = "button3";
            button3.Size = new Size(36, 36);
            button3.TabIndex = 127;
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnSearch_TogglesOnOff_Click;
            // 
            // label14
            // 
            label14.BackColor = SystemColors.ControlDark;
            label14.Dock = DockStyle.Top;
            label14.Location = new Point(0, 0);
            label14.Name = "label14";
            label14.Size = new Size(951, 40);
            label14.TabIndex = 126;
            label14.Text = "      Main Options";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(317, 276);
            label42.Name = "label42";
            label42.Size = new Size(120, 32);
            label42.TabIndex = 125;
            label42.Text = "Threshold";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(317, 232);
            label41.Name = "label41";
            label41.Size = new Size(155, 32);
            label41.TabIndex = 124;
            label41.Text = "Min Sell Rate";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(317, 188);
            label40.Name = "label40";
            label40.Size = new Size(124, 32);
            label40.TabIndex = 123;
            label40.Text = "Item Level";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(317, 143);
            label39.Name = "label39";
            label39.Size = new Size(79, 32);
            label39.TabIndex = 122;
            label39.Text = "Worth";
            // 
            // txtSearchMaxItemLevel
            // 
            txtSearchMaxItemLevel.Location = new Point(561, 186);
            txtSearchMaxItemLevel.MaxLength = 4;
            txtSearchMaxItemLevel.Name = "txtSearchMaxItemLevel";
            txtSearchMaxItemLevel.Size = new Size(60, 39);
            txtSearchMaxItemLevel.TabIndex = 121;
            txtSearchMaxItemLevel.Text = "9999";
            // 
            // rbSearch_MaxG
            // 
            rbSearch_MaxG.AutoSize = true;
            rbSearch_MaxG.Checked = true;
            rbSearch_MaxG.Location = new Point(321, 100);
            rbSearch_MaxG.Name = "rbSearch_MaxG";
            rbSearch_MaxG.Size = new Size(125, 36);
            rbSearch_MaxG.TabIndex = 120;
            rbSearch_MaxG.TabStop = true;
            rbSearch_MaxG.Text = "Max (g)";
            rbSearch_MaxG.UseVisualStyleBackColor = true;
            // 
            // rbSearch_Percentage
            // 
            rbSearch_Percentage.AutoSize = true;
            rbSearch_Percentage.Location = new Point(321, 56);
            rbSearch_Percentage.Name = "rbSearch_Percentage";
            rbSearch_Percentage.Size = new Size(163, 36);
            rbSearch_Percentage.TabIndex = 119;
            rbSearch_Percentage.Text = "Percentage";
            rbSearch_Percentage.UseVisualStyleBackColor = true;
            // 
            // txtSearchMinSellRate
            // 
            txtSearchMinSellRate.Location = new Point(493, 230);
            txtSearchMinSellRate.Name = "txtSearchMinSellRate";
            txtSearchMinSellRate.Size = new Size(128, 39);
            txtSearchMinSellRate.TabIndex = 118;
            txtSearchMinSellRate.Text = "-1";
            // 
            // txtSearchMinItemLevel
            // 
            txtSearchMinItemLevel.Location = new Point(493, 186);
            txtSearchMinItemLevel.MaxLength = 4;
            txtSearchMinItemLevel.Name = "txtSearchMinItemLevel";
            txtSearchMinItemLevel.Size = new Size(60, 39);
            txtSearchMinItemLevel.TabIndex = 117;
            txtSearchMinItemLevel.Text = "0";
            // 
            // txtSearchWorth
            // 
            txtSearchWorth.Location = new Point(493, 141);
            txtSearchWorth.Name = "txtSearchWorth";
            txtSearchWorth.Size = new Size(128, 39);
            txtSearchWorth.TabIndex = 116;
            txtSearchWorth.Text = "20000";
            // 
            // txtSearchMaxG
            // 
            txtSearchMaxG.Location = new Point(493, 98);
            txtSearchMaxG.Name = "txtSearchMaxG";
            txtSearchMaxG.Size = new Size(128, 39);
            txtSearchMaxG.TabIndex = 115;
            txtSearchMaxG.Text = "199";
            // 
            // txtSearchPercentage
            // 
            txtSearchPercentage.Location = new Point(493, 54);
            txtSearchPercentage.Name = "txtSearchPercentage";
            txtSearchPercentage.Size = new Size(128, 39);
            txtSearchPercentage.TabIndex = 114;
            txtSearchPercentage.Text = "5";
            // 
            // txtSearchThreshold
            // 
            txtSearchThreshold.Location = new Point(493, 274);
            txtSearchThreshold.Name = "txtSearchThreshold";
            txtSearchThreshold.Size = new Size(128, 39);
            txtSearchThreshold.TabIndex = 113;
            txtSearchThreshold.Text = "20";
            // 
            // panelSearch_Frequency
            // 
            panelSearch_Frequency.Controls.Add(rbSearchShowAllItems);
            panelSearch_Frequency.Controls.Add(rbSearchShowCheapest);
            panelSearch_Frequency.Controls.Add(rbSearchRemoveDuplicates);
            panelSearch_Frequency.Location = new Point(675, 43);
            panelSearch_Frequency.Name = "panelSearch_Frequency";
            panelSearch_Frequency.Size = new Size(276, 138);
            panelSearch_Frequency.TabIndex = 128;
            // 
            // rbSearchShowAllItems
            // 
            rbSearchShowAllItems.AutoSize = true;
            rbSearchShowAllItems.Location = new Point(15, 97);
            rbSearchShowAllItems.Name = "rbSearchShowAllItems";
            rbSearchShowAllItems.Size = new Size(199, 36);
            rbSearchShowAllItems.TabIndex = 115;
            rbSearchShowAllItems.Text = "Show all items";
            rbSearchShowAllItems.UseVisualStyleBackColor = true;
            // 
            // rbSearchShowCheapest
            // 
            rbSearchShowCheapest.AutoSize = true;
            rbSearchShowCheapest.Location = new Point(15, 55);
            rbSearchShowCheapest.Name = "rbSearchShowCheapest";
            rbSearchShowCheapest.Size = new Size(205, 36);
            rbSearchShowCheapest.TabIndex = 114;
            rbSearchShowCheapest.Text = "Show cheapest";
            rbSearchShowCheapest.UseVisualStyleBackColor = true;
            // 
            // rbSearchRemoveDuplicates
            // 
            rbSearchRemoveDuplicates.AutoSize = true;
            rbSearchRemoveDuplicates.Checked = true;
            rbSearchRemoveDuplicates.Location = new Point(15, 12);
            rbSearchRemoveDuplicates.Name = "rbSearchRemoveDuplicates";
            rbSearchRemoveDuplicates.Size = new Size(246, 36);
            rbSearchRemoveDuplicates.TabIndex = 113;
            rbSearchRemoveDuplicates.TabStop = true;
            rbSearchRemoveDuplicates.Text = "Remove duplicates";
            rbSearchRemoveDuplicates.UseVisualStyleBackColor = true;
            // 
            // pnlSearch_Class
            // 
            pnlSearch_Class.BackColor = SystemColors.ControlLight;
            pnlSearch_Class.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch_Class.Controls.Add(button2);
            pnlSearch_Class.Controls.Add(label12);
            pnlSearch_Class.Location = new Point(1399, 148);
            pnlSearch_Class.Name = "pnlSearch_Class";
            pnlSearch_Class.Size = new Size(660, 330);
            pnlSearch_Class.TabIndex = 105;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(2, 2);
            button2.Name = "button2";
            button2.Size = new Size(36, 36);
            button2.TabIndex = 106;
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnSearch_TogglesOnOff_Click;
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ControlDark;
            label12.Dock = DockStyle.Top;
            label12.Location = new Point(0, 0);
            label12.Name = "label12";
            label12.Size = new Size(658, 40);
            label12.TabIndex = 103;
            label12.Text = "      Item Class";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSearch_Quality
            // 
            pnlSearch_Quality.BackColor = SystemColors.ControlLight;
            pnlSearch_Quality.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch_Quality.Controls.Add(btnSearch_Quality_OnOff);
            pnlSearch_Quality.Controls.Add(label13);
            pnlSearch_Quality.Location = new Point(2113, 151);
            pnlSearch_Quality.Name = "pnlSearch_Quality";
            pnlSearch_Quality.Size = new Size(337, 327);
            pnlSearch_Quality.TabIndex = 106;
            // 
            // btnSearch_Quality_OnOff
            // 
            btnSearch_Quality_OnOff.BackColor = SystemColors.ControlDark;
            btnSearch_Quality_OnOff.FlatAppearance.BorderSize = 0;
            btnSearch_Quality_OnOff.FlatStyle = FlatStyle.Flat;
            btnSearch_Quality_OnOff.Image = (Image)resources.GetObject("btnSearch_Quality_OnOff.Image");
            btnSearch_Quality_OnOff.Location = new Point(2, 2);
            btnSearch_Quality_OnOff.Name = "btnSearch_Quality_OnOff";
            btnSearch_Quality_OnOff.Size = new Size(36, 36);
            btnSearch_Quality_OnOff.TabIndex = 105;
            btnSearch_Quality_OnOff.UseVisualStyleBackColor = false;
            btnSearch_Quality_OnOff.Click += btnSearch_TogglesOnOff_Click;
            // 
            // label13
            // 
            label13.BackColor = SystemColors.ControlDark;
            label13.Dock = DockStyle.Top;
            label13.Location = new Point(0, 0);
            label13.Name = "label13";
            label13.Size = new Size(335, 40);
            label13.TabIndex = 104;
            label13.Text = "      Item Quality";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(tslVersion);
            panel2.Controls.Add(tslDataCountPets);
            panel2.Controls.Add(tslDataCountItems);
            panel2.Controls.Add(tslDataCountRegion);
            panel2.Controls.Add(tslQuickSearches);
            panel2.Controls.Add(lblProgress);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label15);
            panel2.Location = new Point(0, 56);
            panel2.Name = "panel2";
            panel2.Size = new Size(3834, 48);
            panel2.TabIndex = 107;
            // 
            // tslVersion
            // 
            tslVersion.Font = new Font("Segoe UI", 7.875F, FontStyle.Bold);
            tslVersion.Location = new Point(3308, 8);
            tslVersion.Name = "tslVersion";
            tslVersion.Size = new Size(500, 30);
            tslVersion.TabIndex = 9;
            tslVersion.Text = "[Version]";
            tslVersion.TextAlign = ContentAlignment.TopRight;
            // 
            // tslDataCountPets
            // 
            tslDataCountPets.Font = new Font("Segoe UI", 7.875F);
            tslDataCountPets.Location = new Point(834, 8);
            tslDataCountPets.Name = "tslDataCountPets";
            tslDataCountPets.Size = new Size(66, 32);
            tslDataCountPets.TabIndex = 8;
            tslDataCountPets.Text = "9999";
            tslDataCountPets.TextAlign = ContentAlignment.TopCenter;
            tslDataCountPets.Visible = false;
            // 
            // tslDataCountItems
            // 
            tslDataCountItems.Font = new Font("Segoe UI", 7.875F);
            tslDataCountItems.Location = new Point(744, 8);
            tslDataCountItems.Name = "tslDataCountItems";
            tslDataCountItems.Size = new Size(80, 32);
            tslDataCountItems.TabIndex = 7;
            tslDataCountItems.Text = "99999";
            tslDataCountItems.TextAlign = ContentAlignment.TopCenter;
            tslDataCountItems.Visible = false;
            // 
            // tslDataCountRegion
            // 
            tslDataCountRegion.Font = new Font("Segoe UI", 7.875F);
            tslDataCountRegion.Location = new Point(661, 8);
            tslDataCountRegion.Name = "tslDataCountRegion";
            tslDataCountRegion.Size = new Size(80, 32);
            tslDataCountRegion.TabIndex = 6;
            tslDataCountRegion.Text = "99999";
            tslDataCountRegion.TextAlign = ContentAlignment.TopCenter;
            tslDataCountRegion.Visible = false;
            // 
            // tslQuickSearches
            // 
            tslQuickSearches.AutoSize = true;
            tslQuickSearches.Font = new Font("Segoe UI", 7.875F);
            tslQuickSearches.Location = new Point(2502, 8);
            tslQuickSearches.Name = "tslQuickSearches";
            tslQuickSearches.Size = new Size(188, 30);
            tslQuickSearches.TabIndex = 5;
            tslQuickSearches.Text = "Quick Searches  ->";
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("Segoe UI", 7.875F);
            lblProgress.Location = new Point(1138, 8);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(1300, 32);
            lblProgress.TabIndex = 4;
            lblProgress.Text = "Progress";
            lblProgress.TextAlign = ContentAlignment.TopCenter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 7.875F);
            label18.Location = new Point(27, 8);
            label18.Name = "label18";
            label18.Size = new Size(75, 30);
            label18.TabIndex = 3;
            label18.Text = "Search";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 7.875F);
            label17.Location = new Point(553, 8);
            label17.Name = "label17";
            label17.Size = new Size(85, 30);
            label17.TabIndex = 2;
            label17.Text = "Data ->";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 7.875F);
            label16.Location = new Point(980, 8);
            label16.Name = "label16";
            label16.Size = new Size(76, 30);
            label16.TabIndex = 1;
            label16.Text = "Theme";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 7.875F);
            label15.Location = new Point(249, 9);
            label15.Name = "label15";
            label15.Size = new Size(149, 30);
            label15.TabIndex = 0;
            label15.Text = "Search Profiles";
            // 
            // btnToggleRealms
            // 
            btnToggleRealms.BackColor = SystemColors.ControlLightLight;
            btnToggleRealms.FlatAppearance.BorderSize = 0;
            btnToggleRealms.FlatStyle = FlatStyle.Flat;
            btnToggleRealms.Image = (Image)resources.GetObject("btnToggleRealms.Image");
            btnToggleRealms.Location = new Point(41, 520);
            btnToggleRealms.Name = "btnToggleRealms";
            btnToggleRealms.Size = new Size(36, 36);
            btnToggleRealms.TabIndex = 128;
            btnToggleRealms.UseVisualStyleBackColor = false;
            btnToggleRealms.Click += btnToggleRealms_Click;
            // 
            // chartTotalAuctions
            // 
            chartTotalAuctions.BackColor = SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            chartTotalAuctions.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartTotalAuctions.Legends.Add(legend1);
            chartTotalAuctions.Location = new Point(2484, 1406);
            chartTotalAuctions.Name = "chartTotalAuctions";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartTotalAuctions.Series.Add(series1);
            chartTotalAuctions.Size = new Size(1279, 600);
            chartTotalAuctions.TabIndex = 129;
            chartTotalAuctions.Text = "chart1";
            // 
            // chartTopSearches
            // 
            chartTopSearches.BackColor = SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            chartTopSearches.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartTopSearches.Legends.Add(legend2);
            chartTopSearches.Location = new Point(2484, 767);
            chartTopSearches.Name = "chartTopSearches";
            chartTopSearches.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTopSearches.Series.Add(series2);
            chartTopSearches.Size = new Size(1279, 600);
            chartTopSearches.TabIndex = 130;
            chartTopSearches.Text = "chart2";
            // 
            // chartTotalValue
            // 
            chartTotalValue.BackColor = SystemColors.Control;
            chartArea3.Name = "ChartArea1";
            chartTotalValue.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartTotalValue.Legends.Add(legend3);
            chartTotalValue.Location = new Point(2484, 120);
            chartTotalValue.Name = "chartTotalValue";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartTotalValue.Series.Add(series3);
            chartTotalValue.Size = new Size(1279, 600);
            chartTotalValue.TabIndex = 131;
            chartTotalValue.Text = "chart1";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(3808, 2044);
            Controls.Add(chartTotalValue);
            Controls.Add(chartTopSearches);
            Controls.Add(chartTotalAuctions);
            Controls.Add(btnToggleRealms);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lvAuctions);
            Controls.Add(toolStripMain);
            Controls.Add(lvRealms);
            Controls.Add(pnlSearch_Main);
            Controls.Add(pnlSearch_Class);
            Controls.Add(pnlSearch_Quality);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "WOW Auction API Scanner for .Net 10";
            WindowState = FormWindowState.Maximized;
            Load += FormMain_Load;
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchProfile).EndInit();
            pnlSearch_Main.ResumeLayout(false);
            pnlSearch_Main.PerformLayout();
            panelSearch_Frequency.ResumeLayout(false);
            panelSearch_Frequency.PerformLayout();
            pnlSearch_Class.ResumeLayout(false);
            pnlSearch_Quality.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartTotalAuctions).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTopSearches).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTotalValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvRealms;
        private ColumnHeader colRealms_S;
        private ColumnHeader colRealms_RealmName;
        private ColumnHeader colRealms_LastModified;
        private ColumnHeader colRealms_Auctions;
        private ToolStrip toolStripMain;
        private ImageList imgStatus;
        private ToolStripButton tsbWriteRegionData;
        private ToolStripDropDownButton tsddItemCache;
        private ToolStripDropDownButton tsddPets;
        private ToolStripMenuItem tsmUpdateItemCache;
        private ToolStripMenuItem tsmBuildItemCache;
        private ToolStripMenuItem tsmUpdatePetCache;
        private ToolStripMenuItem tsmBuildPetCache;
        private ToolStripSeparator tsSep1;
        private ToolStripButton tsbRefreshAuctionData;
        private ImageList imgColorMode;
        private ListView lvAuctions;
        private ColumnHeader colItemName;
        private ColumnHeader colLevel;
        private ColumnHeader colSaleRate;
        private ColumnHeader colBuyout;
        private ColumnHeader colRegion;
        private ColumnHeader colPetLv;
        private ColumnHeader colLatestXpac;
        private Panel panel1;
        private ComboBox cboSearchProfile;
        private ImageList imgToolbar48;
        private Panel pnlSearch_Main;
        private Panel pnlSearch_Class;
        private Panel pnlSearch_Quality;
        private ToolStripButton tsbSearch;
        private ToolStripButton tsbSaveSearch;
        private ToolStripButton tsbSaveSearchAs;
        private Label label42;
        private Label label41;
        private Label label40;
        private Label label39;
        private TextBox txtSearchMaxItemLevel;
        private RadioButton rbSearch_MaxG;
        private RadioButton rbSearch_Percentage;
        private TextBox txtSearchMinSellRate;
        private TextBox txtSearchMinItemLevel;
        private TextBox txtSearchWorth;
        private TextBox txtSearchMaxG;
        private TextBox txtSearchPercentage;
        private TextBox txtSearchThreshold;
        private Label label12;
        private Label label10;
        private Label label14;
        private Label label13;
        private Button btnSearch_Quality_OnOff;
        private Button button2;
        private Button button3;
        private Panel panelSearch_Frequency;
        private RadioButton rbSearchShowAllItems;
        private RadioButton rbSearchShowCheapest;
        private RadioButton rbSearchRemoveDuplicates;
        private Label label11;
        private ToggleSlider tsInToolbar;
        private PictureBox picSearchProfile;
        private Panel panel2;
        private Label label15;
        private ToolStripProgressBar tspProgress;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private Label label16;
        private ToolStripButton tsbRenameSearch;
        private ToolStripButton tsbNewSearch;
        private ToolStripButton tsbDeleteSearch;
        private ToolStripSeparator toolStripSeparator3;
        private Label label18;
        private Label label17;
        private ToolStripSeparator toolStripSeparator4;
        private Label tslQuickSearches;
        private Label lblProgress;
        private ToolStripButton tsbSearchDefault;
        private Button btnToggleRealms;
        private ColumnHeader colSide;
        private Label lblIconIndex;
        private Button btnChangeIcon;
        private ToolStripButton tsbThemeLight;
        private ToolStripButton tsbThemeDark;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalAuctions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSearches;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalValue;
        private ColumnHeader colPerc;
        private ToolStripButton tsbTest;
        private ToolStripButton tsbActivate;
        private ToolStripButton tsbRefreshWoWProcesses;
        private Label label1;
        private TextBox txtSearchStringFilter;
        private ToolStripMenuItem tsmSortItemCacheAsc;
        private ToolStripMenuItem tsmSortItemCacheDesc;
        private ToolStripMenuItem tsmSortPetCacheAsc;
        private ToolStripMenuItem tsmSortPetCacheDesc;
        private ToolStripButton tsbUpdateAllData;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator5;
        private Label tslDataCountPets;
        private Label tslDataCountItems;
        private Label tslDataCountRegion;
        private ToolStripSeparator toolStripSeparator6;
        private Label tslVersion;
    }
}
