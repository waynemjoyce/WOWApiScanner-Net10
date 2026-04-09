namespace WOWAuctionApi_Net10
{
    partial class MainOptions
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
            lblSellRate = new Label();
            lblSearchWorth = new Label();
            txtSearchMinSellRate = new TextBox();
            txtSearchWorth = new TextBox();
            pnlSubOptions = new Panel();
            rbSearch_MaxG = new RadioButton();
            rbSearch_Percentage = new RadioButton();
            txtSearchMaxG = new TextBox();
            txtSearchPercentage = new TextBox();
            lblSearchCharLevel = new Label();
            txtSearchMaxCharLevel = new TextBox();
            txtSearchMinCharLevel = new TextBox();
            lblSearchItemLevel = new Label();
            txtSearchMaxItemLevel = new TextBox();
            txtSearchMinItemLevel = new TextBox();
            pnlSubOptions.SuspendLayout();
            SuspendLayout();
            // 
            // lblSellRate
            // 
            lblSellRate.AutoSize = true;
            lblSellRate.Location = new Point(273, 193);
            lblSellRate.Name = "lblSellRate";
            lblSellRate.Size = new Size(106, 32);
            lblSellRate.TabIndex = 153;
            lblSellRate.Text = "Sell Rate";
            // 
            // lblSearchWorth
            // 
            lblSearchWorth.AutoSize = true;
            lblSearchWorth.Location = new Point(273, 148);
            lblSearchWorth.Name = "lblSearchWorth";
            lblSearchWorth.Size = new Size(79, 32);
            lblSearchWorth.TabIndex = 152;
            lblSearchWorth.Text = "Worth";
            // 
            // txtSearchMinSellRate
            // 
            txtSearchMinSellRate.Location = new Point(406, 191);
            txtSearchMinSellRate.Name = "txtSearchMinSellRate";
            txtSearchMinSellRate.Size = new Size(123, 39);
            txtSearchMinSellRate.TabIndex = 151;
            txtSearchMinSellRate.Text = "-1";
            // 
            // txtSearchWorth
            // 
            txtSearchWorth.Location = new Point(406, 146);
            txtSearchWorth.Name = "txtSearchWorth";
            txtSearchWorth.Size = new Size(123, 39);
            txtSearchWorth.TabIndex = 150;
            txtSearchWorth.Text = "20000";
            // 
            // pnlSubOptions
            // 
            pnlSubOptions.Controls.Add(rbSearch_MaxG);
            pnlSubOptions.Controls.Add(rbSearch_Percentage);
            pnlSubOptions.Controls.Add(txtSearchMaxG);
            pnlSubOptions.Controls.Add(txtSearchPercentage);
            pnlSubOptions.Location = new Point(272, 230);
            pnlSubOptions.Name = "pnlSubOptions";
            pnlSubOptions.Size = new Size(259, 89);
            pnlSubOptions.TabIndex = 149;
            // 
            // rbSearch_MaxG
            // 
            rbSearch_MaxG.AutoSize = true;
            rbSearch_MaxG.Checked = true;
            rbSearch_MaxG.Location = new Point(6, 50);
            rbSearch_MaxG.Name = "rbSearch_MaxG";
            rbSearch_MaxG.Size = new Size(95, 36);
            rbSearch_MaxG.TabIndex = 130;
            rbSearch_MaxG.TabStop = true;
            rbSearch_MaxG.Text = "Gold";
            rbSearch_MaxG.UseVisualStyleBackColor = true;
            // 
            // rbSearch_Percentage
            // 
            rbSearch_Percentage.AutoSize = true;
            rbSearch_Percentage.Location = new Point(6, 5);
            rbSearch_Percentage.Name = "rbSearch_Percentage";
            rbSearch_Percentage.Size = new Size(65, 36);
            rbSearch_Percentage.TabIndex = 129;
            rbSearch_Percentage.Text = "%";
            rbSearch_Percentage.UseVisualStyleBackColor = true;
            // 
            // txtSearchMaxG
            // 
            txtSearchMaxG.Location = new Point(134, 48);
            txtSearchMaxG.Name = "txtSearchMaxG";
            txtSearchMaxG.Size = new Size(123, 39);
            txtSearchMaxG.TabIndex = 126;
            txtSearchMaxG.Text = "199";
            // 
            // txtSearchPercentage
            // 
            txtSearchPercentage.Location = new Point(134, 4);
            txtSearchPercentage.Name = "txtSearchPercentage";
            txtSearchPercentage.Size = new Size(123, 39);
            txtSearchPercentage.TabIndex = 125;
            txtSearchPercentage.Text = "5";
            // 
            // lblSearchCharLevel
            // 
            lblSearchCharLevel.AutoSize = true;
            lblSearchCharLevel.Location = new Point(273, 103);
            lblSearchCharLevel.Name = "lblSearchCharLevel";
            lblSearchCharLevel.Size = new Size(125, 32);
            lblSearchCharLevel.TabIndex = 148;
            lblSearchCharLevel.Text = "Char Level";
            // 
            // txtSearchMaxCharLevel
            // 
            txtSearchMaxCharLevel.Location = new Point(469, 101);
            txtSearchMaxCharLevel.MaxLength = 3;
            txtSearchMaxCharLevel.Name = "txtSearchMaxCharLevel";
            txtSearchMaxCharLevel.Size = new Size(60, 39);
            txtSearchMaxCharLevel.TabIndex = 147;
            txtSearchMaxCharLevel.Text = "80";
            // 
            // txtSearchMinCharLevel
            // 
            txtSearchMinCharLevel.Location = new Point(406, 101);
            txtSearchMinCharLevel.MaxLength = 3;
            txtSearchMinCharLevel.Name = "txtSearchMinCharLevel";
            txtSearchMinCharLevel.Size = new Size(60, 39);
            txtSearchMinCharLevel.TabIndex = 146;
            txtSearchMinCharLevel.Text = "0";
            // 
            // lblSearchItemLevel
            // 
            lblSearchItemLevel.AutoSize = true;
            lblSearchItemLevel.Location = new Point(273, 58);
            lblSearchItemLevel.Name = "lblSearchItemLevel";
            lblSearchItemLevel.Size = new Size(124, 32);
            lblSearchItemLevel.TabIndex = 145;
            lblSearchItemLevel.Text = "Item Level";
            // 
            // txtSearchMaxItemLevel
            // 
            txtSearchMaxItemLevel.Location = new Point(469, 56);
            txtSearchMaxItemLevel.MaxLength = 3;
            txtSearchMaxItemLevel.Name = "txtSearchMaxItemLevel";
            txtSearchMaxItemLevel.Size = new Size(60, 39);
            txtSearchMaxItemLevel.TabIndex = 144;
            txtSearchMaxItemLevel.Text = "999";
            // 
            // txtSearchMinItemLevel
            // 
            txtSearchMinItemLevel.Location = new Point(406, 56);
            txtSearchMinItemLevel.MaxLength = 3;
            txtSearchMinItemLevel.Name = "txtSearchMinItemLevel";
            txtSearchMinItemLevel.Size = new Size(60, 39);
            txtSearchMinItemLevel.TabIndex = 143;
            txtSearchMinItemLevel.Text = "0";
            // 
            // MainOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(lblSellRate);
            Controls.Add(lblSearchWorth);
            Controls.Add(txtSearchMinSellRate);
            Controls.Add(txtSearchWorth);
            Controls.Add(pnlSubOptions);
            Controls.Add(lblSearchCharLevel);
            Controls.Add(txtSearchMaxCharLevel);
            Controls.Add(txtSearchMinCharLevel);
            Controls.Add(lblSearchItemLevel);
            Controls.Add(txtSearchMaxItemLevel);
            Controls.Add(txtSearchMinItemLevel);
            Name = "MainOptions";
            OptionsTitle = "      Main Options";
            Size = new Size(551, 331);
            Controls.SetChildIndex(txtSearchMinItemLevel, 0);
            Controls.SetChildIndex(txtSearchMaxItemLevel, 0);
            Controls.SetChildIndex(lblSearchItemLevel, 0);
            Controls.SetChildIndex(txtSearchMinCharLevel, 0);
            Controls.SetChildIndex(txtSearchMaxCharLevel, 0);
            Controls.SetChildIndex(lblSearchCharLevel, 0);
            Controls.SetChildIndex(pnlSubOptions, 0);
            Controls.SetChildIndex(txtSearchWorth, 0);
            Controls.SetChildIndex(txtSearchMinSellRate, 0);
            Controls.SetChildIndex(lblSearchWorth, 0);
            Controls.SetChildIndex(lblSellRate, 0);
            pnlSubOptions.ResumeLayout(false);
            pnlSubOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSellRate;
        private Label lblSearchWorth;
        private TextBox txtSearchMinSellRate;
        private TextBox txtSearchWorth;
        private Panel pnlSubOptions;
        private RadioButton rbSearch_MaxG;
        private RadioButton rbSearch_Percentage;
        private TextBox txtSearchMaxG;
        private TextBox txtSearchPercentage;
        private Label lblSearchCharLevel;
        private TextBox txtSearchMaxCharLevel;
        private TextBox txtSearchMinCharLevel;
        private Label lblSearchItemLevel;
        private TextBox txtSearchMaxItemLevel;
        private TextBox txtSearchMinItemLevel;
    }
}
