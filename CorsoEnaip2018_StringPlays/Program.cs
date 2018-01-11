using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_StringPlays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma per giocare con le stringhe");

            // stringa semplice
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            //per andare a capo metto '\r\n': \r\n
            Console.WriteLine("Hello\r\nworld");
            Console.WriteLine();

            // Il carattere "a capo" è diverso in base al sistema operativo.
            // Il sistema mi mette a disposizione questa proprietà:
            string newLine = Environment.NewLine;
            // In base al sistema su cui sono, il valore può essere diverso.

            Console.WriteLine("Hello" + newLine + "world!");
            Console.WriteLine();

            // tab
            Console.WriteLine("Hello\tworld\t!");
            Console.WriteLine("Ciao\tmondo\t!");
            Console.WriteLine("arrivederci\tmondo\t!");
            Console.WriteLine();

            //stampare un backslash \:
            Console.WriteLine("backslash: \\");

            Console.WriteLine();

            Console.WriteLine("Stampare un file path:");

            // file path with manual backslash:
            Console.WriteLine("C:\\Users\\triprog-1\\Documents\\Visual Studio 2015\\Projects\\CorsoEnaipNet2018");

            // file path with @:
            Console.WriteLine(@"C:\Users\triprog-1\Documents\Visual Studio 2015\Projects\CorsoEnaipNet2018");

            Console.WriteLine();

            int i1 = 5;
            int i2 = 7;
            int sum = i1 + i2;

            // manual concatenation
            Console.WriteLine("La somma di " + i1 + " + " + i2 + " = " + sum);

            // string.Format
            Console.WriteLine(string.Format("La somma di {0} + {1} = {2}", i1, i2, sum));

            string fiscalCode = "KRSMSM87...";
            Console.WriteLine(string.Format(
                "Fiscal code is: surname: {0}, name: {1}, birth: {2}",
                fiscalCode.Substring(0, 3),
                fiscalCode.Substring(3, 3),
                fiscalCode.Substring(6,2)));
            Console.WriteLine(string.Format(
                "Codice fiscale: cognome: {0}, nome: {1}, nascita: {2}",
                fiscalCode.Substring(0, 3),
                fiscalCode.Substring(3, 3),
                fiscalCode.Substring(6, 2)));
            // posso mettere gli argomenti nell'ordine che voglio
            Console.WriteLine(string.Format(
                "Codice fiscale: nome: {1}, cognome: {0}, , nascita: {2}",
                fiscalCode.Substring(0, 3),
                fiscalCode.Substring(3, 3),
                fiscalCode.Substring(6, 2)));

            // string interpolation
            Console.WriteLine($"La somma di {i1} + {i2} = {sum}");
            // senza $ iniziale diventa una striga hard-coded;
            Console.WriteLine("La somma di {i1} + {i2} = {sum}");

            Console.WriteLine();

            // i metodi sulle stringhe non modificano le stringhe stesse
            // ma creano ogni volta una nuova stringa.
            // insert
            string s = "una certa stringa";
            string ss = s.Insert(4, "bella");
            Console.WriteLine("stringa originale: " + s);
            Console.WriteLine("stringa modificata con l'insert: " + ss);

            // divide la stringa in un elenco di stringhe in base al separatore
            string toSplit = "maria,rossi,1987";
            string[] splitValues = toSplit.Split(',');

            // Trim elimina spazi bianchi all'inizio e/o alla fine

            // SubString
            string surname = "Li";
            // substring troppo lunga, questo lancia eccezione!
            //string formattedSurname = surname.Substring(0, 4);

            string formattedSurname = surname.Substring(0, Math.Min(4, surname.Length));

            //alternativa manuale:
            int length;
            if (surname.Length < 4)
                length = surname.Length;
            else
                length = 4;

            // operatore ternario -> meglio non usare, meno chiaro e meno debuggabile
            length = surname.Length < 4
                ? length = surname.Length
                : 4;

            Console.WriteLine($"Substring di {surname} è {formattedSurname}");

            Console.Read();
        }
    }
}
