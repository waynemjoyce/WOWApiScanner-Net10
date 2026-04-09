namespace WOWAuctionApi_Net10.Forms
{
    partial class FormBlank1
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
            colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
            colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            colorWheel1 = new Cyotek.Windows.Forms.ColorWheel();
            screenColorPicker1 = new Cyotek.Windows.Forms.ScreenColorPicker();
            colorEditorManager2 = new Cyotek.Windows.Forms.ColorEditorManager();
            screenColorPicker2 = new Cyotek.Windows.Forms.ScreenColorPicker();
            lblColor = new Label();
            colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            colorEditorManager3 = new Cyotek.Windows.Forms.ColorEditorManager();
            button1 = new Button();
            SuspendLayout();
            // 
            // colorGrid1
            // 
            colorGrid1.Location = new Point(51, 26);
            colorGrid1.Name = "colorGrid1";
            colorGrid1.Size = new Size(400, 200);
            colorGrid1.TabIndex = 0;
            // 
            // colorEditorManager1
            // 
            colorEditorManager1.Color = Color.Empty;
            // 
            // colorWheel1
            // 
            colorWheel1.Alpha = 1D;
            colorWheel1.Location = new Point(576, 33);
            colorWheel1.Name = "colorWheel1";
            colorWheel1.Size = new Size(500, 494);
            colorWheel1.TabIndex = 1;
            colorWheel1.ColorChanged += colorWheel1_ColorChanged;
            // 
            // screenColorPicker1
            // 
            screenColorPicker1.Color = Color.Empty;
            screenColorPicker1.Location = new Point(1199, 54);
            screenColorPicker1.Name = "screenColorPicker1";
            screenColorPicker1.Size = new Size(150, 46);
            screenColorPicker1.Text = "screenColorPicker1";
            // 
            // colorEditorManager2
            // 
            colorEditorManager2.Color = Color.Empty;
            // 
            // screenColorPicker2
            // 
            screenColorPicker2.Color = Color.Empty;
            screenColorPicker2.Location = new Point(128, 376);
            screenColorPicker2.Name = "screenColorPicker2";
            screenColorPicker2.Size = new Size(150, 46);
            screenColorPicker2.Text = "screenColorPicker2";
            // 
            // lblColor
            // 
            lblColor.BackColor = Color.RosyBrown;
            lblColor.Location = new Point(1402, 663);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(260, 53);
            lblColor.TabIndex = 3;
            // 
            // colorEditor1
            // 
            colorEditor1.Location = new Point(1151, 110);
            colorEditor1.Margin = new Padding(6, 7, 6, 7);
            colorEditor1.Name = "colorEditor1";
            colorEditor1.Size = new Size(750, 562);
            colorEditor1.TabIndex = 2;
            colorEditor1.ColorChanged += colorEditor1_ColorChanged;
            // 
            // colorEditorManager3
            // 
            colorEditorManager3.Color = Color.Empty;
            // 
            // button1
            // 
            button1.Location = new Point(551, 712);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormBlank1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2003, 1108);
            Controls.Add(button1);
            Controls.Add(lblColor);
            Controls.Add(screenColorPicker2);
            Controls.Add(colorEditor1);
            Controls.Add(screenColorPicker1);
            Controls.Add(colorWheel1);
            Controls.Add(colorGrid1);
            Name = "FormBlank1";
            Text = "FormBlank1";
            ResumeLayout(false);
        }

        #endregion

        private Cyotek.Windows.Forms.ColorGrid colorGrid1;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private Cyotek.Windows.Forms.ColorWheel colorWheel1;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker1;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager2;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker2;
        private Label lblColor;
        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager3;
        private Button button1;
    }
}