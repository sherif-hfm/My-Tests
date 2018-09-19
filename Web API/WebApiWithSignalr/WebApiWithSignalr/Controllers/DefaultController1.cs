using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiWithSignalr.Controllers
{
    [RoutePrefix("api")]
    public class DefaultController : ApiController
    {
        ObjectCache cache = MemoryCache.Default;

        [Route("NeedApprove/{clientCode}")]
        [HttpGet]
        public async Task<IHttpActionResult> NeedApprove(string clientCode)
        {
            int index = 0;
            int waitTimer = 0;
            var obj = cache["Seq"];
            if (obj != null)
                index = int.Parse((string)obj);
            var hub = GlobalHost.ConnectionManager.GetHubContext<MyHub1>();
            var clients = MyHub1.ClientList.Find(e => e.ClientCode == clientCode);
            if (clients != null)
            {
                clients.ApprovedStatus = 0;
                hub.Clients.Client(clients.ClientId).needApprove("need approve for client " + clientCode);
                while (clients.ApprovedStatus == 0 && waitTimer < 10)
                {
                    await Task.Delay(1000);
                    waitTimer++;
                }
                if (clients.ApprovedStatus == 1)
                    return Content(System.Net.HttpStatusCode.OK, "True " + index.ToString());
                else
                    return Content(System.Net.HttpStatusCode.OK, "False " + index.ToString());
            }
            index++;
            cache.Set("Seq", index.ToString(), DateTimeOffset.UtcNow.AddMinutes(5));
            return Content(System.Net.HttpStatusCode.OK, "False " + index.ToString());
        }
    }
}
