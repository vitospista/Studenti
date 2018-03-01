using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Employee> d = new Dictionary<string, Employee>();

            Employee e1 = new Employee
            {
                Name = "Mario",
                Surname = "Rossi",
                Birth = new DateTime(2018, 12, 2),
                Salary = 25000,
            };

            // sono equivalenti: se metto le grafe non servono le tonde.
            //Employee e1 = new Employee()
            //Employee e1 = new Employee { };

            d.Add(e1.Name, e1);

            Employee e11 = d["Mario"];

            // se uso una chiave non esistente nel dizionario,
            // il dizionario lancia eccezione
            try { Employee notExists = d["Luigi"]; }
            catch { }

            // se cerco di inserire una chiave già inserita,
            // il dizionario lancia eccezione.
            try { d.Add(e1.Name, e1); }
            catch { }

            // se uso 'var', C# a compile time cerca di capire
            // a che classe appartiente la variabile.
            // se non ce la fa, mi dà una serpentina rossa.
            // Questo meccanismo si chiama 'Type Inference'
            var e2 = new Employee
            {
                Name = "Anna",
                Surname = "Neri",
                Birth = new DateTime(1970, 1, 1),
                Salary = 35000
            };

            // posso usare il 'var':
            //   -) quando uso un costruttore: var e2 = new Employee();
            //   -) quando uso un valore statico: var s = "ciao";
            //   -) quando uso un metodo: var read = Console.ReadLine();
            //   -) quando devo creare una classe anonima:
            //          var anonymous = new { Code = "ASD", SubCode = "123qwe" };

            Console.WriteLine("foreach sull'intero Dictionary");
            foreach (var el in d)
            {
                Console.WriteLine($"Key: {el.Key}; Value: {el.Value}");
            }
            Console.WriteLine();

            Console.WriteLine("foreach sulla collezione di chiavi");
            foreach (var el in d.Keys)
            {
                Console.WriteLine($"Key: {el}");
            }
            Console.WriteLine();

            Console.WriteLine("foreach sulla collezione di valori");
            foreach (var el in d.Values)
            {
                Console.WriteLine($"Value: {el}");
            }
            Console.WriteLine();

            //Dictionary<string, Dictionary<string, List<string>>> dd1 =
            //    new Dictionary<string, Dictionary<string, List<string>>>();
            //Dictionary<string, string> dd2 = new Dictionary<string, string>();
            //Dictionary<string, List<Dictionary<string, string>>> dd3 =
            //    new Dictionary<string, List<Dictionary<string, string>>>();

            var dd1 = new Dictionary<string, Dictionary<string, List<string>>>();
            var dd2 = new Dictionary<string, string>();
            var dd3 = new Dictionary<string, List<Dictionary<string, string>>>();

            var connection = new SqlConnection();
            var command = new SqlCommand();
            
            Console.Read();
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public decimal Salary { get; set; }

        // la classe di base 'object' ha il metodo 'virtual ToString()',
        // che serve per restituire una rappresentazione di tipo stringa
        // dell'oggetto.
        // Il metodo è 'virtual' perché la classe 'object' dà
        // un'implementazione di default che restituisce il nome della classe.
        // Ma posso sovrascrivere questo metodo.
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }

    class WithVar
    {
        // NON posso usare 'var' per dichiarare i membri di una classe.
        // Posso usarlo SOLO per dichiarare variabili locali dei metodi.

        //var Campo1;
        //var Proprietà1 { get; set; }

        //public var AMethod(var arg1, var arg2)
        //{

        //}
    }
}
