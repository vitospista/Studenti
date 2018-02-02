using CorsoEnaip2018_Visitor_Nodes.Visitors;

namespace CorsoEnaip2018_Visitor_Nodes.LinkedNodes
{
    abstract class LinkedNode
    {
        public LinkedNode Next { get; set; }

        public abstract void Accept(ILinkedNodeVisitor v);
    }
}
