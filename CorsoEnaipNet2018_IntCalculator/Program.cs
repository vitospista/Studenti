using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaipNet2018_IntCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //HardCodedNumbers();
            //NumbersFromConsole_BadCode();
            //NumbersFromConsole_GoodCode();
            IntCalculator();

            Console.Read();
        }

        private static void IntCalculator()
        {
            Console.WriteLine("*** Calcolatrice ***");

            string mustContinue;

            do
            {
                int number1 = ReadIntSafe();

                string operation = ReadOperationSafe();

                int number2 = ReadIntSafe();

                int result = ExecuteOperation(number1, operation, number2);

                Console.WriteLine("risultato: " + result);

                Console.WriteLine("Vuoi continuare (s/n)? ");

                mustContinue = Console.ReadLine();

            } while (mustContinue == "s");
        }

        private static int ExecuteOperation(int number1, string operation, int number2)
        {
            switch(operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    return number1 / number2;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static string ReadOperationSafe()
        {
            Console.Write("Inserisci l'operazione da eseguire: ");

            string operation = Console.ReadLine();

            // un po' troppo verboso
            //while(operation != "+" &&
            //    operation != "-" &&
            //    operation != "*" &&
            //    operation != "/")
            //{
            //    Console.Write("Non hai inserito un'operazione valida! Riprova: ");
            //    operation = Console.ReadLine();
            //}

            List<string> availableOperations = new List<string>
            {
                "+", "-", "*", "/"
            };

            while(!availableOperations.Contains(operation))
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
            //Qui ci sono ancora duplicazioni:

            //Console.WriteLine("Inserisci un numero: ");
            //string read = Console.ReadLine();
            //int number;
            //bool succeeded = int.TryParse(read, out number);
            //while (!succeeded)
            //{
            //    Console.WriteLine("Il valore inserito non è un numero! Riprova: ");
            //    read = Console.ReadLine();
            //    succeeded = int.TryParse(read, out number);
            //}
            //return number;

            Console.Write("Inserisci un numero: ");

            int number;

            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Valore non valido! Riprova: ");
            }

            return number;
        }

        private static void HardCodedNumbers()
        {
            //dichiarazione
            int oreTeoria;
            //assegnazione
            oreTeoria = 194;

            //dichiarazione e assegnazione insieme
            int orePratica = 136;

            Console.WriteLine("Ore totali all'ENAIP: " + (oreTeoria + orePratica));
        }
    }
}
