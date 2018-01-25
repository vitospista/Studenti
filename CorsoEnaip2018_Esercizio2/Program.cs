using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Esercizio2
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = new List<Child>
            {
                new Child("Franz"),
                new Child("Karl"),
                new Child("Joseph"),
                new Child("Annah"),
            };

            MakeFriends(children[0], children[1]);
            MakeFriends(children[0], children[3]);

            foreach(var c in children)
                Console.WriteLine(c);

            Console.Read();
        }

        static void MakeFriends(Child c1, Child c2)
        {
            c1.Friends.Add(c2);
            c2.Friends.Add(c1);
        }
    }

    class Child
    {
        public Child(string name)
        {
            Name = name;
            Friends = new List<Child>();
        }

        public string Name { get; set; }
        public List<Child> Friends { get; }

        public override string ToString()
        {
            // voglio stampare una cosa tipo: "Franz has these friends: Annah, Johannes, Odino
            return $"{Name} has these friends: "
                + string.Join(", ", Friends.Select(x => x.Name));
        }
    }
}
