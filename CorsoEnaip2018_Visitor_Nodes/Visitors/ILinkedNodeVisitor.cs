using CorsoEnaip2018_Visitor_Nodes.LinkedNodes;

namespace CorsoEnaip2018_Visitor_Nodes.Visitors
{
    interface ILinkedNodeVisitor
    {
        void Visit(IncrementLinkedNode n);
        void Visit(DecrementLinkedNode n);
    }
}
