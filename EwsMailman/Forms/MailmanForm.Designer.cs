namespace EwsMailman.Forms
{
    partial class MailmanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailmanForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.exportMailButton = new System.Windows.Forms.Button();
            this.ImportMailBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sendMailBtn = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 165);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(133, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // exportMailButton
            // 
            this.exportMailButton.Image = global::EwsMailman.Properties.Resources.Export_16x;
            this.exportMailButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportMailButton.Location = new System.Drawing.Point(18, 128);
            this.exportMailButton.Name = "exportMailButton";
            this.exportMailButton.Size = new System.Drawing.Size(99, 23);
            this.exportMailButton.TabIndex = 29;
            this.exportMailButton.Text = "Export items";
            this.exportMailButton.UseVisualStyleBackColor = true;
            this.exportMailButton.Click += new System.EventHandler(this.ExportMailButton_Click);
            // 
            // ImportMailBtn
            // 
            this.ImportMailBtn.Image = global::EwsMailman.Properties.Resources.Import_16x;
            this.ImportMailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportMailBtn.Location = new System.Drawing.Point(18, 99);
            this.ImportMailBtn.Name = "ImportMailBtn";
            this.ImportMailBtn.Size = new System.Drawing.Size(99, 23);
            this.ImportMailBtn.TabIndex = 28;
            this.ImportMailBtn.Text = "Import items";
            this.ImportMailBtn.UseVisualStyleBackColor = true;
            this.ImportMailBtn.Click += new System.EventHandler(this.ImportMailBtn_Click);
            // 
            // button2
            // 
            this.button2.Image = global::EwsMailman.Properties.Resources.MailOpen_noHalo_16x;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(18, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Read mail";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // sendMailBtn
            // 
            this.sendMailBtn.Image = global::EwsMailman.Properties.Resources.Mail_16x;
            this.sendMailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendMailBtn.Location = new System.Drawing.Point(18, 41);
            this.sendMailBtn.Name = "sendMailBtn";
            this.sendMailBtn.Size = new System.Drawing.Size(99, 23);
            this.sendMailBtn.TabIndex = 26;
            this.sendMailBtn.Text = "Send mail";
            this.sendMailBtn.UseVisualStyleBackColor = true;
            this.sendMailBtn.Visible = false;
            this.sendMailBtn.Click += new System.EventHandler(this.SendMailBtn_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = global::EwsMailman.Properties.Resources.SettingsOutline_16x;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(18, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(99, 23);
            this.buttonSettings.TabIndex = 25;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // MailmanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(133, 187);
            this.Controls.Add(this.exportMailButton);
            this.Controls.Add(this.ImportMailBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sendMailBtn);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailmanForm";
            this.Text = "EwsMailman";
            this.Load += new System.EventHandler(this.MailmanForm_Load);
            this.Shown += new System.EventHandler(this.MailmanForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button sendMailBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ImportMailBtn;
        private System.Windows.Forms.Button exportMailButton;
    }
}