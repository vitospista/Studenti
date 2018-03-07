using System;
using System.ComponentModel;
using System.Reflection;

namespace CorsoEnaip2018_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2 modi per accedere al tipo di un oggetto:
            // statico: typeof(C)
            // dinamico: c.GetType()
            var type = typeof(C);

            // classe base: MemberInfo
            // con le informazioni di base sul membro di una classe.
            // da MemberInfo derivano PropertyInfo, MethodInfo, ...
            var properties = type.GetProperties();
            C.NumberOfInstances = 17;
            var noiPropertyInfo = type.GetProperty(nameof(C.NumberOfInstances));
            var value = noiPropertyInfo.GetValue(null);
            noiPropertyInfo.SetValue(null, 18);
            value = noiPropertyInfo.GetValue(null);

            var oldInstance = new C
            {
                Id = 1,
                Value = "Some Value",
                DeliveryDate = new DateTime(2018, 7, 3),
                Cost = 150000,
            };

            var newInstance = new C
            {
                Id = 1,
                Value = "Some other value",
                DeliveryDate = new DateTime(2018, 7, 3),
                Cost = null,
            };

            Console.WriteLine("Le proprietà cambiate sono:");

            //ManuallyCompare(oldInstance, newInstance);

            ReflectionCompare(oldInstance, newInstance);

            Console.Read();
        }

        private static void ManuallyCompare(C oldInstance, C newInstance)
        {
            // Faccio la comparazione a mano
            // proprietà dopo proprietà.

            // problemi:
            // enorme duplicazione delle logiche.
            // Un bug trovato su un pezzo va riparato su TUTTI gli altri
            // Moltiplico per N la possibilità di fare errori.

            if (newInstance.Id != oldInstance.Id)
            {
                Console.WriteLine(
                    "L'Id è cambiato con valore: " + newInstance.Id);
            }
            if (newInstance.Value != oldInstance.Value)
            {
                Console.WriteLine(
                    "Il Value è cambiato con valore: " + newInstance.Value);
            }
            if (newInstance.DeliveryDate != oldInstance.DeliveryDate)
            {
                Console.WriteLine(
                    "La DeliveryDate è cambiata con valore: " + newInstance.DeliveryDate);
            }
            if (newInstance.Cost != oldInstance.Cost)
            {
                if (newInstance.Cost == null)
                {
                    Console.WriteLine("Il valore di Cost è stato rimosso");
                }
                else
                {
                    Console.WriteLine(
                        "Il Cost è cambiato con valore: " + newInstance.Cost);
                }
            }
        }

        private static void ReflectionCompare<T>(T oldInstance, T newInstance)
        {
            var properties = typeof(T).GetProperties(
                BindingFlags.Instance | BindingFlags.Public);

            foreach(var pi in properties)
            {
                var oldValue = pi.GetValue(oldInstance);
                var newValue = pi.GetValue(newInstance);

                if (!object.Equals(newValue, oldValue))
                {
                    if (newValue == null)
                    {
                        Console.WriteLine(
                            $"Il valore di {pi.Name} è stato rimosso.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Il valore di {pi.Name} è cambiato in: {newValue}.");
                    }
                }
            }
        }
    }

    class C
    {
        public static int NumberOfInstances { get; set; }
        public static string ApplicationName { get; set; }

        public int Id { get; set; }

        public string Value { get; set; }

        [DisplayName("Data di Consegna")]
        public DateTime DeliveryDate { get; set; }

        [DisplayName("Costo di Produzione")]
        public decimal? Cost { get; set; }

        public int Double(int i)
        {
            return i * 2;
        }

        public override bool Equals(object obj)
        {
            var other = obj as C;

            if (other == null)
                return false;

            return Id == other.Id;
        }
    }

    class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Date;

            if (other == null)
                return false;

            return Year == other.Year &&
                Month == other.Month &&
                Day == other.Day;
        }
    }

    class O
    {
        public static bool Equals(object o1, object o2)
        {
            if (o1 == null && o2 == null)
                return true;

            return o1.Equals(o2);
        }
    }
}
