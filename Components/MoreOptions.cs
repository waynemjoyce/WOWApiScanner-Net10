using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class MoreOptions : OptionsBase
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
            this.rbChartShowAll.Checked = (sc.CurrentProfile.ChartFilter == 0);
            this.rbChartTotalValue.Checked = (sc.CurrentProfile.ChartFilter == 1);
            this.rbChartSearchHits.Checked = (sc.CurrentProfile.ChartFilter == 2);
            this.rbChartTotalAuctions.Checked = (sc.CurrentProfile.ChartFilter == 3);

        }

        public void UIToProfile()
        {
            if (this.rbSearchRemoveDuplicates.Checked) { sc.CurrentProfile.SearchFrequency = 0; }
            if (this.rbSearchShowCheapest.Checked) { sc.CurrentProfile.SearchFrequency = 1; }
            if (this.rbSearchShowAllItems.Checked) { sc.CurrentProfile.SearchFrequency = 2; }
            sc.CurrentProfile.StringFilter = this.txtSearchStringFilter.Text.Trim();
            if (this.rbChartShowAll.Checked) { sc.CurrentProfile.ChartFilter = 0; }
            if (this.rbChartTotalValue.Checked) { sc.CurrentProfile.ChartFilter = 1; }
            if (this.rbChartSearchHits.Checked) { sc.CurrentProfile.ChartFilter = 2; }
            if (this.rbChartTotalAuctions.Checked) { sc.CurrentProfile.ChartFilter = 3; }
        }   

        private void MoreOptions_Load(object sender, EventArgs e)
        {
            rbChartTotalValue.Text = $"Top {sc.Config.ChartMarketValue} Realms Total Value";
            rbChartSearchHits.Text = $"Top {sc.Config.ChartSearchHits} Realms Search Hits";
            rbChartTotalAuctions.Text = $"Top {sc.Config.ChartTotalAuctions} Realms Total Auctions";
        }
    }
}
