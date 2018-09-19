using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        static List<string> itemList = new List<string>();
        static void Main(string[] args)
        {
            //ParallelFor();
            ////ParallelForEach();
            //ParallelInvoke();
            Task4();
            //Task2();
            //Task3();

            Console.WriteLine("Done All");
            Console.ReadLine();
        }

        static void ParallelFor()
        {

            Parallel.For(0, 20, i =>
            {
                Console.WriteLine("A {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("B {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("C {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("D {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("E {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("F {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("G {0} Thread Id : {0}", i.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("----------------------------");
            });
            
        }

        static void ParallelForEach()
        {
            itemList.Add("A");
            itemList.Add("B");
            itemList.Add("C");
            itemList.Add("D");
            itemList.Add("E");
            Parallel.ForEach(itemList, item => PrintItem(item));
        }
        static void PrintItem(string _item)
        {
            Console.WriteLine(_item);
        }

        static void ParallelInvoke()
        {
            Parallel.Invoke(() => Loop1(), () => Loop2());
        }

        static void Loop1()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine(i.ToString());
            Console.WriteLine("Done Loop1");
        }

        static void Loop2()
        {
            for (int i = 100; i < 200; i++)
                Console.WriteLine(i.ToString());
            Console.WriteLine("Done Loop2");
        }

        static async Task<int>  Loop4()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine(i.ToString());
            Console.WriteLine("Done Loop4");
            return 0;
        }

        static void Task1()
        {
            var taskA = new Task(() => Loop1());
            taskA.Start();

            //var taskB = new Task(() => Loop2());
            //taskB.Start();

            Task.Run(() => Loop2());

            Console.WriteLine("Done Task1");
        }

        static void Task2()
        {
            var taskA = Task.Factory.StartNew(() => Loop1());
            var taskB = Task.Factory.StartNew(() => Loop2());

            Console.WriteLine("Done Task2");
        }

        static void Task3()
        {
            var taskA = Task.Factory.StartNew(() => Loop1()).ContinueWith((x) => Loop2());

            Console.WriteLine("Done Task3");
        }

        static void Task4()
        {
            Task<int> task = Loop4();
            int x = await task;
        }

    }
}
