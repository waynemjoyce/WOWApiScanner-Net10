namespace WOWAuctionApi_Net10
{
    partial class GlobalOptions
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
            lblSearchOnSelect = new Label();
            tslSearchOnSelect = new ToggleSlider();
            pnlSubOptions = new Panel();
            lblNewDataOnly = new Label();
            txtThreshold = new TextBox();
            tslNewDataOnly = new ToggleSlider();
            lblSearchThreshold = new Label();
            pnlSubOptions.SuspendLayout();
            SuspendLayout();
            // 
            // lblSearchOnSelect
            // 
            lblSearchOnSelect.AutoSize = true;
            lblSearchOnSelect.Font = new Font("Segoe UI", 9F);
            lblSearchOnSelect.ForeColor = Color.MediumPurple;
            lblSearchOnSelect.Location = new Point(80, 64);
            lblSearchOnSelect.Name = "lblSearchOnSelect";
            lblSearchOnSelect.Size = new Size(195, 32);
            lblSearchOnSelect.TabIndex = 146;
            lblSearchOnSelect.Text = "Search On Select";
            // 
            // tslSearchOnSelect
            // 
            tslSearchOnSelect.Checked = true;
            tslSearchOnSelect.CheckState = CheckState.Checked;
            tslSearchOnSelect.ForeColor = Color.LimeGreen;
            tslSearchOnSelect.Location = new Point(18, 65);
            tslSearchOnSelect.MinimumSize = new Size(46, 22);
            tslSearchOnSelect.Name = "tslSearchOnSelect";
            tslSearchOnSelect.OffBackColor = Color.Gray;
            tslSearchOnSelect.OffToggleColor = Color.Gainsboro;
            tslSearchOnSelect.OnBackColor = Color.MediumPurple;
            tslSearchOnSelect.OnToggleColor = Color.MistyRose;
            tslSearchOnSelect.OptionBit = 0;
            tslSearchOnSelect.OptionValue = "";
            tslSearchOnSelect.Size = new Size(60, 32);
            tslSearchOnSelect.TabIndex = 145;
            tslSearchOnSelect.Tag = "!EXCLUDE";
            tslSearchOnSelect.UseVisualStyleBackColor = true;
            // 
            // pnlSearch_GlobalOptions_SubOptions
            // 
            pnlSubOptions.Controls.Add(lblNewDataOnly);
            pnlSubOptions.Controls.Add(txtThreshold);
            pnlSubOptions.Controls.Add(tslNewDataOnly);
            pnlSubOptions.Controls.Add(lblSearchThreshold);
            pnlSubOptions.Location = new Point(16, 95);
            pnlSubOptions.Name = "pnlSearch_GlobalOptions_SubOptions";
            pnlSubOptions.Size = new Size(332, 128);
            pnlSubOptions.TabIndex = 147;
            pnlSubOptions.Visible = false;
            // 
            // lblNewDataOnly
            // 
            lblNewDataOnly.AutoSize = true;
            lblNewDataOnly.Font = new Font("Segoe UI", 9F);
            lblNewDataOnly.ForeColor = Color.Firebrick;
            lblNewDataOnly.Location = new Point(65, 3);
            lblNewDataOnly.Name = "lblNewDataOnly";
            lblNewDataOnly.Size = new Size(175, 32);
            lblNewDataOnly.TabIndex = 145;
            lblNewDataOnly.Text = "New Data Only";
            // 
            // txtSearchThreshold
            // 
            txtThreshold.Location = new Point(152, 55);
            txtThreshold.Name = "txtSearchThreshold";
            txtThreshold.Size = new Size(128, 39);
            txtThreshold.TabIndex = 142;
            txtThreshold.Text = "20";
            // 
            // tslNewDataOnly
            // 
            tslNewDataOnly.Checked = true;
            tslNewDataOnly.CheckState = CheckState.Checked;
            tslNewDataOnly.ForeColor = Color.LimeGreen;
            tslNewDataOnly.Location = new Point(3, 4);
            tslNewDataOnly.MinimumSize = new Size(46, 22);
            tslNewDataOnly.Name = "tslNewDataOnly";
            tslNewDataOnly.OffBackColor = Color.Gray;
            tslNewDataOnly.OffToggleColor = Color.Gainsboro;
            tslNewDataOnly.OnBackColor = Color.Firebrick;
            tslNewDataOnly.OnToggleColor = Color.MistyRose;
            tslNewDataOnly.OptionBit = 0;
            tslNewDataOnly.OptionValue = "";
            tslNewDataOnly.Size = new Size(60, 32);
            tslNewDataOnly.TabIndex = 144;
            tslNewDataOnly.Tag = "!EXCLUDE";
            tslNewDataOnly.UseVisualStyleBackColor = true;
            // 
            // lblSearchThreshold
            // 
            lblSearchThreshold.AutoSize = true;
            lblSearchThreshold.Location = new Point(5, 58);
            lblSearchThreshold.Name = "lblSearchThreshold";
            lblSearchThreshold.Size = new Size(120, 32);
            lblSearchThreshold.TabIndex = 143;
            lblSearchThreshold.Text = "Threshold";
            // 
            // GlobalOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSearchOnSelect);
            Controls.Add(tslSearchOnSelect);
            Controls.Add(pnlSubOptions);
            Name = "GlobalOptions";
            OptionsTitle = " Global Options";
            ShowToggleButton = false;
            Size = new Size(379, 331);
            Controls.SetChildIndex(pnlSubOptions, 0);
            Controls.SetChildIndex(tslSearchOnSelect, 0);
            Controls.SetChildIndex(lblSearchOnSelect, 0);
            pnlSubOptions.ResumeLayout(false);
            pnlSubOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSearchOnSelect;
        private ToggleSlider tslSearchOnSelect;
        private Panel pnlSubOptions;
        private Label lblNewDataOnly;
        private TextBox txtThreshold;
        private ToggleSlider tslNewDataOnly;
        private Label lblSearchThreshold;
    }
}
