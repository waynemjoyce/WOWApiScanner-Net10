using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Windows.Forms;
using WOWAuctionApi_Net10.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class RealmOptions : OptionsBase
    {
        public DisplayMode ViewMode = DisplayMode.Auctions;

        private OptionSet flagOptions;
        private bool isDoubleClickCheck = false;
        int cachedStock = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageList SmallImageList
        {
            get { return lvRealms.SmallImageList; }
            set { lvRealms.SmallImageList = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.CheckedListViewItemCollection CheckedItems
        {
            get { return lvRealms.CheckedItems; }
        }

        public event EventHandler<RealmEventArgs>? SelectedChanged;

        public RealmOptions()
        {
            InitializeComponent();
        }

        public void CheckOnlyFirst()
        {
            //If OnlyFirst is set, only check the first X realms and uncheck the rest to speed up loading for users who don't care about all realms
            if (sc.Config.OnlyFirst > 0)
            {
                ToggleRealms();
                Application.DoEvents();
                for (int i = 0; i < sc.Config.OnlyFirst; i++)
                {
                    lvRealms.Items[i].Checked = true;
                }
            }
        }

        public bool RealmChecked(int realmId)
        {

            try
            {

                foreach (ListViewItem lvi in lvRealms.Items)
                {
                    if (lvi.Tag != null)
                    {
                        Realm r = lvi.Tag as Realm;
                        if (r != null)
                        {
                            if (r.RealmId == realmId)
                            {
                                return lvi.Checked;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool CheckAllRealmsHaveData()
        {
            foreach (ListViewItem listItem in lvRealms.Items)
            {
                if (listItem == null)
                {
                    return false;
                }
                if (listItem.Checked)
                {
                    int numAuctions = int.Parse(listItem.SubItems[SIIndex(SII.AuctionCount)].Text.Replace(",", ""));

                    if (numAuctions == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void RenderColumns()
        {
            AddColumn("R", 70);
            AddColumn("S", 30); //Stock limit exceeded warning
            AddColumn("Stock", 70, HorizontalAlignment.Right);

            foreach (ToggleOption flagOption in flagOptions.ToggleOptions)
            {
                AddColumn(flagOption.Name, 30);
            }

            AddColumn("Realm Name", 220);
            AddColumn("Modified", 110);
            AddColumn("#", 110, HorizontalAlignment.Right);
            AddColumn("A", 60);
        }

        public void AddColumn(string name, int width, HorizontalAlignment alignment = HorizontalAlignment.Left)
        {
            ColumnHeader column = new ColumnHeader();
            column.Name = $"colRealms_{name}";
            column.Text = name;
            column.Width = width;
            column.TextAlign = alignment;
            lvRealms.Columns.Add(column);
        }

        public void LoadRealms()
        {
            flagOptions = sc.UIOptions.OptionSets.Single(set => set.SetName == "RealmFlags");

            RenderColumns();

            lvRealms.FullRowSelect = true;

            btnToggleRealms.Visible = true;
            OptionsTitle = "      Realms";

            var items = new List<ListViewItem>();
            foreach (var r in sc.RealmData.Realms)
            {
                if (r.Active.HasValue && r.Active.Value || (r.Active == false && sc.Config.DisplayInactiveRealms))
                {
                    ListViewItem lvi = GetLVIForRealm(r);
                    items.Add(lvi);
                }
            }

            lvRealms.BeginUpdate();
            lvRealms.Items.Clear(); // Clear existing
            lvRealms.Items.AddRange(items.ToArray()); // Add all at once
            lvRealms.EndUpdate();
            Application.DoEvents();
            UpdateStockCount();

            foreach (ToggleOption flagOption in flagOptions.ToggleOptions)
            {
                ToolStripMenuItem tsiFlag = new ToolStripMenuItem();
                tsiFlag.Name = $"miFlagRealmSpecific_{flagOption.Name}";
                tsiFlag.Text = $"{flagOption.Name}: {flagOption.Label}";
                tsiFlag.Tag = flagOption;
                tsiFlag.Click += miFlagRealmSpecific_Click;
                miFlagAllSpecific.DropDownItems.AddRange(new ToolStripItem[] { tsiFlag });

                ToolStripMenuItem tsiUnflag = new ToolStripMenuItem();
                tsiUnflag.Name = $"miFlagRealmSpecific_{flagOption.Name}";
                tsiUnflag.Text = $"{flagOption.Name}: {flagOption.Label}";
                tsiUnflag.Tag = flagOption;
                tsiUnflag.Click += miUnflagRealmSpecific_Click;
                miUnflagAllSpecific.DropDownItems.AddRange(new ToolStripItem[] { tsiUnflag });


            }

        }

        private ListViewItem GetLVIForRealm(Realm r, string modified = "", int status = 0, string auctionCount = "0")
        {
            // Create ListViewItem with subitems
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = r;
            lvi.Text = "";
            lvi.UseItemStyleForSubItems = false;

            int flagCount = flagOptions.ToggleOptions.Count;

            //Stock limit warning
            lvi.SubItems.Add("");
            StockLimitForListItem(lvi);

            lvi.SubItems.Add(r.Stock.Value.ToString());
            lvi.SubItems[SIIndex(SII.Stock)].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[SIIndex(SII.Stock)].ForeColor = Color.White;

            foreach (ToggleOption flagOption in flagOptions.ToggleOptions)
            {
                bool isFlagged = (r.RealmFlags.HasValue && (r.RealmFlags.Value & flagOption.Id.Value) != 0);
                if (isFlagged)
                {
                    lvi.SubItems.Add(flagOption.Name);
                    if (sc.UIOptions.ColorMode == SystemColorMode.Dark)
                    {
                        lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].BackColor
                            = Color.FromName(flagOption.BackColorDark);
                    }
                    else
                    {
                        lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].BackColor
                            = Color.FromName(flagOption.BackColorLight);
                    }

                }
                else
                {
                    lvi.SubItems.Add("");
                }
            }

            lvi.SubItems.Add(r.RealmName);
            lvi.SubItems[SIIndex(SII.RealmName)].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[SIIndex(SII.RealmName)].ForeColor = Color.White;
            lvi.SubItems.Add((modified == "") ? "Stale" : modified);
            lvi.SubItems[SIIndex(SII.Modified)].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[SIIndex(SII.Modified)].ForeColor = Color.White;
            lvi.SubItems.Add(auctionCount);
            lvi.SubItems[SIIndex(SII.AuctionCount)].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[SIIndex(SII.AuctionCount)].ForeColor = Color.White;
            lvi.SubItems.Add(r.Area);
            lvi.SubItems[SIIndex(SII.Area)].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[SIIndex(SII.Area)].ForeColor = Color.White;

            //Realm status
            //0 Blue = live data not loaded
            //1 Red = loading
            //2 Yellow = old data
            //3 Green = new data

            lvi.ImageIndex = status;
            lvi.Checked = r.Active.Value;

            return lvi;
        }

        private void btnToggleRealms_Click(object sender, EventArgs e)
        {
            ToggleRealms();
        }

        public void ToggleRealms()
        {
            bool newValue = !lvRealms.Items[0].Checked;
            lvRealms.Items.Cast<ListViewItem>().ToList().ForEach(item => item.Checked = newValue);
        }

        private void RealmOptions_Load(object sender, EventArgs e)
        {

        }

        public void SetRealmStatus(Realm realm, int status, string lastModified, int auctionCount)
        {

            lvRealms.SuspendLayout();
            realm.Status = status;
            realm.NumAuctions = auctionCount;

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
                            lvi.SubItems[SIIndex(SII.Modified)].Text = DateTime.Parse(lastModified).ToString("hh:mm:ss");
                            lvi.SubItems[SIIndex(SII.AuctionCount)].Text = auctionCount.ToString("N0");
                        }
                    }
                }

            }
            lvRealms.ResumeLayout();
        }

        private void miEditRealm_Click(object sender, EventArgs e)
        {
            EditRealm();
        }

        private void EditRealm()
        {
            FormEditRealm editRealm = new FormEditRealm();
            editRealm.LoadRealm(GetSelectedRealm());
            editRealm.ShowDialog();
            if (editRealm.DialogResult == DialogResult.OK)
            {
                SetSelectedRealm(editRealm.Realm);
                sc.RealmData.Save();
            }
            UpdateStockCount();
        }

        private void SetSelectedRealm(Realm realm)
        {
            for (int i = 0; i < lvRealms.Items.Count; i++)
            {
                var lvi = lvRealms.Items[i];
                if (lvi.Tag != null && ((Realm)lvi.Tag).RealmId == realm.RealmId)
                {
                    string modified = lvi.SubItems[SIIndex(SII.Modified)].Text;
                    int status = realm.Status;
                    string auctionCount = lvi.SubItems[SIIndex(SII.AuctionCount)].Text;
                    var newLvi = GetLVIForRealm(realm, modified, status, auctionCount);
                    newLvi.Tag = realm;
                    lvRealms.Items[i] = newLvi; // replace the item in the collection
                    break;
                }
            }

            foreach (Realm r in sc.RealmData.Realms)
            {
                if (r.RealmId == realm.RealmId)
                {
                    r.BackColor = realm.BackColor;
                    r.Flagged = realm.Flagged;
                    r.RealmName = realm.RealmName;
                    r.RealmId = realm.RealmId;
                    r.Stock = realm.Stock;
                    break;
                }
            }
        }

        private Realm GetSelectedRealm()
        {
            ListViewItem lvi = lvRealms.SelectedItems[0] as ListViewItem;
            if (lvi != null)
            {
                return lvi.Tag as Realm;
            }
            return null;
        }

        private void lvRealms_DoubleClick(object sender, EventArgs e)
        {
            EditRealm();
        }

        private void UpdateStockCount()
        {
            int stockCount = 0;
            foreach (ListViewItem lvi in lvRealms.Items)
            {
                stockCount += int.Parse(lvi.SubItems[SIIndex(SII.Stock)].Text);
                if (lvi.Tag != null)
                {
                    Realm realm = lvi.Tag as Realm;
                    StockLimitForListItem(lvi);
                }
            }
            lvRealms.Columns[SIIndex(SII.Stock)].Text = stockCount.ToString();
        }

        private void StockLimitForListItem(ListViewItem lvi)
        {
            if (lvi.Tag != null)
            {
                Realm realm = lvi.Tag as Realm;
                if (realm.Stock.HasValue && realm.Stock.Value > sc.Config.StockLimit)
                {
                    lvi.SubItems[SIIndex(SII.StockWarning)].Text = "!";
                    lvi.SubItems[SIIndex(SII.StockWarning)].BackColor = Color.Red;
                    lvi.SubItems[SIIndex(SII.StockWarning)].ForeColor = Color.White;
                }
                else
                {
                    lvi.SubItems[SIIndex(SII.StockWarning)].Text = "";
                    lvi.SubItems[SIIndex(SII.StockWarning)].BackColor = SystemColors.ControlLight;
                    lvi.SubItems[SIIndex(SII.StockWarning)].ForeColor = Color.Black;
                }
            }

            ListViewItem.ListViewSubItem lvi2 = lvi.SubItems[1];
        }   

        public enum SII
        {
            StockWarning,
            Stock,
            RealmName,
            Modified,
            AuctionCount,
            Area
        }

        public int SIIndex(SII subItemName)
        {
            switch (subItemName)
            {
                case SII.StockWarning:
                    return 1;
                case SII.Stock:
                    return 2;
                case SII.RealmName:
                    return 3 + flagOptions.ToggleOptions.Count;
                case SII.Modified:
                    return 4 + flagOptions.ToggleOptions.Count;
                case SII.AuctionCount:
                    return 5 + flagOptions.ToggleOptions.Count;
                case SII.Area:
                    return 6 + flagOptions.ToggleOptions.Count;
            }

            return 0;
        }


        private void lvRealms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks > 1)
            {
                isDoubleClickCheck = true;
            }
        }

        private void lvRealms_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isDoubleClickCheck)
            {
                e.NewValue = e.CurrentValue; // Cancels the visual toggle
                isDoubleClickCheck = false;  // 4. Reset the state
            }
        }

        private void lvRealms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            var item = listView1.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                MessageBox.Show($"You double-clicked: {item.Text}");
            }
            */
        }

        private void miFlagAllRealms_Click(object sender, EventArgs e)
        {
            FlagAllRealms(true);
        }

        private void miUnflagAllRealms_Click(object sender, EventArgs e)
        {
            UnflagAllRealms();
        }

        private void UnflagAllRealms()
        {
            if (MessageBox.Show(
                "This will unflag all flags on all realms.\r\nAre you sure you wish to continue?",
                    "Unflag All Realms", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvRealms.Items)
                {
                    Realm selectedRealm = lvi.Tag as Realm;
                    if (selectedRealm != null)
                    {
                        selectedRealm.RealmFlags = 0;
                    }
                }
                UpdateAllFlags();
                sc.RealmData.Save();
            }
        }

        private void FlagAllRealms(bool flag)
        {
            foreach (ListViewItem lvi in lvRealms.Items)
            {
                Realm selectedRealm = lvi.Tag as Realm;
                if (flag)
                {
                    lvi.SubItems[1].Text = "F";
                    selectedRealm.Flagged = true;
                }
                else
                {
                    lvi.SubItems[1].Text = "";
                    selectedRealm.Flagged = false;
                }
            }
            sc.RealmData.Save();
        }

        private void mnRealms_Opened(object sender, EventArgs e)
        {
            Realm currentRealm = GetSelectedRealm();
            if (currentRealm != null)
            {
                int cachedStock = currentRealm.Stock.Value;
                miStockText.Text = currentRealm.Stock.ToString();
            }
        }

        private void miStockText_Enter(object sender, EventArgs e)
        {
            miStockText.SelectAll();
        }

        private void miStockText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Suppress the ding sound when Enter is pressed in a textbox
                e.SuppressKeyPress = true;

                // Execute your desired logic here
                Realm currentRealm = GetSelectedRealm();
                if (currentRealm != null)
                {
                    if (int.Parse(miStockText.Text) != cachedStock)
                    {
                        currentRealm.Stock = int.Parse(miStockText.Text);
                        SetSelectedRealm(currentRealm);

                        if (sc.Config.FlagFirstWithStockUpdate)
                        {
                            currentRealm.RealmFlags = AddBitIfNotExists(currentRealm.RealmFlags.Value, 1);
                            UpdateAllFlags();
                        }
                    }
                    sc.RealmData.Save();
                    UpdateStockCount();
                    mnRealms.Close();
                }
            }
        }

        private void miStockText_Click(object sender, EventArgs e)
        {
            miStockText.SelectAll();
        }

        private void miClearRealmFlags_Click(object sender, EventArgs e)
        {
            Realm currentRealm = GetSelectedRealm();
            if (currentRealm != null)
            {
                currentRealm.RealmFlags = 0;
                SetSelectedRealm(currentRealm);
                sc.RealmData.Save();
                mnRealms.Close();
            }
        }

        private void miFlagRealmSpecific_Click(object sender, EventArgs e)
        {
            FlagAllSpecific(true, (sender as ToolStripMenuItem).Tag as ToggleOption);
        }

        private void miUnflagRealmSpecific_Click(object sender, EventArgs e)
        {
            FlagAllSpecific(false, (sender as ToolStripMenuItem).Tag as ToggleOption);
        }

        public void FlagAllSpecific(bool flag, ToggleOption flagOption)
        {
            if (flagOption != null)
            {
                foreach (ListViewItem lvi in lvRealms.Items)
                {
                    Realm selectedRealm = lvi.Tag as Realm;
                    if (selectedRealm != null)
                    {
                        if (flag) { selectedRealm.RealmFlags = AddBitIfNotExists(selectedRealm.RealmFlags.Value, flagOption.Id.Value); }
                        if (!flag) { selectedRealm.RealmFlags = DeleteBitIfExists(selectedRealm.RealmFlags.Value, flagOption.Id.Value); }
                    }

                }
            }

            sc.RealmData.Save();
            UpdateAllFlags();
        }   

        public int AddBitIfNotExists(int currentValue, int bitToAdd)
        {
            if (!UIHelper.BitwiseHasValue(currentValue, bitToAdd))
            {
                return currentValue += bitToAdd;
            }
            return currentValue;
        }

        public int DeleteBitIfExists(int currentValue, int bitToDelete)
        {
            if (UIHelper.BitwiseHasValue(currentValue, bitToDelete))
            {
                return currentValue - bitToDelete;
            }
            return currentValue;
        }   


        public void UpdateAllFlags()
        {
            foreach (ListViewItem lvi in lvRealms.Items)
            {
                Realm r = lvi.Tag as Realm; 
                foreach (ToggleOption flagOption in flagOptions.ToggleOptions)
                {
               
                    bool isFlagged = (r.RealmFlags.HasValue && (r.RealmFlags.Value & flagOption.Id.Value) != 0);
                    if (isFlagged)
                    {
                        lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].Text = flagOption.Name;
                        if (sc.UIOptions.ColorMode == SystemColorMode.Dark)
                        {
                            lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].BackColor
                                = Color.FromName(flagOption.BackColorDark);
                        }
                        else
                        {
                            lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].BackColor
                                = Color.FromName(flagOption.BackColorLight);
                        }
                    }
                    else
                    {
                        lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].Text = "";
                        lvi.SubItems[3 + flagOptions.ToggleOptions.IndexOf(flagOption)].BackColor 
                            = SystemColors.ControlLight;
                    }
                }
            }
        }
    }

    public class RealmEventArgs : EventArgs
    {
        public Realm RealmSelected { get; set; }
    }
}
