using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class OptionsBase : ComponentBase
    {
        [Category("WOWAPI Options")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string OptionsTitle 
        { 
            get { return lblTitle.Text; } 
            set { lblTitle.Text = value; }  
        }

        [Category("WOWAPI Options")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowToggleButton
        { 
            get { return btnToggle.Visible; }  
            set { btnToggle.Visible = value; } 
        }

        public OptionsBase()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            UIHelper.ToggleOnOffClick(sender, e);
        }
    }
}
