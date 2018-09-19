using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiSimple.Controllers
{
    [RoutePrefix("api")]
    public class LoginApiController : ApiController
    {
        [Route("Login")]
        [HttpPost]
        public LoginResult Login(LoginInfo loginInfo)
        {
            return new LoginResult() { Status = true, Message = "Login for User : " + loginInfo.UserName };
        }
    }

    public class LoginInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
