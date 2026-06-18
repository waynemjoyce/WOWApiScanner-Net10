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
            colRealms_RealmName = new ColumnHeader();
            colRealms_LastModified = new ColumnHeader();
            colRealms_Auctions = new ColumnHeader();
            mnRealms = new ContextMenuStrip(components);
            miFlagRealm = new ToolStripMenuItem();
            miEditRealm = new ToolStripMenuItem();
            btnToggleRealms = new Button();
            mnRealms.SuspendLayout();
            SuspendLayout();
            // 
            // lvRealms
            // 
            lvRealms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvRealms.BackColor = SystemColors.ControlLight;
            lvRealms.CheckBoxes = true;
            lvRealms.Columns.AddRange(new ColumnHeader[] { colRealms_S, colRealms_Flag, colRealms_RealmName, colRealms_LastModified, colRealms_Auctions });
            lvRealms.ContextMenuStrip = mnRealms;
            lvRealms.Font = new Font("Segoe UI", 9F);
            lvRealms.FullRowSelect = true;
            lvRealms.Location = new Point(26, 61);
            lvRealms.MultiSelect = false;
            lvRealms.Name = "lvRealms";
            lvRealms.Size = new Size(455, 1489);
            lvRealms.TabIndex = 131;
            lvRealms.UseCompatibleStateImageBehavior = false;
            lvRealms.View = View.Details;
            lvRealms.SelectedIndexChanged += lvRealms_SelectedIndexChanged;
            // 
            // colRealms_S
            // 
            colRealms_S.Text = "";
            colRealms_S.Width = 70;
            // 
            // colRealms_Flag
            // 
            colRealms_Flag.Text = "";
            colRealms_Flag.Width = 40;
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
            colRealms_Auctions.Width = 0;
            // 
            // mnRealms
            // 
            mnRealms.ImageScalingSize = new Size(32, 32);
            mnRealms.Items.AddRange(new ToolStripItem[] { miFlagRealm, miEditRealm });
            mnRealms.Name = "contextMenuStrip1";
            mnRealms.Size = new Size(301, 124);
            mnRealms.Text = "Realm options";
            // 
            // miFlagRealm
            // 
            miFlagRealm.Name = "miFlagRealm";
            miFlagRealm.Size = new Size(300, 38);
            miFlagRealm.Text = "Flag Realm";
            miFlagRealm.Click += miFlagRealm_Click;
            // 
            // miEditRealm
            // 
            miEditRealm.Name = "miEditRealm";
            miEditRealm.Size = new Size(300, 38);
            miEditRealm.Text = "Edit Realm";
            miEditRealm.Click += miEditRealm_Click;
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
            // RealmOptions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnToggleRealms);
            Controls.Add(lvRealms);
            Name = "RealmOptions";
            OptionsTitle = "      Realms";
            ShowToggleButton = false;
            Size = new Size(507, 1582);
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
    }
}
