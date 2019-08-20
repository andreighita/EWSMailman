namespace EwsMailman.Forms
{
    partial class ExportForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            this.folderIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.itemListView = new System.Windows.Forms.ListView();
            this.dateTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subjectHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exportBtn = new System.Windows.Forms.Button();
            this.itemIdBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.itemSubjectBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.browseFoldersBtn = new System.Windows.Forms.Button();
            this.folderPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1018, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1018, 545);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 2;
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
            this.splitContainer3.Panel2.Controls.Add(this.folderIdBox);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.folderNameBox);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Size = new System.Drawing.Size(400, 545);
            this.splitContainer3.SplitterDistance = 490;
            this.splitContainer3.TabIndex = 0;
            // 
            // folderTreeView
            // 
            this.folderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderTreeView.Location = new System.Drawing.Point(0, 0);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.Size = new System.Drawing.Size(400, 490);
            this.folderTreeView.TabIndex = 1;
            this.folderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterSelect);
            // 
            // folderIdBox
            // 
            this.folderIdBox.Enabled = false;
            this.folderIdBox.Location = new System.Drawing.Point(82, 29);
            this.folderIdBox.Name = "folderIdBox";
            this.folderIdBox.Size = new System.Drawing.Size(315, 20);
            this.folderIdBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Folder id:";
            // 
            // folderNameBox
            // 
            this.folderNameBox.Enabled = false;
            this.folderNameBox.Location = new System.Drawing.Point(82, 3);
            this.folderNameBox.Name = "folderNameBox";
            this.folderNameBox.Size = new System.Drawing.Size(315, 20);
            this.folderNameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder name:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.itemListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.exportBtn);
            this.splitContainer2.Panel2.Controls.Add(this.itemIdBox);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.itemSubjectBox);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.browseFoldersBtn);
            this.splitContainer2.Panel2.Controls.Add(this.folderPathBox);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(614, 545);
            this.splitContainer2.SplitterDistance = 454;
            this.splitContainer2.TabIndex = 0;
            // 
            // itemListView
            // 
            this.itemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateTimeHeader,
            this.subjectHeader});
            this.itemListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemListView.HideSelection = false;
            this.itemListView.Location = new System.Drawing.Point(0, 0);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(614, 454);
            this.itemListView.TabIndex = 0;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ItemListView_ColumnClick);
            this.itemListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ItemListView_ItemSelectionChanged);
            // 
            // dateTimeHeader
            // 
            this.dateTimeHeader.Text = "DateTime";
            // 
            // subjectHeader
            // 
            this.subjectHeader.Text = "Subject";
            // 
            // exportBtn
            // 
            this.exportBtn.Image = global::EwsMailman.Properties.Resources.Export_16x;
            this.exportBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exportBtn.Location = new System.Drawing.Point(492, 4);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(110, 75);
            this.exportBtn.TabIndex = 10;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // itemIdBox
            // 
            this.itemIdBox.Enabled = false;
            this.itemIdBox.Location = new System.Drawing.Point(77, 59);
            this.itemIdBox.Name = "itemIdBox";
            this.itemIdBox.Size = new System.Drawing.Size(399, 20);
            this.itemIdBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Item id:";
            // 
            // itemSubjectBox
            // 
            this.itemSubjectBox.Enabled = false;
            this.itemSubjectBox.Location = new System.Drawing.Point(77, 33);
            this.itemSubjectBox.Name = "itemSubjectBox";
            this.itemSubjectBox.Size = new System.Drawing.Size(399, 20);
            this.itemSubjectBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Subject:";
            // 
            // browseFoldersBtn
            // 
            this.browseFoldersBtn.Location = new System.Drawing.Point(382, 4);
            this.browseFoldersBtn.Name = "browseFoldersBtn";
            this.browseFoldersBtn.Size = new System.Drawing.Size(94, 23);
            this.browseFoldersBtn.TabIndex = 2;
            this.browseFoldersBtn.Text = "Browse";
            this.browseFoldersBtn.UseVisualStyleBackColor = true;
            this.browseFoldersBtn.Click += new System.EventHandler(this.BrowseFoldersBtn_Click);
            // 
            // folderPathBox
            // 
            this.folderPathBox.Enabled = false;
            this.folderPathBox.Location = new System.Drawing.Point(77, 6);
            this.folderPathBox.Name = "folderPathBox";
            this.folderPathBox.Size = new System.Drawing.Size(299, 20);
            this.folderPathBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Export folder:";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ExportForm";
            this.Text = "ExportForm";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.Shown += new System.EventHandler(this.ExportForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.ColumnHeader dateTimeHeader;
        private System.Windows.Forms.ColumnHeader subjectHeader;
        private System.Windows.Forms.Button browseFoldersBtn;
        private System.Windows.Forms.TextBox folderPathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView folderTreeView;
        private System.Windows.Forms.TextBox folderIdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox folderNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemIdBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox itemSubjectBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exportBtn;
    }
}