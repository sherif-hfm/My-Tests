using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RouteTest
{
    class Program
    {
        public static WSHttpBinding WsHttpBinding
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

        static void Main(string[] args)
        {
            Test2();
        }

        private static void Test2()
        {
            TlsWcf.TLSWebClient srv = new TlsWcf.TLSWebClient();
            var result = srv.GetBoardsTypes();
        }

        private static void Test1()
        {
            var binding = WsHttpBinding;
            var factory = new ChannelFactory<Riyadh.EServices.IServices.ITLSWeb>(binding);
            //var serviceUrl = "http://localhost:8020/TLS/TLSService.svc";
            var serviceUrl = "http://localhost:9030/RoutingService.svc/tls";
            factory.Endpoint.Address = new EndpointAddress(serviceUrl);
            var srv = factory.CreateChannel();
            var result = srv.GetBoardsTypes();
        }
    }
}
