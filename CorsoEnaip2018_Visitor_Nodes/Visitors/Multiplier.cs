using CorsoEnaip2018_Visitor_Nodes.LinkedNodes;
using CorsoEnaip2018_Visitor_Nodes.TreeNodes;

namespace CorsoEnaip2018_Visitor_Nodes.Visitors
{
    class Multiplier : ILinkedNodeVisitor, ITreeNodeVisitor
    {
        public double Total { get; private set; }

        public Multiplier()
        {
            Total = 1;
        }

        public void Visit(IncrementLinkedNode n)
        {
            Total *= n.Increment;
        }

        public void Visit(DecrementLinkedNode n)
        {
            Total /= n.Decrement;
        }

        public void Visit(IncrementTreeNode n)
        {
            Total *= n.Increment;
        }

        public void Visit(DecrementTreeNode n)
        {
            Total /= n.Decrement;
        }
    }
}
