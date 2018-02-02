using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorsoEnaip2018_Visitor_Nodes.TreeNodes;
using System.Collections.Generic;

namespace CorsoEnaip2018_Visitor_Nodes
{
    [TestClass]
    public class TreeNodesTest
    {
        [TestMethod]
        public void Sum_works()
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

            Assert.AreEqual(7.6, node.Sum(), 0.001);
        }
    }
}
