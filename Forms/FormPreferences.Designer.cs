namespace WOWAuctionApi_Net10
{
    partial class FormPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreferences));
            btnSave = new Button();
            btnCancel = new Button();
            configCheckOptions1 = new ConfigCheckOptions();
            configTextOptions1 = new ConfigTextOptions();
            configNumberOptions1 = new ConfigNumberOptions();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(948, 1173);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(792, 1173);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // configCheckOptions1
            // 
            configCheckOptions1.BackColor = SystemColors.ControlLight;
            configCheckOptions1.Location = new Point(29, 445);
            configCheckOptions1.Name = "configCheckOptions1";
            configCheckOptions1.OptionsTitle = "      Config Check Options";
            configCheckOptions1.ShowEnabled = true;
            configCheckOptions1.ShowToggleButton = true;
            configCheckOptions1.Size = new Size(515, 697);
            configCheckOptions1.TabIndex = 175;
            // 
            // configTextOptions1
            // 
            configTextOptions1.BackColor = SystemColors.ControlLight;
            configTextOptions1.Location = new Point(29, 29);
            configTextOptions1.Name = "configTextOptions1";
            configTextOptions1.OptionsTitle = " Config Main Options";
            configTextOptions1.ShowEnabled = true;
            configTextOptions1.ShowToggleButton = false;
            configTextOptions1.Size = new Size(1069, 384);
            configTextOptions1.TabIndex = 176;
            // 
            // configNumberOptions1
            // 
            configNumberOptions1.BackColor = SystemColors.ControlLight;
            configNumberOptions1.Location = new Point(583, 451);
            configNumberOptions1.Name = "configNumberOptions1";
            configNumberOptions1.OptionsTitle = " Config Number Options";
            configNumberOptions1.ShowEnabled = true;
            configNumberOptions1.ShowToggleButton = false;
            configNumberOptions1.Size = new Size(515, 691);
            configNumberOptions1.TabIndex = 177;
            // 
            // FormPreferences
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 1268);
            Controls.Add(configNumberOptions1);
            Controls.Add(configTextOptions1);
            Controls.Add(configCheckOptions1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPreferences";
            StartPosition = FormStartPosition.CenterParent;
            Text = " Preferences";
            Load += FormPreferences_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private ConfigCheckOptions configCheckOptions1;
        private ConfigTextOptions configTextOptions1;
        private ConfigNumberOptions configNumberOptions1;
    }
}