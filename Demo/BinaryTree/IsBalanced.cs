using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class IsBalanced
    {
        /// <summary>
        /// 平衡二叉树 左右节点高度差不超过1
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Boolean IsBalanced1(Node head)
        {
            var ans = true;
            Process1(head, ans);
            return ans;
        }

        public static int Process1(Node head,Boolean ans)
        {
            if (!ans || head == null)
                return -1;

            int lefHeight = Process1(head.Left, ans);
            int rightHeight = Process1(head.Right, ans);
            if (Math.Abs(lefHeight - rightHeight) > 1)
                ans = false;

            return Math.Max(lefHeight, rightHeight) + 1;
        }

        public class Info
        {
            public Boolean IsBalaced { get; set; }
            public int Height { get; set; }

            public Info(Boolean b,int h)
            {
                IsBalaced = b;
                Height = h;
            }
        }

        public static Info Process2(Node head)
        {
            if (head == null)
                return new Info(true, 0);

            Info leftInfo = Process2(head.Left);
            Info rightInfo = Process2(head.Right);

            int height = Math.Max(leftInfo.Height, rightInfo.Height) + 1;
            Boolean isBalanced = true;

            if (!leftInfo.IsBalaced || !rightInfo.IsBalaced || Math.Abs(leftInfo.Height - rightInfo.Height) > 1)
                isBalanced = false;

            return new Info(isBalanced, height);
        }
    }
}
