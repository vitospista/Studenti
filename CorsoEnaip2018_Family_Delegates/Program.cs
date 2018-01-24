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
            mum.Child.StartCrying();
            mum.Child.StartCrying();
            mum.Child.StartCrying();

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
            b.RemoveComforter(EscapeToMexico);

            Console.WriteLine($"{Name} escapes to Mexico!");
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
            Child.AddComforter(Comfort);
            Child.AddComforter(d.EscapeToMexico);
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
                b.RemoveComforter(Comfort);
            }
        }
    }

    class Baby : Person
    {
        private List<CryHandler> _comforters;

        public Baby(string name)
            : base(name)
        {
            _comforters = new List<CryHandler>();
        }

        public void AddComforter(CryHandler h)
        {
            _comforters.Add(h);
        }

        public void RemoveComforter(CryHandler h)
        {
            _comforters.Remove(h);
        }

        public void StartCrying()
        {
            Console.WriteLine($"{Name} started crying.");

            if (_comforters.Count > 0)
            {
                foreach (var h in _comforters.ToList())
                    h.Invoke(this);

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
