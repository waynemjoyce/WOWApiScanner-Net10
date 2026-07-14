using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10.Forms
{
    public partial class FormEditRealm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Realm Realm
        {
            get { return realm; }
            set { realm = value; }
        }

        private Realm realm;

        public FormEditRealm()
        {
            InitializeComponent();
        }

        public void LoadRealm(Realm r)
        {
            this.realm = r;
            txtRealmName.Text = realm.RealmName;
            numRealmId.Value = realm.RealmId.Value;
            colorEditor1.Color = UIHelper.StringToColor(realm.BackColor);
            txtStock.Text = realm.Stock.Value.ToString();
            tslFlagged.Checked = realm.Flagged.Value;
            tslActive.Checked = realm.Active.Value;
            txtArea.Text = realm.Area;  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            realm.Flagged = tslFlagged.Checked;
            realm.RealmName = txtRealmName.Text;
            realm.RealmId = (int)numRealmId.Value;
            realm.Stock = int.Parse(txtStock.Text);
            realm.BackColor = UIHelper.ColorToString(colorEditor1.Color);
            realm.Active = tslActive.Checked;
            realm.Area = txtArea.Text;
        }

        private void colorWheel1_ColorChanged(object sender, EventArgs e)
        {
            colorEditor1.Color = colorWheel1.Color;
        }

        private void colorEditor1_ColorChanged(object sender, EventArgs e)
        {
            lblColor.BackColor = colorEditor1.Color;
            lblColor.Text = " " + UIHelper.ColorToString(colorEditor1.Color);
        }
    }
}
