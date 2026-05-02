using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WOWAuctionApi_Net10.Json_Classes;

namespace WOWAuctionApi_Net10
{
    public partial class ConfigTextOptions : OptionsBase
    {
        public ConfigTextOptions()
        {
            InitializeComponent();
        }

        public void SaveToConfig()
        {
            sc.Config.BlizzClientID = txtBlizzClientID.Text;
            sc.Config.BlizzClientSecret = txtBlizzClientSecret.Text;
            sc.Config.TSMKey = txtTSMKey.Text;
            sc.Config.TSMClientID = txtTSMClientID.Text;
            sc.Config.DefaultSearch = cboDefaultSearch.Text;
        }

        public void LoadFromConfig()
        {
            txtBlizzClientID.Text = sc.Config.BlizzClientID;
            txtBlizzClientSecret.Text = sc.Config.BlizzClientSecret;
            txtTSMKey.Text = sc.Config.TSMKey;
            txtTSMClientID.Text = sc.Config.TSMClientID;

            foreach (SearchProfile profile in sc.SearchProfiles.Profiles)
            {
               cboDefaultSearch.Items.Add(profile.ProfileName);    
            }
            cboDefaultSearch.Text = sc.Config.DefaultSearch;
        }
    }
}
