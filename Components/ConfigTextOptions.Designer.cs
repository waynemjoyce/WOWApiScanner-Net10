namespace WOWAuctionApi_Net10
{
    partial class ConfigTextOptions
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
            cboDefaultSearch = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTSMClientID = new TextBox();
            txtTSMKey = new TextBox();
            txtBlizzClientSecret = new TextBox();
            txtBlizzClientID = new TextBox();
            SuspendLayout();
            // 
            // cboDefaultSearch
            // 
            cboDefaultSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboDefaultSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDefaultSearch.FormattingEnabled = true;
            cboDefaultSearch.Location = new Point(210, 244);
            cboDefaultSearch.Name = "cboDefaultSearch";
            cboDefaultSearch.Size = new Size(458, 40);
            cboDefaultSearch.TabIndex = 140;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 246);
            label5.Name = "label5";
            label5.Size = new Size(170, 32);
            label5.TabIndex = 139;
            label5.Text = "Default Search";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 201);
            label4.Name = "label4";
            label4.Size = new Size(135, 32);
            label4.TabIndex = 138;
            label4.Text = "TSM Secret";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 156);
            label3.Name = "label3";
            label3.Size = new Size(108, 32);
            label3.TabIndex = 137;
            label3.Text = "TSM Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 111);
            label2.Name = "label2";
            label2.Size = new Size(149, 32);
            label2.TabIndex = 136;
            label2.Text = "Client Secret";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 66);
            label1.Name = "label1";
            label1.Size = new Size(106, 32);
            label1.TabIndex = 135;
            label1.Text = "Client ID";
            // 
            // txtTSMClientID
            // 
            txtTSMClientID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTSMClientID.Location = new Point(210, 199);
            txtTSMClientID.Name = "txtTSMClientID";
            txtTSMClientID.Size = new Size(458, 39);
            txtTSMClientID.TabIndex = 134;
            // 
            // txtTSMKey
            // 
            txtTSMKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTSMKey.Location = new Point(210, 154);
            txtTSMKey.Name = "txtTSMKey";
            txtTSMKey.Size = new Size(458, 39);
            txtTSMKey.TabIndex = 133;
            // 
            // txtBlizzClientSecret
            // 
            txtBlizzClientSecret.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBlizzClientSecret.Location = new Point(210, 109);
            txtBlizzClientSecret.Name = "txtBlizzClientSecret";
            txtBlizzClientSecret.Size = new Size(458, 39);
            txtBlizzClientSecret.TabIndex = 132;
            // 
            // txtBlizzClientID
            // 
            txtBlizzClientID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBlizzClientID.Location = new Point(210, 64);
            txtBlizzClientID.Name = "txtBlizzClientID";
            txtBlizzClientID.Size = new Size(458, 39);
            txtBlizzClientID.TabIndex = 131;
            // 
            // ConfigTextOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboDefaultSearch);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTSMClientID);
            Controls.Add(txtTSMKey);
            Controls.Add(txtBlizzClientSecret);
            Controls.Add(txtBlizzClientID);
            Name = "ConfigTextOptions";
            OptionsTitle = " Config Main Options";
            ShowToggleButton = false;
            Size = new Size(688, 304);
            Controls.SetChildIndex(txtBlizzClientID, 0);
            Controls.SetChildIndex(txtBlizzClientSecret, 0);
            Controls.SetChildIndex(txtTSMKey, 0);
            Controls.SetChildIndex(txtTSMClientID, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(cboDefaultSearch, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboDefaultSearch;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTSMClientID;
        private TextBox txtTSMKey;
        private TextBox txtBlizzClientSecret;
        private TextBox txtBlizzClientID;
    }
}
