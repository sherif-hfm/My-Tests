using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalROnIIS
{
    public class MyHub : Hub
    {
        public void dosomething(dynamic message)
        {
            message.DateTime = DateTime.Now;
            //Clients.Client((string)message.ClientId).DoSomeThingClient(message);
            Clients.All.DoSomeThingClient(message);
        }
        
    }
}