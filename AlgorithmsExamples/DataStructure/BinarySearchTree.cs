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
        private TreeNode _root { get; set; }
        private int _count { get; set; }
        public int Count
        {
            get { return _count; }
        }

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

                if (_count == 0)
                    _root = node;
                _count++;
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

        // Searches for a node with name value. If found it returns a reference
        // to the node and to the node's parent. Else returns null.
        private TreeNode FindParent(int value, ref TreeNode parent)
        {
            TreeNode node = _root;
            parent = null;

            while (node != null)
            {
                if (value == node.Value)
                {
                    return node;
                }
                else if (value < node.Value)
                {
                    parent = node;
                    node = node.Left;
                }
                else
                {
                    parent = node;
                    node = node.Right;
                }
            }
            return null;
        }

        /// <summary>
        /// Find the next ordinal node starting at node startNode.
        /// Due to the structure of a binary search tree, the
        /// successor node is simply the left-most node on the right branch.
        /// </summary>
        /// <param name="startNode">Name key to use for searching</param>
        /// <param name="parent">Returns the parent node if search successful</param>
        /// <returns>Returns a reference to the node if successful, else null</returns>
        private TreeNode FindSuccessor(TreeNode startNode, ref TreeNode parent)
        {
            parent = startNode;
            startNode = startNode.Right;
            while (startNode.Left != null)
            {
                parent = startNode;
                startNode = startNode.Left;
            }
            return startNode;
        }

        /// <summary>
        /// Delete a given node. This is the more complex method in the binary search
        /// class. The method considers three senarios, 
        /// 1) the deleted node has no children;
        /// 2) the deleted node has one child; 
        /// 3) the deleted node has two children. 
        /// Case 1 and 2 are relatively simple to handle, the only unusual considerations are when the node is the root node. 
        /// Case 3 is much more complicated. It requires the location of the successor node.
        /// The node to be deleted is then replaced by the sucessor node and the
        /// successor node itself deleted. Throws an exception if the method fails to locate the node for deletion.
        /// </summary>
        /// <param name="key">Name key of node to delete</param>
        public void Delete(int key)
        {
            TreeNode parent = null;
            // First find the node to delete and its parent
            TreeNode nodeToDelete = FindParent(key, ref parent);
            if (nodeToDelete == null)
                throw new Exception("Unable to delete node: " + key.ToString());

            // Three cases to consider, leaf, one child, two children

            #region 1) If it is a simple leaf then just null what the parent is pointing to

            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                if (parent == null)
                {
                    _root = null;
                    return;
                }

                // find out whether left or right is associated with the parent 
                // and null as appropriate
                if (parent.Left == nodeToDelete)
                    parent.Left = null;
                else
                    parent.Right = null;
                _count--;
                return;
            }

            #endregion
            
            #region 2). One of the children is null, in this case delete the node and move child up

            if (nodeToDelete.Left == null)
            {
                // Special case if we're at the root
                if (parent == null)
                {
                    _root = nodeToDelete.Right;
                    return;
                }

                // Identify the child and point the parent at the child
                if (parent.Right == nodeToDelete)
                    parent.Right = nodeToDelete.Right;
                else
                    parent.Left = nodeToDelete.Right;
                nodeToDelete = null; // Clean up the deleted node
                _count--;
                return;
            }

            if (nodeToDelete.Right == null)
            {
                // Special case if we're at the root			
                if (parent == null)
                {
                    _root = nodeToDelete.Left;
                    return;
                }

                // Identify the child and point the parent at the child
                if (parent.Left == nodeToDelete)
                    parent.Left = nodeToDelete.Left;
                else
                    parent.Right = nodeToDelete.Left;
                nodeToDelete = null; // Clean up the deleted node
                _count--;
                return;
            }

            #endregion

            #region 3). Both children have nodes, therefore find the successor, replace deleted node with successor and remove successor. The parent argument becomes the parent of the successor

            TreeNode successor = FindSuccessor(nodeToDelete, ref parent);
            // Make a copy of the successor node
            TreeNode tmp = new TreeNode();
            // Find out which side the successor parent is pointing to the
            tmp.Value = successor.Value;
            // successor and remove the successor
            if (parent.Left == successor)
            {
                if (successor.Right == null)
                    parent.Left = null;
                else
                    parent.Left = successor.Right;
            }
            else
            {
                if (parent.Right.Right != null)
                    parent.Right = successor.Right;
                else
                    parent.Right = null;
            }

            // Copy over the successor values to the deleted node position
            nodeToDelete.Value = tmp.Value;
            _count--;

            #endregion
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
