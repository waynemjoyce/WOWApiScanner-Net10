using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class MainOptions : OptionsBase
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowSuboptions 
        {
            get { return this.pnlSubOptions.Visible; } 
            set { this.pnlSubOptions.Visible = value; } 
        }

        public MainOptions()
        {
            InitializeComponent();
        }

        public void ProfileToUI()
        {
            UIHelper.SetControlBitwiseValue(this, sc.CurrentProfile.MainOptions.Value);
            this.txtSearchMaxG.Text = sc.CurrentProfile.SearchMaxG.Value.ToString();
            this.txtSearchMaxItemLevel.Text = sc.CurrentProfile.MaxItemLevel.Value.ToString();
            this.txtSearchMinItemLevel.Text = sc.CurrentProfile.MinItemLevel.Value.ToString();
            this.txtSearchMaxCharLevel.Text = sc.CurrentProfile.MaxCharLevel.Value.ToString();
            this.txtSearchMinCharLevel.Text = sc.CurrentProfile.MinCharLevel.Value.ToString();
            this.txtSearchMinSellRate.Text = sc.CurrentProfile.MinSellRate.Value.ToString();
            this.txtSearchPercentage.Text = sc.CurrentProfile.SearchPercentage.Value.ToString();
            this.txtSearchWorth.Text = sc.CurrentProfile.WorthAtLeast.Value.ToString();
            this.rbSearch_Percentage.Checked = (sc.CurrentProfile.SearchFraction.Value == 0);
            this.rbSearch_MaxG.Checked = (sc.CurrentProfile.SearchFraction.Value == 1);
            this.Enabled = sc.CurrentProfile.MainFilter.Value;
        }

        public void UIToProfile()
        {
            sc.CurrentProfile.MainOptions = UIHelper.GetControlBitwiseValue(this);
            sc.CurrentProfile.SearchMaxG = int.Parse(this.txtSearchMaxG.Text.Trim());
            sc.CurrentProfile.MaxItemLevel = int.Parse(this.txtSearchMaxItemLevel.Text.Trim());
            sc.CurrentProfile.MinItemLevel = int.Parse(this.txtSearchMinItemLevel.Text.Trim());
            sc.CurrentProfile.MaxCharLevel = int.Parse(this.txtSearchMaxCharLevel.Text.Trim());
            sc.CurrentProfile.MinCharLevel = int.Parse(this.txtSearchMinCharLevel.Text.Trim());
            sc.CurrentProfile.WorthAtLeast = int.Parse(this.txtSearchWorth.Text.Trim());
            sc.CurrentProfile.MinSellRate = float.Parse(this.txtSearchMinSellRate.Text);
            sc.CurrentProfile.SearchPercentage = float.Parse(this.txtSearchPercentage.Text);
            sc.CurrentProfile.SearchFraction = (rbSearch_Percentage.Checked) ? 0 : 1;
            sc.CurrentProfile.MainFilter = this.Enabled;
        }

    }
}
