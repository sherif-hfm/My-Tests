using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FileConvertServiceWinHost
{
    public partial class frmMain : Form
    {
        private ServiceHost host = null;

        public WSHttpBinding WsHttpBinding
        {
            get
            {
                var wsHttpBinding = new WSHttpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    OpenTimeout = new TimeSpan(0, 5, 0),
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
                    SendTimeout = new TimeSpan(0, 5, 0),
                    BypassProxyOnLocal = false,
                    MessageEncoding = WSMessageEncoding.Text,
                    TextEncoding = Encoding.UTF8,
                    UseDefaultWebProxy = true,
                    HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                    ReaderQuotas = new XmlDictionaryReaderQuotas(),
                    Security = new WSHttpSecurity() { Mode = SecurityMode.None }
                };
                wsHttpBinding.ReaderQuotas.MaxArrayLength = wsHttpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                wsHttpBinding.ReaderQuotas.MaxStringContentLength =
                    wsHttpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                wsHttpBinding.ReaderQuotas.MaxDepth = 2147483647;
                wsHttpBinding.ReliableSession = new OptionalReliableSession() { Enabled = true, Ordered = true };
                return wsHttpBinding;
            }
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (host == null)
            {
                string serviceUri = System.Configuration.ConfigurationManager.AppSettings["SrvUri"];
                StartHost();
                txtLog.Text += txtLog.Text + "Service Started Uri "+ serviceUri + Environment.NewLine;
            }
                
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (host != null)
            {
                host.Close();
                host = null;
                txtLog.Text += txtLog.Text + "Service Stoped" + Environment.NewLine;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (host != null)
            {
                host.Close();
                host = null;
            }
            this.Close();
        }

        private void StartHost()
        {
            try
            {
                // netsh http add urlacl url=http://+:8090/ user=\Everyone
                //Base Address for StudentService
                string serviceUri = System.Configuration.ConfigurationManager.AppSettings["SrvUri"];
                Uri httpBaseAddress = new Uri(serviceUri);

                //Instantiate ServiceHost
                host = new ServiceHost(typeof(FileConvertService.FileConvertSrv), httpBaseAddress);

                //Add Endpoint to Host
                host.AddServiceEndpoint(typeof(FileConvertService.IFileConvertSrv), this.WsHttpBinding, "");

                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(serviceBehavior);

                //Open
                host.Open();
            }
            catch (Exception ex)
            {
                txtLog.Text += txtLog.Text + "Service Error " + ex.Message + Environment.NewLine;
                host = null;
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
