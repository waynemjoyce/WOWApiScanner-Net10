using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class ManageRealm : OptionsBase
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Realm Realm
        {
            get { return realm; }
            set { realm = value; }
        }



        private Realm realm = new Realm();

        /*
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color RealmColor
        {
            get { return colorEditor1.Color; }
            set { colorEditor1.Color = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RealmName
        {
            get { return txtRealmName.Text; }
            set { txtRealmName.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RealmId
        {
            get { return (int)numRealmId.Value; }
            set { numRealmId.Value = value; }
        }
        */

        public ManageRealm()
        {
            InitializeComponent();
        }

        public void InitRealm(Realm realm)
        {
            this.realm = realm;
            txtRealmName.Text = realm.RealmName;
            numRealmId.Value = realm.RealmId.Value;
            colorEditor1.Color = UIHelper.StringToColor(realm.BackColor);
            txtStock.Text = realm.Stock.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveRealm_Click(object sender, EventArgs e)
        {
            this.realm.RealmName = txtRealmName.Text;
            this.realm.RealmId = (int)numRealmId.Value;
            this.realm.BackColor = UIHelper.ColorToString(colorEditor1.Color);
            this.realm.Stock = int.Parse(txtStock.Text);
        }
    }
}
