using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Threading;

namespace SignalR2Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //netsh http add urlacl url = http://127.0.0.1:3040/ user=\Everyone
            //netsh http delete urlacl url = http://127.0.0.1:3040/
            //netsh http show urlacl
            string url = "http://*:3040";
            //string url = "http://127.0.0.1:3040";
            //var options = new StartOptions(url)
            //{
            //    ServerFactory = "Microsoft.Owin.Host.HttpListener",
            //};

            using (var srv=WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            GlobalHost.Configuration.ConnectionTimeout = new TimeSpan(0, 0, 110);
            GlobalHost.Configuration.DisconnectTimeout = new TimeSpan(0, 0, 20);
            GlobalHost.Configuration.KeepAlive = new TimeSpan(0, 0, 5);
            app.UseCors(CorsOptions.AllowAll);
            //app.Map("/signalr", map =>
            //{
            //    // Setup the CORS middleware to run before SignalR.
            //    // By default this will allow all origins. You can 
            //    // configure the set of origins and/or http verbs by
            //    // providing a cors options with a different policy.
            //    map.UseCors(CorsOptions.AllowAll);
            //    var hubConfiguration = new HubConfiguration
            //    {
            //        // You can enable JSONP by uncommenting line below.
            //        // JSONP requests are insecure but some older browsers (and some
            //        // versions of IE) require JSONP to work cross domain
            //        // EnableJSONP = true;
            //    };
            //    // Run the SignalR pipeline. We're not using MapSignalR
            //    // since this branch already runs under the "/signalr"
            //    // path.
            //    map.RunSignalR(hubConfiguration);
            //});
            app.MapSignalR();
        }
    }

    public class MyHub : Hub
    {

        public override Task OnConnected()
        {
            Console.WriteLine("OnConnected Id:{0}" , Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public void Send( dynamic message)
        {
            Console.WriteLine("Message :{0} Client Id:{1}", message.Text, message.ClientId);
            //Clients.All.addMessage(message);
            //Clients.Client(message.ClientId).addMessage(message.Text);
            OpenApp openApp = new OpenApp(message);
            openApp.AppClosed += OpenApp_AppClosed;
            openApp.OpenTheApp();
            //var clients = Clients;
        }

        private void OpenApp_AppClosed(object sender, dynamic messagee)
        {
            Clients.Client((string)messagee.ClientId).addMessage(messagee);
        }
    }

    public class OpenApp
    {
        public dynamic Message { get; set; }
        
        public OpenApp(dynamic _message)
        {
            this.Message = _message;
        }

        public void OpenTheApp()
        {
            Task.Run(() =>
            {
                Thread.Sleep(new TimeSpan(0, 0, 10));
                this.DoAppClosed();
            });
        }

        public delegate void AppCloseDelegate(object sender, dynamic messagee);
        public event AppCloseDelegate AppClosed;

        private void DoAppClosed()
        {
            this.AppClosed(this, this.Message);
        }
    }
}
