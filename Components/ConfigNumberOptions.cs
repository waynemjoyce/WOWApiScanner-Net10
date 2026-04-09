using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class ConfigNumberOptions : BaseOptions
    {
        public ConfigNumberOptions()
        {
            InitializeComponent();
        }

        public void SaveToConfig()
        {
            sc.Config.AuctionsCap = (int)numAuctionsCap.Value;
            sc.Config.ItemsSearchCap = (int)numItemsSearchCap.Value;
            sc.Config.LatestXpacItemId = (long)numLatestXpacItemId.Value;
            sc.Config.LivePollInterval = (int)numPollInterval.Value;
            sc.Config.OnlyFirst = (int)numOnlyFirst.Value;
            sc.Config.Threshold = (int)numThreshold.Value;
        }

        public void LoadFromConfig()
        {
            numAuctionsCap.Value = sc.Config.AuctionsCap.Value;
            numItemsSearchCap.Value = sc.Config.ItemsSearchCap.Value;
            numLatestXpacItemId.Value = sc.Config.LatestXpacItemId.Value;
            numPollInterval.Value = sc.Config.LivePollInterval.Value;
            numOnlyFirst.Value = sc.Config.OnlyFirst.Value;
            numThreshold.Value = sc.Config.Threshold.Value;
        }
    }
}
