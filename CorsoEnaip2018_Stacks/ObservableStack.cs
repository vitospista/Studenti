using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Stacks
{
    public class ObservableStack<T> : Stack<T>
    {
        private List<IStackSubscriber<T>> _subscribers;

        public ObservableStack(int capacity)
            : base(capacity)
        {
            _subscribers = new List<IStackSubscriber<T>>();
        }

        public void Subscribe(IStackSubscriber<T> subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(IStackSubscriber<T> subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public override void Put(T element)
        {
            base.Put(element);

            foreach (var s in _subscribers)
                s.HandlePut(this, element);
        }

        public override T Pop()
        {
            var element = base.Pop();

            foreach (var s in _subscribers)
                s.HandlePop(this, element);

            return element;
        }
    }
}
