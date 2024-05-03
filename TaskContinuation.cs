using System;

namespace TaskContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(CountPrimeNumberInARange(2, 2_000_000));

            Task<int> task = Task.Run(() =>  CountPrimeNumberInARange(2, 3_000_000) );
            //Console.WriteLine(task.Result);// BAD !! - It Blocks The Thread

            Console.WriteLine("Using awaiter , OnComplete()");
            var aWaiter = task.GetAwaiter();
            aWaiter.OnCompleted(() =>
            {
                Console.WriteLine(aWaiter.GetResult());// it also Block the thread , but when the task is completed
            });
            Console.WriteLine("Matigator");



            Console.WriteLine("Using task continuewith ");

            task.ContinueWith((x) => Console.WriteLine(x.Result)); 

            Console.WriteLine("Matigator");

            Console.ReadKey ();

        }
        static int CountPrimeNumberInARange(int lowerBound, int upperBound)
        {
            var count = 0;
            for(int i= lowerBound;i< upperBound; i++)
            {
                var j = lowerBound;
                var isPrime = true;
                while(j < (int)Math.Sqrt(i))
                {
                    if(i%j == 0)
                    {
                        isPrime=false;
                    }
                    ++j;
                }
                if(isPrime)
                {
                    ++count;
                }
            }
            return count;
        }
    }
}