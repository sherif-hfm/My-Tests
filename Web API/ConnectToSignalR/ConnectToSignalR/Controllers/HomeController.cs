using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR.Client;

namespace ConnectToSignalR.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("Send")]
        [HttpGet]
        public Task<IHttpActionResult> SendMessage()
        {
            var connection = new HubConnection("http://localhost:8070/SignalR/signalr/hubs/");
            //Make proxy to hub based on hub name on server
            var myHub = connection.CreateHubProxy("myHub");
            //Start connection

            connection.Start().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();
            myHub.Invoke<string>("dosomething", new { ClientId= connection.ConnectionId, Text="WebApi" }).ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine(task.Result);
                }
            });
            connection.Stop();
            return Task.FromResult<IHttpActionResult>(Ok());
        }
    }
}
