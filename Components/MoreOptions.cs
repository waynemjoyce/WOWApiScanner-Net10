using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class MoreOptions : BaseOptions
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowSuboptions
        {
            get { return this.pnlSubOptions.Visible; }
            set { this.pnlSubOptions.Visible = value; }
        }

        public MoreOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            this.rbSearchRemoveDuplicates.Checked = (sc.CurrentProfile.SearchFrequency == 0);
            this.rbSearchShowCheapest.Checked = (sc.CurrentProfile.SearchFrequency == 1);
            this.rbSearchShowAllItems.Checked = (sc.CurrentProfile.SearchFrequency == 2);
            this.txtSearchStringFilter.Text = sc.CurrentProfile.StringFilter;
        }

        public void UIToProfile()
        {
            if (this.rbSearchRemoveDuplicates.Checked) { sc.CurrentProfile.SearchFrequency = 0; }
            if (this.rbSearchShowCheapest.Checked) { sc.CurrentProfile.SearchFrequency = 1; }
            if (this.rbSearchShowAllItems.Checked) { sc.CurrentProfile.SearchFrequency = 2; }
            sc.CurrentProfile.StringFilter = this.txtSearchStringFilter.Text.Trim();
        }
    }
}
