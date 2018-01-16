using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;

            // su due righe
            //int fii = FactorialIterativeIncremental(n);
            //Console.WriteLine($"factorial of {n} = {fii}");

            //in una riga:

            Console.WriteLine($"factorial incremental of {n} = {FactorialIterativeIncremental(n)}");
            Console.WriteLine($"factorial decremental of {n} = {FactorialIterativeDecremental(n)}");

            Console.WriteLine($"factorial recursive of {n} = {FactorialRecursive(n)}");


            Console.WriteLine($"il numero di Fibonacci n° {n} = {FibonacciRecursive(n)}");
            Console.WriteLine($"il numero di Fibonacci n° {n} = {FibonacciIterative(n)}");

            Console.Read();
        }

        static int FactorialIterativeIncremental(int n)
        {
            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                // esteso
                //int newResult = result * i;
                //result = newResult;

                // più compatto
                //result = result * i;

                //compattazione massima
                result *= i;  // += -= /=
            }

            return result;
        }

        static int FactorialIterativeDecremental(int n)
        {
            int result = 1;

            for(int i = n; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }

        static int FactorialRecursive(int n)
        {
            if (n == 0)
                return 1;

            return n * FactorialRecursive(n - 1);
        }

        static int FibonacciRecursive(int n)
        {
            // 1o: 0
            // 2o: 1
            // n-esimo: (n-esimo - 1) + (n-esimo - 2)

            // 0 1 1 2 3 5 8 13 21 ...

            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        static int FibonacciIterative(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            int first = 0;
            int second = 1;
            int result = first + second;

            for(int i = 3; i <= n; i++)
            {
                first = second;
                second = result;
                result = first + second;
            }

            return result;
            /*
             * first second result
             *     0      1      1
             *     1      1      2
             *     1      2      3
             *     2      3      5
             *     
             */
        }

        // 0! ==> 1
        // 1! ==> 1
        // 2! ==> 2 * 1         ==>  2
        // 4! ==> 4 * 3 * 2 * 1 ==> 24
        // 4! ==> 1 * 2 * 3 * 4 ==> 24
        // 24
        // 12! ==> 12 * 11 * ... * 2 * 1

        // n! = n * !(n-1)
    }
}
