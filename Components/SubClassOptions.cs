using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class SubClassOptions : OptionsBase
    {
        public SubClassOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            UIHelper.SetControlBitwiseValue(this, sc.CurrentProfile.SubClass.Value);
            this.Enabled = sc.CurrentProfile.SubClassFilter.Value;
        }

        public void UIToProfile()
        {
            sc.CurrentProfile.SubClass = UIHelper.GetControlBitwiseValue(this);
            sc.CurrentProfile.SubClassFilter = this.Enabled;
        }
    }
}
