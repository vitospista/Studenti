using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Cup_2
{
    class Cup
    {
        public Person DrinkingPerson { get; private set; }
        public int Quantity { get; private set; }

        public void BeDrunk(Person p, int quantity)
        {
            Quantity -= quantity;
            DrinkingPerson = p;
        }
    }

    class Person
    {
        public void Drink(Cup c, int quantity)
        {
            if (c.DrinkingPerson != null && c.DrinkingPerson != this)
                throw new InvalidOperationException();
            else
                c.BeDrunk(this, quantity);
            
        }
    }
}
