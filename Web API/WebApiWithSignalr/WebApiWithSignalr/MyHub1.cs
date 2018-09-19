using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Runtime.Caching;

namespace WebApiWithSignalr
{
    public class MyHub1 : Hub
    {
        public static List<ClientInfo> ClientList = new List<ClientInfo>();

        public void Hello(string _val)
        {
            Clients.All.hello(_val);
        }

        public void Subscribe(dynamic message)
        {
            string clientId = message.ClientId.ToString();
            var clientExt = ClientList.Find(c => c.ClientCode == message.ClientCode.ToString());
            if (clientExt != null)
                clientExt.ClientId = message.ClientId;
            else
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.ClientId = message.ClientId;
                clientInfo.ClientCode = message.ClientCode;
                ClientList.Add(clientInfo);
                
            }
            
            this.Clients.Client(clientId).subscribeDone("");
            //this.Clients.All.subscribeDone("");
        }

        public void Approve(dynamic clientCode)
        {
            var clients = MyHub1.ClientList.Find(e => e.ClientCode == clientCode);
            if (clients != null)
            {
                clients.ApprovedStatus = 1;
            }
        }

        public void NotApprove(dynamic clientCode)
        {
            var clients = MyHub1.ClientList.Find(e => e.ClientCode == clientCode);
            if (clients != null)
            {
                clients.ApprovedStatus = 2;
            }
        }
    }

    public class  ClientInfo
    {
        public string ClientId { get; set; }

        public string ClientCode { get; set; }

        public int ApprovedStatus { get; set; }
    }
}