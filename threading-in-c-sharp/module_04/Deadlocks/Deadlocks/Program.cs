using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlocks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            object firstLock = new object();
            object secondLock = new object();

            new Thread(() =>
            {
                lock (firstLock)
                {
                    Console.WriteLine("First Lock obtained");
                    Thread.Sleep(2000);
                    lock (secondLock)
                    {
                        Console.WriteLine("Second Lock obtained");
                    }
                }
            }).Start();
            lock (secondLock)
            {
                Console.WriteLine("Main Thread obtained Second Lock - 1");
                Thread.Sleep(2000);
                lock (firstLock)
                {
                    Console.WriteLine("Main Thread obtained Second Lock - 2");
                }

            }

            Console.ReadLine();
        }
    }
}
