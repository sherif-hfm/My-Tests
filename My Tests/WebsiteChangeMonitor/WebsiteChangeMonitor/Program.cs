using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebsiteChangeMonitor
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static System.Timers.Timer timerS9;
        private static System.Timers.Timer timer3D;
        private static System.Timers.Timer timer3D_2;
        private static System.Timers.Timer timerL3;

        static void Main(string[] args)
        {
            Log.Info("Application Start");

            timerS9 = new System.Timers.Timer();
            timerS9.Elapsed += TimerS9_Elapsed;
            timerS9.Interval = 1000;
            timerS9.Enabled = true;

            timer3D = new System.Timers.Timer();
            timer3D.Elapsed += Timer3D_Elapsed;
            timer3D.Interval = 1000;
            timer3D.Enabled = true;

            timer3D_2 = new System.Timers.Timer();
            timer3D_2.Elapsed += timer3D_2_Elapsed;
            timer3D_2.Interval = 1000;
            timer3D_2.Enabled = true;

            timerL3 = new System.Timers.Timer();
            timerL3.Elapsed += TimerL3_Elapsed;
            timerL3.Interval = 1000;
            timerL3.Enabled = true;


            Console.ReadLine();
            Log.Info("Application End");
        }

        private static void TimerS9_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)sender;
            timer.Enabled = false;
            string minerName = "Antminer S9";
            try
            {
                Log.Info($"Check {minerName}");
                var text = GetUrlData("https://shop.bitmain.com/antminer_s9_asic_bitcoin_miner.htm");
                if (string.IsNullOrEmpty(text) == false && !text.Contains("maintenance") )
                {
                    if (!text.Contains("Coming soon"))
                    {
                        Log.Info($"Bitmain {minerName} is available");
                        SendEmail($"Bitmain {minerName} is available", $"Bitmain {minerName} is available" + DateTime.Now.ToString());
                    }
                    else
                    {
                        Log.Info($"Bitmain {minerName} is not available");
                    }
                    timer.Interval = 600000;
                    timer.Enabled = true;
                }
                else
                {
                    Log.Info($"{minerName} Url no data or under maintenance");
                    timer.Interval = 60000;
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                timer.Interval = 60000;
                timer.Enabled = true;
            }
        }

        private static void Timer3D_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)sender;
            timer.Enabled = false;
            string minerName = "Antminer 3D";
            try
            {
                Log.Info($"Check {minerName}");
                var text = GetUrlData("https://shop.bitmain.com/productDetail.htm?pid=00020170817162128100hiH7jINR0692");
                if (string.IsNullOrEmpty(text) == false && !text.Contains("maintenance"))
                {
                    if (CheckD3(text))
                    {
                        Log.Info($"Bitmain {minerName} is available");
                        SendEmail($"Bitmain {minerName} is available", $"Bitmain {minerName} is available" + DateTime.Now.ToString());
                    }
                    else
                    {
                        Log.Info($"Bitmain {minerName} is not available");
                    }
                    timer.Interval = 600000;
                    timer.Enabled = true;
                }
                else
                {
                    Log.Info($"{minerName} Url no data or under maintenance");
                    timer.Interval = 60000;
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                timer.Interval = 60000;
                timer.Enabled = true;
            }
        }

        private static void timer3D_2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)sender;
            timer.Enabled = false;
            string minerName = "Antminer 3D";
            try
            {
                Log.Info($"Check {minerName}");
                var text = GetUrlData("https://shop.bitmain.com/productDetail.htm?pid=00020170718203947438V537cuy7067F");
                if (string.IsNullOrEmpty(text) == false && !text.Contains("maintenance"))
                {
                    if (CheckD3(text))
                    {
                        Log.Info($"Bitmain {minerName} is available");
                        SendEmail($"Bitmain {minerName} is available", $"Bitmain {minerName} is available" + DateTime.Now.ToString());
                    }
                    else
                    {
                        Log.Info($"Bitmain {minerName} is not available");
                    }
                    timer.Interval = 600000;
                    timer.Enabled = true;
                }
                else
                {
                    Log.Info($"{minerName} Url no data or under maintenance");
                    timer.Interval = 60000;
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                timer.Interval = 60000;
                timer.Enabled = true;
            }
        }

        private static void TimerL3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timer = (System.Timers.Timer)sender;
            timer.Enabled = false;
            string minerName = "Antminer L3";
            try
            {
                Log.Info($"Check {minerName}");
                var text = GetUrlData("https://shop.bitmain.com/antminer_l3_litecoin_asic_scrypt_miner.htm");
                if (string.IsNullOrEmpty(text) == false && !text.Contains("maintenance"))
                {
                    if (!text.Contains("Coming soon"))
                    {
                        Log.Info($"Bitmain {minerName} is available");
                        SendEmail($"Bitmain {minerName} is available", $"Bitmain {minerName} is available" + DateTime.Now.ToString());
                    }
                    else
                    {
                        Log.Info($"Bitmain {minerName} is not available");
                    }
                    timer.Interval = 600000;
                    timer.Enabled = true;
                }
                else
                {
                    Log.Info($"{minerName} Url no data or under maintenance");
                    timer.Interval = 60000;
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                timer.Interval = 60000;
                timer.Enabled = true;
            }
        }

        private static string GetUrlData(string _url)
        {
            try
            {
                var client = new WebClient();
                var text = client.DownloadString(_url);
                return text;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return "";
            }
        }

        private static bool CheckD3(string _text)
        {
            string input = _text;
            string pattern = "<input type=\"button\".*?disabled=\"disabled\".*?>";

            MatchCollection matches = Regex.Matches(input, pattern);
            if (matches.Count > 0)
                return false;
            else
                return true;
        }

        private static void SendEmail(string _subject, string _body)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("sherif.hfm@gmail.com");
            msg.To.Add("sherif_hfm@yahoo.com");
            msg.Subject = _subject;
            msg.Body = _body;
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
                Log.Error(ex.Message, ex);
                return;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
