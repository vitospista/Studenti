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
        protected List<T> _elements;

        public Stack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("The capacity cannot be negative!");
            _capacity = capacity;

            _elements = new List<T>();
        }

        public bool CanPut()
        {
            return _elements.Count < _capacity;
        }

        public bool CanPop()
        {
            return _elements.Count > 0;
        }

        public virtual void Put(T element)
        {
            if (!CanPut())
                throw new InvalidOperationException("The Stack is already full!");

            _elements.Add(element);
        }

        public virtual T Pop()
        {
            if (!CanPop())
                throw new InvalidOperationException("The Stack is empty!");

            var removed = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);

            return removed;
        }
    }

}
