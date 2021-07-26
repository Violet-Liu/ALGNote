using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 搜索二叉树
    /// </summary>
    public class IsBST
    {
        public static bool IsBST1(Node head)
        {
            if (head == null)
                return true;

            List<Node> arr = new List<Node>();
            In(head, arr);
            for(int i = 1; i < arr.Count; i++)
            {
                if (arr[i].Value < arr[i - 1].Value)
                {
                    return false;
                }
            }
            return true;
        }

        public static void In(Node head,List<Node> arr)
        {
            if (head == null)
                return;

            In(head.Left, arr);
            arr.Add(head);
            In(head.Right, arr);
        }

        public class Info
        {
            public bool IsBST { get; set; }

            public int Min { get; set; }

            public int Max { get; set; }

            public Info(bool isBST,int min,int max)
            {
                IsBST = isBST;
                Min = min;
                Max = max;
            }
        }

        public static Info Process(Node head)
        {
            if (head == null)
                return null;

            var leftInfo = Process(head.Left);
            var rightInfo = Process(head.Right);

            int min = head.Value;
            int max = head.Value;

            if(leftInfo!=null)
            {
                min = Math.Min(min, leftInfo.Min);
                max = Math.Max(max, leftInfo.Max);
            }

            if(rightInfo!=null)
            {
                min = Math.Min(min, rightInfo.Min);
                max = Math.Max(max, rightInfo.Max);
            }
            Boolean isBST = false;
            if ((leftInfo == null ? true:(leftInfo.IsBST&&leftInfo.Max<head.Value))&&(rightInfo==null?true:(rightInfo.IsBST&&rightInfo.Min>head.Value)))
            {
                isBST = true;
            }
            return new Info(isBST, min, max);
        }


    }
}
