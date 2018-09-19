using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServiceSrv
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        public UserName mUserName;
        public Password mPassword;


        public UserName Username
        {
            get
            {
                return this.mUserName;
            }
            set
            {
                this.mUserName = value;
            }
        }

        public Password Password
        {
            get
            {
                return this.mPassword;
            }
            set
            {
                this.mPassword = value;
            }
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeaderAttribute("Username")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("Password")]
        public string HelloWorld(string _data)
        {
            var u = Username;
            var p = Password;
            return "Hello World " + u.Text;
        }

        [System.Web.Services.Protocols.SoapHeaderAttribute("Username")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("Password")]
        [WebMethod]
        public void AddAmanahResponse(int CardStatus, [System.Xml.Serialization.XmlIgnoreAttribute()] bool CardStatusSpecified, int CerResultID, [System.Xml.Serialization.XmlIgnoreAttribute()] bool CerResultIDSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string CertificateCard_ID, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string CertificateExpire_Date, int ClientResponseStatus, [System.Xml.Serialization.XmlIgnoreAttribute()] bool ClientResponseStatusSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string Remarks, out short ResultCode, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool ResultCodeSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] out string ResultMessage)
        {
            ResultCode = 0;
            ResultCodeSpecified = true;
            ResultMessage = "";
        }
    }
    public class UserName : System.Web.Services.Protocols.SoapHeader
    {
        private string[] textField;

        public string[] Text
        {
            get
            {
                return textField;
            }
            set 
            {
                textField = value;
            }
        }
    }

    public class Password : System.Web.Services.Protocols.SoapHeader
    {
        private string textField;

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Text
        {
            get
            {
                return textField;
            }
            set
            {
                textField = value;
            }
        }
    }

}
