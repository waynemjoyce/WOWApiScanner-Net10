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
        public Realm SelectedRealm = null;

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

            if (SelectedRealm != null)
            {
                SelectRealm(SelectedRealm);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configTextOptions1.SaveToConfig();
            configNumberOptions1.SaveToConfig();
            sc.Config.ConfigChecks = UIHelper.GetControlBitwiseValue(configCheckOptions1);
        }

        private void realmOptions1_SelectedChanged(object sender, RealmEventArgs e)
        {
            SelectRealm(e.RealmSelected);
        }

        private void SelectRealm(Realm selectedRealm)
        {
            manageRealm1.RealmColor = UIHelper.StringToColor(selectedRealm.BackColor);
            manageRealm1.RealmName = selectedRealm.RealmName;
            manageRealm1.RealmId = selectedRealm.RealmId.Value;
            manageRealm1.Realm = selectedRealm;
        }
    }

}