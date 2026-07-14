namespace WOWAuctionApi_Net10
{
    partial class AuctionsView
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
            lvAuctions = new ListView();
            colSide = new ColumnHeader();
            colItemName = new ColumnHeader();
            colLevel = new ColumnHeader();
            colSaleRate = new ColumnHeader();
            colPerc = new ColumnHeader();
            colBuyout = new ColumnHeader();
            colRegion = new ColumnHeader();
            colPetLv = new ColumnHeader();
            colLatestXpac = new ColumnHeader();
            SuspendLayout();
            // 
            // lvAuctions
            // 
            lvAuctions.BackColor = SystemColors.Control;
            lvAuctions.Columns.AddRange(new ColumnHeader[] { colSide, colItemName, colLevel, colSaleRate, colPerc, colBuyout, colRegion, colPetLv, colLatestXpac });
            lvAuctions.Font = new Font("Segoe UI", 9F);
            lvAuctions.FullRowSelect = true;
            lvAuctions.Location = new Point(0, 0);
            lvAuctions.Name = "lvAuctions";
            lvAuctions.ShowItemToolTips = true;
            lvAuctions.Size = new Size(1380, 1490);
            lvAuctions.TabIndex = 102;
            lvAuctions.UseCompatibleStateImageBehavior = false;
            lvAuctions.View = View.Details;
            lvAuctions.DoubleClick += lvAuctions_DoubleClick;
            lvAuctions.KeyPress += lvAuctions_KeyPress;
            // 
            // colSide
            // 
            colSide.Text = "";
            colSide.Width = 40;
            // 
            // colItemName
            // 
            colItemName.Text = "Item Name";
            colItemName.Width = 500;
            // 
            // colLevel
            // 
            colLevel.Text = "Level";
            colLevel.Width = 80;
            // 
            // colSaleRate
            // 
            colSaleRate.Text = "Sale Rate";
            colSaleRate.Width = 120;
            // 
            // colPerc
            // 
            colPerc.Text = "%";
            colPerc.TextAlign = HorizontalAlignment.Right;
            colPerc.Width = 120;
            // 
            // colBuyout
            // 
            colBuyout.Text = "Buyout";
            colBuyout.TextAlign = HorizontalAlignment.Right;
            colBuyout.Width = 170;
            // 
            // colRegion
            // 
            colRegion.Text = "Region Price";
            colRegion.TextAlign = HorizontalAlignment.Right;
            colRegion.Width = 150;
            // 
            // colPetLv
            // 
            colPetLv.Text = "Pet Lv";
            colPetLv.Width = 90;
            // 
            // colLatestXpac
            // 
            colLatestXpac.Text = "LX";
            // 
            // AuctionsView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lvAuctions);
            Name = "AuctionsView";
            Size = new Size(1380, 1490);
            ResumeLayout(false);
        }

        #endregion

        private ListView lvAuctions;
        private ColumnHeader colSide;
        private ColumnHeader colItemName;
        private ColumnHeader colLevel;
        private ColumnHeader colSaleRate;
        private ColumnHeader colPerc;
        private ColumnHeader colBuyout;
        private ColumnHeader colRegion;
        private ColumnHeader colPetLv;
        private ColumnHeader colLatestXpac;
    }
}
