using System;
using System.Threading;

namespace SharedResources
{
    public class Program
    {
        private static bool isCompleted;
        static readonly object lockCompleted = new object();

        public static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);
            thread.Start();

            HelloWorld();
        }

        private static void HelloWorld()
        {
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    isCompleted = true;
                    Console.WriteLine("Hello world should be printed only once");
                }
            }
        }
    }
}
