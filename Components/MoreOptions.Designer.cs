namespace WOWAuctionApi_Net10
{
    partial class MoreOptions
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
            pnlSubOptions = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            rbChartTotalAuctions = new RadioButton();
            rbChartSearchHits = new RadioButton();
            rbChartTotalValue = new RadioButton();
            rbChartShowAll = new RadioButton();
            panelSearch_Frequency = new Panel();
            rbSearchShowAllItems = new RadioButton();
            rbSearchShowCheapest = new RadioButton();
            rbSearchRemoveDuplicates = new RadioButton();
            label1 = new Label();
            txtSearchStringFilter = new TextBox();
            pnlSubOptions.SuspendLayout();
            panel1.SuspendLayout();
            panelSearch_Frequency.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSubOptions
            // 
            pnlSubOptions.Controls.Add(label3);
            pnlSubOptions.Controls.Add(label2);
            pnlSubOptions.Controls.Add(panel1);
            pnlSubOptions.Controls.Add(panelSearch_Frequency);
            pnlSubOptions.Location = new Point(16, 104);
            pnlSubOptions.Name = "pnlSubOptions";
            pnlSubOptions.Size = new Size(706, 224);
            pnlSubOptions.TabIndex = 143;
            pnlSubOptions.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(392, 8);
            label3.Name = "label3";
            label3.Size = new Size(130, 32);
            label3.TabIndex = 145;
            label3.Text = "Frequency:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 8);
            label2.Name = "label2";
            label2.Size = new Size(132, 32);
            label2.TabIndex = 144;
            label2.Text = "Chart filter:";
            // 
            // panel1
            // 
            panel1.Controls.Add(rbChartTotalAuctions);
            panel1.Controls.Add(rbChartSearchHits);
            panel1.Controls.Add(rbChartTotalValue);
            panel1.Controls.Add(rbChartShowAll);
            panel1.Location = new Point(0, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(364, 173);
            panel1.TabIndex = 143;
            // 
            // rbChartTotalAuctions
            // 
            rbChartTotalAuctions.AutoSize = true;
            rbChartTotalAuctions.Location = new Point(15, 120);
            rbChartTotalAuctions.Name = "rbChartTotalAuctions";
            rbChartTotalAuctions.Size = new Size(344, 36);
            rbChartTotalAuctions.TabIndex = 116;
            rbChartTotalAuctions.Text = "Top X Realms Total Auctions";
            rbChartTotalAuctions.UseVisualStyleBackColor = true;
            // 
            // rbChartSearchHits
            // 
            rbChartSearchHits.AutoSize = true;
            rbChartSearchHits.Location = new Point(15, 84);
            rbChartSearchHits.Name = "rbChartSearchHits";
            rbChartSearchHits.Size = new Size(313, 36);
            rbChartSearchHits.TabIndex = 115;
            rbChartSearchHits.Text = "Top X Realms Search Hits";
            rbChartSearchHits.UseVisualStyleBackColor = true;
            // 
            // rbChartTotalValue
            // 
            rbChartTotalValue.AutoSize = true;
            rbChartTotalValue.Location = new Point(15, 48);
            rbChartTotalValue.Name = "rbChartTotalValue";
            rbChartTotalValue.Size = new Size(310, 36);
            rbChartTotalValue.TabIndex = 114;
            rbChartTotalValue.Text = "Top X Realms Total Value";
            rbChartTotalValue.UseVisualStyleBackColor = true;
            // 
            // rbChartShowAll
            // 
            rbChartShowAll.AutoSize = true;
            rbChartShowAll.Checked = true;
            rbChartShowAll.Location = new Point(15, 12);
            rbChartShowAll.Name = "rbChartShowAll";
            rbChartShowAll.Size = new Size(134, 36);
            rbChartShowAll.TabIndex = 113;
            rbChartShowAll.TabStop = true;
            rbChartShowAll.Text = "Show all";
            rbChartShowAll.UseVisualStyleBackColor = true;
            // 
            // panelSearch_Frequency
            // 
            panelSearch_Frequency.Controls.Add(rbSearchShowAllItems);
            panelSearch_Frequency.Controls.Add(rbSearchShowCheapest);
            panelSearch_Frequency.Controls.Add(rbSearchRemoveDuplicates);
            panelSearch_Frequency.Location = new Point(389, 43);
            panelSearch_Frequency.Name = "panelSearch_Frequency";
            panelSearch_Frequency.Size = new Size(313, 138);
            panelSearch_Frequency.TabIndex = 142;
            // 
            // rbSearchShowAllItems
            // 
            rbSearchShowAllItems.AutoSize = true;
            rbSearchShowAllItems.Location = new Point(15, 84);
            rbSearchShowAllItems.Name = "rbSearchShowAllItems";
            rbSearchShowAllItems.Size = new Size(199, 36);
            rbSearchShowAllItems.TabIndex = 115;
            rbSearchShowAllItems.Text = "Show all items";
            rbSearchShowAllItems.UseVisualStyleBackColor = true;
            // 
            // rbSearchShowCheapest
            // 
            rbSearchShowCheapest.AutoSize = true;
            rbSearchShowCheapest.Location = new Point(15, 48);
            rbSearchShowCheapest.Name = "rbSearchShowCheapest";
            rbSearchShowCheapest.Size = new Size(205, 36);
            rbSearchShowCheapest.TabIndex = 114;
            rbSearchShowCheapest.Text = "Show cheapest";
            rbSearchShowCheapest.UseVisualStyleBackColor = true;
            // 
            // rbSearchRemoveDuplicates
            // 
            rbSearchRemoveDuplicates.AutoSize = true;
            rbSearchRemoveDuplicates.Checked = true;
            rbSearchRemoveDuplicates.Location = new Point(15, 12);
            rbSearchRemoveDuplicates.Name = "rbSearchRemoveDuplicates";
            rbSearchRemoveDuplicates.Size = new Size(246, 36);
            rbSearchRemoveDuplicates.TabIndex = 113;
            rbSearchRemoveDuplicates.TabStop = true;
            rbSearchRemoveDuplicates.Text = "Remove duplicates";
            rbSearchRemoveDuplicates.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 55);
            label1.Name = "label1";
            label1.Size = new Size(134, 32);
            label1.TabIndex = 142;
            label1.Text = "Filter string";
            // 
            // txtSearchStringFilter
            // 
            txtSearchStringFilter.Location = new Point(151, 56);
            txtSearchStringFilter.Name = "txtSearchStringFilter";
            txtSearchStringFilter.Size = new Size(577, 39);
            txtSearchStringFilter.TabIndex = 141;
            // 
            // MoreOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlSubOptions);
            Controls.Add(label1);
            Controls.Add(txtSearchStringFilter);
            Name = "MoreOptions";
            OptionsTitle = " More Options";
            ShowToggleButton = false;
            Size = new Size(750, 331);
            Load += MoreOptions_Load;
            Controls.SetChildIndex(txtSearchStringFilter, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(pnlSubOptions, 0);
            pnlSubOptions.ResumeLayout(false);
            pnlSubOptions.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelSearch_Frequency.ResumeLayout(false);
            panelSearch_Frequency.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlSubOptions;
        private Panel panelSearch_Frequency;
        private RadioButton rbSearchShowAllItems;
        private RadioButton rbSearchShowCheapest;
        private RadioButton rbSearchRemoveDuplicates;
        private Label label1;
        private TextBox txtSearchStringFilter;
        private Panel panel1;
        private RadioButton rbChartTotalAuctions;
        private RadioButton rbChartSearchHits;
        private RadioButton rbChartTotalValue;
        private RadioButton rbChartShowAll;
        private Label label3;
        private Label label2;
    }
}
