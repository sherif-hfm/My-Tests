using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsiteChangeMonitor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void ChkTimerS9_Tick(object sender, EventArgs e)
        {
            try
            {
                ChkTimerS9.Enabled = false;
                var client = new WebClient();
                var text = client.DownloadString("https://shop.bitmain.com/antminer_s9_asic_bitcoin_miner.htm");
                if (!text.Contains("maintenance"))
                {
                    if (!text.Contains("coming soon"))
                    {
                        SendEmail("bitmain antminer_s9 is available", "bitmain antminer_s9 is available" + DateTime.Now.ToString());
                    }
                    ChkTimerS9.Interval = 600000;
                    ChkTimerS9.Enabled = true;
                }
                else
                {
                    ChkTimerS9.Interval = 60000;
                    ChkTimerS9.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ChkTimerS9.Interval = 60000;
                ChkTimerS9.Enabled = true;
            }
        }

       

        private void SendEmail( string _subject , string _body)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("sherif.hfm@gmail.com");
            msg.To.Add("sherif_hfm@yahoo.com");
            msg.Subject = "bitmain is up " ;
            msg.Body = "bitmain is up ... :)" + DateTime.Now.ToString();
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("sherif.hfm@gmail.com", "urzcsmizpmwhxaay");
            client.Timeout = 200000;
            try
            {
                client.Send(msg);
                return;
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                msg.Dispose();
            }
        }
        
    }
}
