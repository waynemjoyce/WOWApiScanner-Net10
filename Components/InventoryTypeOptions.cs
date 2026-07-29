using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class InventoryTypeOptions : OptionsBase
    {
        public InventoryTypeOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            UIHelper.SetControlBitwiseValue(this, sc.CurrentProfile.InventoryType.Value);
            this.Enabled = sc.CurrentProfile.InventoryTypeFilter.Value;
        }

        public void UIToProfile()
        {
            sc.CurrentProfile.InventoryType = UIHelper.GetControlBitwiseValue(this);
            sc.CurrentProfile.InventoryTypeFilter = this.Enabled;
        }
    }
}
