using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskIntro
{
    public class Program
    {
        public static void Main()
        {
            Task task = new Task(SimpleMethod);
            task.Start();

            Task<string> taskThatReturns = new Task<string>(MethodThatReturns);
            taskThatReturns.Start();
            taskThatReturns.Wait();
            Console.WriteLine(taskThatReturns.Result);

            Console.ReadLine();
        }

        private static string MethodThatReturns()
        {
            Thread.Sleep(2000);
            return "Hi again";
        }

        private static void SimpleMethod()
        {
            //Thread.Sleep(5000);
            Console.WriteLine("Hello World!");
        }
    }
}
