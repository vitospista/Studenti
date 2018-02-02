using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorsoEnaip2018_Visitor_Nodes.TreeNodes;
using System.Collections.Generic;
using CorsoEnaip2018_Visitor_Nodes.Visitors;

namespace CorsoEnaip2018_Visitor_Nodes
{
    [TestClass]
    public class TreeNodesTest
    {
        [TestMethod]
        public void Accumulator_works()
        {
            var node = new IncrementTreeNode
            {
                Increment = 3.4,
                Children = 
                {
                    new DecrementTreeNode
                    {
                        Decrement = 0.2,
                        Children =
                        {
                            new IncrementTreeNode
                            {
                                Increment = 7.2,
                            },
                            new DecrementTreeNode
                            {
                                Decrement = 2.9
                            }
                        }
                    },
                    new IncrementTreeNode
                    {
                        Increment = 0.1
                    }
                }
            };

            var acc = new Accumulator();

            node.Accept(acc);

            Assert.AreEqual(3.4 - 0.2 + 7.2 - 2.9 + 0.1, acc.Total, 0.001);
        }

        [TestMethod]
        public void Multiplier_works()
        {
            var node = new IncrementTreeNode
            {
                Increment = 3.4,
                Children =
                {
                    new DecrementTreeNode
                    {
                        Decrement = 0.2,
                        Children =
                        {
                            new IncrementTreeNode
                            {
                                Increment = 7.2,
                            },
                            new DecrementTreeNode
                            {
                                Decrement = 2.9
                            }
                        }
                    },
                    new IncrementTreeNode
                    {
                        Increment = 0.1
                    }
                }
            };

            var mul = new Multiplier();

            node.Accept(mul);

            Assert.AreEqual(3.4 / 0.2 * 7.2 / 2.9 * 0.1, mul.Total, 0.001);
        }

    }
}
