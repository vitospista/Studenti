using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new[]
            {
                new Boy { Name = "Adam", Age = 20, IsSober = false },
                new Boy { Name = "Bob", Age = 19, IsSober = false },
                new Boy { Name = "Charlie", Age = 30, IsSober = false }
            };

            bool areAllAdults = list.All(x => x.Age > 18);
            if (areAllAdults)
                Console.WriteLine("Il gruppo può entrare in discoteca.");
            else
                Console.WriteLine("Al gruppo non rimane che passare la serata in bar.");

            Console.WriteLine();

            bool isAnySober = list.Any(x => x.IsSober);
            if (isAnySober)
                Console.WriteLine("Il gruppo torna a casa da solo in macchina.");
            else
                Console.WriteLine("Il gruppo deve chiamare un taxi.");

            list.Any(x => x.IsSober);
            list.All(x => x.Age > 18);

            Console.Read();
        }
    }

    class Boy
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSober { get; set; }
    }


    static class ListExtension
    {
        public static bool Any<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            foreach (var el in list)
                if (condition(el))
                    return true;

            return false;
        }

        public static bool All<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            foreach (var el in list)
                if (!condition(el))
                    return false;

            return true;
        }
    }
}
