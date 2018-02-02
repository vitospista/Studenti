using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorsoEnaip2018_Visitor_Nodes.LinkedNodes;
using System.Collections.Generic;
using CorsoEnaip2018_Visitor_Nodes.Visitors;

namespace CorsoEnaip2018_Visitor_Nodes
{
    [TestClass]
    public class LinkedNodesTest
    {
        // se avessi il metodo Sum sui nodi, potrei testare così:
        //[TestMethod]
        //public void Sum_works()
        //{
        //    var node = new IncrementLinkedNode
        //    {
        //        Increment = 5.4,
        //        Next = new DecrementLinkedNode
        //        {
        //            Decrement = 2.3,
        //            Next = new IncrementLinkedNode
        //            {
        //                Increment = 1.2
        //            }
        //        }
        //    };

        //    Assert.AreEqual(4.3, node.Sum(), 0.001);
        //}

        [TestMethod]
        public void Accumulator_works()
        {
            var node = new IncrementLinkedNode
            {
                Increment = 5.4,
                Next = new DecrementLinkedNode
                {
                    Decrement = 2.3,
                    Next = new IncrementLinkedNode
                    {
                        Increment = 1.2
                    }
                }
            };

            var acc = new Accumulator();

            node.Accept(acc);

            Assert.AreEqual(4.3, acc.Total, 0.001);
        }

        [TestMethod]
        public void Multiplier_works()
        {
            var node = new IncrementLinkedNode
            {
                Increment = 5.4,
                Next = new DecrementLinkedNode
                {
                    Decrement = 2.3,
                    Next = new IncrementLinkedNode
                    {
                        Increment = 1.2
                    }
                }
            };

            var mul = new Multiplier();

            node.Accept(mul);

            Assert.AreEqual(5.4 / 2.3 * 1.2, mul.Total, 0.001);
        }
    }
}
