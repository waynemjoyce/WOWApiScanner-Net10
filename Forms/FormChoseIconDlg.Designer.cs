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
            SuspendLayout();
            // 
            // lvImages
            // 
            lvImages.Location = new Point(36, 26);
            lvImages.MultiSelect = false;
            lvImages.Name = "lvImages";
            lvImages.Size = new Size(1214, 593);
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
            // FormChoseIconDlg
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 708);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lvImages);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormChoseIconDlg";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Choose Your Icon";
            Load += FormChoseIcon_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lvImages;
        private Button btnOK;
        private Button btnCancel;
    }
}