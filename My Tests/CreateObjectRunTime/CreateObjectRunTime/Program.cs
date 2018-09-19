using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace CreateObjectRunTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var asd = GetValue<string>();
        }

        public static T GetValue<T>()
        {
            if (typeof(T) == typeof(string))
                return (T)Activator.CreateInstance(typeof(string), new object[] {"".ToCharArray()});
            var result = (T)Activator.CreateInstance<T>();
            return result;
        }
    }
}
