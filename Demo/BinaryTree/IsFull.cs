using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 完美二叉树
    /// </summary>
    public class IsFull
    {
        public static Boolean IsFull1(Node head)
        {
            if (head == null)
                return true;

            int height = GetHeight(head);
            int nodes = GetNodes(head);

            return (1 << height) - 1 == nodes;
        }

        public static int GetHeight(Node head)
        {
            if (head == null)
                return 0;
            return Math.Max(GetHeight(head.Left), GetHeight(head.Right)) + 1;
        }

        public static int GetNodes(Node head)
        {
            if (head == null)
                return 0;

            return GetNodes(head.Left) + GetNodes(head.Right) + 1;
        }

        public class Info
        {
            public int Height { get; set; }

            public int Nodes { get; set; }

            public Info(int h,int n)
            {
                Height = h;
                Nodes = n;
            }
        }

        public static Boolean IsFull2(Node head)
        {
            if (head == null)
                return true;

            var all = Process(head);

            return (1 << all.Height) - 1 == all.Nodes;
        }

        public static Info Process(Node head)
        {
            if (head == null)
                return new Info(0, 0);

            var leftInfo = Process(head.Left);
            var rightInfo = Process(head.Right);

            var nodes = leftInfo.Nodes + rightInfo.Nodes + 1;
            var height = Math.Max(leftInfo.Height, rightInfo.Height) + 1;

            return new Info(height, nodes);
        }
    }
}
