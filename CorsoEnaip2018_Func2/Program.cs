using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Func2
{
    class Program
    {
        static void Main(string[] args)
        {
            printResult(factorialIterative, 15);
            printResult(factorialRecursive, 15);

            Console.WriteLine("Somma di 7 e 4");
            printResult(
                (int1, int2) => int1 + int2,
                7,
                4);

            Console.WriteLine("Differenza di 7 e 4");
            printResult(
                (int1, int2) => int1 - int2,
                7,
                4);

            Action<object> print = (object o) => Console.WriteLine(o);
            print("ciao");

            measurePerformance(freeze);

            Console.Read();
        }

        static void printResult(Func<int, int> operation, int n)
        {
            int result = operation(n);

            Console.WriteLine(result);
        }

        static int factorialIterative(int n)
        {
            int result = 1;

            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }

        static int factorialRecursive(int n)
        {
            if (n == 0)
                return 1;

            return n * factorialRecursive(n - 1);
        }


        static void printResult(Func<int, int, int> operation, int a, int b)
        {
            int result = operation(a, b);

            Console.WriteLine(result);
        }

        static void measurePerformance(Action a)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            Stopwatch sw = Stopwatch.StartNew();

            a();

            sw.Stop();

            Console.WriteLine($"Tempo di esecuzione: {sw.ElapsedMilliseconds} ms");
        }

        static void freeze()
        {
            Thread.Sleep(3000);
        }
    }
}
