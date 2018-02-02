using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Visitor_Nodes.TreeNodes
{
    class DecrementTreeNode : TreeNode
    {
        public double Decrement { get; set; }

        public override double Sum()
        {
            return -Decrement + Children.Sum(c => c.Sum());
        }
    }
}
