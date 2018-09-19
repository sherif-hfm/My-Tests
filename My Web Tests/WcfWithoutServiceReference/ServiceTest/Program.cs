using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfService;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Xml;
using System.Runtime;
using System.ServiceModel.Description;
namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CallWcf();
        }

        private static void CallWcf()
        {
            var client = GetWebHttpService<IService1>("web2");
            var result = client.GetData2(1);
        }

        private static WSHttpBinding WsHttpBinding
        {
            get
            {
                var wsHttpBinding = new WSHttpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    OpenTimeout = new TimeSpan(0, 1, 0),
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
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
        private static WebHttpBinding HttpBinding
        {
            get
            {
                return new WebHttpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    Security = { Mode = WebHttpSecurityMode.None }
                };
            }
        }

        public static T GetWsService<T>()
        {
            string typeName = typeof(T).FullName;
            WSHttpBinding binding = WsHttpBinding;
            ChannelFactory<T> factory = new ChannelFactory<T>(binding);
            var serviceURL = GetSetting(typeName);
            factory.Endpoint.Address = new EndpointAddress(serviceURL);
            return (T)factory.CreateChannel();
        }

        public static T GetWebHttpService<T>(string _baseAddressFilter)
        {
            string typeName = typeof(T).FullName;
            WebHttpBinding binding = HttpBinding;
            ChannelFactory<T> factory = new ChannelFactory<T>(binding);
            var serviceURL = GetSetting(typeName) + "/" + _baseAddressFilter;
            factory.Endpoint.Address = new EndpointAddress(serviceURL);
            factory.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            return (T)factory.CreateChannel();
        }

        public static string GetSetting(string settingKey)
        {
            return ConfigurationManager.AppSettings.AllKeys
                .Where(key => key.Equals(settingKey))
                .Select(key => ConfigurationManager.AppSettings[key]).First();
            ;
        }
    }
}
