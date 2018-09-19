using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallPriority
{
    public class Base
    {
        public virtual void Foo(int x)
        {
            Console.WriteLine("Base.Foo(int)");
        }

        //public virtual void Foo(object x)
        //{
        //    Console.WriteLine("Base.Foo(object)");
        //}
    }

    public class Derived : Base
    {
        public override void Foo(int x)
        {
            Console.WriteLine("Derived.Foo(int)");
        }

        public  void Foo(object x)
        {
            Console.WriteLine("Derived.Foo(object)");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            int x = 10;
            d.Foo(x);
            Console.ReadLine();
        }
    }
}
