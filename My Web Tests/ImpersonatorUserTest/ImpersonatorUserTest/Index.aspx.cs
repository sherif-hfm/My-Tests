using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
namespace ImpersonatorUserTest
{
    public partial class Index : System.Web.UI.Page
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        protected void Page_Load(object sender, EventArgs e)
        {
            // this is for read file which has permission for specific user
            ReadFile1();
        }
        private void ReadFile1()
        {
            Impersonate();
            var Text = File.ReadAllText(@"D:\Dropbox\My Tests\My Web Tests\ImpersonatorUserTest\Text.txt");
            txt.InnerHtml = Text;
        }
        private void Impersonate()
        {
            string userName, domainName, password;
            userName = "Test";
            domainName = "SherifHamdy";
            password = "Test";
            SafeTokenHandle safeTokenHandle;
            const int LOGON32_PROVIDER_DEFAULT = 0;
            //This parameter causes LogonUser to create a primary token. 
            const int LOGON32_LOGON_INTERACTIVE = 2;
            bool returnValue = LogonUser(userName, domainName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out safeTokenHandle);
            if ( returnValue == false )
            {
                // login error
            }
            using (safeTokenHandle)
            {
                WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                WindowsImpersonationContext impersonatedUser = newId.Impersonate();
            }

        }
    }

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}