using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class RealmOptions : BaseOptions
    {
        public DisplayMode ViewMode = DisplayMode.Auctions;

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
                    int numAuctions = int.Parse(listItem.SubItems[3].Text.Replace(",", ""));

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
            switch (ViewMode)
            {
                case DisplayMode.Auctions:
                default:
                    lvRealms.Columns[2].Text = "Modified";
                    lvRealms.FullRowSelect = false;
                    btnToggleRealms.Visible = true;
                    OptionsTitle = "      Realms";
                    break;
                case DisplayMode.Config:
                    lvRealms.Columns[0].Width = 0;
                    lvRealms.Columns[2].Text = "Realm Id";
                    lvRealms.FullRowSelect = true;
                    btnToggleRealms.Visible = false;
                    OptionsTitle = " Realms";
                    break;
            }

            var items = new List<ListViewItem>();
            foreach (var r in sc.Config.Realms)
            {
                // Create ListViewItem with subitems
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.UseItemStyleForSubItems = false;
                lvi.SubItems.Add(r.RealmName);
                lvi.SubItems[1].BackColor = UIHelper.StringToColor(r.BackColor);
                lvi.SubItems[1].ForeColor = Color.White;
                lvi.SubItems.Add((ViewMode == DisplayMode.Auctions) ? "Stale" : r.RealmId.ToString());
                lvi.SubItems[2].BackColor = UIHelper.StringToColor(r.BackColor);
                lvi.SubItems[2].ForeColor = Color.White;
                lvi.SubItems.Add("0");
                lvi.SubItems[3].BackColor = UIHelper.StringToColor(r.BackColor);
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

        private void lvRealms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Need to raise an event here
            if (this.ViewMode == DisplayMode.Config && lvRealms.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvRealms.SelectedItems[0] as ListViewItem;
                if (lvi != null)
                {
                    RealmEventArgs eventArgs = new RealmEventArgs();
                    eventArgs.RealmSelected = lvi.Tag as Realm;
                    SelectedChanged?.Invoke(this, eventArgs);
                }
            }
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
    }

    public class RealmEventArgs : EventArgs
    {
        public Realm RealmSelected { get; set; }
    }
}
