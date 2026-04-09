using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WOWAuctionApi_Net10.Json_Classes;

namespace WOWAuctionApi_Net10
{
    public partial class FormPreferences : Form
    {
        public FormPreferences()
        {
            InitializeComponent();
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            realmOptions1.ViewMode = DisplayMode.Config;
            realmOptions1.LoadRealms();
            UIHelper.RenderUIOptionsSet(sc.UIOptions.OptionSets.Single(set => set.SetName == "Config"), configCheckOptions1);
            configTextOptions1.LoadFromConfig();
            configNumberOptions1.LoadFromConfig();
            UIHelper.SetControlBitwiseValue(configCheckOptions1, sc.Config.ConfigChecks.Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configTextOptions1.SaveToConfig();
            configNumberOptions1.SaveToConfig();
            sc.Config.ConfigChecks = UIHelper.GetControlBitwiseValue(configCheckOptions1);
        }

        private void realmOptions1_SelectedChanged(object sender, RealmEventArgs e)
        {
            manageRealm1.RealmColor = UIHelper.StringToColor(e.RealmSelected.BackColor);
            manageRealm1.RealmName = e.RealmSelected.RealmName;
            manageRealm1.RealmId = e.RealmSelected.RealmId.Value;
            manageRealm1.Realm = e.RealmSelected;
        }
    }
}
