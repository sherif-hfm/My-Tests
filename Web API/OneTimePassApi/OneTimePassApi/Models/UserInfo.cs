using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneTimePassApi.Models
{
    public class UserInfo
    {
        public string UserId { get; set; }

        public string UserLogin { get; set; }

        public int UserTypeId { get; set; }

        public string UserName { get; set; }

        public string SmsCode { get; set; }

        public int SmsTry { get; set; }

        public bool SmsSent { get; set; }

    }

    public class ApplicationInfo
    {
        public string AppId { get; set; }

        public int LoginTry { get; set; }
    }

    public class UserLoginInfo
    {
        public string AppId { get; set; }

        public string UserId { get; set; }

        public string UserLogin { get; set; }
       
        public string Password { get; set; }
    }

    public class UserVerificationInfo
    {
        public string UserId { get; set; }

        public string SmsCode { get; set; }

    }
}