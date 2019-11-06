using System;
using System.Threading.Tasks;

namespace TaskIo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/posts"));

            SomethingElse();

            //task.Wait();
            try
            {
                Console.WriteLine(task.Result);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private static void SomethingElse()
        {
            // Dummy implementation
        }


        private static string GetPosts(string url)
        {
            //throw null;
            using (var client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
