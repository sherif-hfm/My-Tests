using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Threading;

namespace SignalROnIIS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            GlobalHost.Configuration.ConnectionTimeout = new TimeSpan(0, 0, 110);
            GlobalHost.Configuration.DisconnectTimeout = new TimeSpan(0, 0, 20);
            GlobalHost.Configuration.KeepAlive = new TimeSpan(0, 0, 5);
            app.UseCors(CorsOptions.AllowAll);
            
            app.MapSignalR();
        }
    }
}