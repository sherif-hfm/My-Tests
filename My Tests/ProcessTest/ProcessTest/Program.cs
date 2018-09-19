using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task startProcess = new Task(StartProcess);
            Task startProcess2 = new Task(StartProcess2);
            Task startProcess3 = new Task(StartProcess3);
            startProcess.Start();
            startProcess2.Start();
            startProcess3.Start();
            Console.ReadLine();
        }

        private static void StartProcess()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = @"D:\DocFlowFiles\test.docx";
                process.StartInfo.Verb = "PrintTo";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try start Process");
                process.Start();
                process.WaitForExit(10000);
                if (process.HasExited == false)
                    process.Kill();
                Console.WriteLine("Task 1 Done");
            }
        }

        private static void StartProcess2()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = @"D:\DocFlowFiles\test2.docx";
                process.StartInfo.Verb = "PrintTo";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try start Process");
                process.Start();
                process.WaitForExit(10000);
                if (process.HasExited == false)
                    process.Kill();
                Console.WriteLine("Task 2 Done");
            }
        }

        private static void StartProcess3()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = @"D:\DocFlowFiles\test3.docx";
                process.StartInfo.Verb = "PrintTo";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                //File.AppendAllText(@"C:\DocFlowFiles\log.txt", "Try start Process");
                process.Start();
                process.WaitForExit(10000);
                if (process.HasExited == false)
                    process.Kill();
                Console.WriteLine("Task 3 Done");
            }
        }
    }
}
