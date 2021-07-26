using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 获取后继节点 中序排序某个节点的后一个节点
    /// </summary>
    public class SuccessorNode
    {
        public class Node2
        {
            public int Value { get; set; }

            public Node2 Left { get; set; }

            public Node2 Right { get; set; }

            public Node2 Parent { get; set; }

            public Node2(int value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// 根据中序遍历左->中->右的特性，假如有右节点，那节点的后继一定是它的最左节点
        /// 如果没有右节点，找到它的父节点，如果它是它父节点的左节点，直接返回父节点，如果是右节点，接着往父节点的父节点判断
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Node2 GetSuccessorNode(Node2 node)
        {
            if (node == null)
                return null;

            if(node.Right!=null)
            {
                return GetLeftMost(node.Right);
            }
            else
            {
                var parent = node.Parent;
                while (parent != null && parent.Right == node)
                {
                    node = parent;
                    parent = node.Parent;
                }
                return parent;
            }
        }

        public static Node2 GetPredecessorNode(Node2 node)
        {
            if (node == null)
                return null;

            if (node.Left != null)
                return GetRightMost(node.Left);

            if (node.Parent != null && node.Parent.Right == node)
                return node.Parent;
            else if (node.Parent != null && node.Parent.Left == node)
                return node.Parent.Parent;

            return null;
        }

        public static Node2 GetLeftMost(Node2 node)
        {
            if (node == null)
                return node;

            while (node.Left != null)
                node = node.Left;

            return node;
        }

        public static Node2 GetRightMost(Node2 node)
        {
            if (node == null)
                return node;

            while (node.Right != null)
                node = node.Right;

            return node;
        }
    }
}
