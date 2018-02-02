using System.Linq;

namespace CorsoEnaip2018_Visitor_Nodes.TreeNodes
{
    class IncrementTreeNode : TreeNode
    {
        public double Increment { get; set; }

        public override double Sum()
        {
            return Increment + Children.Sum(c => c.Sum());
        }
    }
}
