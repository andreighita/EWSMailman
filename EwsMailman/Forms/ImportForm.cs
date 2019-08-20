using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EwsMailman
{
    public partial class ImportForm : Form
    {
        Point setPoint;
        public ImportForm()
        {
            InitializeComponent();
        }

        public ImportForm(Point point)
        {
            setPoint = point;
            InitializeComponent();
        }
        private void ImportForm_Load(object sender, EventArgs e)
        {
            Location = setPoint;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Get the bitmap.
            Bitmap bm = new Bitmap(Properties.Resources.Import_16x);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
        }

        private void ImportForm_Shown(object sender, EventArgs e)
        {
            folderTreeView.Nodes.Add(EwsHelper.GetFoldersTree());
        }

        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != folderTreeView.SelectedNode)
            {
                folderNameBox.Text = folderTreeView.SelectedNode.Text;
                folderIdBox.Text = (string)folderTreeView.SelectedNode.Tag;
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            if (string.Empty == folderIdBox.Text)
            {
                MessageBox.Show("Please select a valid folder from the folders tree");
                return;
            }
            var fileContent = string.Empty;
            var filePath = string.Empty;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                    openFileDialog.Filter = "EWS files (*.ews)|*.ews";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        EwsHelper.UploadItem(folderIdBox.Text, openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
