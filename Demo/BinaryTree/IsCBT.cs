using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 判断是不是完全二叉树
    /// 1、任何节点，有右无左 false
    /// 2、宽度遍历，一旦遇到左右孩子不双全，后序遇到所有的节点必须为叶节点
    /// </summary>
    public class IsCBT
    {
        public static Boolean IsCBT1(Node head)
        {
            if (head == null)
                return true;

            Queue<Node> queue = new Queue<Node>();
            //满足条件1
            Boolean leaf = false;
            Node L = null;
            Node R = null;
            queue.Enqueue(head);
            while(queue.Count>0)
            {
                head = queue.Dequeue();
                L = head.Left;
                R = head.Right;
                //满足条件2
                if ((leaf && !(L == null && R == null)) || (L == null && R != null))
                    return false;
                //宽度遍历
                if (L != null)
                    queue.Enqueue(L);
                //宽度遍历
                if (R != null)
                    queue.Enqueue(R);

                //只有改过一次，后序的遍历都不会更改这个开关
                if (L == null || R == null)
                    return true;
            }

            return true;
        }

        public class Info
        {
            public bool IsFull { get; set; }

            public bool IsCBT { get; set; }

            public int Height { get; set; }

            public Info(bool isFull,bool isCBT,int height)
            {
                IsFull = isFull;
                IsCBT = isCBT;
                Height = height;
            }
        }

        public static Info Process(Node head)
        {
            if (head == null)
                return new Info(true, true, 0);

            var leftInfo = Process(head.Left);
            var rightInfo = Process(head.Right);

            int height = Math.Max(leftInfo.Height, rightInfo.Height) + 1;
            bool isFull = leftInfo.IsFull && rightInfo.IsFull && leftInfo.Height == rightInfo.Height;
            bool isCBT = false;

            if (isFull)
                isCBT = true;
            else
            {
                if(leftInfo.IsCBT&&rightInfo.IsCBT)
                {
                    if (leftInfo.IsCBT && rightInfo.IsFull && leftInfo.Height == rightInfo.Height + 1)
                        isCBT=true;
                    if (leftInfo.IsFull && rightInfo.IsFull && leftInfo.Height == rightInfo.Height)
                        isCBT = true;
                    if (leftInfo.IsFull && rightInfo.IsCBT && leftInfo.Height == rightInfo.Height)
                        isCBT = true;

                }
            }
            return new Info(isFull, isCBT, height);
        }
    }
}
