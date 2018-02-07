using System;

namespace CorsoEnaip2018_Cup
{
    class Cup
    {
        private Person _drinkingPerson;

        public void Fill()
        {
            if (Quantity != 0)
                throw new InvalidOperationException("The Cup is not empty!");

            Quantity = 10;
        }

        public void Empty()
        {
            if (Quantity == 0)
                throw new InvalidOperationException("The Cup is already empty!");

            Quantity = 0;
        }

        public void Drink(int quantity, Person p)
        {
            if (quantity > Quantity)
                throw new InvalidOperationException("Cannot drink so much!");
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            if (_drinkingPerson != null && _drinkingPerson != p)
                throw new InvalidOperationException("Another Person is already drinking from this Cup!");

            if (_drinkingPerson == null)
                _drinkingPerson = p;

            Quantity -= quantity;
        }

        public void Wash()
        {
            _drinkingPerson = null;

            if (Quantity != 0)
                Empty();
        }

        public int Quantity { get; private set; }
    }

    class Person
    {

    }
}
