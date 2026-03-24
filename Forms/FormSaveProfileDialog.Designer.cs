namespace WOWAuctionApi_Net10
{
    partial class FormSaveProfileDialog
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaveProfileDialog));
            label1 = new Label();
            textBoxProfileName = new TextBox();
            picProfileImage = new PictureBox();
            btnSave = new Button();
            btnCancel = new Button();
            imgIcons = new ImageList(components);
            btnChangeIcon = new Button();
            ((System.ComponentModel.ISupportInitialize)picProfileImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 24);
            label1.Name = "label1";
            label1.Size = new Size(153, 32);
            label1.TabIndex = 0;
            label1.Text = "Profile Name";
            // 
            // textBoxProfileName
            // 
            textBoxProfileName.Location = new Point(30, 73);
            textBoxProfileName.MaxLength = 20;
            textBoxProfileName.Name = "textBoxProfileName";
            textBoxProfileName.Size = new Size(585, 39);
            textBoxProfileName.TabIndex = 1;
            // 
            // picProfileImage
            // 
            picProfileImage.Location = new Point(567, 18);
            picProfileImage.Name = "picProfileImage";
            picProfileImage.Size = new Size(48, 48);
            picProfileImage.TabIndex = 2;
            picProfileImage.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(465, 130);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(305, 130);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // imgIcons
            // 
            imgIcons.ColorDepth = ColorDepth.Depth32Bit;
            imgIcons.ImageStream = (ImageListStreamer)resources.GetObject("imgIcons.ImageStream");
            imgIcons.TransparentColor = Color.Transparent;
            imgIcons.Images.SetKeyName(0, "save_as.ico");
            imgIcons.Images.SetKeyName(1, "edit.ico");
            imgIcons.Images.SetKeyName(2, "new.ico");
            // 
            // btnChangeIcon
            // 
            btnChangeIcon.Location = new Point(334, 18);
            btnChangeIcon.Name = "btnChangeIcon";
            btnChangeIcon.Size = new Size(227, 46);
            btnChangeIcon.TabIndex = 5;
            btnChangeIcon.Text = "Change Icon";
            btnChangeIcon.UseVisualStyleBackColor = true;
            btnChangeIcon.Click += btnChangeIcon_Click;
            // 
            // FormSaveSearchDlg
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 205);
            Controls.Add(btnChangeIcon);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(picProfileImage);
            Controls.Add(textBoxProfileName);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSaveSearchDlg";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Save Search";
            ((System.ComponentModel.ISupportInitialize)picProfileImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxProfileName;
        private PictureBox picProfileImage;
        private Button btnSave;
        private Button btnCancel;
        private ImageList imgIcons;
        private Button btnChangeIcon;
    }
}