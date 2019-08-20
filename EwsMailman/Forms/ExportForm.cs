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
using EwsMailman;
namespace EwsMailman.Forms
{
    public partial class ExportForm : Form
    {
        Point setPoint;
        private ListViewColumnSorter lvwColumnSorter;

        public ExportForm()
        {
            InitializeComponent();
        }

        public ExportForm(Point point)
        {
            setPoint = point;
            InitializeComponent();
        }
        private void ExportForm_Load(object sender, EventArgs e)
        {
            Location = setPoint;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            folderPathBox.Text = System.IO.Directory.GetCurrentDirectory();
            // Get the bitmap.
            Bitmap bm = new Bitmap(Properties.Resources.Export_16x);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
            
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.itemListView.ListViewItemSorter = lvwColumnSorter;
        }

        private void ExportForm_Shown(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Getting the list of folders, please wait...";
            folderTreeView.Nodes.Add(EwsHelper.GetFoldersTree());
            toolStripStatusLabel1.Text = "Ready...";
        }

        private void FolderTreeView_Click(object sender, EventArgs e)
        {

        }

        private void ItemListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            itemListView.Sort();
        }

        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != folderTreeView.SelectedNode)
            {
                folderNameBox.Text = folderTreeView.SelectedNode.Text;
                folderIdBox.Text = (string)folderTreeView.SelectedNode.Tag;

                if (folderTreeView.SelectedNode.Tag != null)
                {
                    itemListView.Items.Clear();
                    toolStripStatusLabel1.Text = "Getting the list of items, please wait...";
                    EwsHelper.GetItemsList((string)folderTreeView.SelectedNode.Tag, itemListView);
                    toolStripStatusLabel1.Text = "Ready...";
                }
            }
        }

        private void ItemListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (itemListView.SelectedItems.Count > 0)
            {
                itemSubjectBox.Text = itemListView.SelectedItems[0].SubItems[0].Text + " " + itemListView.SelectedItems[0].SubItems[1].Text;
                itemIdBox.Text = (string)itemListView.SelectedItems[0].Tag;
            }
        }

        private void BrowseFoldersBtn_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPathBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {

            if ((itemIdBox.Text != string.Empty) && (itemSubjectBox.Text != string.Empty) && (folderPathBox.Text != string.Empty))
            {
                EwsHelper.ExportItem(itemIdBox.Text, Path.Combine(folderPathBox.Text, String.Join(".", String.Join("_", itemSubjectBox.Text.Split(System.IO.Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries)), ".ews")));
                MessageBox.Show("Item was exported");
            }
            else
            {
                MessageBox.Show("Please select an item to export by clicking on a row in the DateTimeReceived column. Also please make sure you've specified a valid folder for the export path");
            }
        }
    }
}
