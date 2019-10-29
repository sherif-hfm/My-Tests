using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WcfClientMessageInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            var typeName = typeof(WcfServerMessageInspector.IService1).FullName;
            var binding = GlobalSettings.WsHttpBinding;
            var factory = new ChannelFactory<WcfServerMessageInspector.IService1>(binding);
            var serviceUrl = "http://localhost:9637/Service1.svc";
            factory.Endpoint.Address = new EndpointAddress(serviceUrl);
            SimpleEndpointBehavior simpleEndpointBehavior = new SimpleEndpointBehavior();
            factory.Endpoint.EndpointBehaviors.Add(simpleEndpointBehavior);
            var srv = factory.CreateChannel();
            var result = srv.GetData(1);
        }
    }

    public class SimpleMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Implement this method to inspect/modify messages after a message  
            // is received but prior to passing it back to the client   
            Console.WriteLine("AfterReceiveReply called");
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            // Implement this method to inspect/modify messages before they   
            // are sent to the service 


            MessageHeader hdear = MessageHeader.CreateHeader("UserInfo", "http://RmServices.Headers", "9004050");
            request.Headers.Add(hdear);

            Console.WriteLine("BeforeSendRequest called");
            return null;
        }
    }

    public class SimpleEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // No implementation necessary  
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new SimpleMessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // No implementation necessary  
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            // No implementation necessary  
        }
    }

    public class SimpleBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(SimpleEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            // Create the  endpoint behavior that will insert the message  
            // inspector into the client runtime  
            return new SimpleEndpointBehavior();
        }
    }
   
}
