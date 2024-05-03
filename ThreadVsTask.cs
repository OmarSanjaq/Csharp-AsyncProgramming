using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadVsTask
{
    class program
    {
        static void Main(string[] args)
        {
            var th = new Thread(() => Display("Metigator using Thread !!"));
            th.Start();
            th.Join();

            Task.Run(() => Display("Metigator using Task !!")).Wait();
            Console.ReadKey();
        }
        static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"ThreadID:{th.ManagedThreadId}, Pooled:{th.IsThreadPoolThread},Background:{th.IsBackground}");
        }
    }
}