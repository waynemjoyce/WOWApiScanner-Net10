using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class BonusOptions : BaseOptions
    {
        public BonusOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            UIHelper.SetControlBitwiseValue(this, sc.CurrentProfile.Bonuses.Value);
        }

        public void UIToProfile()
        {
            sc.CurrentProfile.Bonuses = UIHelper.GetControlBitwiseValue(this);
            
        }
    }
}
