using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Stacks
{
    public class Stack<T>
    {
        private int _capacity;
        private int _count;
        private T[] _elements;

        public Stack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("The capacity cannot be negative!");
            _capacity = capacity;

            _elements = new T[capacity];
        }

        public bool CanPut()
        {
            return _count < _capacity;
        }

        public bool CanPop()
        {
            return _count > 0;
        }

        public virtual void Put(T element)
        {
            if (!CanPut())
                throw new InvalidOperationException("The Stack is already full!");

            _elements[_count] = element;
            _count++;
        }

        public virtual T Pop()
        {
            if (!CanPop())
                throw new InvalidOperationException("The Stack is empty!");

            _count--;
            var element = _elements[_count];
            return element;
        }
    }
}
