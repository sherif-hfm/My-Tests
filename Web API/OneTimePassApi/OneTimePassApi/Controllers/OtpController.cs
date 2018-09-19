using OneTimePassApi.Models;
using Riyadh.EServices.Model.Common;
using Riyadh.EServices.WebHttp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OneTimePassApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OtpController : ApiController
    {
        
        [Route("Otp/Test/{_data}")]
        [HttpGet]
        public ServiceResultInfo<string> Test(string _data)
        {
            Random rnd = new Random();
            var result = string.Join("", (from n in Enumerable.Range(0, 10) select new { Num = n, Index = rnd.Next() }).OrderBy(n => n.Index).Select(n => n.Num).Take(6));

            return new ServiceResultInfo<string>() { Status = true, ResultSet = _data + result };
        }

        [Authorize]
        [Route("Otp/UserLogin")]
        [HttpPost]
        public ServiceResultInfo<dynamic> UserLogin(UserLoginInfo _userLoginInfo)
        {
            string errMsg = "";

            ApplicationInfo _appInfo;

            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };

            // Application Id
            if (string.IsNullOrEmpty(_userLoginInfo.AppId) == false)
            {
                _appInfo = (ApplicationInfo)cache[_userLoginInfo.AppId];
                if (_appInfo == null)
                {
                    _appInfo = new ApplicationInfo();
                    _appInfo.AppId = _userLoginInfo.AppId;
                }
            }
            else
            {
                _appInfo = new ApplicationInfo();
                _appInfo.AppId = Guid.NewGuid().ToString();
            }

            if (_appInfo.LoginTry > 2)
                return new ServiceResultInfo<dynamic>() { Status = false, Message = "لقد تجاوزت عدد المحاولات يجب ", ResultSet = new { AppId = _appInfo.AppId } };

            var srv = RmServices.GetWsService<Riyadh.EServices.IServices.IUser>();
            var loginResult = srv.GetUser(Helper.ToEnglishNumbers(_userLoginInfo.UserLogin), Helper.ToEnglishNumbers(_userLoginInfo.Password), ref errMsg);
            if (loginResult != null)
            {
                UserInfo _userInfo;
                _userInfo = (UserInfo)cache[_userLoginInfo.UserLogin];
                if (_userInfo == null)
                {
                    _userInfo = new UserInfo();
                    _userInfo.UserId = Guid.NewGuid().ToString();
                }
                else
                {
                    if (_userInfo.UserLogin != _userLoginInfo.UserLogin)
                    {
                        _userInfo = new UserInfo();
                        _userInfo.UserId = Guid.NewGuid().ToString();
                    }
                }

                _userInfo.UserName = loginResult.FullName;
                _userInfo.UserTypeId = int.Parse(loginResult.UserType);
                _userInfo.UserLogin = _userLoginInfo.UserLogin;

                // Send SMS
                if (_userInfo.SmsSent == false)
                {
                    _userInfo.SmsCode = GenerateSmsCode();
                    //_userInfo.SmsCode = "1234";
                    var smsSrv = RmServices.GetWsService<Riyadh.EServices.IServices.ISMS>();
                    smsSrv.SendSMS("OTP", _userInfo.SmsCode, loginResult.ContactData.Mobile);
                    _userInfo.SmsSent = true;
                }

                //Save Cash Info
                cache.Set(_userInfo.UserLogin, _userInfo, policy);
                cache.Set(_userInfo.UserId, _userInfo, policy);
                cache.Set(_appInfo.AppId, _appInfo, policy);

                return new ServiceResultInfo<dynamic>() { Status = true, ResultSet = new { AppId = _appInfo.AppId, UserId = _userInfo.UserId, UserMobile = loginResult.ContactData.Mobile.Substring(7, 3) } };
            }
            else
            {
                _appInfo.LoginTry += 1;
                cache.Set(_appInfo.AppId, _appInfo, policy);
                return new ServiceResultInfo<dynamic>() { Status = false, Message = "تأكد من بيانات الدخول", ResultSet = new { AppId = _appInfo.AppId } };
            }
        }

        [Route("Otp/CheckCode")]
        [HttpPost]
        public bool CheckCode(CheckOtp data)
        {
            var srv = RmServices.GetWsService<Riyadh.EServices.IServices.IUser>();
            var result = srv.GetUserSecKey(data.UserLogin, 1);
            if (result.Status == true)
            {
                OneTimePassword otp = new OneTimePassword(result.ResultSet);
                return otp.IsCodeValid(data.Code);
            }
            else
                return false;
        }

        [Authorize]
        [Route("Otp/SaveUserTwoFactorAuthInfo")]
        [HttpPost]
        public ServiceResultInfo<dynamic> SaveUserTwoFactorAuthInfo(UserVerificationInfo _userVerificationInfo)
        {
            // Get User Info From Cash
            try
            {
                CacheItemPolicy policy = new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };
                ObjectCache cache = MemoryCache.Default;
                UserInfo _userInfo = (UserInfo)cache[_userVerificationInfo.UserId];

                if (_userInfo.SmsTry > 2)
                    return new ServiceResultInfo<dynamic>() { Status = false, Message = "لقد تجاوزت عدد المحاولات يجب ", ResultSet = new { UserId = _userInfo.UserId } };

                if (Helper.ToEnglishNumbers(_userVerificationInfo.SmsCode) == _userInfo.SmsCode)
                {
                    var srv = RmServices.GetWsService<Riyadh.EServices.IServices.IUser>();
                    var userKey = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString());
                    var userSecKey = OneTimePassword.ToBase32(userKey, userKey.Length, SecretFormatFlags.None);
                    var twoFactorAuthInfo = new TwoFactorAuthInfo()
                    {
                        UserLogin = Helper.ToEnglishNumbers(_userInfo.UserLogin),
                        UserTypeCode = _userInfo.UserTypeId,
                        SecretKey = userSecKey
                    };
                    var keyResult = srv.SaveUserTwoFactorAuthInfo(twoFactorAuthInfo);
                    if (keyResult.Status == true)
                        return new ServiceResultInfo<dynamic>() { Status = true, ResultSet = new { UserId = _userInfo.UserId, UserLogin = _userInfo.UserLogin, UserName = _userInfo.UserName, UserSecKey = userSecKey } };
                    else
                        return new ServiceResultInfo<dynamic>() { Status = false, Message = "حدث خطأ غير متوقع" };
                }
                {
                    _userInfo.SmsTry += 1;
                    cache.Set(_userInfo.UserId, _userInfo, policy);
                    return new ServiceResultInfo<dynamic>() { Status = false, Message = "رمز التحقق غير صحيح" };
                }
            }
            catch (Exception)
            {
                return new ServiceResultInfo<dynamic>() { Status = false, Message = "حدث خطأ غير متوقع" };
            }
        }

        private string GenerateSmsCode()
        {
            Random rnd = new Random();
            var result = string.Join("", (from n in Enumerable.Range(0, 10) select new { Num = n, Index = rnd.Next() }).OrderBy(n => n.Index).Select(n => n.Num).Take(6));
            return result;
        }
    }

   
}
