using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTimePassApi.Models
{
    public class CheckOtp
    {
        public string UserLogin { get; set; }

        public int Code { get; set; }
    }
}