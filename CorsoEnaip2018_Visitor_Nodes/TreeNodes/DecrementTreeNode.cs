using CorsoEnaip2018_Visitor_Nodes.Visitors;

namespace CorsoEnaip2018_Visitor_Nodes.TreeNodes
{
    class DecrementTreeNode : TreeNode
    {
        public double Decrement { get; set; }

        public override void Accept(ITreeNodeVisitor v)
        {
            v.Visit(this);

            foreach (var c in Children)
                c.Accept(v);
        }
    }
}
