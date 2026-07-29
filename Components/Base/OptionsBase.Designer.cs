namespace WOWAuctionApi_Net10
{
    partial class OptionsBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsBase));
            lblTitle = new Label();
            btnToggle = new Button();
            tslEnabled = new ToggleSlider();
            labelBlock = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.ControlDark;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(576, 41);
            lblTitle.TabIndex = 129;
            lblTitle.Text = "      [Set OptionsTitle]";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnToggle
            // 
            btnToggle.BackColor = SystemColors.ControlDark;
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.Image = (Image)resources.GetObject("btnToggle.Image");
            btnToggle.Location = new Point(3, 3);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(36, 36);
            btnToggle.TabIndex = 130;
            btnToggle.UseVisualStyleBackColor = false;
            btnToggle.Click += btnToggle_Click;
            // 
            // tslEnabled
            // 
            tslEnabled.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tslEnabled.BackColor = SystemColors.ControlDark;
            tslEnabled.Checked = true;
            tslEnabled.CheckState = CheckState.Checked;
            tslEnabled.ForeColor = Color.LimeGreen;
            tslEnabled.Location = new Point(514, 5);
            tslEnabled.MinimumSize = new Size(46, 22);
            tslEnabled.Name = "tslEnabled";
            tslEnabled.OffBackColor = Color.Gray;
            tslEnabled.OffToggleColor = Color.Gainsboro;
            tslEnabled.OnBackColor = Color.LimeGreen;
            tslEnabled.OnToggleColor = Color.PaleGreen;
            tslEnabled.OptionBit = 0;
            tslEnabled.OptionValue = "";
            tslEnabled.Size = new Size(60, 32);
            tslEnabled.TabIndex = 147;
            tslEnabled.Tag = "!EXCLUDE";
            tslEnabled.UseVisualStyleBackColor = false;
            tslEnabled.CheckedChanged += tslEnabled_CheckedChanged;
            // 
            // labelBlock
            // 
            labelBlock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelBlock.Location = new Point(3, 42);
            labelBlock.Name = "labelBlock";
            labelBlock.Size = new Size(573, 331);
            labelBlock.TabIndex = 148;
            labelBlock.Visible = false;
            // 
            // OptionsBase
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(labelBlock);
            Controls.Add(tslEnabled);
            Controls.Add(btnToggle);
            Controls.Add(lblTitle);
            Name = "OptionsBase";
            Size = new Size(576, 373);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Button btnToggle;
        private ToggleSlider tslEnabled;
        private Label labelBlock;
    }
}
