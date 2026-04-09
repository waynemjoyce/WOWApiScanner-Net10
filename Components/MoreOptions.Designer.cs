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
            panelSearch_Frequency = new Panel();
            rbSearchShowAllItems = new RadioButton();
            rbSearchShowCheapest = new RadioButton();
            rbSearchRemoveDuplicates = new RadioButton();
            label1 = new Label();
            txtSearchStringFilter = new TextBox();
            pnlSubOptions.SuspendLayout();
            panelSearch_Frequency.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch_MoreOptions_SubOptions
            // 
            pnlSubOptions.Controls.Add(panelSearch_Frequency);
            pnlSubOptions.Location = new Point(16, 139);
            pnlSubOptions.Name = "pnlSearch_MoreOptions_SubOptions";
            pnlSubOptions.Size = new Size(706, 179);
            pnlSubOptions.TabIndex = 143;
            pnlSubOptions.Visible = false;
            // 
            // panelSearch_Frequency
            // 
            panelSearch_Frequency.Controls.Add(rbSearchShowAllItems);
            panelSearch_Frequency.Controls.Add(rbSearchShowCheapest);
            panelSearch_Frequency.Controls.Add(rbSearchRemoveDuplicates);
            panelSearch_Frequency.Location = new Point(389, 20);
            panelSearch_Frequency.Name = "panelSearch_Frequency";
            panelSearch_Frequency.Size = new Size(313, 138);
            panelSearch_Frequency.TabIndex = 142;
            // 
            // rbSearchShowAllItems
            // 
            rbSearchShowAllItems.AutoSize = true;
            rbSearchShowAllItems.Location = new Point(15, 97);
            rbSearchShowAllItems.Name = "rbSearchShowAllItems";
            rbSearchShowAllItems.Size = new Size(199, 36);
            rbSearchShowAllItems.TabIndex = 115;
            rbSearchShowAllItems.Text = "Show all items";
            rbSearchShowAllItems.UseVisualStyleBackColor = true;
            // 
            // rbSearchShowCheapest
            // 
            rbSearchShowCheapest.AutoSize = true;
            rbSearchShowCheapest.Location = new Point(15, 55);
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
            label1.Location = new Point(29, 55);
            label1.Name = "label1";
            label1.Size = new Size(402, 32);
            label1.TabIndex = 142;
            label1.Text = "Filter by all or part of the item name";
            // 
            // txtSearchStringFilter
            // 
            txtSearchStringFilter.Location = new Point(34, 96);
            txtSearchStringFilter.Name = "txtSearchStringFilter";
            txtSearchStringFilter.Size = new Size(688, 39);
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
            Controls.SetChildIndex(txtSearchStringFilter, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(pnlSubOptions, 0);
            pnlSubOptions.ResumeLayout(false);
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
    }
}
