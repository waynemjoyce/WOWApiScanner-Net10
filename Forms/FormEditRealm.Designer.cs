namespace WOWAuctionApi_Net10.Forms
{
    partial class FormEditRealm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFlagged = new Label();
            tslFlagged = new ToggleSlider();
            txtStock = new TextBox();
            label4 = new Label();
            colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            colorWheel1 = new Cyotek.Windows.Forms.ColorWheel();
            lblColor = new Label();
            numRealmId = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            txtRealmName = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numRealmId).BeginInit();
            SuspendLayout();
            // 
            // lblFlagged
            // 
            lblFlagged.AutoSize = true;
            lblFlagged.Font = new Font("Segoe UI", 9F);
            lblFlagged.ForeColor = Color.MediumPurple;
            lblFlagged.Location = new Point(740, 26);
            lblFlagged.Name = "lblFlagged";
            lblFlagged.Size = new Size(99, 32);
            lblFlagged.TabIndex = 179;
            lblFlagged.Text = "Flagged";
            // 
            // tslFlagged
            // 
            tslFlagged.Checked = true;
            tslFlagged.CheckState = CheckState.Checked;
            tslFlagged.ForeColor = Color.LimeGreen;
            tslFlagged.Location = new Point(678, 26);
            tslFlagged.MinimumSize = new Size(46, 22);
            tslFlagged.Name = "tslFlagged";
            tslFlagged.OffBackColor = Color.Gray;
            tslFlagged.OffToggleColor = Color.Gainsboro;
            tslFlagged.OnBackColor = Color.MediumPurple;
            tslFlagged.OnToggleColor = Color.MistyRose;
            tslFlagged.OptionBit = 0;
            tslFlagged.OptionValue = "";
            tslFlagged.Size = new Size(60, 32);
            tslFlagged.TabIndex = 178;
            tslFlagged.Tag = "!EXCLUDE";
            tslFlagged.UseVisualStyleBackColor = true;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(559, 21);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(94, 39);
            txtStock.TabIndex = 177;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(447, 23);
            label4.Name = "label4";
            label4.Size = new Size(71, 32);
            label4.TabIndex = 176;
            label4.Text = "Stock";
            // 
            // colorEditor1
            // 
            colorEditor1.Font = new Font("Segoe UI", 9F);
            colorEditor1.Location = new Point(445, 77);
            colorEditor1.Margin = new Padding(6, 7, 6, 7);
            colorEditor1.Name = "colorEditor1";
            colorEditor1.ShowAlphaChannel = false;
            colorEditor1.Size = new Size(603, 489);
            colorEditor1.TabIndex = 172;
            colorEditor1.ColorChanged += colorEditor1_ColorChanged;
            // 
            // colorWheel1
            // 
            colorWheel1.Alpha = 1D;
            colorWheel1.Location = new Point(43, 212);
            colorWheel1.Name = "colorWheel1";
            colorWheel1.Size = new Size(353, 332);
            colorWheel1.TabIndex = 171;
            colorWheel1.ColorChanged += colorWheel1_ColorChanged;
            // 
            // lblColor
            // 
            lblColor.BackColor = Color.Tomato;
            lblColor.Location = new Point(218, 133);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(199, 39);
            lblColor.TabIndex = 170;
            // 
            // numRealmId
            // 
            numRealmId.Location = new Point(218, 77);
            numRealmId.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numRealmId.Name = "numRealmId";
            numRealmId.Size = new Size(199, 39);
            numRealmId.TabIndex = 169;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 132);
            label3.Name = "label3";
            label3.Size = new Size(71, 32);
            label3.TabIndex = 168;
            label3.Text = "Color";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 79);
            label2.Name = "label2";
            label2.Size = new Size(34, 32);
            label2.TabIndex = 167;
            label2.Text = "Id";
            // 
            // txtRealmName
            // 
            txtRealmName.Location = new Point(218, 22);
            txtRealmName.Name = "txtRealmName";
            txtRealmName.Size = new Size(199, 39);
            txtRealmName.TabIndex = 166;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 24);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 165;
            label1.Text = "Name";
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(898, 576);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 180;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(740, 576);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 181;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormEditRealm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 653);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblFlagged);
            Controls.Add(tslFlagged);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(colorEditor1);
            Controls.Add(colorWheel1);
            Controls.Add(lblColor);
            Controls.Add(numRealmId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtRealmName);
            Controls.Add(label1);
            Name = "FormEditRealm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Realm";
            ((System.ComponentModel.ISupportInitialize)numRealmId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFlagged;
        private ToggleSlider tslFlagged;
        private TextBox txtStock;
        private Label label4;
        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private Cyotek.Windows.Forms.ColorWheel colorWheel1;
        private Label lblColor;
        private NumericUpDown numRealmId;
        private Label label3;
        private Label label2;
        private TextBox txtRealmName;
        private Label label1;
        private Button btnSave;
        private Button btnCancel;
    }
}