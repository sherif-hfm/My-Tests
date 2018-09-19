using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSrv.Controllers
{
    [RoutePrefix("api/Services")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        [Route("GetUserData")]
        [HttpPost]
        public void GetUserData(string userName)
        {
            var context= System.Web.HttpContext.Current;
            var readre = context.Request.InputStream;
            byte[] data = new byte[readre.Length];
            readre.Read(data, 0, (int)readre.Length);
            var dataStr = System.Text.UTF8Encoding.UTF8.GetString(data);
            //userData.UserImage = @"http://localhost:65460/Image.ashx";
            //userData.UserName = userData.UserName + " OK";
            ////userData.UserAddress = new List<Address>();
            //return userData;
        }
    }

    
    public class UserData
    {
    
        public string UserName { get; set; }

    
        public decimal UserAge { get; set; }

    
        public string UserImage { get; set; }

    
        public List<Address> UserAddress { get; set; }
    }

    
    public class Address
    {
        public string Town { get; set; }

        public string Street { get; set; }

        public string PoBox { get; set; }
    }
}
