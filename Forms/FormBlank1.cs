using Cyotek.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10.Forms
{
    public partial class FormBlank1 : Form
    {
        public FormBlank1()
        {
            InitializeComponent();
        }

        private void colorWheel1_ColorChanged(object sender, EventArgs e)
        {
            colorEditor1.Color = colorWheel1.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorEditorManager1 = new ColorEditorManager();
            colorEditorManager1.ScreenColorPicker.Show();
        }

        private void colorEditor1_ColorChanged(object sender, EventArgs e)
        {
            lblColor.BackColor = colorEditor1.Color;
        }
    }
}
