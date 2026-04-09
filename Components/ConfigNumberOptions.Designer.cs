namespace WOWAuctionApi_Net10
{
    partial class ConfigNumberOptions
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
            label15 = new Label();
            label16 = new Label();
            label13 = new Label();
            label14 = new Label();
            label12 = new Label();
            label11 = new Label();
            numOnlyFirst = new NumericUpDown();
            numPollInterval = new NumericUpDown();
            numThreshold = new NumericUpDown();
            numLatestXpacItemId = new NumericUpDown();
            numAuctionsCap = new NumericUpDown();
            numItemsSearchCap = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numOnlyFirst).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPollInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLatestXpacItemId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAuctionsCap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numItemsSearchCap).BeginInit();
            SuspendLayout();
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(22, 291);
            label15.Name = "label15";
            label15.Size = new Size(198, 32);
            label15.TabIndex = 182;
            label15.Text = "Items Search Cap";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(22, 156);
            label16.Name = "label16";
            label16.Size = new Size(120, 32);
            label16.TabIndex = 180;
            label16.Text = "Threshold";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 246);
            label13.Name = "label13";
            label13.Size = new Size(154, 32);
            label13.TabIndex = 178;
            label13.Text = "Auctions Cap";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(22, 111);
            label14.Name = "label14";
            label14.Size = new Size(187, 32);
            label14.TabIndex = 176;
            label14.Text = "Live Poll Interval";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 201);
            label12.Name = "label12";
            label12.Size = new Size(216, 32);
            label12.TabIndex = 174;
            label12.Text = "Latest Xpac Item Id";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(22, 66);
            label11.Name = "label11";
            label11.Size = new Size(222, 32);
            label11.TabIndex = 172;
            label11.Text = "Only First N Realms";
            // 
            // numOnlyFirst
            // 
            numOnlyFirst.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numOnlyFirst.Location = new Point(259, 64);
            numOnlyFirst.Maximum = new decimal(new int[] { 80, 0, 0, 0 });
            numOnlyFirst.Name = "numOnlyFirst";
            numOnlyFirst.Size = new Size(130, 39);
            numOnlyFirst.TabIndex = 183;
            // 
            // numPollInterval
            // 
            numPollInterval.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numPollInterval.Location = new Point(259, 109);
            numPollInterval.Name = "numPollInterval";
            numPollInterval.Size = new Size(130, 39);
            numPollInterval.TabIndex = 184;
            // 
            // numThreshold
            // 
            numThreshold.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numThreshold.Location = new Point(259, 154);
            numThreshold.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            numThreshold.Name = "numThreshold";
            numThreshold.Size = new Size(130, 39);
            numThreshold.TabIndex = 185;
            // 
            // numLatestXpacItemId
            // 
            numLatestXpacItemId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numLatestXpacItemId.Location = new Point(258, 199);
            numLatestXpacItemId.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numLatestXpacItemId.Name = "numLatestXpacItemId";
            numLatestXpacItemId.Size = new Size(130, 39);
            numLatestXpacItemId.TabIndex = 186;
            // 
            // numAuctionsCap
            // 
            numAuctionsCap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numAuctionsCap.Location = new Point(258, 244);
            numAuctionsCap.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numAuctionsCap.Name = "numAuctionsCap";
            numAuctionsCap.Size = new Size(130, 39);
            numAuctionsCap.TabIndex = 187;
            // 
            // numItemsSearchCap
            // 
            numItemsSearchCap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numItemsSearchCap.Location = new Point(258, 289);
            numItemsSearchCap.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numItemsSearchCap.Name = "numItemsSearchCap";
            numItemsSearchCap.Size = new Size(130, 39);
            numItemsSearchCap.TabIndex = 188;
            // 
            // ConfigNumberOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numItemsSearchCap);
            Controls.Add(numAuctionsCap);
            Controls.Add(numLatestXpacItemId);
            Controls.Add(numThreshold);
            Controls.Add(numPollInterval);
            Controls.Add(numOnlyFirst);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(label11);
            Name = "ConfigNumberOptions";
            OptionsTitle = " Config Number Options";
            ShowToggleButton = false;
            Size = new Size(410, 354);
            Controls.SetChildIndex(label11, 0);
            Controls.SetChildIndex(label12, 0);
            Controls.SetChildIndex(label14, 0);
            Controls.SetChildIndex(label13, 0);
            Controls.SetChildIndex(label16, 0);
            Controls.SetChildIndex(label15, 0);
            Controls.SetChildIndex(numOnlyFirst, 0);
            Controls.SetChildIndex(numPollInterval, 0);
            Controls.SetChildIndex(numThreshold, 0);
            Controls.SetChildIndex(numLatestXpacItemId, 0);
            Controls.SetChildIndex(numAuctionsCap, 0);
            Controls.SetChildIndex(numItemsSearchCap, 0);
            ((System.ComponentModel.ISupportInitialize)numOnlyFirst).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPollInterval).EndInit();
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLatestXpacItemId).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAuctionsCap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numItemsSearchCap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label15;
        private TextBox txtItemsSearchCap;
        private Label label16;
        private TextBox txtThreshold;
        private Label label13;
        private TextBox txtAuctionsCap;
        private Label label14;
        private TextBox txtLivePollInterval;
        private Label label12;
        private TextBox txtLatestXpacItemId;
        private Label label11;
        private TextBox txtOnlyFirst;
        private NumericUpDown numOnlyFirst;
        private NumericUpDown numPollInterval;
        private NumericUpDown numThreshold;
        private NumericUpDown numLatestXpacItemId;
        private NumericUpDown numAuctionsCap;
        private NumericUpDown numItemsSearchCap;
    }
}
