using System;

namespace SyncVsAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread,9);
            CallSynchronous();

            ShowThreadInfo(Thread.CurrentThread, 12);
            CallASynchronous();

            ShowThreadInfo(Thread.CurrentThread, 15);

            Console.ReadKey();
        }
        static void CallSynchronous()
        {
            Thread.Sleep(4000);
            ShowThreadInfo(Thread.CurrentThread,21);
            Task.Run(() => Console.WriteLine("++++++++++ Sync +++++++++")).Wait();

        }
        static void CallASynchronous()
        {
            ShowThreadInfo(Thread.CurrentThread,28);
            Task.Delay(4000).GetAwaiter().OnCompleted(() => {
                ShowThreadInfo(Thread.CurrentThread, 30);
                Console.WriteLine("++++++++++ ASync +++++++++");
                });
        }
        private static void ShowThreadInfo(Thread th ,int Line)
        {
            Console.WriteLine($"Line Num: {Line} , ThreadID:{th.ManagedThreadId}, Pooled:{th.IsThreadPoolThread},Background:{th.IsBackground}");
        }
    }
}