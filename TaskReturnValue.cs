using System;
using System.Threading.Tasks;

namespace TaskReturnsValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(theTime);
          //  Console.WriteLine(task.Result); //Block The Thread

            Console.WriteLine(task.GetAwaiter().GetResult()); 
            Console.ReadKey();
        }
        static DateTime theTime()
        {
            return DateTime.Now;
        }
    }
}