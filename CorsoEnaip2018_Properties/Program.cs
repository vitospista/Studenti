using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseFieldsRange();   
            //UseMethodsRange();
            UsePropertiesRange();
            OnlyGetProperties();

            Console.Read();
        }

        private static void OnlyGetProperties()
        {
            throw new NotImplementedException();
        }

        private static void UsePropertiesRange()
        {
            Console.WriteLine("*** UsePropertiesRange ***");

            PropertiesRange pr = new PropertiesRange();
            pr.Max = 7;
            pr.Min = 4;
            Console.WriteLine($"Il 5 sta nel range? {pr.IsInRange(5)}");
            Console.WriteLine($"Il 2 sta nel range? {pr.IsInRange(2)}");
            Console.WriteLine($"Il 90 sta nel range? {pr.IsInRange(90)}");

            // Con le proprietà, ho un unico nome che racchiude
            // sia il getter che il setter
            // ==> non ho pericolo di sbagliare il nome.
            // ma mantengo la solidità dei metodi, con il controllo di accesso.
            //pr.Min = 10;
            Console.WriteLine($"Il 5 sta nel range? {pr.IsInRange(5)}");
            Console.WriteLine($"Il 2 sta nel range? {pr.IsInRange(2)}");
            Console.WriteLine($"Il 90 sta nel range? {pr.IsInRange(90)}");

            // con le properties, posso usare operatori come ++
            // che con i metodi Get e Set non mi erano possibili:
            var newMax = ++pr.Max;
            pr.Max += 10;
        }

        static void UseFieldsRange()
        {
            Console.WriteLine("*** UseFieldsRange ***");

            FieldsRange fr = new FieldsRange();
            fr.Min = 4;
            fr.Max = 7;
            Console.WriteLine($"Il 5 sta nel range? {fr.IsInRange(5)}");
            Console.WriteLine($"Il 2 sta nel range? {fr.IsInRange(2)}");
            Console.WriteLine($"Il 90 sta nel range? {fr.IsInRange(90)}");

            // il problema dei campi pubblici è che sono modificabili da chiunque
            // e non ho nessuno controllo sui valori di ingresso.
            fr.Min = 10;
            Console.WriteLine($"Il 5 sta nel range? {fr.IsInRange(5)}");
            Console.WriteLine($"Il 2 sta nel range? {fr.IsInRange(2)}");
            Console.WriteLine($"Il 90 sta nel range? {fr.IsInRange(90)}");
        }

        static void UseMethodsRange()
        {
            // usando metodi per recuperare o modificare il valore di un campo,
            // posso porre dei controlli in ingresso,
            // che TUTTI gli utilizzatori della classe
            // sono costretti ad usare.

            Console.WriteLine("*** UseMethodsRange ***");

            MethodsRange mr = new MethodsRange();
            mr.SetMax(7);
            mr.SetMin(4);
            Console.WriteLine($"Il 5 sta nel range? {mr.IsInRange(5)}");
            Console.WriteLine($"Il 2 sta nel range? {mr.IsInRange(2)}");
            Console.WriteLine($"Il 90 sta nel range? {mr.IsInRange(90)}");

            try
            {
                Console.WriteLine("Provo a settare un Min > Max");
                mr.SetMin(10);
                Console.WriteLine($"Il 5 sta nel range? {mr.IsInRange(5)}");
                Console.WriteLine($"Il 2 sta nel range? {mr.IsInRange(2)}");
                Console.WriteLine($"Il 90 sta nel range? {mr.IsInRange(90)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // con i metodi non posso usare operatori come ++.
            // devo implementare a mano:
            // Max++
            //var max = mr.GetMax();
            //mr.SetMax(max + 1);
            //return max;

            // ++Max
            //var max = mr.GetMax() + 1;
            //mr.SetMax(max);
            //return max;
        }

        // creare funzioni statiche di controllo non è utile
        // perché comunque un sviluppatore non è obbligato ad usarle.
        //static void SetMinOnRange(FieldsRange fr, int min)
        //{
        //    if (min > fr.Max)
        //        throw new Exception();
        //}
    }
}
