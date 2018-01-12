using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sexes = new string[2];
            sexes[0] = "M";
            sexes[1] = "F";
            Console.WriteLine("First Sex: " + sexes[0]);
            Console.WriteLine("Second Sex: " + sexes[1]);

            int[] ints = new int[10];
            ints[0] = 2;
            ints[1] = 4;
            ints[2] = 6;
            // ...
            int[] intsTo100 = new int[100];
            // tutti i valori sono inizializzati al valore di default.
            Console.WriteLine(intsTo100[45]);
            Console.WriteLine(intsTo100[72]);

            // come riempio un array con tutti i numeri da 1 a 100?
            for(int i = 0; i < 100; i++)
            {
                intsTo100[i] = i + 1;
            }

            for(int i = 0; i < 100; i++)
            {
                Console.Write(intsTo100[i] + " ");
            }

            // un indice fuori dal range lancia eccezione!
            //Console.WriteLine(intsTo100[1000]);

            int[] first50even = createFirst50evenNumbers();

            int[] firstfifteen7multiplies = createFirst7multiplies(15);

            Console.Read();
        }

        static int[] createFirst50evenNumbers()
        {
            int[] a = new int[50];

            for(int i = 0; i < 50; i++)
            {
                a[i] = i * 2;
            }

            return a;
        }

        static int[] createFirst7multiplies(int n)
        {
            //   7   14  21  28  ...  7n 
            //   0   1   2   3   4   ...   n

            int[] a = new int[n];

            for(int i = 0; i < n; i++)
            {
                a[i] = 7 * (i + 1);
            }

            return a;
        }
    }
}
