using CorsoEnaip2018_Visitor_Nodes.TreeNodes;

namespace CorsoEnaip2018_Visitor_Nodes.Visitors
{
    interface ITreeNodeVisitor
    {
        void Visit(IncrementTreeNode n);
        void Visit(DecrementTreeNode n);
    }

    // Le interfacce generale del pattern Visitor sono:

    interface IVisitor
    {
        void Visit(IVisitable visitable);
    }

    interface IVisitable
    {
        void Accept(IVisitor v);
    }
}
