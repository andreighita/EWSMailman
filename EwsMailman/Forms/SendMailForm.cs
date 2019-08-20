using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using System.Net;

namespace EwsMailman
{
    public partial class SendMailForm : Form
    {
        private bool useAutodiscover;
        private bool useDefaultCredentials;
        private bool useImpersonation;
        private ExchangeService exchangeService;
        private ExchangeVersion exchangeVersion;
        private string emailAddress;
        private string password;
        private string username;
        private Uri EwsUri;

        private List<string> errorRecipients;
        private string[] unresolvedToRecipients;
        private string[] unresolvedCCRecipients;
        private string messageSubject;
        private string messageBody;
        Point setPoint;

        public SendMailForm()
        {
            InitializeComponent();
        }

        public SendMailForm(Point point)
        {
            setPoint = point;
            InitializeComponent();
        }

        public bool RemoteCertificateValidationCallback(object sender,
System.Security.Cryptography.X509Certificates.X509Certificate certificate,
System.Security.Cryptography.X509Certificates.X509Chain chain,
System.Net.Security.SslPolicyErrors sslPolicyErrors)
        { return true; }



        private bool ParseParameters()
        {
            try
            {
                errorRecipients = new List<string>();
                exchangeVersion = (ExchangeVersion)Enum.Parse(typeof(ExchangeVersion), Properties.Settings.Default.EXCHANGE_VERSION);
                password = Properties.Settings.Default.PASSWORD;
                useAutodiscover = Properties.Settings.Default.USE_AUTODISCOVER;
                useDefaultCredentials = Properties.Settings.Default.USE_DEFAULT_CREDENTIALS;
                useImpersonation = Properties.Settings.Default.USE_IMPERSONATION;
                username = Properties.Settings.Default.USERNAME;
                if (Properties.Settings.Default.SERVICE_URI != string.Empty)
                    EwsUri = new Uri(Properties.Settings.Default.SERVICE_URI);
                if (textBoxFrom.Text != string.Empty && textBoxFrom.Text.Contains('@') && textBoxFrom.Text.Contains('.'))
                    emailAddress = textBoxFrom.Text;
                else
                    return false;
                unresolvedToRecipients = textBoxTo.Text.Split(';');
                unresolvedCCRecipients = textBoxCC.Text.Split(';');
                messageSubject = textBoxSubject.Text;
                messageBody = textBoxBody.Text;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private ExchangeService CreateService()
        {
            if (exchangeService != null)
            {
                return exchangeService;
            }

            // Creating a new ExchangeService instance
            exchangeService = new ExchangeService(exchangeVersion);
            exchangeService.UseDefaultCredentials = useDefaultCredentials;
            exchangeService.Url = EwsUri;
            if (useAutodiscover)
            {
                try
                {
                    toolStripStatusLabel.Text = "Performing autodiscover lookup...";
                    exchangeService.AutodiscoverUrl(emailAddress, delegate { return true; });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Autodiscover wasn't able to locate your settings, please check your DNS settings or fill in the Ews Url in the settings menu./nException:/n" + ex.ToString());
                    toolStripStatusLabel.Text = "Autodiscover error encountered.";
                    return null;
                }
            }
            exchangeService.Credentials = new WebCredentials(username, password);
            exchangeService.UseDefaultCredentials = useDefaultCredentials;
            if (useImpersonation)
                exchangeService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
            return exchangeService;
        }

        private string ResolveRecipients(string[] unresolvedRecipients, EmailAddressCollection emailAddressCollection)
        {
            string resolvedRecipients = string.Empty;
            foreach (string recipient in unresolvedRecipients)
            {
                try
                {
                    NameResolutionCollection nameResolutionCollection = exchangeService.ResolveName(recipient);
                    if (nameResolutionCollection != null)
                    {
                        if (nameResolutionCollection.Count == 1)
                        {
                            if (nameResolutionCollection[0].Mailbox != null)
                                emailAddressCollection.Add(nameResolutionCollection[0].Mailbox.Address);
                            resolvedRecipients += nameResolutionCollection[0].Mailbox.Address + "; ";
                        }
                        else
                        {
                            if (errorRecipients.Contains(recipient))
                                errorRecipients.Add(recipient);
                        }
                    }
                }
                catch
                {
                    if (errorRecipients.Contains(recipient))
                        errorRecipients.Add(recipient);
                }
            }
            return resolvedRecipients;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (ParseParameters())
            {
                toolStripStatusLabel.Text = "Creating service...";
                exchangeService = CreateService();
                if (exchangeService != null)
                {
                    try
                    {
                        toolStripStatusLabel.Text = "Testing service...";
                        FolderId folderId = new FolderId(WellKnownFolderName.MsgFolderRoot, new Mailbox(emailAddress));
                        Folder.Bind(exchangeService, folderId, BasePropertySet.IdOnly);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Service is down. Error details:/n" + ex.ToString());
                        return;
                    }
                    EmailMessage emailMessage = new EmailMessage(exchangeService);
                    if (emailMessage != null)
                    {
                        toolStripStatusLabel.Text = "Resolving To recipients...";
                        textBoxTo.Text = ResolveRecipients(unresolvedToRecipients, emailMessage.ToRecipients);
                        toolStripStatusLabel.Text = "Resolcing CC recipients...";
                        textBoxCC.Text = ResolveRecipients(unresolvedCCRecipients, emailMessage.CcRecipients);
                        emailMessage.Subject = messageSubject;
                        emailMessage.Body = messageBody;
                    }
                    if (errorRecipients.Count > 0)
                    {
                        string message = "The following recipient couldn't be resolved or multiple entries were returned. Please check the list and amend the entries or be more specific:/n";
                        foreach (string recipient in errorRecipients)
                        {
                            message += recipient + "/n";
                        }
                        message += "Click \"Yes\" to send the message anyway or \"No\" to return and amend the list of recipients";
                        DialogResult dialogResult = MessageBox.Show(message, "Recipient(s) error", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                toolStripStatusLabel.Text = "Sending message...";
                                emailMessage.SendAndSaveCopy();
                                toolStripStatusLabel.Text = "Done.";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                toolStripStatusLabel.Text = "Error encountered.";
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            toolStripStatusLabel.Text = "Sending message...";
                            emailMessage.SendAndSaveCopy();
                            toolStripStatusLabel.Text = "Done.";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            toolStripStatusLabel.Text = "Error encountered.";
                        }
                    }
                }
            }
            else
                MessageBox.Show("Unable to parse parameters");
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog(this);
        }

        private void SendMailForm_Load(object sender, EventArgs e)
        {
            Location = setPoint;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidationCallback;
        }
    }
}
