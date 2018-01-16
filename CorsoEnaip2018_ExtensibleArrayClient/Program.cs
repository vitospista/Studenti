using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorsoEnaip2018_ExtensibleArray;

namespace CorsoEnaip2018_ExtensibleArrayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtensibleArray a1 = new ExtensibleArray(4);

            a1.Add(45);
            Console.WriteLine($"a1[0] = {a1[0]}");
            Console.WriteLine($"a1.Count() = {a1.Count()}");

            a1.Add(23);

            a1.Add(123);
            Console.WriteLine($"a1[2] = {a1[2]}");
            Console.WriteLine($"a1.Count() = {a1.Count()}");

            a1.Add(65);

            a1.Add(123123);
            Console.WriteLine($"a1[4] = {a1[4]}");
            Console.WriteLine($"a1.Count() = {a1.Count()}");

            for (int i = 0; i < 1000; i++)
                a1.Add(i);

            Console.WriteLine($"a1[1004] = {a1[1004]}");
            Console.WriteLine($"a1.Count() = {a1.Count()}");

            try
            {
                ExtensibleArray a2 = new ExtensibleArray(-1);
                Console.WriteLine($"a2.Count() = {a2.Count()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("size negativo lancia eccezione!");
                Console.WriteLine(ex.Message);
            }

            ExtensibleArray a3 = new ExtensibleArray(0);

            a3.Add(45);
            Console.WriteLine($"a3[0] = {a3[0]}");
            Console.WriteLine($"a3.Count() = {a3.Count()}");

            a3.Add(23);

            a3.Add(123);
            Console.WriteLine($"a3[2] = {a3[2]}");
            Console.WriteLine($"a3.Count() = {a3.Count()}");

            a3.Add(432);
            a3.Add(987);

            try
            {
                Console.WriteLine(a3[5]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("accedere a un indice > _index lancia eccezione!");
                Console.WriteLine(ex.Message);
            }

            try
            {
                a3[5] = 765765;
            }
            catch (Exception ex)
            {
                Console.WriteLine("settare un valore in indice > _index lancia eccezione!");
                Console.WriteLine(ex.Message);
            }

            ExtensibleArray a4 = new ExtensibleArray(0);
            a4.Add(1);
            a4.Add(1);
            a4.Add(2);
            a4.Add(1);
            a4.Add(1);
            a4.Add(1);
            a4.Add(1);
            a4.Add(3);
            a4.Add(1);

            // [1 1 2 1 1 1 1 3 1] index: 9
            a4.Remove(1);
            // [2 3] index: 2

            Console.WriteLine($"a4[0] = {a4[0]}");
            Console.WriteLine($"a4[1] = {a4[1]}");
            Console.WriteLine($"a4.Count() = {a4.Count()}");

            a4.Add(5);
            a4.Add(7);
            a4.Add(1);
            // [2 3 5 7 1] index: 5

            //List<int> l = new List<int>();
            //for(int i = 0; i < 100; i++)
            //{
            //    l.Add(i);
            //}

            Console.Read();
        }
    }
}
