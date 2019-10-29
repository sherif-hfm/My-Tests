using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UmAlQuraCalendarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //SetCultureInfo();
            //05-10-1396
            //GetMonthName();
            //ConvertToUmAlQura();
            //ConvertToGregorian("05/10/1396");
            //Console.Write(GetNextDayHijryDate());
            //GetPriviosMonth();
            ConvertStringToDate();
            //AddUmAlQuraYear();
            //UmAlQuraCalendar();
            Console.ReadLine();
        }

        private static void UmAlQuraCalendar()
        {
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            var mydate = umAlQuraCalendar.ToDateTime(1440, 2, 30, 0, 0, 0, 0);
            SetCultureInfo();
            var dateStr = mydate.ToString();
            var unmYear = umAlQuraCalendar.GetYear(mydate);
        }

        private static void ConvertStringToDate()
        {

            //SetCultureInfo();
            
            CultureInfo SAculture = new System.Globalization.CultureInfo("ar-SA", false);
            var umAlQuraCalendar= new System.Globalization.UmAlQuraCalendar();
            SAculture.DateTimeFormat.Calendar = umAlQuraCalendar;

            CultureInfo EGculture = new System.Globalization.CultureInfo("ar-EG", true);
            var gregorianCalendar= new System.Globalization.GregorianCalendar();
            EGculture.DateTimeFormat.Calendar = gregorianCalendar;

            DateTime date0 = new DateTime(2019, 2, 25);
            DateTime date1 = new DateTime(2019, 2, 1, gregorianCalendar);
            DateTime date2 = new DateTime(1440, 6, 1, umAlQuraCalendar);
            string date1str = date1.ToString((IFormatProvider)SAculture);

            DateTime dt = DateTime.ParseExact("31-10-2017 23:55", "dd-MM-yyyy HH:mm", (IFormatProvider)EGculture);
            DateTime dt2 = DateTime.ParseExact("29-02-1439 23:55", "dd-MM-yyyy HH:mm", (IFormatProvider)SAculture);
            DateTime dt3 = DateTime.ParseExact("1396/10/05", "yyyy/MM/dd", (IFormatProvider)SAculture);
            var dateStr = dt2.ToString((IFormatProvider)EGculture);
        }

        private static void AddUmAlQuraYear()
        {
            //SetCultureInfo();
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            var umCrDate = new DateTime(umAlQuraCalendar.GetYear(DateTime.Now), umAlQuraCalendar.GetMonth(DateTime.Now), umAlQuraCalendar.GetDayOfMonth(DateTime.Now), umAlQuraCalendar);
            var newUmDate= umAlQuraCalendar.AddYears(umCrDate, 1);
        }

        private static void DateDiff()
        {
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            var umCrDate = new DateTime(umAlQuraCalendar.GetYear(DateTime.Now), umAlQuraCalendar.GetMonth(DateTime.Now), umAlQuraCalendar.GetDayOfMonth(DateTime.Now), umAlQuraCalendar);
            var umbirthDate = new DateTime(1396, 10, 05, umAlQuraCalendar);
            decimal diffDays = (umCrDate - umbirthDate).Days;
            var diffYears = diffDays / 360;
        }

        private static void ConvertToUmAlQura()
        {
            DateTime mDate = new DateTime(2015, 02, 28);
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            var umCrDate = umAlQuraCalendar.GetYear(mDate).ToString() + "-" + umAlQuraCalendar.GetMonth(mDate).ToString("00") + "-" + umAlQuraCalendar.GetDayOfMonth(mDate).ToString("00");
        }

        private static void ConvertToGregorian(string _date)
        {
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            var dateParts = _date.Split('/');
            if (dateParts.Length == 3)
            {
                int day = Convert.ToInt16(dateParts[0]);
                int month = Convert.ToInt16(dateParts[1]);
                int year = Convert.ToInt16(dateParts[2]);
                var mDate = new DateTime(year, month, day, umAlQuraCalendar);
            }
        }

        private static void SetCultureInfo()
        {
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            var saCulture = new CultureInfo("ar-SA");
            saCulture.DateTimeFormat.Calendar = umAlQuraCalendar;
            Thread.CurrentThread.CurrentCulture = saCulture;
            Thread.CurrentThread.CurrentUICulture = saCulture;
        }

        private static string GetMonthName()
        {
            var saCulture = new CultureInfo("ar-SA");
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            int crDay = umAlQuraCalendar.GetDayOfMonth(DateTime.Now);
            int crMonth = umAlQuraCalendar.GetMonth(DateTime.Now);
            int crYear = umAlQuraCalendar.GetYear(DateTime.Now);
            var crDate = new DateTime(crYear, crMonth, crDay, umAlQuraCalendar).AddDays(-10);
            var monthName = crDate.ToString("MMMM");
            var monthName2 = DateTime.Now.ToString("MMMM");
            return "";
        }

        private static string GetNextDayHijryDate()
        {
            UmAlQuraCalendar cal = new UmAlQuraCalendar();
            var nextDayDate=cal.AddDays(DateTime.Now,1);
            var nextDay = cal.GetYear(nextDayDate).ToString() + "/" + cal.GetMonth(nextDayDate).ToString("00") + "/" + cal.GetDayOfMonth(nextDayDate).ToString("00");
            return "1438/01/01";
        }

        private static void GetPriviosMonth()
        {
            SetCultureInfo();
            UmAlQuraCalendar umAlQuraCalendar = new UmAlQuraCalendar();
            int crDay = umAlQuraCalendar.GetDayOfMonth(DateTime.Now);
            int crMonth = umAlQuraCalendar.GetMonth(DateTime.Now);
            int crYear = umAlQuraCalendar.GetYear(DateTime.Now);
            var crDate = new DateTime(1437, 7, 1, umAlQuraCalendar).AddDays(-10);
            var monthName = crDate.ToString("MMMM");
        }
    }
}
