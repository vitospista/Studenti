using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LINQ = Language INtegrated Query
namespace CorsoEnaip2018_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3 };
            var list = new List<int> { 1, 2, 3 };

            var isAnyArray = array.Any(x => x > 2);
            var isAnyList = list.Any(x => x > 2);

            Console.WriteLine(isAnyArray);
            Console.WriteLine(isAnyList);

            Console.WriteLine("Ci sono elementi nella lista? " + list.Any());

            // Deferred Execution:
            // l'IEnumerable restituito da metodi come Select, Where, GroupBy, ...
            // non viene riempito subito,
            // ma solo quando uso il foreach su di esso.

            Console.WriteLine("*** SELECT ***");

            var strings = list.Select(x => x.ToString("000.00"));

            Console.WriteLine("Stampa del Select prima di aggiungere alla lista");
            foreach (var x in strings)
                Console.Write($"{x} ");
            Console.WriteLine();

            list.Add(4);

            Console.WriteLine("Stampa del Select dopo aver aggiunto alla lista");
            foreach (var x in strings)
                Console.Write($"{x} ");
            Console.WriteLine();

            Console.WriteLine("*** WHERE ***");

            var evens = list.Where(x => x % 2 == 0);

            Console.WriteLine("Stampa del Where prima di aver rimosso alla lista");
            foreach (var x in evens)
                Console.WriteLine(x);

            list.Remove(2);

            Console.WriteLine("Stampa del Where dopo aver rimosso dalla lista");
            foreach (var x in evens)
                Console.WriteLine(x);


            Console.WriteLine("*** GROUP BY ***");

            // forma "contratta"
            var groups = list.GroupBy(x => x % 2 == 0 ? "pari" : "dispari");
            // forma estesa
            groups = list.GroupBy(x =>
            {
                if (x % 2 == 0)
                    return "pari";
                else
                    return "dispari";
            });

            list.Add(8);

            foreach(var g in groups)
            {
                Console.Write($"Chiave: {g.Key}; Valori: {{ ");
                // così viene fuori anche una virgola finale che non voglio.
                //foreach(var i in g)
                //    Console.Write($"{i}, ");
                //Console.WriteLine("}");
                Console.Write(string.Join(", ", g));
                Console.WriteLine(" }");
            }


            Console.WriteLine("*** ORDER BY ***");

            var disordered = new[] { 5, 2, 8, 1, 10, 2 };

            var ordered = disordered.OrderBy(x => x);
            Console.WriteLine("Stampa del OrderBy");
            foreach (var x in ordered)
                Console.Write($"{x} ");
            Console.WriteLine();

            Console.WriteLine("*** DISTINCT ***");

            var distincts = ordered.Distinct();
            Console.WriteLine("Stampa del Distinct");
            foreach (var x in distincts)
                Console.Write($"{x} ");
            Console.WriteLine();


            Console.WriteLine("*** SELECT MANY ***");
            var people = new List<Person>
            {
                new Person
                {
                    Name = "Adam",
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Fuffi", Type = PetType.Cat },
                        new Pet { Name = "Whiskey", Type = PetType.Dog }
                    }
                },
                new Person
                {
                    Name = "Bob",
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Bobby", Type = PetType.Dog },
                        new Pet { Name = "Palla di Pelo", Type = PetType.Cat },
                        new Pet { Name = "Fox", Type = PetType.Dog },
                    }
                },
                new Person
                {
                    Name = "Charlie",
                    Pets = new List<Pet>
                    {
                        new Pet { Name = "Batuffolo", Type = PetType.Cat },
                    }
                },
            };
            var pets = people.SelectMany(x => x.Pets);
            foreach (var p in pets)
                Console.Write($"{p.Name}, ");
            Console.WriteLine();


            Console.WriteLine("*** CALDERONE ***");

            var filteredPets = people
                .Where(x => !x.Name.Contains('c'))
                .SelectMany(x => x.Pets)
                .Where(x => x.Type == PetType.Dog)
                .Select(x => x.Name)
                .OrderBy(x => x);

            foreach(var fp in filteredPets)
                Console.Write($"{fp}, ");
            Console.WriteLine();

            Console.Read();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
    }

    enum PetType
    {
        Cat,
        Dog
    }
}
