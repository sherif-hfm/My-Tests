using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMTP;
namespace SendAnonymousEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail();
            Console.ReadLine();
        }

        private static void SendEmail()
        {
            System.Web.Mail.MailMessage msg=new System.Web.Mail.MailMessage();
            msg.To="sherif_hfm@yahoo.com";
            msg.From="test@yahoo.com";
            msg.Subject="test";
            msg.Body="test body";
            SmtpDirect.Send(msg);
            
        }
    }
}
