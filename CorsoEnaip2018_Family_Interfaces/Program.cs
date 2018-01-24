using System;
using System.Collections.Generic;

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

    class Dad : Person, IComforter
    {
        public Dad(string name)
            : base(name)
        { }

        public void Comfort(Baby b)
        {
            Console.WriteLine($"Dad {Name} gives a caress to the Baby {b.Name}");
        }

        public void EscapeToMexico(Baby b)
        {
            // ? how can I do this?
        }

    }

    class Mum : Person, IComforter
    {
        public Baby Child { get; private set; }

        public Mum(string name)
            : base(name)
        { }

        public void MakeBaby(Dad d, string babyName)
        {
            Console.WriteLine($"Mum {Name} made a Baby with Dad {d.Name}");
            Child = new Baby(babyName);
            Child.AddComforter(this);
            Child.AddComforter(d);
        }

        public void Comfort(Baby b)
        {
            Console.WriteLine($"Mum {Name} comforts Baby {b.Name}");
        }
    }

    class Baby : Person
    {
        private List<IComforter> _comforters;

        public Baby(string name)
            : base(name)
        {
            _comforters = new List<IComforter>();
        }

        public void AddComforter(IComforter c)
        {
            _comforters.Add(c);
        }

        public void StartCrying()
        {
            Console.WriteLine($"Baby {Name} started crying.");

            foreach (var c in _comforters)
                c.Comfort(this);
        }
    }

    interface IComforter
    {
        void Comfort(Baby b);
    }
}
