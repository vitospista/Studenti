using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Student("Pino", "Marsiglia")
            {
                StudentCode = "S123456",
            };

            var e = new Employee("Kent", "Beck");

            var list = new List<Person>();
            // posso inserire nella lista istanze di classi derivate!
            list.Add(s);
            list.Add(e);
            // però quando ripesco fuori i dati, sono dichiarati con la classe base!
            var p = list[0]; // var è Person! Non Student!

            // per ridichiarare sull'istanza pescata il tipo più specifico,
            // devo usare un cast:
            var ss = (Student)list[0];
            Console.WriteLine($"Lo studente in indice 0 ha StudentCode: {ss.StudentCode}");

            var ss1 = (Student)list[1];

            // il caso più estremo è una List<object>:
            // posso buttarci dentro tutto quello che voglio.
            var objectList = new List<object>();
            objectList.Add(129);
            var i = (int)objectList[0];
            objectList.Add("ciao");
            var str = (string)objectList[1];
            objectList.Add(s);
            objectList.Add(new object());

            Console.Read();
        }
    }

    class Person //se non indico una classe base, di default è 'object'
    {
        // senza costruttori, C# costruisce in automatico
        // un costruttore di default vuoto senza parametri:
        // public Person() { }

        // se io aggiungo un costruttore,
        // il costruttore di default NON viene messo.
        public Person(string name, string surname)
            // se non indico un costruttore della classe base,
            // C# aggiunge in automatico la chiamata
            // al costruttore di base senza parametri ': base()'
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; }
        public string Surname { get; }
        public DateTime Birth { get; set; }
    }

    class Student : Person
    {
        public Student(string name, string surname)
            : base(name, surname)
        { }

        // il costruttore della classe derivata NON è obbligato
        // ad avere gli stessi parametri del costruttore di base.
        // Semplicemente, deve CHIAMARE il costruttore di base con
        // i parametri del costruttore di base.
        // Ma il costruttore della classe derivata può avere i parametri che vuole:
        //public Student()
        //    : base("DefaultName", "DefaultSurname")
        //{ }

        public string StudentCode { get; set; }
        public CorsoUniversitario Corso { get; set; }
        public bool Outsider { get; set; }
    }

    class MarioRossiStudent : Student
    {
        public MarioRossiStudent()
            : base("Mario", "Rossi")
        { }
    }

    class MasterStudent : Student
    {
        public MasterStudent(string name, string surname)
            : base(name, surname)
        { }

        public string MasterName { get; set; }
    }

    public class CorsoUniversitario
    {
        public string Name { get; set; }
    }

    class Employee : Person
    {
        public Employee(string name, string surname)
            : base(name, surname)
        { }

        public decimal Salary { get; set; }
        public bool IsExternal { get; set; }
    }
}
