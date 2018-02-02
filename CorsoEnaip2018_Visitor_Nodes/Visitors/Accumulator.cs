using CorsoEnaip2018_Visitor_Nodes.LinkedNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Visitor_Nodes.Visitors
{
    class Accumulator
    {
        public double Total { get; private set; }

        public void Sum(IncrementLinkedNode n)
        {
            Total += n.Increment;
        }

        public void Sum(DecrementLinkedNode n)
        {
            Total -= n.Decrement;
        }
    }
}
