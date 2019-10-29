using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;
using System.Configuration;

namespace WcfClientMessageInspector
{
    public class GlobalSettings
    {
        public static WebHttpBinding HttpBinding => new WebHttpBinding
        {
            MaxReceivedMessageSize = 2147483647,
            MaxBufferPoolSize = 2147483647,
            Security = { Mode = WebHttpSecurityMode.None }
        };

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
                    Security = new WSHttpSecurity { Mode = SecurityMode.None },
                    AllowCookies = true

                };
                wsHttpBinding.ReaderQuotas.MaxArrayLength = wsHttpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                wsHttpBinding.ReaderQuotas.MaxStringContentLength =
                    wsHttpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                wsHttpBinding.ReaderQuotas.MaxDepth = 2147483647;
                wsHttpBinding.ReliableSession = new OptionalReliableSession { Enabled = true, Ordered = true, InactivityTimeout = new TimeSpan(1, 5, 0) };
                return wsHttpBinding;
            }
        }

        public static BasicHttpBinding BasicHttpBinding
        {
            get
            {
                var basicHttpBinding = new BasicHttpBinding
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
                    Security = new BasicHttpSecurity { Mode = BasicHttpSecurityMode.None }
                };
                basicHttpBinding.ReaderQuotas.MaxArrayLength =
                    basicHttpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                basicHttpBinding.ReaderQuotas.MaxStringContentLength =
                    basicHttpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                basicHttpBinding.ReaderQuotas.MaxDepth = 2147483647;
                return basicHttpBinding;
            }
        }

        public static NetTcpBinding TcpBinding
        {
            get
            {
                var tcpBinding = new NetTcpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    OpenTimeout = new TimeSpan(0, 5, 0),
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
                    SendTimeout = new TimeSpan(0, 5, 0),
                    HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                    ReaderQuotas = new XmlDictionaryReaderQuotas()
                };
                tcpBinding.ReaderQuotas.MaxArrayLength = tcpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                tcpBinding.ReaderQuotas.MaxStringContentLength =
                    tcpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                tcpBinding.ReaderQuotas.MaxDepth = 2147483647;

                return tcpBinding;
            }
        }

        public static string GetSetting(string settingKey)
        {
            return ConfigurationManager.AppSettings.AllKeys
                .Where(key => key.Equals(settingKey))
                .Select(key => ConfigurationManager.AppSettings[key]).First();

        }

        #region Private Methods

        public static T HttpService<T>(string serviceKey)
        {
            var naviEndpoint = new EndpointAddress(new Uri(GetSetting(serviceKey)));
            var cf = new ChannelFactory<T>(HttpBinding, naviEndpoint);
            cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
            var client = cf.CreateChannel();

            return client;
        }

        public static T WsService<T>(string serviceKey)
        {
            var naviEndpoint = new EndpointAddress(new Uri(GetSetting(serviceKey)));
            var cf = new ChannelFactory<T>(WsHttpBinding, naviEndpoint);
            var client = cf.CreateChannel();

            return client;
        }

        #endregion
    }
}
