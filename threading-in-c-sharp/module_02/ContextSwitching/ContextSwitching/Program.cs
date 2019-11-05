using System;
using System.Threading;

namespace ContextSwitching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(WriteUsingNewThread);
            thread.Name = "Worker Thread";
            Thread.CurrentThread.Name = "Main Thread";
            thread.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" A" + i + " ");
                Thread.Sleep(100);
            }
        }

        private static void WriteUsingNewThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" Z" + i + " ");
                Thread.Sleep(100);
            }
        }
    }
}
