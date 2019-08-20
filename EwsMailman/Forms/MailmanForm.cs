using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EwsMailman.Forms
{
    public partial class MailmanForm : Form
    {
        public MailmanForm()
        {
            InitializeComponent();
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(new Point(Location.X + Width, Location.Y));
            optionsForm.ShowDialog(this);
        }

        private void MailmanForm_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ServicePointManager.ServerCertificateValidationCallback += EwsHelper.RemoteCertificateValidationCallback;
        }

        private void ExportMailButton_Click(object sender, EventArgs e)
        {
            ExportForm exportForm = new ExportForm(new Point(Location.X + Width, Location.Y));
            exportForm.ShowDialog();
        }

        private void MailmanForm_Shown(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(new Point(Location.X + Width, Location.Y));
            optionsForm.ShowDialog();
        }

        private void ImportMailBtn_Click(object sender, EventArgs e)
        {
            ImportForm importForm = new ImportForm(new Point(Location.X + Width, Location.Y));
            importForm.ShowDialog();
        }

        private void SendMailBtn_Click(object sender, EventArgs e)
        {
            SendMailForm sendMailForm =  new SendMailForm(new Point(Location.X + Width, Location.Y));
            sendMailForm.ShowDialog();
        }
    }
}
