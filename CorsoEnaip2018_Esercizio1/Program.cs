using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Esercizio1
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = new List<Child>
            {
                new Child { Name = "Franz" },
                new Child { Name = "Karl" },
                new Child { Name = "Joseph" },
                new Child { Name = "Annah" },
            };

            foreach(var c in children)
                Console.WriteLine(c.Name);

            Console.Write("Fino a quanto devo contare? ");
            int count = int.Parse(Console.ReadLine());

            var deveContareIndex = (count-1) % children.Count;
            var deveContare = children[deveContareIndex];

            Console.WriteLine("Deve contare: " + deveContare.Name);
            //  0  1  2  3

            //  0  1  2  3
            //  4  5  6  7
            //  8  9 10 11 
            // 12 13 14 15

            // 0 + n*4
            // 1 + n*4
            // 2 + n*4
            // 3 + n*4 = C   ===>   C % 4 = 3

            Console.Read();
        }
    }

    class Child
    {
        public string Name { get; set; }
    }
}
