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
            button1.Location = new Point(477, 60);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(680, 76);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(1108, 670);
            textBox1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(486, 163);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 11;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormMouseTest
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1843, 805);
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
    }
}