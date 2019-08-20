using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EwsMailman
{
    public partial class OptionsForm : Form
    {
        Point setPoint;
        public OptionsForm()
        {
            InitializeComponent();
        }

        public OptionsForm(Point point)
        {
            setPoint = point;
            InitializeComponent();
        }
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.Location = setPoint;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Properties.Settings.Default.Reload();
            useAutodiscoverBtn.Checked = Properties.Settings.Default.USE_AUTODISCOVER;
            useServiceUriBtn.Checked = Properties.Settings.Default.USE_SERVICE_URI;
            ewsUrlBox.Text = Properties.Settings.Default.SERVICE_URI;
            useDefaultCredentialsBox.Checked = Properties.Settings.Default.USE_DEFAULT_CREDENTIALS;
            usernameBox.Text = Properties.Settings.Default.USERNAME;
            passwordBox.Text = Properties.Settings.Default.PASSWORD;
            exchangeVersionCombo.Text = Properties.Settings.Default.EXCHANGE_VERSION;
            useImpersonationBox.Checked = Properties.Settings.Default.USE_IMPERSONATION;
            impersonateEmailBox.Text = Properties.Settings.Default.EMAIL_ADDRESS;
            tracingOnBox.Checked = Properties.Settings.Default.TRACING_ENABLED;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.USE_AUTODISCOVER = useAutodiscoverBtn.Checked;
            Properties.Settings.Default.USE_SERVICE_URI = useServiceUriBtn.Checked;
            Properties.Settings.Default.SERVICE_URI = ewsUrlBox.Text;
            Properties.Settings.Default.USE_DEFAULT_CREDENTIALS = useDefaultCredentialsBox.Checked;
            Properties.Settings.Default.USERNAME = usernameBox.Text;
            Properties.Settings.Default.PASSWORD = passwordBox.Text;
            Properties.Settings.Default.EXCHANGE_VERSION = exchangeVersionCombo.Text;
            Properties.Settings.Default.USE_IMPERSONATION = useImpersonationBox.Checked;
            Properties.Settings.Default.EMAIL_ADDRESS = impersonateEmailBox.Text;
            Properties.Settings.Default.TRACING_ENABLED = tracingOnBox.Checked;
            Properties.Settings.Default.Save();
            EwsHelper.Initialise();
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void useDefaultCredentialsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useDefaultCredentialsBox.Checked)
            {
                usernameBox.Enabled = false;
                passwordBox.Enabled = false;
            }
            else
            {
                usernameBox.Enabled = true;
                passwordBox.Enabled = true;
            }

        }

        private void useAutodiscoverBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (useAutodiscoverBtn.Checked)
            {
                ewsUrlBox.Enabled = false;

            }
            else
            {
                ewsUrlBox.Enabled = true;
            }
        }

        private void UseImpersonationBox_CheckedChanged(object sender, EventArgs e)
        {
            impersonateEmailBox.Enabled = useImpersonationBox.Checked;
        }
    }
}
