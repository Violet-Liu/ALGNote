using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 递归遍历二叉树
    /// </summary>
    public class RecursiveTraversal
    {
        /// <summary>
        /// 先序遍历头->左->右
        /// </summary>
        /// <param name="head"></param>
        public static void Pre(Node head)
        {
            if (head == null)
                return;

            Console.WriteLine(head.Value);
            Pre(head.Left);
            Pre(head.Right);
        }

        /// <summary>
        /// 中序遍历 左->头->右
        /// </summary>
        /// <param name="head"></param>
        public static void In(Node head)
        {
            if (head == null)
                return;

            Pre(head.Left);
            Console.WriteLine(head.Value);
            Pre(head.Right);
        }

        /// <summary>
        /// 后序 左->右->头
        /// </summary>
        /// <param name="head"></param>
        public static void Pos(Node head)
        {
            if (head == null)
                return;

            Pos(head.Left);
            Pos(head.Right);
            Console.WriteLine(head.Value);
        }

    }
}
