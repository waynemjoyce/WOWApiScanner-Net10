using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class ItemClassOptions : OptionsBase
    {
        public ItemClassOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            UIHelper.SetControlBitwiseValue(this, sc.CurrentProfile.Class.Value);
            this.Enabled = sc.CurrentProfile.ClassFilter.Value;
        }

        public void UIToProfile()
        {
            sc.CurrentProfile.Class = UIHelper.GetControlBitwiseValue(this);
            sc.CurrentProfile.ClassFilter = this.Enabled;
        }
    }
}
