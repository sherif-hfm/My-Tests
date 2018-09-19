using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileConvertServiceHost
{
    public partial class FileConvertServiceHost : ServiceBase
    {
        private ServiceHost host = null;
        public  WSHttpBinding WsHttpBinding
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

        public FileConvertServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartHost();
        }

        protected override void OnStop()
        {
            if(host != null)
            {
                host.Close();
                host = null;
            }
        }

        private void StartHost()
        {
            try
            {
                // netsh http add urlacl url=http://+:8090/ user=\Everyone
                //Base Address for StudentService
                string serviceUri= System.Configuration.ConfigurationManager.AppSettings["SrvUri"];
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
                host = null;
            }
        }
    }
}
