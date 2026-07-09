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

    }

}