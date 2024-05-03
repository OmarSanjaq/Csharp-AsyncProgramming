using System;
using System.Net.Http;


namespace AsyncFunction
{
    class Program
    {
        static async void Main(string[] args)
        {  //        1
           //var task = Task.Run(() => ReadContent("https://www.youtube.com/watch?v=uY3iina6q0Q&ab_channel=TerraLyrics"));
           //var awaiter= task.GetAwaiter();
           //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));

            //       2

            var content = await ReadContentAsync("https://www.youtube.com");
            Console.WriteLine(content);

            Console.ReadKey();
        }
        static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();

            var task = client.GetStringAsync(url);
            
            return task;
        }
        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(url);

            return content;
        }
    }
    
}