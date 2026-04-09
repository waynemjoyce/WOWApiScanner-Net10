namespace WOWAuctionApi_Net10
{
    partial class ItemListOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListOptions));
            lbItems = new ListBox();
            pnlButtons = new Panel();
            btnItemListSaveAs = new Button();
            btnItemListEdit = new Button();
            btnItemListDelete = new Button();
            btnItemListNew = new Button();
            pnlOptions = new Panel();
            rbSearch_List_OnlyByList = new RadioButton();
            rbSearch_List_AdditionalCriteria = new RadioButton();
            rbSearch_List_DontUse = new RadioButton();
            pnlButtons.SuspendLayout();
            pnlOptions.SuspendLayout();
            SuspendLayout();
            // 
            // lbItems
            // 
            lbItems.BackColor = SystemColors.Control;
            lbItems.DrawMode = DrawMode.OwnerDrawFixed;
            lbItems.FormattingEnabled = true;
            lbItems.ItemHeight = 48;
            lbItems.Location = new Point(20, 128);
            lbItems.Name = "lbItems";
            lbItems.Size = new Size(513, 1300);
            lbItems.TabIndex = 152;
            lbItems.DrawItem += lbItems_DrawItem;
            lbItems.SelectedIndexChanged += lbItems_SelectedIndexChanged;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnItemListSaveAs);
            pnlButtons.Controls.Add(btnItemListEdit);
            pnlButtons.Controls.Add(btnItemListDelete);
            pnlButtons.Controls.Add(btnItemListNew);
            pnlButtons.Location = new Point(17, 58);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(227, 63);
            pnlButtons.TabIndex = 151;
            // 
            // btnItemListSaveAs
            // 
            btnItemListSaveAs.BackColor = SystemColors.Control;
            btnItemListSaveAs.FlatAppearance.BorderSize = 0;
            btnItemListSaveAs.FlatStyle = FlatStyle.Flat;
            btnItemListSaveAs.Image = (Image)resources.GetObject("btnItemListSaveAs.Image");
            btnItemListSaveAs.Location = new Point(3, 4);
            btnItemListSaveAs.Name = "btnItemListSaveAs";
            btnItemListSaveAs.Size = new Size(52, 52);
            btnItemListSaveAs.TabIndex = 139;
            btnItemListSaveAs.UseVisualStyleBackColor = false;
            btnItemListSaveAs.Click += btnItemListSaveAs_Click;
            // 
            // btnItemListEdit
            // 
            btnItemListEdit.BackColor = SystemColors.Control;
            btnItemListEdit.FlatAppearance.BorderSize = 0;
            btnItemListEdit.FlatStyle = FlatStyle.Flat;
            btnItemListEdit.Image = (Image)resources.GetObject("btnItemListEdit.Image");
            btnItemListEdit.Location = new Point(56, 4);
            btnItemListEdit.Name = "btnItemListEdit";
            btnItemListEdit.Size = new Size(52, 52);
            btnItemListEdit.TabIndex = 140;
            btnItemListEdit.UseVisualStyleBackColor = false;
            btnItemListEdit.Click += btnItemListEdit_Click;
            // 
            // btnItemListDelete
            // 
            btnItemListDelete.BackColor = SystemColors.Control;
            btnItemListDelete.FlatAppearance.BorderSize = 0;
            btnItemListDelete.FlatStyle = FlatStyle.Flat;
            btnItemListDelete.Image = (Image)resources.GetObject("btnItemListDelete.Image");
            btnItemListDelete.Location = new Point(111, 4);
            btnItemListDelete.Name = "btnItemListDelete";
            btnItemListDelete.Size = new Size(52, 52);
            btnItemListDelete.TabIndex = 141;
            btnItemListDelete.UseVisualStyleBackColor = false;
            btnItemListDelete.Click += btnItemListDelete_Click;
            // 
            // btnItemListNew
            // 
            btnItemListNew.BackColor = SystemColors.Control;
            btnItemListNew.FlatAppearance.BorderSize = 0;
            btnItemListNew.FlatStyle = FlatStyle.Flat;
            btnItemListNew.Image = (Image)resources.GetObject("btnItemListNew.Image");
            btnItemListNew.Location = new Point(169, 5);
            btnItemListNew.Name = "btnItemListNew";
            btnItemListNew.Size = new Size(52, 52);
            btnItemListNew.TabIndex = 142;
            btnItemListNew.UseVisualStyleBackColor = false;
            btnItemListNew.Click += btnItemListNew_Click;
            // 
            // pnlOptions
            // 
            pnlOptions.Controls.Add(rbSearch_List_OnlyByList);
            pnlOptions.Controls.Add(rbSearch_List_AdditionalCriteria);
            pnlOptions.Controls.Add(rbSearch_List_DontUse);
            pnlOptions.Location = new Point(17, 60);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(513, 60);
            pnlOptions.TabIndex = 150;
            // 
            // rbSearch_List_OnlyByList
            // 
            rbSearch_List_OnlyByList.AutoSize = true;
            rbSearch_List_OnlyByList.Location = new Point(129, 12);
            rbSearch_List_OnlyByList.Name = "rbSearch_List_OnlyByList";
            rbSearch_List_OnlyByList.Size = new Size(95, 36);
            rbSearch_List_OnlyByList.TabIndex = 115;
            rbSearch_List_OnlyByList.Text = "Only";
            rbSearch_List_OnlyByList.UseVisualStyleBackColor = true;
            // 
            // rbSearch_List_AdditionalCriteria
            // 
            rbSearch_List_AdditionalCriteria.AutoSize = true;
            rbSearch_List_AdditionalCriteria.Location = new Point(247, 13);
            rbSearch_List_AdditionalCriteria.Name = "rbSearch_List_AdditionalCriteria";
            rbSearch_List_AdditionalCriteria.Size = new Size(251, 36);
            rbSearch_List_AdditionalCriteria.TabIndex = 114;
            rbSearch_List_AdditionalCriteria.Text = "Criteria + List Items";
            rbSearch_List_AdditionalCriteria.UseVisualStyleBackColor = true;
            // 
            // rbSearch_List_DontUse
            // 
            rbSearch_List_DontUse.AutoSize = true;
            rbSearch_List_DontUse.Checked = true;
            rbSearch_List_DontUse.Location = new Point(15, 12);
            rbSearch_List_DontUse.Name = "rbSearch_List_DontUse";
            rbSearch_List_DontUse.Size = new Size(104, 36);
            rbSearch_List_DontUse.TabIndex = 113;
            rbSearch_List_DontUse.TabStop = true;
            rbSearch_List_DontUse.Text = "None";
            rbSearch_List_DontUse.UseVisualStyleBackColor = true;
            // 
            // ItemListOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            Controls.Add(lbItems);
            Controls.Add(pnlButtons);
            Controls.Add(pnlOptions);
            Name = "ItemListOptions";
            OptionsTitle = " My Item Lists";
            ShowToggleButton = false;
            Size = new Size(551, 1490);
            Controls.SetChildIndex(pnlOptions, 0);
            Controls.SetChildIndex(pnlButtons, 0);
            Controls.SetChildIndex(lbItems, 0);
            pnlButtons.ResumeLayout(false);
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbItems;
        private Panel pnlButtons;
        private Button btnItemListSaveAs;
        private Button btnItemListEdit;
        private Button btnItemListDelete;
        private Button btnItemListNew;
        private Panel pnlOptions;
        private RadioButton rbSearch_List_OnlyByList;
        private RadioButton rbSearch_List_AdditionalCriteria;
        private RadioButton rbSearch_List_DontUse;
    }
}
