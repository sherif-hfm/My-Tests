using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Configuration;
using System.Xml;

namespace WcfCallTest
{
    public class WcfServices
    {
        public static T GetWsService<T>()
        {
            var typeName = typeof(T).FullName;
            var binding = GlobalSettings.WsHttpBinding;
            var factory = new ChannelFactory<T>(binding);
            var serviceUrl = GlobalSettings.GetSetting(typeName);
            factory.Endpoint.Address = new EndpointAddress(serviceUrl);
            return factory.CreateChannel();
        }

        public static T GetWebHttpService<T>(string baseAddressFilter)
        {
            var typeName = typeof(T).FullName;
            var binding = GlobalSettings.HttpBinding;
            var factory = new ChannelFactory<T>(binding);
            var serviceUrl = GlobalSettings.GetSetting(typeName) + "/" + baseAddressFilter;
            factory.Endpoint.Address = new EndpointAddress(serviceUrl);
            factory.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            return factory.CreateChannel();
        }
    }

    public class GlobalSettings
    {
        public static WebHttpBinding HttpBinding
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

        public static string GetSetting(string settingKey)
        {
            return ConfigurationManager.AppSettings.AllKeys
                .Where(key => key.Equals(settingKey))
                .Select(key => ConfigurationManager.AppSettings[key]).First();
            ;
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