using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CorsoEnaip2018_Stacks.Test
{
    [TestClass]
    public class CountableStackTest
    {
        [TestMethod]
        public void Empty_Stack_returns_0()
        {
            var s = new CountableStack<string>(0);

            Assert.AreEqual(0, s.Count(x => x == null));
            Assert.AreEqual(0, s.Count(x => x.StartsWith("c")));
            Assert.AreEqual(0, s.Count(x => x.Length > 3));

            s = new CountableStack<string>(10);

            Assert.AreEqual(0, s.Count(x => x == null));
            Assert.AreEqual(0, s.Count(x => x.StartsWith("c")));
            Assert.AreEqual(0, s.Count(x => x.Length > 3));

            s = new CountableStack<string>(20);
            s.Put("cc");
            s.Put("heeeeey");
            s.Pop();
            s.Pop();

            Assert.AreEqual(0, s.Count(x => x == null));
            Assert.AreEqual(0, s.Count(x => x.StartsWith("c")));
            Assert.AreEqual(0, s.Count(x => x.Length > 3));
        }

        [TestMethod]
        public void Full_Stack_Count_with_no_valid_elements_returns_0()
        {
            var s = new CountableStack<string>(10);
            s.Put("aa");
            s.Put("z");

            Assert.AreEqual(0, s.Count(x => x == null));
            Assert.AreEqual(0, s.Count(x => x.StartsWith("c")));
            Assert.AreEqual(0, s.Count(x => x.Length > 3));
        }

        [TestMethod]
        public void Full_Stack_Count_returns_correct_number_of_elements()
        {
            var s = new CountableStack<string>(10);
            s.Put(null);
            s.Put("ciao");
            s.Put("mondo");
            s.Put("another string");

            Assert.AreEqual(1, s.Count(x => x == null));

            // Short Circuit conditions:
            // && restituisce false alla prima condizione falsa,
            // NON controlla tutte le condizioni.
            Assert.AreEqual(1, s.Count(x => x != null && x.StartsWith("c")));

            Assert.AreEqual(3, s.Count(x => x!= null && x.Length > 3));  
        }
    }
}
