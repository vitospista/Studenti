﻿using CorsoEnaip2018_Visitor_Nodes.Visitors;

namespace CorsoEnaip2018_Visitor_Nodes.LinkedNodes
{
    class DecrementLinkedNode : LinkedNode
    {
        public double Decrement { get; set; }

        public override void Accept(Accumulator a)
        {
            a.Sum(this);

            if (Next != null)
                Next.Accept(a);
        }
    }
}
