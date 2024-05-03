using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


namespace ExceptionPropagation
{
    class Program
    {
        static void Main(string[] args)
        { ///         1         using thread and it the exception will not be thrown via the main

            //try
            //{
            //    var th = new Thread(ThrowException);
            //    th.Start();
            //    th.Join();
            //}
            //catch{
            //    Console.WriteLine("Exception is Thrown !!");
            //}


            ////      2     here i do the try/catch in the method not in the thread so it handled

            //var th = new Thread(ThrowExceptionWithTryCatchBlock);
            //    th.Start();
            //    th.Join();


            ///   3  with task

            try
            {
                Task.Run(ThrowExceptionWithTryCatchBlock).Wait();
            }
            catch
            {
                Console.WriteLine("Exception Thrown");
            }
            Console.ReadKey();
        }
        static void ThrowException()
        {
            throw new NullReferenceException();
        }
        static void ThrowExceptionWithTryCatchBlock()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch
            {
                Console.WriteLine("Exception Thwon");
                throw;
            }

        }
    }
}