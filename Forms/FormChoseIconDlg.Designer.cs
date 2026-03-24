namespace WOWAuctionApi_Net10
{
    partial class FormChoseIconDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoseIconDlg));
            lvImages = new ListView();
            btnOK = new Button();
            btnCancel = new Button();
            txtFilter = new TextBox();
            btnFilterByName = new Button();
            label1 = new Label();
            btnClearFilter = new Button();
            SuspendLayout();
            // 
            // lvImages
            // 
            lvImages.Location = new Point(36, 103);
            lvImages.MultiSelect = false;
            lvImages.Name = "lvImages";
            lvImages.Size = new Size(1214, 516);
            lvImages.TabIndex = 0;
            lvImages.UseCompatibleStateImageBehavior = false;
            lvImages.SelectedIndexChanged += lvImages_SelectedIndexChanged;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(1100, 642);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(150, 46);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(944, 642);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(224, 47);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(299, 39);
            txtFilter.TabIndex = 3;
            // 
            // btnFilterByName
            // 
            btnFilterByName.BackColor = SystemColors.Control;
            btnFilterByName.FlatAppearance.BorderSize = 0;
            btnFilterByName.FlatStyle = FlatStyle.Flat;
            btnFilterByName.Image = (Image)resources.GetObject("btnFilterByName.Image");
            btnFilterByName.Location = new Point(529, 39);
            btnFilterByName.Name = "btnFilterByName";
            btnFilterByName.Size = new Size(52, 52);
            btnFilterByName.TabIndex = 148;
            btnFilterByName.UseVisualStyleBackColor = false;
            btnFilterByName.Click += btnFilterByName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 47);
            label1.Name = "label1";
            label1.Size = new Size(171, 32);
            label1.TabIndex = 149;
            label1.Text = "Filter By Name";
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = SystemColors.Control;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Image = (Image)resources.GetObject("btnClearFilter.Image");
            btnClearFilter.Location = new Point(581, 39);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(52, 52);
            btnClearFilter.TabIndex = 150;
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // FormChoseIconDlg
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 708);
            Controls.Add(btnClearFilter);
            Controls.Add(label1);
            Controls.Add(btnFilterByName);
            Controls.Add(txtFilter);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lvImages);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormChoseIconDlg";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Choose Your Icon";
            Load += FormChoseIcon_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvImages;
        private Button btnOK;
        private Button btnCancel;
        private TextBox txtFilter;
        private Button btnFilterByName;
        private Label label1;
        private Button btnClearFilter;
    }
}