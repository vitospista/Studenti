using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_for
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("PostIncrementCompressed");
            //PostIncrementCompressed();
            //Console.WriteLine();
            //Console.WriteLine("PreIncrementCompressed");
            //PreIncrementCompressed();

            //PrintTriangularTable(7);
            PrintPrimeNumbers();

            Console.Read();
        }

        static void PrintPrimeNumbers()
        {
            for (int i = 2; i <= 100; i++)
            {
                if (IsPrime(i))
                    Console.WriteLine(i);
            }
        }

        private static bool IsPrime(int candidate)
        {
            /*
             * divisioni con gli interi:
             * 7 / 2 = 3
             * 7 % 2 = 1
             * ==> 3 * 2 + 1 = 7
             * 
             * 45 / 13 = 3
             * 45 % 13 = 6
             * 3 * 13 + 6 = 45
             */

            // prima idea: uso una variabile isPrime
            // tutti i numeri che risultano divisori settano isPrime a false.

            //bool isPrime = true;

            //for (int divisor = 2; divisor < i; divisor++)
            //{
            //    if (i % divisor == 0)
            //    {
            //        isPrime = false;
            //    }
            //}

            //return isPrime;

            // ho un problema di performance:
            // se già il primo numero è un divisore,
            // questo algoritmo continua comunque a controllare
            // tutti i possibili divisori.

            // versione ottimizzata:
            for (int divisor = 2; divisor < candidate; divisor++)
            {
                if (candidate % divisor == 0)
                {
                    return false;
                }
            }

            return true;          
        }

        static void PrintTriangularTable(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            /* n = 4;
             *   i    j
             *   1    1
             *   2    1
             *   2    2
             */

            /*
             * 1_
             * 1_2_
             * 1_2_3_
             * 
             * 
             * 

            // esercizio: far venir fuori una stampa "triangolare" così:
            /*
             r 1: * 1
             r 2: * 1 2
             r 3: * 1 2 3 
             r 4: * 1 2 3 4
             r .:* ...
             r n:* 1 2 3 4 5 6 7 8 9 ... n
             */
        }

        static void ForInsideAFor()
        {
            Console.WriteLine("for inside a for");
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j}\t");
                }

                Console.WriteLine();
            }
        }

        static void PostIncrement()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            {
                int i = 0;
                while (i < 10)
                {
                    Console.WriteLine(i);
                    i++;
                }
            }
        }

        static void PreIncrement()
        {
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(i);
            }
            {
                int i = 0;
                while (i < 10)
                {
                    Console.WriteLine(i);
                    ++i;
                }
            }
        }

        static void PostIncrementCompressed()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i++);
            }
        }

        static void PreIncrementCompressed()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(++i);
            }
        }
    }
}
