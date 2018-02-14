using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_DvdStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new SubscriptionFactory();

            var id1 = UserManager.Instance.AddUser();
            var u1 = UserManager.Instance.GetUser(id1);
            u1.Subscription = f.Create("money", 100);
            u1.Subscription.Rented += (s, e) =>
            {
                Console.WriteLine(e);
            };

            var rented1 = u1.Subscription.ApplyRent(new Rent
            {
                Title = "Die Hard",
                Price = 3
            });
            var rented2 = u1.Subscription.ApplyRent(new Rent
            {
                Title = "Zoologic behavior of the Mongolian Kangaroo",
                Price = 150
            });

            var id2 = UserManager.Instance.AddUser();
            var u2 = UserManager.Instance.GetUser(id2);

            var rented3 = u2.Subscription.ApplyRent(new Rent
            {
                Title = "Die Hard",
                Price = 3
            });

            u2.Subscription = f.Create("count", 5);

            var rented4 = u2.Subscription.ApplyRent(new Rent
            {
                Title = "Die Hard",
                Price = 3
            });

            Console.Read();
        }
    }

    public class User
    {
        public User(int id)
        {
            Id = id;
            Subscription = new NullSubscription();
        }

        public int Id { get; }

        public Subscription Subscription { get; set; }
    }

    public class Rent
    {
        public string Title { get; set; }
        public double Price { get; set; }
    }

    public interface ISubscription
    {
        bool ApplyRent(Rent rent);
    }

    public abstract class Subscription : ISubscription
    {
        public bool ApplyRent(Rent rent)
        {
            if (isValid(rent))
            {
                apply(rent);
                Rented?.Invoke(this, getRentedMessage());
                return true;
            }
            else
            {
                return false;
            }
        }

        protected abstract bool isValid(Rent rent);
        protected abstract void apply(Rent rent);
        protected abstract string getRentedMessage();

        public event EventHandler<string> Rented;
    }
    public class MoneySubscription : Subscription
    {
        private double remaining;

        public MoneySubscription(int total)
        {
            remaining = total;
        }

        protected override bool isValid(Rent rent)
        {
            return remaining > rent.Price;
        }

        protected override void apply(Rent rent)
        {
            remaining -= rent.Price;
        }

        protected override string getRentedMessage()
        {
            return $"You have {remaining} remaining money";
        }
    }
    public class CountSubscription : Subscription
    {
        private int count;

        public CountSubscription(int count)
        {
            this.count = count;
        }

        protected override bool isValid(Rent rent)
        {
            return count > 0;
        }

        protected override void apply(Rent rent)
        {
            count--;
        }

        protected override string getRentedMessage()
        {
            return $"You have {count} remaining rents";
        }
    }
    public class NullSubscription : Subscription
    {
        protected override void apply(Rent rent)
        { }

        protected override string getRentedMessage()
        {
            return "";
        }

        protected override bool isValid(Rent rent)
        {
            return false;
        }
    }

    public class SubscriptionFactory
    {
        public Subscription Create(string name, int total)
        {
            switch(name)
            {
                case "money":
                    return new MoneySubscription(total);
                case "count":
                    return new CountSubscription(total);
                default:
                    throw new ArgumentException("Invalid Subscription type!");
            }
        }
    }

    public class UserManager
    {
        static UserManager()
        {
            Instance = new UserManager();
        }

        public static UserManager Instance { get; }

        private UserManager()
        {
            _users = new List<User>();
        }

        private List<User> _users;

        public int AddUser()
        {
            int newId;

            if (_users.Count > 0)
                newId = _users.Max(x => x.Id) + 1;
            else
                newId = 1;

            var u = new User(newId);

            _users.Add(u);

            return newId;
        }

        public User GetUser(int id)
        {
            return _users.Single(x => x.Id == id);
        }
    }

    // APPLICATION LOGIC
    // BUSINESS LOGIC

    // Prefer Composition over Inheritance
}
