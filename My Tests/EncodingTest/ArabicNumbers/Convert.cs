using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ArabicNumbers
{
    public class Convert
    {
        public static string ToArabicNumbers(string str)
        {
            Dictionary<char, char> codes = new Dictionary<char, char>();
            codes['0'] = '\u0660'; //1632
            codes['1'] = '\u0661';
            codes['2'] = '\u0662';
            codes['3'] = '\u0663';
            codes['4'] = '\u0664';
            codes['5'] = '\u0665';
            codes['6'] = '\u0666';
            codes['7'] = '\u0667';
            codes['8'] = '\u0668';
            codes['9'] = '\u0669';
            codes['-'] = '-';
            codes[' '] = '0';
            //string newStr2 = "";
            //foreach (char crChar in str.ToCharArray())
            //{
            //    if (codes.ContainsKey(crChar))
            //        newStr2 += codes[crChar];
            //    else
            //        newStr2 += crChar;
            //}

            var newStr = Regex.Replace(str, @"[\d]", m =>
            {
                return codes[m.Captures[0].ToString()[0]].ToString();
            });
            return newStr;
            //return "OK1";
        }

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
