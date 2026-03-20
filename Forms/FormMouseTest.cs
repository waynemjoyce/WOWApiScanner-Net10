using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WOWAuctionApi_Net10
{
    public partial class FormMouseTest : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public FormCache fc { get; set; }
        public FormMouseTest()
        {
            InitializeComponent();
        }

        private void btnGetMouseXY_Click(object sender, EventArgs e)
        {
            ProcHelper.ActivateApp(fc.CurrentWoWProcess);
            Thread.Sleep(2000);
            this.txtX.Text = Cursor.Position.X.ToString();
            this.txtY.Text = Cursor.Position.Y.ToString();

        }

        private void btnMoveMouse_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveAndPaste_Click(object sender, EventArgs e)
        {
            int x = int.Parse(this.txtX.Text);
            int y = int.Parse(this.txtY.Text);


            SendKeys.Send("^a");
            Thread.Sleep(500);
            SendKeys.Send("^v");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            BlizzItem bi = API_Blizzard.GetBlizzItemFromItemId(fc.BlizzAccessToken, long.Parse(this.textBox1.Text));
                    
            if (bi != null)
            {
                //break point here
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InteractionScript ins = (InteractionScript)InteractionScript.LoadFromFile("", "wowahbuy");
            ins.ProcessScript();
        }
    }
}
