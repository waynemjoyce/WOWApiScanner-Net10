using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;


namespace WOWAuctionApi_Net10
{
    public partial class FormMouseTest : Form
    {

        public FormMouseTest()
        {
            InitializeComponent();
        }

        private void btnGetMouseXY_Click(object sender, EventArgs e)
        {
            ProcHelper.ActivateApp(sc.CurrentWoWProcess);
            Thread.Sleep(2000);
            this.txtX.Text = Cursor.Position.X.ToString();
            this.txtY.Text = Cursor.Position.Y.ToString();
            Clipboard.SetText(this.txtX.Text + " " + this.txtY.Text);
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
            textBox1.Clear();

            //List all unique values for X
            List<string> uniqueInventoryTypes = sc.Caches.ItemCache.Items
                .Select(p => p.SubClassName)
                .Distinct()
                .ToList();

            foreach (string type in uniqueInventoryTypes)
            {
                textBox1.Text += type + "\r\n";

            }

            /*
            BlizzItem bi = API_Blizzard.GetBlizzItemFromItemId(sc.BlizzAccessToken, long.Parse(this.textBox1.Text));

            if (bi != null)
            {
                //break point here
            }
            */

            //MessageBox.Show(sc.Config.Realms.Count.ToString());



            //int realmId = API_Blizzard.GetConnectedRealmFromName(sc.BlizzAccessToken, "Aerie Peak");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InteractionScript ins = (InteractionScript)InteractionScript.LoadFromFile("", "wowahbuy");
            ins.ProcessScript();
        }

        private void btnPostAuctions_Click(object sender, EventArgs e)
        {
            InteractionScript postAuctions = InteractionScript.LoadFromFile("", "postauctions");
            postAuctions.ProcessScript();
        }

        private void FormMouseTest_Load(object sender, EventArgs e)
        {

        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            InteractionScript script = InteractionScript.LoadFromFile("", txtInteractionScript.Text);
            script.ProcessID = sc.CurrentWoWProcess;
            script.ProcessScript();
        }
    }
}
