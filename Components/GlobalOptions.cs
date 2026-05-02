using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class GlobalOptions : OptionsBase
    {
        [Category("WOWAPI Options")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Threshold
        {
            get { return int.Parse(txtThreshold.Text); }
            set { txtThreshold.Text = value.ToString(); }
        }

        [Category("WOWAPI Options")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool SearchOnSelect
        {
            get { return tslSearchOnSelect.Checked; }
            set { tslSearchOnSelect.Checked = value; }
        }

        [Category("WOWAPI Options")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool NewDataOnly
        {
            get { return tslNewDataOnly.Checked; }
            set { tslNewDataOnly.Checked = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowSuboptions
        {
            get { return this.pnlSubOptions.Visible; }
            set { this.pnlSubOptions.Visible = value; }
        }

        public GlobalOptions()
        {
            InitializeComponent();
        }
    }
}
