using System;
using System.Threading;
namespace LongRunningTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() => runLongTask(),
                TaskCreationOptions.LongRunning);
            Console.ReadKey();
        }
        static void runLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }
        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"ThreadID:{th.ManagedThreadId}, Pooled:{th.IsThreadPoolThread},Background:{th.IsBackground}");
        }
    }
}