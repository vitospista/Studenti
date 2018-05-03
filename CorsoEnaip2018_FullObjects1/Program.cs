using System;
using System.Collections.Generic;

namespace CorsoEnaip2018_FullObjects1
{
    class Program
    {
        static void Main(string[] args)
        {
            OddEven();


            Console.Read();
        }

        private void OddEven()
        {
            Console.Write("Insert a number: ");
            var numberString = Console.ReadLine();
            var number = int.Parse(numberString);

            //var message = "The number is ";

            //if (number % 2 == 0)
            //{
            //    message += "even";
            //}
            //else
            //{
            //    message += "odd";
            //}

            // versione più simile a programmazione ad oggetti
            var dict = new Dictionary<bool, string>
            {
                { true, "even" },
                { false, "odd" },
            };

            var message = "The number is " + dict[number % 2 == 0];

            Console.WriteLine(message);
        }

        private void CompareTwoInts()
        {
            Console.Write("Insert the first number: ");
            var numberString1 = Console.ReadLine();
            var number1 = int.Parse(numberString1);

            Console.Write("Insert the second number: ");
            var numberString2 = Console.ReadLine();
            var number2 = int.Parse(numberString2);

            //if (number1 > number2)
            //    Console.WriteLine("The first is greater than the second");
            //else if (number1 < number2)
            //    Console.WriteLine("The first is less than the second");
            //else
            //    Console.WriteLine("The two numbers are equal");

            var dict = new Dictionary<int, string>
            {
                { 1, "The first is greater than the second" },
                { -1, "The first is less than the second" },
                { 0, "The two numbers are equal" },
            };

            var result = Comparer<int>.Default.Compare(number1, number2);

            var message = dict[result];

            Console.WriteLine(message);

            //così trovo il massimo in modo "procedurale"
            var max = Math.Max(number1, number2);

            // la pura programmazione ad oggetti vorrebbe:
            //max = new Max(number1, number2).Value;
            // ma usare un paradigma in modo troppo da puristi
            // può creare più problemi di quanti ne risolva.
        }

        public static int Max(int x, int y)
        {
            return x > y ? x : y;
        }
    }

    public class Max
    {
        private static Dictionary<bool, Func<int, int, int>> _dict
            = new Dictionary<bool, Func<int, int, int>>
        {
            { true, (x, y) => x },
            { false, (x, y) => y },
        };

        private int _Value;

        public Max(int x, int y)
        {
            _Value = _dict[x > y](x, y);
        }

        public int Value
        {
            get { return _Value; }
        }
    }

    abstract class Animal
    {
        public abstract string Speak();
    }

    class Dog : Animal
    {
        public override string Speak()
        {
            return "Uof!";
        }
    }

    class Cat : Animal
    {
        public string Name { get; set; }
        public string Nickname { get; set; }

        public override string Speak()
        {
            return "Meow!";
        }
    }

    // Object-oriented C
}
