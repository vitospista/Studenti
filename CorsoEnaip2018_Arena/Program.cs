using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            var characters = new List<Character>
            {
                new Warrior
                {
                    DamagePercentage = 20,
                    LifePoints = 100,
                    Name = "Korn il Furioso",
                    Speed = 10
                },
                new Wizard
                {
                    LifePoints = 70,
                    MaxPower = 60,
                    Name = "Gandalf il Decrepito",
                    Speed = 4
                },
                new Ogre
                {
                    Damage = 15,
                    LifePoints = 80,
                    Name = "Orky",
                    Speed = 8,
                }
            };
            
            foreach(var c in characters)
            {
                c.Attacked += (s, e) =>
                {
                    Console.WriteLine($"'{((Character)s).Name}' attacked with a strength of {e.Damages} lp.");
                };
                c.Injuried += (s, e) =>
                {
                    Console.WriteLine($"'{((Character)s).Name}' has {e.LifePointsRemained} lp remained.");
                };
                c.Died += (s, e) =>
                {
                    Console.WriteLine($"'{((Character)s).Name}' died.");
                };
            }

            var a = new Arena();

            a.Insert(characters);

            a.Finished += (s, e) =>
            {
                Console.WriteLine(
                    "Il gioco è finito. Ha vinto " + e.Winner.Name);
            };

            a.StartFight();

            Console.Read();
        }
    }

    //class Arena
    //{
    //    private Character[] _characters;

    //    private Random _r;

    //    public Arena()
    //    {
    //        _r = new Random();
    //    }

    //    public void Insert(IEnumerable<Character> characters)
    //    {
    //        if (characters == null)
    //            throw new ArgumentNullException(nameof(characters));

    //        _characters = characters
    //            .OrderByDescending(x => x.Speed)
    //            .ToArray();
    //    }

    //    public void StartFight()
    //    {
    //        while (true)
    //        {
    //            for (int i = 0; i < _characters.Length; i++)
    //            {
    //                var c = _characters[i];

    //                if (c.IsAlive)
    //                {
    //                    int attackedIndex;

    //                    do
    //                    {
    //                        attackedIndex = _r.Next(_characters.Length);
    //                    }
    //                    while (attackedIndex == i || !_characters[attackedIndex].IsAlive);

    //                    var attacked = _characters[attackedIndex];

    //                    c.Attack(attacked);

    //                    if (_characters.Count(x => x.IsAlive) == 1)
    //                    {
    //                        var winner = _characters.First(x => x.IsAlive);
    //                        Finished?.Invoke(this, new FinishedEventArgs { Winner = winner });
    //                        return;
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public event EventHandler<FinishedEventArgs> Finished;
    //}

    class Arena
    {
        private List<Character> _characters;

        private Random _r;

        public Arena()
        {
            _r = new Random();
        }

        public void Insert(IEnumerable<Character> characters)
        {
            if (characters == null)
                throw new ArgumentNullException(nameof(characters));

            _characters = characters
                .OrderByDescending(x => x.Speed)
                .ToList();
        }

        public void StartFight()
        {
            while (true)
            {
                for (int i = 0; i < _characters.Count; i++)
                {
                    var c = _characters[i];

                    int attackedIndex;
                    Character attacked;

                    do
                    {
                        attackedIndex = _r.Next(_characters.Count);
                        attacked = _characters[attackedIndex];
                    }
                    while (attacked == c || !attacked.IsAlive);

                    c.Attack(attacked);

                    if (!attacked.IsAlive)
                        _characters.Remove(attacked);

                    if (_characters.Count == 1)
                    {
                        var winner = _characters.First();
                        Finished?.Invoke(this, new FinishedEventArgs { Winner = winner });
                        return;
                    }
                }

                //foreach(var c in _characters.ToArray())
                //{
                //    if (!c.IsAlive)
                //        continue;

                //    int attackedIndex;
                //    Character attacked;

                //    do
                //    {
                //        attackedIndex = _r.Next(_characters.Count);
                //        attacked = _characters[attackedIndex];
                //    }
                //    while (attacked == c || !attacked.IsAlive);

                //    c.Attack(attacked);

                //    if (!attacked.IsAlive)
                //        _characters.Remove(attacked);

                //    if (_characters.Count == 1)
                //    {
                //        var winner = _characters.First();
                //        Finished?.Invoke(this, new FinishedEventArgs { Winner = winner });
                //        return;
                //    }
                //}
            }
        }

        public event EventHandler<FinishedEventArgs> Finished;
    }

    class FinishedEventArgs : EventArgs
    {
        public Character Winner { get; set; }
    }

    abstract class Character
    {
        public int LifePoints { get; set; }

        public int Speed { get; set; }

        public string Name { get; set; }

        public bool IsAlive
        {
            get { return LifePoints > 0; }
        }

        public void Attack(Character other)
        {
            var damage = calculateDamage(other);

            Attacked?.Invoke(this, new AttackEventArgs { Damages = damage });

            other.Receive(damage);
        }

        public void Receive(int damage)
        {
            // modo 1
            var effectiveDamage = Math.Min(LifePoints, damage);
            LifePoints -= effectiveDamage;

            // modo 2
            //LifePoints -= damage;
            //if (LifePoints < 0)
            //    LifePoints = 0;

            Injuried?.Invoke(this, new InjuriedEventArgs { LifePointsRemained = LifePoints });

            if (LifePoints == 0)
                Died?.Invoke(this, null);
        }

        protected abstract int calculateDamage(Character c);

        public event EventHandler<AttackEventArgs> Attacked;
        public event EventHandler<InjuriedEventArgs> Injuried;
        public event EventHandler<EventArgs> Died;
    }

    class Warrior : Character
    {
        public int DamagePercentage { get; set; }

        protected override int calculateDamage(Character c)
        {
            var damage = (int)(c.LifePoints * ((double)DamagePercentage / 100));

            return Math.Max(damage, 5);
        }
    }

    class Wizard : Character
    {
        private static Random _r;

        static Wizard()
        {
            _r = new Random();
        }

        public int MaxPower { get; set; }

        protected override int calculateDamage(Character c)
        {
            var damage = (int)(_r.NextDouble() * MaxPower);

            return damage;
        }
    }

    class Ogre : Character
    {
        public int Damage { get; set; }

        protected override int calculateDamage(Character c)
        {
            return Damage;
        }
    }

    class AttackEventArgs : EventArgs
    {
        public int Damages { get; set; }
    }

    class InjuriedEventArgs : EventArgs
    {
        public int LifePointsRemained { get; set; }
    }
}
