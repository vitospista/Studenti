using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Family
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A long long time ago, in a galaxy far away...");

            var mum = new Mum("Leila");
            var dad = new Dad("Han Solo");
            mum.MakeBaby(dad, "Kylo Ren");
            mum.Child.StartsCrying();
            mum.Child.StartsCrying();
            mum.Child.StartsCrying();
            mum.Child.Cries += b =>
            {
                Console.WriteLine($"The Force feels the evil of {mum.Child.Name}");
                Console.WriteLine($"The Force balances the evil with the birth of Rey");
            };
            mum.Child.StartsCrying();

            Console.Read();
        }
    }

    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
    }

    class Dad : Person
    {
        public Dad(string name)
            : base(name)
        { }

        public void Comfort(Baby b)
        {
            Console.WriteLine($"{Name} gives a caress to the {b.Name}");
        }

        public void EscapeToMexico(Baby b)
        {
            Console.WriteLine($"{Name} escapes to Mexico!");

            b.Cries -= EscapeToMexico;
        }
    }

    class Mum : Person
    {
        private bool _isExhausted;

        public Baby Child { get; private set; }

        public Mum(string name)
            : base(name)
        { }

        public void MakeBaby(Dad d, string babyName)
        {
            Console.WriteLine($"{Name} made a Baby with {d.Name}");
            Child = new Baby(babyName);
            // Ad un evento posso associare metodi con l'operatore +=.
            // Quindi quando l'evento viene invocato,
            // i metodi "agganciati" vengono chiamati. In ordine.
            Child.Cries += Comfort;
            Child.Cries += d.EscapeToMexico;
        }

        public void Comfort(Baby b)
        {
            Console.WriteLine($"{Name} comforts {b.Name}");

            if (!_isExhausted)
            {
                _isExhausted = true;
            }
            else
            {
                // Posso rimuovere metodi da un evento, con l'operatore -=
                b.Cries -= Comfort;
            }
        }
    }

    class Baby : Person
    {
        public Baby(string name)
            : base(name)
        { }

        // Un'evento va dichiarato come "campo"
        // e non serve inizializzarlo.
        public event CryHandler Cries;

        public void StartsCrying()
        {
            Console.WriteLine($"{Name} started crying.");

            if (Cries != null && Cries.GetInvocationList().Length > 0)
            {
                // solo la classe che ha dichiarato l'evento
                // può invocarlo.
                // Fuori dalla classe il metodo Invoke non esiste.
                // Il metodo Invoke rispetta il Delegate dell'evento.
                Cries.Invoke(this);

                Console.WriteLine($"{Name} has been comforted.");
            }
            else
            {
                Console.WriteLine($"Nobody wants to comfort {Name}!");
                Console.WriteLine($"{Name} goes to the Dark Side!");
            }
        }
    }

    delegate void CryHandler(Baby b);
}
