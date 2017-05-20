using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181
    /// https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx
    /// https://www.codeproject.com/Articles/18976/A-simple-Binary-Search-Tree-written-in-C
    /// </summary>
    public class BinarySearchTree
    {
        public bool Contains(TreeNode root, int value)
        {
            TreeNode current = root;

            while(current != null)
            {
                if (value == current.Value) 
                    return true;
                else if (value < current.Value) 
                    current = current.Left;
                else if (value >= current.Value) 
                    current = current.Right;
            }
            return false;
        }

        public TreeNode Insert(TreeNode node, int value)
        {
            if (node == null)
            {
                node = new TreeNode();
                node.Value = value;
            }
            else if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }
            return node;
        }

        public void Traverse(TreeNode node)
        {
            if (node == null) return;
            Console.Write("-->" + node.Value);
            Traverse(node.Left);
            Traverse(node.Right);
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
