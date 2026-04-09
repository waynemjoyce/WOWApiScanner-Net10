namespace WOWAuctionApi_Net10
{
    partial class ManageRealm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageRealm));
            label1 = new Label();
            txtRealmName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            numRealmId = new NumericUpDown();
            colorDialog1 = new ColorDialog();
            lblColor = new Label();
            colorWheel1 = new Cyotek.Windows.Forms.ColorWheel();
            colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            btnSaveRealm = new Button();
            btnDeleteRealm = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numRealmId).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 66);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 131;
            label1.Text = "Name";
            // 
            // txtRealmName
            // 
            txtRealmName.Location = new Point(210, 64);
            txtRealmName.Name = "txtRealmName";
            txtRealmName.Size = new Size(199, 39);
            txtRealmName.TabIndex = 132;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 121);
            label2.Name = "label2";
            label2.Size = new Size(34, 32);
            label2.TabIndex = 133;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 174);
            label3.Name = "label3";
            label3.Size = new Size(71, 32);
            label3.TabIndex = 134;
            label3.Text = "Color";
            // 
            // numRealmId
            // 
            numRealmId.Location = new Point(210, 119);
            numRealmId.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numRealmId.Name = "numRealmId";
            numRealmId.Size = new Size(199, 39);
            numRealmId.TabIndex = 135;
            // 
            // lblColor
            // 
            lblColor.BackColor = Color.Tomato;
            lblColor.Location = new Point(210, 175);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(199, 39);
            lblColor.TabIndex = 136;
            // 
            // colorWheel1
            // 
            colorWheel1.Alpha = 1D;
            colorWheel1.Location = new Point(35, 254);
            colorWheel1.Name = "colorWheel1";
            colorWheel1.Size = new Size(353, 332);
            colorWheel1.TabIndex = 137;
            colorWheel1.ColorChanged += colorWheel1_ColorChanged;
            // 
            // colorEditor1
            // 
            colorEditor1.Font = new Font("Segoe UI", 9F);
            colorEditor1.Location = new Point(437, 119);
            colorEditor1.Margin = new Padding(6, 7, 6, 7);
            colorEditor1.Name = "colorEditor1";
            colorEditor1.ShowAlphaChannel = false;
            colorEditor1.Size = new Size(603, 489);
            colorEditor1.TabIndex = 138;
            colorEditor1.ColorChanged += colorEditor1_ColorChanged;
            // 
            // btnSaveRealm
            // 
            btnSaveRealm.BackColor = SystemColors.Control;
            btnSaveRealm.FlatAppearance.BorderSize = 0;
            btnSaveRealm.FlatStyle = FlatStyle.Flat;
            btnSaveRealm.Image = (Image)resources.GetObject("btnSaveRealm.Image");
            btnSaveRealm.Location = new Point(862, 59);
            btnSaveRealm.Name = "btnSaveRealm";
            btnSaveRealm.Size = new Size(52, 52);
            btnSaveRealm.TabIndex = 143;
            btnSaveRealm.UseVisualStyleBackColor = false;
            btnSaveRealm.Click += btnSaveRealm_Click;
            // 
            // btnDeleteRealm
            // 
            btnDeleteRealm.BackColor = SystemColors.Control;
            btnDeleteRealm.FlatAppearance.BorderSize = 0;
            btnDeleteRealm.FlatStyle = FlatStyle.Flat;
            btnDeleteRealm.Image = (Image)resources.GetObject("btnDeleteRealm.Image");
            btnDeleteRealm.Location = new Point(920, 58);
            btnDeleteRealm.Name = "btnDeleteRealm";
            btnDeleteRealm.Size = new Size(52, 52);
            btnDeleteRealm.TabIndex = 144;
            btnDeleteRealm.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Control;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(978, 59);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(52, 52);
            btnCancel.TabIndex = 145;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ManageRealm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSaveRealm);
            Controls.Add(btnDeleteRealm);
            Controls.Add(btnCancel);
            Controls.Add(colorEditor1);
            Controls.Add(colorWheel1);
            Controls.Add(lblColor);
            Controls.Add(numRealmId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtRealmName);
            Controls.Add(label1);
            Name = "ManageRealm";
            OptionsTitle = " Manage Realm";
            ShowToggleButton = false;
            Size = new Size(1046, 621);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(txtRealmName, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(numRealmId, 0);
            Controls.SetChildIndex(lblColor, 0);
            Controls.SetChildIndex(colorWheel1, 0);
            Controls.SetChildIndex(colorEditor1, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(btnDeleteRealm, 0);
            Controls.SetChildIndex(btnSaveRealm, 0);
            ((System.ComponentModel.ISupportInitialize)numRealmId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRealmName;
        private Label label2;
        private Label label3;
        private NumericUpDown numRealmId;
        private ColorDialog colorDialog1;
        private Label lblColor;
        private Cyotek.Windows.Forms.ColorWheel colorWheel1;
        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private Button btnSaveRealm;
        private Button btnDeleteRealm;
        private Button btnCancel;
    }
}
