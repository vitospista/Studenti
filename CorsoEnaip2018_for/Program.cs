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

            

            Console.Read();
        }

        static void PrintTriangularTable()
        {
            /*
             * 1
             * 1 2
             * 1 2 3 
             * 1 2 3 4
             * ..
             * 1 2 3 4 5 6 7 8 9 10
             * 
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
