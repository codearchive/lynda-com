using System;
using System.Threading;

namespace ThreadPoolDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1: " + Thread.CurrentThread.IsThreadPoolThread);

            Employee employee = new Employee("Pavel", "RideOn");
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

            //var processorCount = Environment.ProcessorCount;
            //ThreadPool.SetMaxThreads(processorCount * 2, processorCount * 2);
            int workerThreads = 0;
            int completionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);

            ThreadPool.SetMaxThreads(workerThreads * 2, completionPortThreads * 2);
            Console.WriteLine("2: " + Thread.CurrentThread.IsThreadPoolThread);
            Console.ReadLine();
        }

        private static void DisplayEmployeeInfo(object employeeObject)
        {
            Console.WriteLine("3: " + Thread.CurrentThread.IsThreadPoolThread);
            Employee employee = employeeObject as Employee;
            Console.WriteLine($"Person name is {employee.Name}. Company name is {employee.CompanyName}");

        }
    }
}