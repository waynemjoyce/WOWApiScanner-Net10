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
            mnRealms = new ContextMenuStrip(components);
            miEditRealm = new ToolStripMenuItem();
            miClearRealmFlags = new ToolStripMenuItem();
            miStockText = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            miUnflagAllSpecific = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator4 = new ToolStripSeparator();
            miUnflagAllRealms = new ToolStripMenuItem();
            btnToggleRealms = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            miFlagAllSpecific = new ToolStripMenuItem();
            mnRealms.SuspendLayout();
            SuspendLayout();
            // 
            // lvRealms
            // 
            lvRealms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvRealms.BackColor = SystemColors.ControlLight;
            lvRealms.CheckBoxes = true;
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
            // mnRealms
            // 
            mnRealms.ImageScalingSize = new Size(32, 32);
            mnRealms.Items.AddRange(new ToolStripItem[] { miEditRealm, miClearRealmFlags, miStockText, toolStripSeparator1, toolStripSeparator2, miFlagAllSpecific, miUnflagAllSpecific, toolStripSeparator3, toolStripSeparator4, miUnflagAllRealms });
            mnRealms.Name = "contextMenuStrip1";
            mnRealms.Size = new Size(316, 305);
            mnRealms.Text = "Realm options";
            mnRealms.Opened += mnRealms_Opened;
            // 
            // miEditRealm
            // 
            miEditRealm.Name = "miEditRealm";
            miEditRealm.Size = new Size(315, 38);
            miEditRealm.Text = "Edit Realm";
            miEditRealm.Click += miEditRealm_Click;
            // 
            // miClearRealmFlags
            // 
            miClearRealmFlags.Name = "miClearRealmFlags";
            miClearRealmFlags.Size = new Size(315, 38);
            miClearRealmFlags.Text = "Clear Realm Flags";
            miClearRealmFlags.Click += miClearRealmFlags_Click;
            // 
            // miStockText
            // 
            miStockText.Name = "miStockText";
            miStockText.Size = new Size(100, 39);
            miStockText.Enter += miStockText_Enter;
            miStockText.KeyDown += miStockText_KeyDown;
            miStockText.Click += miStockText_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(312, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(312, 6);
            // 
            // miUnflagAllSpecific
            // 
            miUnflagAllSpecific.Name = "miUnflagAllSpecific";
            miUnflagAllSpecific.Size = new Size(315, 38);
            miUnflagAllSpecific.Text = "Unflag All ...";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(312, 6);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(312, 6);
            // 
            // miUnflagAllRealms
            // 
            miUnflagAllRealms.Name = "miUnflagAllRealms";
            miUnflagAllRealms.Size = new Size(315, 38);
            miUnflagAllRealms.Text = "UNFLAG ALL REALMS";
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
            // miFlagAllSpecific
            // 
            miFlagAllSpecific.Name = "miFlagAllSpecific";
            miFlagAllSpecific.Size = new Size(315, 38);
            miFlagAllSpecific.Text = "Flag All ...";
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
            mnRealms.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView lvRealms;
        private Button btnToggleRealms;
        private ContextMenuStrip mnRealms;
        private ToolStripMenuItem miEditRealm;
        private ToolStripMenuItem miUnflagAllRealms;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem miClearRealmFlags;
        private ToolStripTextBox miStockText;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem miUnflagAllSpecific;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem miFlagAllSpecific;
    }
}
