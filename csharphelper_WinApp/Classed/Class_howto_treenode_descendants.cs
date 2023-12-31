
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

  namespace  howto_treenode_descendants

 { 

public static class TreeViewExtensions
    {
        // Return the nodes in this collection and their descendants.
        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;
                foreach (TreeNode child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }

        // Return this node and its descendants.
        public static IEnumerable<TreeNode> Descendants(this TreeNode node)
        {
            yield return node;
            foreach (TreeNode child in node.Nodes.Descendants())
            {
                yield return child;
            }
        }

        // Return all of the TreeView's nodes.
        public static IEnumerable<TreeNode> Descendants(this TreeView trv)
        {
            foreach (TreeNode node in trv.Nodes.Descendants())
                yield return node;
        }
    }

}