using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorsoEnaip2018_Stacks.Test
{
    [TestClass]
    public class ObservableStackTest
    {
        [TestMethod]
        public void The_subscribers_receive_the_Put_element()
        {
            var s = new CountableStack<int>(3);
            var sub1 = new StackSubscriber<int>();
            var sub2 = new StackSubscriber<int>();
            s.Subscribe(sub1);
            s.Subscribe(sub2);
            s.Put(40);
            Assert.AreEqual(40, sub1.LastPut);
            Assert.AreEqual(40, sub2.LastPut);
        }

        [TestMethod]
        public void The_subscribers_receive_the_Pop_element()
        {
            var s = new CountableStack<int>(3);
            s.Put(40);
            s.Put(41);
            var sub1 = new StackSubscriber<int>();
            var sub2 = new StackSubscriber<int>();
            s.Subscribe(sub1);
            s.Subscribe(sub2);

            s.Pop();
            Assert.AreEqual(41, sub1.LastPop);
            Assert.AreEqual(41, sub2.LastPop);
        }

        [TestMethod]
        public void An_unsubscribed_does_not_receive_the_Put_element()
        {
            var s = new CountableStack<int>(3);
            var sub1 = new StackSubscriber<int>();
            var sub2 = new StackSubscriber<int>();
            s.Subscribe(sub1);
            s.Subscribe(sub2);
            s.Put(40);
            s.Unsubscribe(sub1);
            s.Put(41);
            Assert.AreEqual(40, sub1.LastPut);
            Assert.AreEqual(41, sub2.LastPut);
        }

        [TestMethod]
        public void An_unsubscribed_does_not_receive_the_Pop_element()
        {
            var s = new CountableStack<int>(3);
            var sub1 = new StackSubscriber<int>();
            var sub2 = new StackSubscriber<int>();
            s.Subscribe(sub1);
            s.Subscribe(sub2);
            s.Put(40);
            s.Put(41);
            s.Pop();
            s.Unsubscribe(sub1);
            s.Pop();
            Assert.AreEqual(41, sub1.LastPop);
            Assert.AreEqual(40, sub2.LastPop);
        }
    }

    class StackSubscriber<T> : IStackSubscriber<T>
    {
        public void HandlePop(Stack<T> sender, T element)
        {
            LastPop = element;
        }

        public void HandlePut(Stack<T> sender, T element)
        {
            LastPut = element;
        }

        public T LastPut { get; set; }
        public T LastPop { get; set; }
    }
}
