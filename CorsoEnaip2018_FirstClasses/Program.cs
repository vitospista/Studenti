using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_FirstClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;

            // questo non modifica 'i' originale del Main,
            // perché il valore di 'i' viene copiato
            // nella variable 'i' del metodo chiamato.
            Console.WriteLine("IncrementIntVoid");
            IncrementIntVoid(i);
            Console.WriteLine(i);

            // per incrementare 'i' avrei dovuto scrivere:
            Console.WriteLine("IncrementIntReturn");
            i = IncrementIntReturn(i);
            Console.WriteLine(i);

            int i2 = i;
            Console.WriteLine($"Prima di fare i++: i = {i} e i2 = {i2}");
            i++;
            Console.WriteLine($"Dopo aver fatto i++: i = {i} e i2 = {i2}");

            Person p = new Person();
            Console.WriteLine($"Età iniziale di p: {p.Age}");
            p.Age = 27;
            IncrementIntVoid(p.Age);
            Console.WriteLine($"Età di p dopo IncrementIntVoid: {p.Age}");

            IncrementPersonAge(p);
            Console.WriteLine($"Età di p dopo IncrementPersonAge: {p.Age}");

            Person p2 = p;
            Console.WriteLine(
                $"Prima di fare p.Age++: p.Age = {p.Age} e p2.Age = {p2.Age}");
            p.Age++;
            Console.WriteLine(
                $"Dopo aver fatto p.Age++: p.Age = {p.Age} e p2.Age = {p2.Age}");

            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = list1;

            list1.Add(4);

            Console.WriteLine("list2 contiene il 4? " + (list2.Contains(4)));

            // Per creare un'intera nuova copia di Person,
            // posso usare il metodo Clone dell'interfaccia ICloneable
            Person clone = (Person)p.Clone();
            Console.WriteLine($"Age del clone prima di p.Age++: {clone.Age}");
            p.Age++;
            Console.WriteLine($"Age del clone dopo p.Age++: {clone.Age}");

            Console.Read();
        }

        static void IncrementIntVoid(int i)
        {
            i++;
        }

        static int IncrementIntReturn(int i)
        {
            i = i + 1;
            return i;

            //return i++;
        }

        static void IncrementPersonAge(Person p)
        {
            p.Age++;
        }

        /*
         * n++:
         *   PostIncrement(int n)
         *       return n;
         *       n = n + 1;
         * ++n
         *   PreIncrement(int n)
         *       n = n + 1;
         *       return n;
         */
    }

    class Person
    {
        public int Age;

        public object Clone()
        {
            Person p = new Person();
            p.Age = this.Age;
            return p;
        }
    }
}
