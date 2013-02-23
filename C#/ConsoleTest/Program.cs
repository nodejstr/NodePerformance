using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        private static readonly object obj = new object();
        static void Main()
        {
            Console.WriteLine("Started");
            Calc2();
            Calc();
            Console.WriteLine("Ended");
            Console.ReadKey();
        }

        static void Calc()
        {
            double result = 0;
            Console.WriteLine("Calc");
            var date = DateTime.Now;
            for (var i = 0; i < 1000000000; i++)
            {
                result += Math.Sqrt(i);
            }
            Console.WriteLine((DateTime.Now - date).TotalMilliseconds);
            Console.WriteLine("Result: {0}", result);
        }


        public static void Calc2()
        {
            double result = 0;
            var date = DateTime.Now;
            Parallel.For(0, 1000000000, () => 0.00, (j, loop, total) =>
            {
                total += Math.Sqrt(j);
                return total;
            }, x =>
            {
                lock (obj)
                result += x;
            }
            );
            Console.WriteLine((DateTime.Now - date).TotalMilliseconds);
            Console.WriteLine("Result: {0}", result);
        }

    }
}
