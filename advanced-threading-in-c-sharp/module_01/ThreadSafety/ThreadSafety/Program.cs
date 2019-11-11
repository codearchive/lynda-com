using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadSafety
{
    public class Program
    {
        public static Dictionary<int, string> items = new Dictionary<int, string>();

        public static void Main()
        {
            var task1 = Task.Factory.StartNew(AddItem);
            var task2 = Task.Factory.StartNew(AddItem);
            var task3 = Task.Factory.StartNew(AddItem);
            var task4 = Task.Factory.StartNew(AddItem);
            var task5 = Task.Factory.StartNew(AddItem);
            Task.WaitAll(task3, task2, task1, task4, task5);
            Console.ReadLine();
        }

        private static void AddItem()
        {
            lock (items)
            {
                Console.WriteLine("Lock 1 acquireb by " + Task.CurrentId);
                items.Add(items.Count, "ExampleItem " + items.Count);
            }

            Dictionary<int, string> dictionary;
            lock (items)
            {
                Console.WriteLine("Lock 2 acquired by " + Task.CurrentId);
                dictionary = items;
            }

            lock (dictionary)
            {
                foreach (var kv in dictionary)
                {
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                }
            }
        }
    }
}
