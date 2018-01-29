using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorsoEnaip2018_Stacks.Test
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Stack_with_negative_capacity_throws_Exception()
        {
            var stack = new CountableStack<int>(-14);
        }

        [TestMethod]
        public void Stack_with_0_capacity_cannot_Put()
        {
            var s = new CountableStack<int>(0);
            Assert.IsFalse(s.CanPut());
        }

        [TestMethod]
        public void new_Stack_cannot_Pop()
        {
            var s = new CountableStack<int>(5);
            Assert.IsFalse(s.CanPop());
        }

        [TestMethod]
        public void new_Stack_can_Put()
        {
            var s = new CountableStack<int>(3);
            Assert.IsTrue(s.CanPut());
        }

        [TestMethod]
        public void new_Stack_can_Put_up_to_max_capacity()
        {
            var s = new CountableStack<int>(3);
            s.Put(100);
            Assert.IsTrue(s.CanPut());
            s.Put(150);
            Assert.IsTrue(s.CanPut());
            s.Put(200);
            Assert.IsFalse(s.CanPut());
        }

        [TestMethod]
        public void Stack_with_1_element_can_Pop()
        {
            var s = new CountableStack<int>(2);
            s.Put(5);
            Assert.IsTrue(s.CanPop());
        }

        [TestMethod]
        public void Stack_emptied_cannot_Pop()
        {
            var s = new CountableStack<int>(2);
            s.Put(5);
            s.Pop();
            Assert.IsFalse(s.CanPop());
        }

        [TestMethod]
        public void new_Stack_can_Pop_down_to_empty()
        {
            var s = new CountableStack<int>(3);
            s.Put(100);
            s.Put(150);
            s.Put(200);
            Assert.IsTrue(s.CanPop());

            s.Pop();
            Assert.IsTrue(s.CanPop());

            s.Pop();
            Assert.IsTrue(s.CanPop());

            s.Pop();
            Assert.IsFalse(s.CanPop());
        }

        [TestMethod]
        public void Pop_returns_the_elements_in_reverse_order()
        {
            var s = new CountableStack<string>(2);

            s.Put("s1");
            s.Put("s2");

            Assert.AreEqual("s2", s.Pop());
            Assert.AreEqual("s1", s.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Put_on_full_Stack_throws_Exception()
        {
            var s = new CountableStack<string>(2);

            s.Put("s1");
            s.Put("s2");
            s.Put("s3");
        }

        [TestMethod]
        public void Pop_on_empty_Stack_throws_Exception()
        {
            var s = new CountableStack<string>(2);

            s.Put("s1");
            s.Put("s2");
            s.Pop();
            s.Pop();

            try
            {
                s.Pop();
                // se non lancia eccezione,
                // il test deve fallire!
                Assert.Fail("Did not throw Exception");
            }
            catch(InvalidOperationException ex)
            {
                // se viene catturata una InvalidOperationException
                // è tutto a posto
            }
            catch(Exception)
            {
                // se viene lanciata qualche altra eccezione
                // il test deve fallire!
                Assert.Fail("Threw wrong Exception");
            }
        }
    }
}
