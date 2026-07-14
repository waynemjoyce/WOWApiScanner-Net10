namespace WOWAuctionApi_Net10
{
    partial class RealmOptions
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealmOptions));
            lvRealms = new ListView();
            colRealms_S = new ColumnHeader();
            colRealms_Flag = new ColumnHeader();
            colRealms_Stock = new ColumnHeader();
            colRealms_RealmName = new ColumnHeader();
            colRealms_LastModified = new ColumnHeader();
            colRealms_Auctions = new ColumnHeader();
            mnRealms = new ContextMenuStrip(components);
            miFlagRealm = new ToolStripMenuItem();
            miEditRealm = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            miFlagAllRealms = new ToolStripMenuItem();
            miUnflagAllRealms = new ToolStripMenuItem();
            btnToggleRealms = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            colRealms_Area = new ColumnHeader();
            mnRealms.SuspendLayout();
            SuspendLayout();
            // 
            // lvRealms
            // 
            lvRealms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvRealms.BackColor = SystemColors.ControlLight;
            lvRealms.CheckBoxes = true;
            lvRealms.Columns.AddRange(new ColumnHeader[] { colRealms_S, colRealms_Flag, colRealms_Stock, colRealms_RealmName, colRealms_LastModified, colRealms_Auctions, colRealms_Area });
            lvRealms.ContextMenuStrip = mnRealms;
            lvRealms.Font = new Font("Segoe UI", 8F);
            lvRealms.FullRowSelect = true;
            lvRealms.Location = new Point(26, 61);
            lvRealms.MultiSelect = false;
            lvRealms.Name = "lvRealms";
            lvRealms.Size = new Size(736, 1489);
            lvRealms.TabIndex = 131;
            lvRealms.UseCompatibleStateImageBehavior = false;
            lvRealms.View = View.Details;
            lvRealms.ItemCheck += lvRealms_ItemCheck;
            lvRealms.DoubleClick += lvRealms_DoubleClick;
            lvRealms.MouseDoubleClick += lvRealms_MouseDoubleClick;
            lvRealms.MouseDown += lvRealms_MouseDown;
            // 
            // colRealms_S
            // 
            colRealms_S.Text = "";
            colRealms_S.Width = 70;
            // 
            // colRealms_Flag
            // 
            colRealms_Flag.Text = "";
            colRealms_Flag.Width = 30;
            // 
            // colRealms_Stock
            // 
            colRealms_Stock.Text = "Stock";
            colRealms_Stock.TextAlign = HorizontalAlignment.Right;
            colRealms_Stock.Width = 70;
            // 
            // colRealms_RealmName
            // 
            colRealms_RealmName.Text = "Realm Name";
            colRealms_RealmName.Width = 220;
            // 
            // colRealms_LastModified
            // 
            colRealms_LastModified.Text = "Modified";
            colRealms_LastModified.Width = 110;
            // 
            // colRealms_Auctions
            // 
            colRealms_Auctions.Text = "#";
            colRealms_Auctions.TextAlign = HorizontalAlignment.Right;
            colRealms_Auctions.Width = 110;
            // 
            // mnRealms
            // 
            mnRealms.ImageScalingSize = new Size(32, 32);
            mnRealms.Items.AddRange(new ToolStripItem[] { miFlagRealm, miEditRealm, toolStripMenuItem2, miFlagAllRealms, miUnflagAllRealms });
            mnRealms.Name = "contextMenuStrip1";
            mnRealms.Size = new Size(275, 194);
            mnRealms.Text = "Realm options";
            // 
            // miFlagRealm
            // 
            miFlagRealm.Name = "miFlagRealm";
            miFlagRealm.Size = new Size(274, 38);
            miFlagRealm.Text = "Flag Realm";
            miFlagRealm.Click += miFlagRealm_Click;
            // 
            // miEditRealm
            // 
            miEditRealm.Name = "miEditRealm";
            miEditRealm.Size = new Size(274, 38);
            miEditRealm.Text = "Edit Realm";
            miEditRealm.Click += miEditRealm_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(274, 38);
            toolStripMenuItem2.Text = "---";
            // 
            // miFlagAllRealms
            // 
            miFlagAllRealms.Name = "miFlagAllRealms";
            miFlagAllRealms.Size = new Size(274, 38);
            miFlagAllRealms.Text = "Flag All Realms";
            miFlagAllRealms.Click += miFlagAllRealms_Click;
            // 
            // miUnflagAllRealms
            // 
            miUnflagAllRealms.Name = "miUnflagAllRealms";
            miUnflagAllRealms.Size = new Size(274, 38);
            miUnflagAllRealms.Text = "Unflag All Realms";
            miUnflagAllRealms.Click += miUnflagAllRealms_Click;
            // 
            // btnToggleRealms
            // 
            btnToggleRealms.BackColor = SystemColors.ControlDark;
            btnToggleRealms.FlatAppearance.BorderSize = 0;
            btnToggleRealms.FlatStyle = FlatStyle.Flat;
            btnToggleRealms.Image = (Image)resources.GetObject("btnToggleRealms.Image");
            btnToggleRealms.Location = new Point(3, 3);
            btnToggleRealms.Name = "btnToggleRealms";
            btnToggleRealms.Size = new Size(36, 36);
            btnToggleRealms.TabIndex = 132;
            btnToggleRealms.UseVisualStyleBackColor = false;
            btnToggleRealms.Click += btnToggleRealms_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // colRealms_Area
            // 
            colRealms_Area.Text = "A";
            // 
            // RealmOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnToggleRealms);
            Controls.Add(lvRealms);
            Name = "RealmOptions";
            OptionsTitle = "      Realms";
            ShowToggleButton = false;
            Size = new Size(788, 1582);
            Load += RealmOptions_Load;
            Controls.SetChildIndex(lvRealms, 0);
            Controls.SetChildIndex(btnToggleRealms, 0);
            mnRealms.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView lvRealms;
        private ColumnHeader colRealms_S;
        private ColumnHeader colRealms_RealmName;
        private ColumnHeader colRealms_LastModified;
        private ColumnHeader colRealms_Auctions;
        private Button btnToggleRealms;
        private ColumnHeader colRealms_Flag;
        private ContextMenuStrip mnRealms;
        private ToolStripMenuItem miFlagRealm;
        private ToolStripMenuItem miEditRealm;
        private ColumnHeader colRealms_Stock;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem miFlagAllRealms;
        private ToolStripMenuItem miUnflagAllRealms;
        private ContextMenuStrip contextMenuStrip1;
        private ColumnHeader colRealms_Area;
    }
}
