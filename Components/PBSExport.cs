using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class PBSExport : BaseOptions
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ExportText
        {
            get { return this.txtPBSExport.Text; }
            set { this.txtPBSExport.Text = value; }
        }

        public PBSExport()
        {
            InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPBSExport.Text);
        }


        public void ItemListToPBS(ListView itemsInList)
        {
            txtPBSExport.Text = sc.CurrentItemList.Name;

            foreach (ListViewItem lvi in itemsInList.Items)
            {
                CacheItem item = lvi.Tag as CacheItem;
                if (item != null)
                {
                    txtPBSExport.Text += $"^\"{item.Name}\";;0;0;0;0;0;0;0;{item.BuyPrice};;";
                    //txtItemsSearchPBSKeys.Text += $"\"{item.Id} 0 1 0\",\r\n";
                }
            }
        }


    }
}
