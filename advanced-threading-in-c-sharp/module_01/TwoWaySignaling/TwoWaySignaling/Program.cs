using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwoWaySignaling
{
    public class Program
    {
        public static EventWaitHandle first = new AutoResetEvent(false);
        public static EventWaitHandle second = new AutoResetEvent(false);
        public static object lockObject = new object();
        public static string value = string.Empty;
        
        public static void Main()
        {
            Task.Factory.StartNew(WorkerThread);
            Console.WriteLine("Main thread is waiting");
            first.WaitOne();

            lock (lockObject)
            {
                value = "Updating value in main thread";
                Console.WriteLine(value);
            }
            Thread.Sleep(1000);
            second.Set();
            Console.WriteLine("Released worker thread");
        }

        private static void WorkerThread()
        {
            lock (lockObject)
            {
                value = "Updating value in worker thread";
                Console.WriteLine(value);
            }
            Thread.Sleep(1000);
            first.Set();
            Console.WriteLine("Released Main Thread");
            Console.WriteLine("Worker thread is waiting");
            second.WaitOne();
            Console.WriteLine("Worker thread is finishing");
        }
    }
}
