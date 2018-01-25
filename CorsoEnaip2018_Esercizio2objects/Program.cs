using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Esercizio2objects
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

            children[0].AddFriend(children[1]);
            children[0].AddFriend(children[2]);

            foreach (var c in children)
                Console.WriteLine(c);

            Console.Read();
        }
    }

    class Child
    {
        public Child(string name)
        {
            Name = name;
            friends = new List<Child>();
        }

        public void AddFriend(Child friend)
        {
            if (!friends.Contains(friend))
            {
                friends.Add(friend);
                friend.AddFriend(this);
            }
        }

        public string Name { get; }

        public IEnumerable<Child> Friends
        {
            get { return friends; }
        }
        private List<Child> friends;

        public override string ToString()
        {
            // voglio stampare una cosa tipo: "Franz has these friends: Annah, Johannes, Odino
            return $"{Name} has these friends: "
                + string.Join(", ", Friends.Select(x => x.Name));
        }
    }
}
