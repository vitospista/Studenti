using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>
            {
                "s1", "s2", "s3"
            };

            // questo è il modo più generale possibile
            // per iterare su una collezione di dati,
            // anche quando NON ho l'indice numerico,
            // o non so a priori quanti elementi ha la collezione
            Console.WriteLine("en");
            List<string>.Enumerator en = strings.GetEnumerator();
            while(en.MoveNext())
            {
                string s = en.Current;
                Console.WriteLine(s);
            }

            // l'Enumerator tiene un riferimento alla collezione,
            // e un riferimento all'elemento corrente a cui è arrivato.
            // posso chiamare a mano il MoveNext, e i suoi metodi.
            //Console.WriteLine("en2");
            //List<string>.Enumerator en2 = strings.GetEnumerator();
            //en2.MoveNext();
            //Console.WriteLine(en2.Current);

            // il foreach dietro le quinte
            // crea un Enumerator che itera sulla lista.
            foreach(string s in strings)
            {
                Console.WriteLine(s);
            }

            Console.Read();

            // Esercizio:
            /*
             * Prendere il project sulla lista di Employee
             * e trasformare tutti i for in foreach.
             * 
             * Studiare la classe Dictionary.
             */
        }
    }
}
