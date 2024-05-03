using System;

namespace TaskDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"started");

            DelayUsingTask(5000);
            Console.ReadKey();
        }
        static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Completed after Task.Delay({ms})");

            }); 
        }
        static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed after Thread.Sleep({ms})");

        }
    }
}