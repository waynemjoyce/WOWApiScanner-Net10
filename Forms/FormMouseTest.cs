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
        public int ProcessId { get; set; }
        public FormMouseTest()
        {
            InitializeComponent();
        }

        private void btnGetMouseXY_Click(object sender, EventArgs e)
        {
            HelpProc.ActivateApp(ProcessId);
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
            var interactionScript = new InteractionScript();
            interactionScript.ScriptName = "TestScript2";

            interactionScript.Events = new List<InteractionEvent>
                {
                    new InteractionEvent
                    {
                        EventType = InteractionEventType.MouseMove,
                        MouseClickType = InteractionMouseClickType.Left,
                        X = 100,
                        Y = 200,
                        DelayBefore = 500,
                        DelayBetween = 500,
                        DelayAfter = 500,
                        KeysToSend = "Test"
                    },
                    new InteractionEvent
                    {
                        EventType = InteractionEventType.MouseMoveAndClick,
                        MouseClickType = InteractionMouseClickType.Left,
                        X = 100,
                        Y = 200,
                        DelayBefore = 500,
                        DelayBetween = 500,
                        DelayAfter = 500,
                        KeysToSend = "Test"
                    },
                    new InteractionEvent
                    {
                        EventType = InteractionEventType.Activate,
                        MouseClickType = InteractionMouseClickType.Left,
                        X = 100,
                        Y = 200,
                        DelayBefore = 500,
                        DelayBetween = 500,
                        DelayAfter = 500,
                        KeysToSend = "Test"
                    },
                    new InteractionEvent
                    {
                        EventType = InteractionEventType.SendKeys,
                        MouseClickType = InteractionMouseClickType.Left,
                        X = 100,
                        Y = 200,
                        DelayBefore = 500,
                        DelayBetween = 500,
                        DelayAfter = 500,
                        KeysToSend = "Test"
                    }
                };
            this.textBox1.Text = interactionScript.ToJson();
            interactionScript.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InteractionScript ins = (InteractionScript)InteractionScript.LoadFromFile("", "wowahbuy");
            ins.ProcessScript();
        }
    }
}
