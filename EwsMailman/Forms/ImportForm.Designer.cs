namespace EwsMailman
{
    partial class ImportForm
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            this.importBtn = new System.Windows.Forms.Button();
            this.folderIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.folderTreeView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.importBtn);
            this.splitContainer3.Panel2.Controls.Add(this.folderIdBox);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.folderNameBox);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Size = new System.Drawing.Size(517, 637);
            this.splitContainer3.SplitterDistance = 574;
            this.splitContainer3.TabIndex = 1;
            // 
            // folderTreeView
            // 
            this.folderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderTreeView.Location = new System.Drawing.Point(0, 0);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.Size = new System.Drawing.Size(517, 574);
            this.folderTreeView.TabIndex = 1;
            this.folderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterSelect);
            // 
            // importBtn
            // 
            this.importBtn.Image = global::EwsMailman.Properties.Resources.Import_16x;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.importBtn.Location = new System.Drawing.Point(403, 2);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(102, 55);
            this.importBtn.TabIndex = 6;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // folderIdBox
            // 
            this.folderIdBox.Enabled = false;
            this.folderIdBox.Location = new System.Drawing.Point(82, 31);
            this.folderIdBox.Name = "folderIdBox";
            this.folderIdBox.Size = new System.Drawing.Size(315, 20);
            this.folderIdBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Folder id:";
            // 
            // folderNameBox
            // 
            this.folderNameBox.Enabled = false;
            this.folderNameBox.Location = new System.Drawing.Point(82, 5);
            this.folderNameBox.Name = "folderNameBox";
            this.folderNameBox.Size = new System.Drawing.Size(315, 20);
            this.folderNameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder name:";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 637);
            this.Controls.Add(this.splitContainer3);
            this.Name = "ImportForm";
            this.Text = "ImportForm";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.Shown += new System.EventHandler(this.ImportForm_Shown);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView folderTreeView;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.TextBox folderIdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox folderNameBox;
        private System.Windows.Forms.Label label2;
    }
}