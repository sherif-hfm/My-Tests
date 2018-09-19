using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string>();
            var list2 = list1;
            list1.Add("A");
            list1.Add("B");
            list1.Add("C");
            list1.Add("D");
            list1 = null;

        }
    }
}
