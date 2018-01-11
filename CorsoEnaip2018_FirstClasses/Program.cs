using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_FirstClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;

            // questo non modifica 'i' originale del Main,
            // perché il valore di 'i' viene copiato
            // nella variable 'i' del metodo chiamato.
            Console.WriteLine("IncrementIntVoid");
            IncrementIntVoid(i);
            Console.WriteLine(i);

            // per incrementare 'i' avrei dovuto scrivere:
            Console.WriteLine("IncrementIntReturn");
            i = IncrementIntReturn(i);
            Console.WriteLine(i);

            Console.Read();
        }

        static void IncrementIntVoid(int i)
        {
            i++;
        }

        static int IncrementIntReturn(int i)
        {
            i = i + 1;
            return i;

            //return i++;
        }

        /*
         * n++:
         *   PostIncrement(int n)
         *       return n;
         *       n = n + 1;
         * ++n
         *   PreIncrement(int n)
         *       n = n + 1;
         *       return n;
         */
    }

    class Person
    {
        public int Age;
    }
}
