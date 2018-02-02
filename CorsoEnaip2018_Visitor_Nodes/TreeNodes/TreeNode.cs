using CorsoEnaip2018_Visitor_Nodes.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Visitor_Nodes.TreeNodes
{
    abstract class TreeNode
    {
        public TreeNode()
        {
            Children = new List<TreeNode>();
        }

        public List<TreeNode> Children { get; }

        public abstract void Accept(ITreeNodeVisitor v);
    }
}
