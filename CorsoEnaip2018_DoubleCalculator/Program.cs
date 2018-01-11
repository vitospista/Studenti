using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_DoubleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleCalculator();
        }

        private static void DoubleCalculator()
        {
            string proceed;

            do
            {
                double d1 = ReadDoubleSafe();

                string operation = ReadOperationSafe();

                double d2 = ReadDoubleSafe();

                double result = ExecuteOperation(d1, operation, d2);

                Console.WriteLine("Risultato: " + result);

                Console.Write("Vuoi fare un altro calcolo (s/n)? ");

                proceed = Console.ReadLine();

            } while (proceed == "s");
            
        }

        private static double ReadDoubleSafe()
        {
            Console.Write("Inserisci un numero: ");

            double number;

            while(!double.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Il valore inserito non è un numero valido! Riprova: ");
            }

            return number;
        }

        private static string ReadOperationSafe()
        {
            Console.Write("Inserisci l'operazione da eseguire: ");

            var list = new List<string>
            {
                "+", "-", "*", "/",
            };

            string operation;

            while(!list.Contains(operation = Console.ReadLine()))
            {
                Console.Write("Il valore inserito non è un'operazione valida! Riprova: ");
            }

            return operation;
        }

        private static double ExecuteOperation(double d1, string operation, double d2)
        {
            switch(operation)
            {
                case "+": return d1 + d2;
                case "-": return d1 - d2;
                case "*": return d1 * d2;
                case "/": return d1 / d2;
                default: throw new InvalidOperationException();
            }
        }
    }
}
