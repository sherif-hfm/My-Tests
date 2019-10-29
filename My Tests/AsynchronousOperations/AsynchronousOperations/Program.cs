using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousOperations
{
    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("before Thread.Sleep(callDuration)");
            Thread.Sleep(callDuration);
            Console.WriteLine("After Thread.Sleep(callDuration)");
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration, out int threadId);
    class Program
    {
        static void Main()
        {
            Console.ReadLine();
            // The asynchronous method puts the thread id here.
            int threadId;

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            // Initiate the asychronous call.
            Console.WriteLine("before BeginInvoke");
            IAsyncResult result = caller.BeginInvoke(3000,
                out threadId, null, null);
            Console.WriteLine("after BeginInvoke");
            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.",
                Thread.CurrentThread.ManagedThreadId);

            // Wait for the WaitHandle to become signaled.
            Console.WriteLine("before WaitOne");
            result.AsyncWaitHandle.WaitOne();
            Console.WriteLine("after WaitOne");

            // Perform additional processing here.
            // Call EndInvoke to retrieve the results.
            string returnValue = caller.EndInvoke(out threadId, result);

            // Close the wait handle.
            Console.WriteLine("before Close");
            result.AsyncWaitHandle.Close();
            Console.WriteLine("after Close");

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                threadId, returnValue);
            Console.ReadLine();
        }
    }
}
