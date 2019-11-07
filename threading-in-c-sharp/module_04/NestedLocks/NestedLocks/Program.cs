using System;
using System.Threading.Tasks;

namespace NestedLocks
{
    public class Program
    {
        public static object newLock = new object();

        public static void Main()
        {
            lock (newLock)
            {
                DoSomething();
            }
        }

        private static void DoSomething()
        {
            lock (newLock)
            {
                Task.Delay(2000);
                lock (newLock)
                {
                    Console.WriteLine("HEllo");
                    AnotherMethod();
                }
            }
        }

        private static void AnotherMethod()
        {
            lock (newLock)
            {
                Console.WriteLine("World");
            }
        }
    }
}
