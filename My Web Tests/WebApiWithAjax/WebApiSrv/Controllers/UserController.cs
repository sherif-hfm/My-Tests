using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSrv.Controllers
{
    [RoutePrefix("api/User")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [Route("SaveUserData")]
        [HttpPost]
        //[ValidateModel]
        public string SaveUserData(UserInfo userInfo)
        {
            //if (ModelState.IsValid)
            //{
            return userInfo.UserName + " " + DateTime.Now.ToString();
            //}
            //else
            //    return "Error";
        }
    }

    public class UserInfo
    {
        [Required()]
        public int UserCode { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public AddressInfo Address { get; set; }
    }

    public class AddressInfo
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
