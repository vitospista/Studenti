using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_IntCalculator_FuncDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            IntCalculator();

            Console.Read();
        }

        // Ricopiare il progetto IntCalculator
        // Modificare il metodo ExecuteOperation:
        // Invece di uno switch,
        // usare un dizionario di stringhe e funzioni
        // le funzioni saranno del tipo: (int, int) ==> (int)

        // Dictionary:  (string) ===> ((int, int) ==> (int))
        // d["+"] ==> (a, b) => a + b

        private static Dictionary<string, Func<int, int, int>> operationDictionary;

        private static void IntCalculator()
        {
            // posso inizializzare un Dictionary
            // direttamente insieme ai suoi valori,
            // racchiudendo ogni coppia chiave-valore in parentesi grafe.
            operationDictionary = new Dictionary<string, Func<int, int, int>>
            {
                { "+", (a, b) => a + b },
                { "-", (a, b) => a - b },
                { "*", (a, b) => a * b },
                { "/", (a, b) => a / b },
            };

            // Scrivere questo: { "+", (a, b) => a + b }
            // è esattamente identico a scrivere questo:
            //operations.Add("+", (a, b) => a + b);

            Console.WriteLine("*** Calcolatrice ***");

            string mustContinue;

            do
            {
                int number1 = ReadIntSafe();

                string operation = ReadOperationSafe();

                int number2 = ReadIntSafe();

                // ripesco la Func che mi serve dal Dictionary,
                // passando come chiave una stringa.
                var operationFunction = operationDictionary[operation];

                int result = operationFunction(number1, number2);

                Console.WriteLine("risultato: " + result);

                Console.WriteLine("Vuoi continuare (s/n)? ");

                mustContinue = Console.ReadLine();

            } while (mustContinue == "s");
        }

        private static string ReadOperationSafe()
        {
            Console.Write("Inserisci l'operazione da eseguire: ");

            string operation = Console.ReadLine();

            // Non uso più questa lista,
            // perché ha valori duplicati rispetto al dizionario.
            //List<string> availableOperations = new List<string>
            //{
            //    "+", "-", "*", "/", "%"
            //};

            while (!operationDictionary.ContainsKey(operation))
            {
                Console.Write("Non hai inserito un'operazione valida! Riprova: ");
                operation = Console.ReadLine();
            }

            return operation;
        }

        private static void NumbersFromConsole_BadCode()
        {
            string read = Console.ReadLine();

            int number;
            int secondNumber;

            bool succeeded = int.TryParse(read, out number);

            if (succeeded)
            {
                string secondRead = Console.ReadLine();
                bool secondSucceeded = int.TryParse(secondRead, out secondNumber);
            }
            else
            {
                Console.WriteLine("Il valore inserito non è un numero! Riprova: ");
                read = Console.ReadLine();
                succeeded = int.TryParse(read, out number);

                string secondRead = Console.ReadLine();
                bool secondSucceeded = int.TryParse(secondRead, out secondNumber);
            }

            Console.WriteLine("Somma: " + (number + secondNumber));
        }

        private static void NumbersFromConsole_GoodCode()
        {
            Console.WriteLine("Questo programma calcola la somma di due numeri interi");

            int number1 = ReadIntSafe();
            int number2 = ReadIntSafe();

            Console.WriteLine("Somma: " + (number1 + number2));
        }

        private static int ReadIntSafe()
        {
            Console.Write("Inserisci un numero: ");

            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Valore non valido! Riprova: ");
            }

            return number;
        }
    }
}
