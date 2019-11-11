using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoEvent
{
    public class Program
    {
        //static EventWaitHandle autoResetEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
        static EventWaitHandle eventWaitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            Task.Factory.StartNew(WorkerThread);
            Thread.Sleep(2500);
            eventWaitHandle.Set();
            Console.ReadLine();
        }

        private static void WorkerThread()
        {
            Console.WriteLine("Waiting to enter the gate");
            eventWaitHandle.WaitOne();
            Console.WriteLine("Gate was entered");
        }
    }
}
