using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EncodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            return;
            string crNum = "عدد 500 عدد 600 عدد asd";
            string newNum="";
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
            codes[' '] = ' ';

            var str = Regex.Replace(crNum, @"[\d]", m => { Console.WriteLine(m.Captures[0]); return codes[m.Captures[0].ToString()[0]].ToString(); });
            
            //var str = new string(crNum.Select(c => new { code = c }).ToArray().Select(c => codes[c.code]).ToArray());
            foreach(char mychar in crNum)
            {
                int crCode = (int)mychar;
                int newCode = crCode + 1584;
                char newChar = (char)newCode;
                if (codes.ContainsKey(mychar) == true)
                    newNum += codes[mychar];
                else
                    newNum += mychar;
                //newNum += newChar;
            }

            string str1 = "٣";
            string str2 = "懰";
            string str3 = "懸";

            var codes1 = Encoding.Unicode.GetBytes(str1);
            var codes2 = Encoding.Unicode.GetBytes(str2);
            var codes3 = Encoding.Unicode.GetBytes(str3);
            byte b1 = (byte)codes['3'];
            //byte[] codes3 = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, codes2);
            var comes4 = Encoding.Convert(Encoding.BigEndianUnicode, Encoding.UTF8, codes2);
            string msg = Encoding.UTF32.GetString(codes1);
        }

        static void Test()
        {
            string str = "0123456789";
            //string str2 = "١٤٣٥/٤١٩١";
            string str1 = "مكتب الأمين";
            var newStr = ArabicNumbers.Convert.ToArabicNumbers(str);
            //var newStr = ArabicNumbers.Convert.ToEnglishNumbers(str1);
            //var newStr = ArabicNumbers.Convert.ToEnglishNumbers(str2);
        }

        static string Replacement(string s, int i)
        {
            return string.Format("{0}:{1}", i, s.ToUpper());
        }

    }
}
