using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;

namespace ReportViewer
{
    public class ReportViewerCredentials : IReportServerCredentials
    {
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = "user nsme";
            password = "passwoed";
            authority = "";

            return false;
        }

        public WindowsIdentity ImpersonationUser
        {
            get
            {
                WindowsIdentity result = WindowsIdentity.GetCurrent();
                return null;
            }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                ICredentials result = new NetworkCredential("user", "password", "domain");
                return result;
            }
        }
    }
}