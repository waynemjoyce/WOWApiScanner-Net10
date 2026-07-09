using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WOWAuctionApi_Net10.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WOWAuctionApi_Net10
{
    public partial class RealmOptions : OptionsBase
    {
        public DisplayMode ViewMode = DisplayMode.Auctions;

        private bool isDoubleClickCheck = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageList SmallImageList
        {
            get { return lvRealms.SmallImageList; }
            set { lvRealms.SmallImageList = value; }
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
            return (lvRealms.Items
                .Cast<ListViewItem>() // Cast the ListViewItemCollection to IEnumerable<ListViewItem>
                .FirstOrDefault(item =>
                    item.Tag is Realm tagInfo &&
                    tagInfo.RealmId == realmId)).Checked;
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
                    int numAuctions = int.Parse(listItem.SubItems[5].Text.Replace(",", ""));

                    if (numAuctions == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void LoadRealms()
        {
            lvRealms.FullRowSelect = true;
            switch (ViewMode)
            {
                case DisplayMode.Auctions:
                default:
                    lvRealms.Columns[4].Text = "Modified";
                    btnToggleRealms.Visible = true;
                    OptionsTitle = "      Realms";
                    break;
                case DisplayMode.Config:
                    lvRealms.Columns[0].Width = 0;
                    lvRealms.Columns[4].Text = "Realm Id";
                    btnToggleRealms.Visible = false;
                    OptionsTitle = " Realms";
                    break;
            }

            var items = new List<ListViewItem>();
            foreach (var r in sc.Config.Realms)
            {
                ListViewItem lvi = GetLVIForRealm(r);
                items.Add(lvi);
            }

            lvRealms.BeginUpdate();
            lvRealms.Items.Clear(); // Clear existing
            lvRealms.Items.AddRange(items.ToArray()); // Add all at once
            lvRealms.EndUpdate();
            Application.DoEvents();
            UpdateStockCount();
        }

        private ListViewItem GetLVIForRealm(Realm r, string modified = "", int status = 0)
        {
            // Create ListViewItem with subitems
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "";
            lvi.UseItemStyleForSubItems = false;
            if (r.Flagged.Value == true)
            {
                lvi.SubItems.Add("F");
            }
            else
            {
                lvi.SubItems.Add("");
            }

            lvi.SubItems.Add(r.Stock.Value.ToString());
            lvi.SubItems[2].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[2].ForeColor = Color.White;
            lvi.SubItems.Add(r.RealmName);
            lvi.SubItems[3].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[3].ForeColor = Color.White;
            lvi.SubItems.Add((modified == "") ? "Stale" : modified);
            lvi.SubItems[4].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[4].ForeColor = Color.White;
            lvi.SubItems.Add("0");
            lvi.SubItems[5].BackColor = UIHelper.StringToColor(r.BackColor);
            lvi.SubItems[5].ForeColor = Color.White;

            //Realm status
            //0 Blue = live data not loaded
            //1 Red = loading
            //2 Yellow = old data
            //3 Green = new data

            lvi.ImageIndex = status;
            lvi.Tag = r;
            lvi.Checked = true;

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
                            lvi.SubItems[4].Text = DateTime.Parse(lastModified).ToString("hh:mm:ss");
                            lvi.SubItems[5].Text = auctionCount.ToString("N0");
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
                sc.Config.Save();
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
                    string modified = lvi.SubItems[4].Text;
                    int status = realm.Status;
                    var newLvi = GetLVIForRealm(realm, modified, status);
                    newLvi.Tag = realm;
                    lvRealms.Items[i] = newLvi; // replace the item in the collection
                    break;
                }
            }

            foreach (Realm r in sc.Config.Realms)
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

        private void miFlagRealm_Click(object sender, EventArgs e)
        {
            if (lvRealms.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvRealms.SelectedItems[0] as ListViewItem;
                if (lvi != null)
                {
                    Realm selectedRealm = lvi.Tag as Realm;
                    if (selectedRealm.Flagged.Value == false)
                    {
                        lvi.SubItems[1].Text = "F";
                        selectedRealm.Flagged = true;
                    }
                    else
                    {
                        lvi.SubItems[1].Text = "";
                        selectedRealm.Flagged = false;
                    }
                    sc.Config.Save();
                }
            }
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
                stockCount += int.Parse(lvi.SubItems[2].Text);
                if (lvi.Tag != null)
                {
                    Realm realm = lvi.Tag as Realm;
                }
            }
            lvRealms.Columns[2].Text = stockCount.ToString();
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
    }

    public class RealmEventArgs : EventArgs
    {
        public Realm RealmSelected { get; set; }
    }
}
