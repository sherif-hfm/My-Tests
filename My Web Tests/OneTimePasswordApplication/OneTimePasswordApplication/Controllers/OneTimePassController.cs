using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OneTimePasswordApplication.Controllers
{
    public class OneTimePassController : ApiController
    {
        [Route("OneTimePass/CheckPass/{_pass}")]
        [HttpGet]
        public bool CheckPass(string _pass)
        {
            OneTimePassword otp = new OneTimePassword("JBSWY3DPEHPK3PXP");
            int code = int.Parse(_pass);
            return otp.IsCodeValid(code);
        }

        [Route("OneTimePass/GetOTP")]
        [HttpGet]
        public string GetOTP()
        {
            OneTimePassword otp = new OneTimePassword("JBSWY3DPEHPK3PXP");
            var result = otp.GetCode().ToString("000000");
            return result;
        }

        [Route("OneTimePass/GetQrURL")]
        [HttpGet]
        public string GetQrURL()
        {
            var result = "otpauth://totp/user@host.com?secret=JBSWY3DPEHPK3PXP";
            return result;
        }
    }
}