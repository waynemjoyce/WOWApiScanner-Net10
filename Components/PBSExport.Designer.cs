namespace WOWAuctionApi_Net10
{
    partial class PBSExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PBSExport));
            btnCopy = new Button();
            txtPBSExport = new TextBox();
            SuspendLayout();
            // 
            // btnCopy
            // 
            btnCopy.BackColor = SystemColors.ControlDark;
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Image = (Image)resources.GetObject("btnCopy.Image");
            btnCopy.Location = new Point(3, 3);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(36, 36);
            btnCopy.TabIndex = 131;
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtPBSExport
            // 
            txtPBSExport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPBSExport.Location = new Point(17, 58);
            txtPBSExport.Multiline = true;
            txtPBSExport.Name = "txtPBSExport";
            txtPBSExport.ReadOnly = true;
            txtPBSExport.ScrollBars = ScrollBars.Vertical;
            txtPBSExport.Size = new Size(1048, 495);
            txtPBSExport.TabIndex = 132;
            // 
            // PBSExport
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPBSExport);
            Controls.Add(btnCopy);
            Name = "PBSExport";
            OptionsTitle = "      PBS Export";
            ShowToggleButton = false;
            Controls.SetChildIndex(btnCopy, 0);
            Controls.SetChildIndex(txtPBSExport, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCopy;
        private TextBox txtPBSExport;
    }
}
