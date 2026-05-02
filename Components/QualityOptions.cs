using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class QualityOptions : OptionsBase
    {
        public QualityOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            UIHelper.SetControlBitwiseValue(this, sc.CurrentProfile.Quality.Value);
        }

        public void UIToProfile()
        {
            sc.CurrentProfile.Quality = UIHelper.GetControlBitwiseValue(this);
        }
    }
}
