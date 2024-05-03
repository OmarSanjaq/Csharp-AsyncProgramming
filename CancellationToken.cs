using System;

namespace CancellationToken
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            //await DoCheck(cts);
            //await DoCheck02(cts);
            await DoCheck02(cts);

            Console.ReadKey();
        }
        static async Task DoCheck(CancellationTokenSource cts)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if(input.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Task Canceld");
                }
            });

            while (!cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("Checking ..!");
                await Task.Delay(4000);
                Console.Write($"Completed On {DateTime.Now}");
                Console.WriteLine();
            }
            Console.WriteLine("Check was Terminated.");
            cts.Dispose();

        }

        static async Task DoCheck02(CancellationTokenSource cts)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Task Canceld");
                }
            });

            while (true)
            {
                Console.WriteLine("Checking ..!");
                await Task.Delay(4000,cts.Token);
                Console.Write($"Completed On {DateTime.Now}");
                Console.WriteLine();
            }
            Console.WriteLine("Check was Terminated.");
            cts.Dispose();

        }

        static async Task DoCheck03(CancellationTokenSource cts)
        {
            Task.Run(() =>
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Task Canceld");
                }
            });

            try
            {

                while (true)
                {
                    cts.Token.ThrowIfCancellationRequested();
                    Console.WriteLine("Checking ..!");
                    await Task.Delay(4000);
                    Console.Write($"Completed On {DateTime.Now}");
                    Console.WriteLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message)
            }

            Console.WriteLine("Check was Terminated.");
            cts.Dispose();

        }

    }
}