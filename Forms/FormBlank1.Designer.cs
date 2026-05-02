namespace WOWAuctionApi_Net10.Forms
{
    partial class FormBlank1
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
            colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            colorEditorManager2 = new Cyotek.Windows.Forms.ColorEditorManager();
            colorEditorManager3 = new Cyotek.Windows.Forms.ColorEditorManager();
            auctionsView1 = new AuctionsView();
            SuspendLayout();
            // 
            // colorEditorManager1
            // 
            colorEditorManager1.Color = Color.Empty;
            // 
            // colorEditorManager2
            // 
            colorEditorManager2.Color = Color.Empty;
            // 
            // colorEditorManager3
            // 
            colorEditorManager3.Color = Color.Empty;
            // 
            // auctionsView1
            // 
            auctionsView1.Location = new Point(63, 133);
            auctionsView1.Name = "auctionsView1";
            auctionsView1.Size = new Size(3000, 2980);
            auctionsView1.TabIndex = 0;
            // 
            // FormBlank1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2003, 1108);
            Controls.Add(auctionsView1);
            Name = "FormBlank1";
            Text = "FormBlank1";
            ResumeLayout(false);
        }

        #endregion
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager2;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager3;
        private AuctionsView auctionsView1;
    }
}