namespace EwsMailman
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.useImpersonationBox = new System.Windows.Forms.CheckBox();
            this.exchangeVersionCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.useDefaultCredentialsBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ewsUrlBox = new System.Windows.Forms.TextBox();
            this.useServiceUriBtn = new System.Windows.Forms.RadioButton();
            this.useAutodiscoverBtn = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.impersonateEmailBox = new System.Windows.Forms.TextBox();
            this.tracingOnBox = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.impersonateEmailBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.useImpersonationBox);
            this.groupBox3.Controls.Add(this.exchangeVersionCombo);
            this.groupBox3.Location = new System.Drawing.Point(10, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 69);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Service options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Exchange Version:";
            // 
            // useImpersonationBox
            // 
            this.useImpersonationBox.AutoSize = true;
            this.useImpersonationBox.Checked = true;
            this.useImpersonationBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useImpersonationBox.Location = new System.Drawing.Point(6, 42);
            this.useImpersonationBox.Name = "useImpersonationBox";
            this.useImpersonationBox.Size = new System.Drawing.Size(114, 17);
            this.useImpersonationBox.TabIndex = 10;
            this.useImpersonationBox.Text = "Impersonate email:";
            this.useImpersonationBox.UseVisualStyleBackColor = true;
            this.useImpersonationBox.CheckedChanged += new System.EventHandler(this.UseImpersonationBox_CheckedChanged);
            // 
            // exchangeVersionCombo
            // 
            this.exchangeVersionCombo.FormattingEnabled = true;
            this.exchangeVersionCombo.Items.AddRange(new object[] {
            "Exchange2007_SP1",
            "Exchange2010",
            "Exchange2010_SP1",
            "Exchange2010_SP2",
            "Exchange2013",
            "Exchange2013_SP1"});
            this.exchangeVersionCombo.Location = new System.Drawing.Point(131, 15);
            this.exchangeVersionCombo.Name = "exchangeVersionCombo";
            this.exchangeVersionCombo.Size = new System.Drawing.Size(177, 21);
            this.exchangeVersionCombo.TabIndex = 8;
            this.exchangeVersionCombo.Text = "Exchange2013_SP1";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(371, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(291, 264);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 26;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // useDefaultCredentialsBox
            // 
            this.useDefaultCredentialsBox.AutoSize = true;
            this.useDefaultCredentialsBox.Checked = true;
            this.useDefaultCredentialsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useDefaultCredentialsBox.Location = new System.Drawing.Point(6, 13);
            this.useDefaultCredentialsBox.Name = "useDefaultCredentialsBox";
            this.useDefaultCredentialsBox.Size = new System.Drawing.Size(134, 17);
            this.useDefaultCredentialsBox.TabIndex = 8;
            this.useDefaultCredentialsBox.Text = "Use default credentials";
            this.useDefaultCredentialsBox.UseVisualStyleBackColor = true;
            this.useDefaultCredentialsBox.CheckedChanged += new System.EventHandler(this.useDefaultCredentialsBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // passwordBox
            // 
            this.passwordBox.Enabled = false;
            this.passwordBox.Location = new System.Drawing.Point(131, 62);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(175, 20);
            this.passwordBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // usernameBox
            // 
            this.usernameBox.Enabled = false;
            this.usernameBox.Location = new System.Drawing.Point(131, 36);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(175, 20);
            this.usernameBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "EWS URL:";
            // 
            // ewsUrlBox
            // 
            this.ewsUrlBox.Location = new System.Drawing.Point(131, 59);
            this.ewsUrlBox.Name = "ewsUrlBox";
            this.ewsUrlBox.Size = new System.Drawing.Size(296, 20);
            this.ewsUrlBox.TabIndex = 4;
            // 
            // useServiceUriBtn
            // 
            this.useServiceUriBtn.AutoSize = true;
            this.useServiceUriBtn.Location = new System.Drawing.Point(6, 42);
            this.useServiceUriBtn.Name = "useServiceUriBtn";
            this.useServiceUriBtn.Size = new System.Drawing.Size(103, 17);
            this.useServiceUriBtn.TabIndex = 3;
            this.useServiceUriBtn.Text = "Use service URI";
            this.useServiceUriBtn.UseVisualStyleBackColor = true;
            // 
            // useAutodiscoverBtn
            // 
            this.useAutodiscoverBtn.AutoSize = true;
            this.useAutodiscoverBtn.Checked = true;
            this.useAutodiscoverBtn.Location = new System.Drawing.Point(6, 19);
            this.useAutodiscoverBtn.Name = "useAutodiscoverBtn";
            this.useAutodiscoverBtn.Size = new System.Drawing.Size(108, 17);
            this.useAutodiscoverBtn.TabIndex = 2;
            this.useAutodiscoverBtn.TabStop = true;
            this.useAutodiscoverBtn.Text = "Use autodiscover";
            this.useAutodiscoverBtn.UseVisualStyleBackColor = true;
            this.useAutodiscoverBtn.CheckedChanged += new System.EventHandler(this.useAutodiscoverBtn_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 293);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(453, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ewsUrlBox);
            this.groupBox1.Controls.Add(this.useServiceUriBtn);
            this.groupBox1.Controls.Add(this.useAutodiscoverBtn);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 85);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endpoint options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.useDefaultCredentialsBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.passwordBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.usernameBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 89);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credentials";
            // 
            // impersonateEmailBox
            // 
            this.impersonateEmailBox.Location = new System.Drawing.Point(131, 40);
            this.impersonateEmailBox.Name = "impersonateEmailBox";
            this.impersonateEmailBox.Size = new System.Drawing.Size(177, 20);
            this.impersonateEmailBox.TabIndex = 14;
            // 
            // tracingOnBox
            // 
            this.tracingOnBox.AutoSize = true;
            this.tracingOnBox.Checked = true;
            this.tracingOnBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tracingOnBox.Location = new System.Drawing.Point(16, 268);
            this.tracingOnBox.Name = "tracingOnBox";
            this.tracingOnBox.Size = new System.Drawing.Size(94, 17);
            this.tracingOnBox.TabIndex = 29;
            this.tracingOnBox.Text = "Enable tracing";
            this.tracingOnBox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 315);
            this.Controls.Add(this.tracingOnBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox useImpersonationBox;
        private System.Windows.Forms.ComboBox exchangeVersionCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox useDefaultCredentialsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ewsUrlBox;
        private System.Windows.Forms.RadioButton useServiceUriBtn;
        private System.Windows.Forms.RadioButton useAutodiscoverBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox impersonateEmailBox;
        private System.Windows.Forms.CheckBox tracingOnBox;
    }
}