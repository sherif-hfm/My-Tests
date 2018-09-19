using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OneTimePassApi
{
    public class Helper
    {
        public static string ToEnglishNumbers(string str)
        {
            Dictionary<char, char> codes = new Dictionary<char, char>();
            codes['\u0660'] = '0'; //1632
            codes['\u0661'] = '1';
            codes['\u0662'] = '2';
            codes['\u0663'] = '3';
            codes['\u0664'] = '4';
            codes['\u0665'] = '5';
            codes['\u0666'] = '6';
            codes['\u0667'] = '7';
            codes['\u0668'] = '8';
            codes['\u0669'] = '9';

            codes['0'] = '0'; //1632
            codes['1'] = '1';
            codes['2'] = '2';
            codes['3'] = '3';
            codes['4'] = '4';
            codes['5'] = '5';
            codes['6'] = '6';
            codes['7'] = '7';
            codes['8'] = '8';
            codes['9'] = '9';

            var newStr = Regex.Replace(str, @"[\d]", m => { Console.WriteLine(m.Captures[0]); return codes[m.Captures[0].ToString()[0]].ToString(); });
            return newStr;

        }
    }
}