namespace WOWAuctionApi_Net10
{
    partial class FormMouseTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtX = new TextBox();
            txtY = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnMoveMouse = new Button();
            btnMoveAndLMC = new Button();
            btnMoveAndRMC = new Button();
            btnGetMouseXY = new Button();
            btnMoveAndPaste = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            btnPostAuctions = new Button();
            txtInteractionScript = new TextBox();
            btnRunScript = new Button();
            button3 = new Button();
            btnGeneralTest = new Button();
            txtUnpickLockRows = new TextBox();
            label3 = new Label();
            btnUnpickLocks = new Button();
            SuspendLayout();
            // 
            // txtX
            // 
            txtX.Location = new Point(173, 60);
            txtX.Name = "txtX";
            txtX.Size = new Size(89, 39);
            txtX.TabIndex = 0;
            txtX.Text = "100";
            // 
            // txtY
            // 
            txtY.Location = new Point(323, 60);
            txtY.Name = "txtY";
            txtY.Size = new Size(94, 39);
            txtY.TabIndex = 1;
            txtY.Text = "200";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 60);
            label1.Name = "label1";
            label1.Size = new Size(25, 32);
            label1.TabIndex = 2;
            label1.Text = "x";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(291, 60);
            label2.Name = "label2";
            label2.Size = new Size(26, 32);
            label2.TabIndex = 3;
            label2.Text = "y";
            // 
            // btnMoveMouse
            // 
            btnMoveMouse.Location = new Point(127, 150);
            btnMoveMouse.Name = "btnMoveMouse";
            btnMoveMouse.Size = new Size(290, 46);
            btnMoveMouse.TabIndex = 4;
            btnMoveMouse.Text = "Move Mouse";
            btnMoveMouse.UseVisualStyleBackColor = true;
            btnMoveMouse.Click += btnMoveMouse_Click;
            // 
            // btnMoveAndLMC
            // 
            btnMoveAndLMC.Location = new Point(127, 213);
            btnMoveAndLMC.Name = "btnMoveAndLMC";
            btnMoveAndLMC.Size = new Size(290, 46);
            btnMoveAndLMC.TabIndex = 5;
            btnMoveAndLMC.Text = "Move and LMC";
            btnMoveAndLMC.UseVisualStyleBackColor = true;
            // 
            // btnMoveAndRMC
            // 
            btnMoveAndRMC.Location = new Point(127, 275);
            btnMoveAndRMC.Name = "btnMoveAndRMC";
            btnMoveAndRMC.Size = new Size(290, 46);
            btnMoveAndRMC.TabIndex = 6;
            btnMoveAndRMC.Text = "Move And RMC";
            btnMoveAndRMC.UseVisualStyleBackColor = true;
            // 
            // btnGetMouseXY
            // 
            btnGetMouseXY.Location = new Point(127, 338);
            btnGetMouseXY.Name = "btnGetMouseXY";
            btnGetMouseXY.Size = new Size(290, 46);
            btnGetMouseXY.TabIndex = 7;
            btnGetMouseXY.Text = "Get Mouse XY";
            btnGetMouseXY.UseVisualStyleBackColor = true;
            btnGetMouseXY.Click += btnGetMouseXY_Click;
            // 
            // btnMoveAndPaste
            // 
            btnMoveAndPaste.Location = new Point(127, 398);
            btnMoveAndPaste.Name = "btnMoveAndPaste";
            btnMoveAndPaste.Size = new Size(290, 46);
            btnMoveAndPaste.TabIndex = 8;
            btnMoveAndPaste.Text = "Move and Paste";
            btnMoveAndPaste.UseVisualStyleBackColor = true;
            btnMoveAndPaste.Click += btnMoveAndPaste_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1471, 256);
            button1.Name = "button1";
            button1.Size = new Size(255, 46);
            button1.TabIndex = 9;
            button1.Text = "Realms by auc #";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(482, 55);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(888, 505);
            textBox1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(1471, 308);
            button2.Name = "button2";
            button2.Size = new Size(255, 46);
            button2.TabIndex = 11;
            button2.Text = "Active realms";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnPostAuctions
            // 
            btnPostAuctions.Location = new Point(1495, 12);
            btnPostAuctions.Name = "btnPostAuctions";
            btnPostAuctions.Size = new Size(374, 46);
            btnPostAuctions.TabIndex = 12;
            btnPostAuctions.Text = "Post Auctions";
            btnPostAuctions.UseVisualStyleBackColor = true;
            btnPostAuctions.Click += btnPostAuctions_Click;
            // 
            // txtInteractionScript
            // 
            txtInteractionScript.Location = new Point(332, 583);
            txtInteractionScript.Name = "txtInteractionScript";
            txtInteractionScript.Size = new Size(339, 39);
            txtInteractionScript.TabIndex = 13;
            txtInteractionScript.Text = "test1";
            // 
            // btnRunScript
            // 
            btnRunScript.Location = new Point(678, 590);
            btnRunScript.Name = "btnRunScript";
            btnRunScript.Size = new Size(150, 46);
            btnRunScript.TabIndex = 14;
            btnRunScript.Text = "Run Script";
            btnRunScript.UseVisualStyleBackColor = true;
            btnRunScript.Click += btnRunScript_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1471, 360);
            button3.Name = "button3";
            button3.Size = new Size(255, 46);
            button3.TabIndex = 15;
            button3.Text = "A to Z Realms";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btnGeneralTest
            // 
            btnGeneralTest.Location = new Point(1471, 514);
            btnGeneralTest.Name = "btnGeneralTest";
            btnGeneralTest.Size = new Size(255, 46);
            btnGeneralTest.TabIndex = 16;
            btnGeneralTest.Text = "General Test";
            btnGeneralTest.UseVisualStyleBackColor = true;
            btnGeneralTest.Click += btnGeneralTest_Click;
            // 
            // txtUnpickLockRows
            // 
            txtUnpickLockRows.Location = new Point(1479, 702);
            txtUnpickLockRows.Name = "txtUnpickLockRows";
            txtUnpickLockRows.Size = new Size(200, 39);
            txtUnpickLockRows.TabIndex = 17;
            txtUnpickLockRows.Text = "5";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1353, 708);
            label3.Name = "label3";
            label3.Size = new Size(68, 32);
            label3.TabIndex = 18;
            label3.Text = "Rows";
            // 
            // btnUnpickLocks
            // 
            btnUnpickLocks.Location = new Point(1724, 705);
            btnUnpickLocks.Name = "btnUnpickLocks";
            btnUnpickLocks.Size = new Size(150, 46);
            btnUnpickLocks.TabIndex = 19;
            btnUnpickLocks.Text = "Unpick";
            btnUnpickLocks.UseVisualStyleBackColor = true;
            btnUnpickLocks.Click += btnUnpickLocks_Click;
            // 
            // FormMouseTest
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2158, 1085);
            Controls.Add(btnUnpickLocks);
            Controls.Add(label3);
            Controls.Add(txtUnpickLockRows);
            Controls.Add(btnGeneralTest);
            Controls.Add(button3);
            Controls.Add(btnRunScript);
            Controls.Add(txtInteractionScript);
            Controls.Add(btnPostAuctions);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(btnMoveAndPaste);
            Controls.Add(btnGetMouseXY);
            Controls.Add(btnMoveAndRMC);
            Controls.Add(btnMoveAndLMC);
            Controls.Add(btnMoveMouse);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtY);
            Controls.Add(txtX);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMouseTest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mouse Events Test Form";
            Load += FormMouseTest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtX;
        private TextBox txtY;
        private Label label1;
        private Label label2;
        private Button btnMoveMouse;
        private Button btnMoveAndLMC;
        private Button btnMoveAndRMC;
        private Button btnGetMouseXY;
        private Button btnMoveAndPaste;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Button btnPostAuctions;
        private TextBox txtInteractionScript;
        private Button btnRunScript;
        private Button button3;
        private Button btnGeneralTest;
        private TextBox txtUnpickLockRows;
        private Label label3;
        private Button btnUnpickLocks;
    }
}