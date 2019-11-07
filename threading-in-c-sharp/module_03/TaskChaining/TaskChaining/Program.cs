using System;
using System.Threading.Tasks;

namespace TaskChaining
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            Task<string> antecedent = Task.Run(() =>
            {
                Console.WriteLine("What day is today?");
                Task.Delay(5000);
                return DateTime.Today.ToShortDateString();
            });

            Task<string> continuation = antecedent.ContinueWith(x =>
            {
                return "Today is " + antecedent.Result;
            });
            Console.WriteLine("This will display before the result");
            Console.WriteLine(continuation.Result);
            Console.ReadLine();
        }
    }
}
