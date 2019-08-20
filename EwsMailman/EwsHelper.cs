using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Net.Http;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EwsMailman
{
    enum O365UserStatus
    {
        Unknown,
        IsO365User,
        IsNotO365User,
        InvalidEmail
    }
    class EwsHelper
    {
        // private static bool m_ServiceInitialised = false;
        private static ExchangeService m_ExchangeService;
        private static bool m_UseAutodiscover;
        private static bool m_UseDefaultCredentials;
        private static bool m_UseImpersonation;
        private static ExchangeVersion m_ExchangeVersion;
        private static string m_EmailAddress;
        private static string m_Password;
        private static string m_Username;
        private static string m_EwsUri;
        private static Uri m_ServiceUri;
        private static O365UserStatus o365UserStatus = O365UserStatus.Unknown;
        private static bool m_TracingEnabled;
        //private static List<string> m_ErrorRecipients;
        //private static List<string> m_UnresolvedToRecipients;
        //private static List<string> m_UnresolvedCCRecipients;
        //private static string m_MessageSubject;
        //private static string m_MessageBody;
        //private static string m_SenderEmailAddress;

        public static string Status

        {
            get; set;
        }

        public static void Initialise()
        {
            m_UseAutodiscover = Properties.Settings.Default.USE_AUTODISCOVER;
            m_UseDefaultCredentials = Properties.Settings.Default.USE_DEFAULT_CREDENTIALS;
            m_UseImpersonation = Properties.Settings.Default.USE_IMPERSONATION;
            m_EmailAddress = Properties.Settings.Default.EMAIL_ADDRESS;
            m_Password = Properties.Settings.Default.PASSWORD;
            m_Username = Properties.Settings.Default.USERNAME;
            m_ExchangeVersion = (ExchangeVersion)Enum.Parse(typeof(ExchangeVersion), Properties.Settings.Default.EXCHANGE_VERSION);
            m_EwsUri = Properties.Settings.Default.SERVICE_URI;
            m_TracingEnabled = Properties.Settings.Default.TRACING_ENABLED;
            if (string.Empty != m_EwsUri)
            {
                m_ServiceUri = new Uri(m_EwsUri);
            }
            CreateService();
        }

        private static string GetExportItemRequestXml(string serverVersion, string itemId)
        {
            return string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
      xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
      xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
      xmlns:t=""http://schemas.microsoft.com/exchange/services/2006/types""
      xmlns:m=""http://schemas.microsoft.com/exchange/services/2006/messages"">
  <soap:Header>
    <t:RequestServerVersion Version=""{0}"" />
  </soap:Header>
  <soap:Body>
    <m:ExportItems>
      <m:ItemIds>
        <t:ItemId Id=""{1}""/>
      </m:ItemIds>
    </m:ExportItems>
  </soap:Body>
</soap:Envelope>", serverVersion, itemId);

        }

        private static string GetUploadItemRequestXml(string serverVersion, string folderId, string data)
        {
            return string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance""
               xmlns:xsd = ""http://www.w3.org/2001/XMLSchema""
               xmlns:soap = ""http://schemas.xmlsoap.org/soap/envelope/""
               xmlns:t = ""http://schemas.microsoft.com/exchange/services/2006/types""
               xmlns:m = ""http://schemas.microsoft.com/exchange/services/2006/messages"">
  <soap:Header>
    <t:RequestServerVersion Version = ""{0}""/>
  </soap:Header>
  <soap:Body>
    <m:UploadItems>
      <m:Items>
        <t:Item CreateAction=""CreateNew"">
          <t:ParentFolderId Id =""{1}""/>
          <t:Data>
            {2}
          </t:Data>
        </t:Item>
      </m:Items>
    </m:UploadItems>
  </soap:Body>
</soap:Envelope>", serverVersion, folderId, data);

        }

        private static string GetUploadItemRequestXmlWithImpersonation(string serverVersion, string folderId, string data)
        {
            return string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance""
               xmlns:xsd = ""http://www.w3.org/2001/XMLSchema""
               xmlns:soap = ""http://schemas.xmlsoap.org/soap/envelope/""
               xmlns:t = ""http://schemas.microsoft.com/exchange/services/2006/types""
               xmlns:m = ""http://schemas.microsoft.com/exchange/services/2006/messages"">
  <soap:Header>
    <t:RequestServerVersion Version =""{0}""/>
    <t:ExchangeImpersonation>
      <t:ConnectingSID>
        <t:SmtpAddress >{1}</ t:SmtpAddress>
      </t:ConnectingSID>
    </t:ExchangeImpersonation>
  </soap:Header>
  <soap:Body>
    <m:UploadItems>
      <m:Items>
        <t:Item CreateAction =""CreateNew"">
          <t:ParentFolderId Id =""{2}""/>
          <t:Data>
            {3}
          </t:Data>
        </t:Item>
      </m:Items>
    </m:UploadItems>
  </soap:Body>
</soap:Envelope>", serverVersion, m_EmailAddress, folderId, data);

        }

        private static string GetExportItemRequestXmlWithImpersonation(string serverVersion, string itemId)
        {
            return string.Format(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
      xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
      xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
      xmlns:t=""http://schemas.microsoft.com/exchange/services/2006/types""
      xmlns:m=""http://schemas.microsoft.com/exchange/services/2006/messages"">
  <soap:Header>
    <t:RequestServerVersion Version=""{0}""/>
    <t:ExchangeImpersonation>
      <t:ConnectingSID>
        <t:SmtpAddress >{1}</t:SmtpAddress>
      </t:ConnectingSID>
    </t:ExchangeImpersonation>
  </soap:Header>
  <soap:Body>
    <m:ExportItems>
      <m:ItemIds>
        <t:ItemId Id=""{2}""/>
      </m:ItemIds>
    </m:ExportItems>
  </soap:Body>
</soap:Envelope>", serverVersion, m_EmailAddress, itemId);
        }

        static bool IsValidEmail()
        {
            if (string.Empty == m_EmailAddress)
                return false;
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(m_EmailAddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        private static string MakeHttpGetRequest(string url)
        {
            string httpResponse = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    httpResponse = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return httpResponse;
        }

        private static string PostSoapRequest(string url, string soapRequest)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
                if (m_UseDefaultCredentials)
                {
                    webRequest.UseDefaultCredentials = true;
                }
                else
                {
                    webRequest.Credentials = new NetworkCredential(m_Username, m_Password);
                }
                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(soapRequest);

                using (Stream stream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        return rd.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "";
        }

        private static string PostSoapRequest(string url, string soapRequest, bool useAnchorMailbox)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                if (useAnchorMailbox)
                    webRequest.Headers.Add("X-AnchorMailbox", m_EmailAddress);
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";

                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(soapRequest);

                using (Stream stream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        return rd.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "";
        }

        private static void AutodiscoverV2()
        {
            if (!IsValidEmail())
            {
                o365UserStatus = O365UserStatus.InvalidEmail;
                return;
            }

            string autodiscoverResponse = MakeHttpGetRequest(string.Format("https://outlook.office365.com/autodiscover/autodiscover.json/v1.0/{0}?protocol=REST", m_EmailAddress));

            if (autodiscoverResponse.Contains("Protocol") && autodiscoverResponse.Contains("Url"))
            {
                o365UserStatus = O365UserStatus.IsO365User;
                m_ServiceUri = new System.Uri("https://outlook.office365.com/ews/exchange.asmx");
            }
            else
            {
                o365UserStatus = O365UserStatus.IsNotO365User;
            }
        }

        private static bool IsO365User()
        {
            AutodiscoverV2();
            if (O365UserStatus.IsO365User == o365UserStatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static ExchangeService CreateService()
        {
            try
            {
                if (m_ExchangeService != null)
                {
                    return m_ExchangeService;
                }


                // Creating a new ExchangeService instance
                m_ExchangeService = new ExchangeService(m_ExchangeVersion);

                m_ExchangeService.TraceListener = new TraceListener();
                // Optional flags to indicate the requests and responses to trace.
                m_ExchangeService.TraceFlags = TraceFlags.All;
                m_ExchangeService.TraceEnabled = m_TracingEnabled;

                m_ExchangeService.UseDefaultCredentials = m_UseDefaultCredentials;
                m_ExchangeService.Url = m_ServiceUri;
                if (m_UseAutodiscover)
                {
                    try
                    {
                        Status = "Performing autodiscover lookup...";
                        m_ExchangeService.AutodiscoverUrl(m_EmailAddress, delegate { return true; });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Autodiscover wasn't able to locate your settings, please check your DNS settings or fill in the Ews Url in the settings menu./nException:/n" + ex.ToString());
                        Status = "Autodiscover error encountered.";
                        return null;
                    }
                }
                m_ExchangeService.Credentials = new WebCredentials(m_Username, m_Password);
                m_ExchangeService.UseDefaultCredentials = m_UseDefaultCredentials;
                if (m_UseImpersonation)
                    m_ExchangeService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, m_EmailAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return m_ExchangeService;
        }

        public static void ExportItem(string itemId, string Path)
        {
            try
            {
                XDocument xDocument = new XDocument();
                XmlReader reader;
                if (m_UseImpersonation)
                {
                    reader = XmlReader.Create(new StringReader(PostSoapRequest(m_EwsUri.ToString(), GetExportItemRequestXmlWithImpersonation(m_ExchangeVersion.ToString(), itemId))));
                }
                else
                {
                    reader = XmlReader.Create(new StringReader(PostSoapRequest(m_EwsUri.ToString(), GetExportItemRequestXml(m_ExchangeVersion.ToString(), itemId))));
                }
                XElement xElement = XElement.Load(reader);
                var nodes = from p in xElement.Descendants()
                            where p.Name.LocalName == "Data"
                            select p;

                if (nodes.Count() == 1)
                {

                    // Saves the Image via a FileStream created by the OpenFile method.  
                    System.IO.FileStream fs = new FileStream(Path, FileMode.Create);
                    fs.Write(Encoding.ASCII.GetBytes(nodes.FirstOrDefault().Value), 0, Encoding.ASCII.GetByteCount(nodes.FirstOrDefault().Value));

                    fs.Close();
                }
                else
                {
                    MessageBox.Show("No export data found in server response");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void UploadItem(string folderId, string Path)
        {
            try
            {
                var fileContent = string.Empty;
                using (StreamReader streamReader = new StreamReader(Path))
                {
                    fileContent = streamReader.ReadToEnd();
                }

                XDocument xDocument = new XDocument();
                XmlReader reader;
                if (m_UseImpersonation)
                {
                    reader = XmlReader.Create(new StringReader(PostSoapRequest(m_EwsUri.ToString(), GetUploadItemRequestXmlWithImpersonation(m_ExchangeVersion.ToString(), folderId, fileContent))));
                }
                else
                {
                    reader = XmlReader.Create(new StringReader(PostSoapRequest(m_EwsUri.ToString(), GetUploadItemRequestXml(m_ExchangeVersion.ToString(), folderId, fileContent))));
                }
                XElement xElement = XElement.Load(reader);
                var nodes = from p in xElement.Descendants()
                            where p.Name.LocalName == "ResponseCode"
                            select p;

                if (nodes.Count() == 1)
                {

                    MessageBox.Show(string.Format("Import operation returned response code: \"{0}\".", nodes.FirstOrDefault().Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static  bool RemoteCertificateValidationCallback(object sender,
System.Security.Cryptography.X509Certificates.X509Certificate certificate,
System.Security.Cryptography.X509Certificates.X509Chain chain,
System.Net.Security.SslPolicyErrors sslPolicyErrors)
        { return true; }

        public static TreeNode GetFoldersTree()
        {
            TreeNode rootNode = new TreeNode();
            try
            {
                if (null == CreateService())
                {
                    MessageBox.Show("Unable to create Exchange Service Object");

                }


                if (m_UseImpersonation)
                    rootNode.Text = "Root - " + m_EmailAddress;
                else if (m_UseDefaultCredentials)
                {
                    rootNode.Text = "Root";
                }
                else
                {
                    rootNode.Text = "Root - " + m_Username;
                }
                rootNode.Tag = null;


                // Set the page size.
                int pageSize = 100;
                // Set the offset for the paged search.
                int offset = 0;





                // Set the flag that indicates whether to continue iterating through additional pages.
                bool MoreItems = true;

                // Continue paging while there are more items to page.
                while (MoreItems)
                {
                    // Create a view.
                    FolderView view = new FolderView(pageSize, offset, OffsetBasePoint.Beginning);

                    // Identify the properties to return in the results set.
                    view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                    view.PropertySet.Add(FolderSchema.DisplayName);
                    view.PropertySet.Add(FolderSchema.ParentFolderId);

                    // Return only folders that contain items.
                    SearchFilter searchFilter = new SearchFilter.IsGreaterThan(FolderSchema.TotalCount, 0);

                    // Unlike FindItem searches, folder searches can be deep traversals.
                    view.Traversal = FolderTraversal.Deep;
                    FindFoldersResults findFolderResults;
                    if (m_UseImpersonation)
                    {
                        // Send the request to search the mailbox and get the results.
                        findFolderResults = m_ExchangeService.FindFolders(new FolderId(WellKnownFolderName.MsgFolderRoot, new Mailbox(m_EmailAddress)), searchFilter, view);
                    }
                    else
                    {
                        findFolderResults = m_ExchangeService.FindFolders(WellKnownFolderName.MsgFolderRoot, searchFilter, view);
                    }

                    // Process each item.
                    foreach (Folder myFolder in findFolderResults.Folders)
                    {
                        TreeNode parentNode = FromID(myFolder.ParentFolderId.UniqueId, rootNode);
                        TreeNode childNode = parentNode.Nodes.Add(myFolder.DisplayName);
                        childNode.Tag = myFolder.Id.UniqueId;
                    }

                    // Determine whether there are more folders to return.
                    if (findFolderResults.MoreAvailable)
                    {
                        // Make recursive calls with offsets set for the FolderView to get the remaining folders in the result set.

                    }
                    // Set the flag to discontinue paging.
                    if (!findFolderResults.MoreAvailable)
                        MoreItems = false;

                    // Update the offset if there are more items to page.
                    if (MoreItems)
                        offset = findFolderResults.NextPageOffset.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return rootNode;
        }

        public static TreeNode FromID(string itemId, TreeNode rootNode)
        {
            TreeNode foundNode = null;
            try
            {
                foundNode = rootNode.Nodes.OfType<TreeNode>()
                                .FirstOrDefault(node => node.Tag.Equals(itemId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (null != foundNode)
                return foundNode;
            else
                return rootNode;
        }

        public static void GetItemsList(string uniqueId, ListView listView)
        {
            try
            {
                if (null == CreateService())
                {
                    MessageBox.Show("Unable to create Exchange Service Object");
                }

                // Set the page size.
                int pageSize = 100;
                // Set the offset for the paged search.
                int offset = 0;

                // Set the flag that indicates whether to continue iterating through additional pages.
                bool MoreItems = true;

                listView.View = View.Details;
                listView.Columns.Clear();
                listView.Columns.Add("DateTimeReceived").Width = 100;
                listView.Columns.Add("Subject").Width = 450;

                // Continue paging while there are more items to page.
                while (MoreItems)
                {
                    // Create a view.
                    ItemView view = new ItemView(pageSize, offset, OffsetBasePoint.Beginning);

                    // Identify the properties to return in the results set.
                    view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                    view.PropertySet.Add(ItemSchema.DateTimeReceived);
                    view.PropertySet.Add(ItemSchema.Subject);

                    // Unlike FindItem searches, folder searches can be deep traversals.
                    view.Traversal = ItemTraversal.Shallow;

                    // Send the request to search the mailbox and get the results.
                    FindItemsResults<Item> findItemResults = m_ExchangeService.FindItems(new FolderId(uniqueId), view);

                    // Process each item.
                    foreach (Item myItem in findItemResults.Items)
                    {
                        ListViewItem listViewItem = listView.Items.Add(new ListViewItem(new string[] { myItem.DateTimeReceived.ToString("yyyy/MM/dd HH:mm:ss"), myItem.Subject }));
                        listViewItem.Tag = myItem.Id.UniqueId;
                    }

                    // Determine whether there are more folders to return.
                    if (findItemResults.MoreAvailable)
                    {
                        // Make recursive calls with offsets set for the FolderView to get the remaining folders in the result set.

                    }
                    // Set the flag to discontinue paging.
                    if (!findItemResults.MoreAvailable)
                        MoreItems = false;

                    // Update the offset if there are more items to page.
                    if (MoreItems)
                        offset = findItemResults.NextPageOffset.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    class TraceListener : ITraceListener
    {
        #region ITraceListener Members

        public void Trace(string traceType, string traceMessage)
        {
            CreateXMLTextFile(traceType, traceMessage.ToString());
        }

        #endregion

        private void CreateXMLTextFile(string fileName, string traceContent)
        {
            // Create a new XML file for the trace information.
            try
            {
                // If the trace data is valid XML, create an XmlDocument object and save.
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(traceContent);
                xmlDoc.Save(fileName + ".xml");
            }
            catch
            {
                // If the trace data is not valid XML, save it as a text document.
                System.IO.File.WriteAllText(fileName + ".txt", traceContent);
            }
        }
    }
}
