using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexLock
{
    public class Program
    {
        static Mutex mutex = new Mutex(); // false by default

        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(AcquireMutex);
                thread.Name = $"Thread {i + 1}";
                thread.Start();
            }
        }

        private static void AcquireMutex()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}");
                return;
            }

            //mutex.WaitOne();
            DoSomething();
            mutex.ReleaseMutex();
            Console.WriteLine($"Mutex released by {Thread.CurrentThread.Name}");
        }

        private static void DoSomething()
        {
            Thread.Sleep(250);
            //Console.WriteLine($"Mutex acquired by {Thread.CurrentThread.Name}");
        }
    }
}
