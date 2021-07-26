using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MaxSubBSTSize
    {
        public static int GetBSTSize(Node head)
        {
            if (head == null)
                return 0;

            List<Node> arr = new List<Node>();
            In(head, arr);
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i].Value < arr[i - 1].Value)
                {
                    return 0;
                }
            }
            return arr.Count;
        }

        public static void In(Node head, List<Node> arr)
        {
            if (head == null)
                return;

            In(head.Left, arr);
            arr.Add(head);
            In(head.Right, arr);
        }

        public static int MaxSubBSTSize1(Node head)
        {
            if (head == null)
                return 0;

            int h = GetBSTSize(head);
            if (h != 0)
                return h;

            return Math.Max(MaxSubBSTSize1(head.Left), MaxSubBSTSize1(head.Left));
        }

        public class Info
        {
            public bool IsAllBST { get; set; }

            public int MaxSubBSTSize { get; set; }

            public int Min { get; set; }

            public int Max { get; set; }

            public Info(Boolean isAllBST,int size,int min,int max)
            {
                IsAllBST = isAllBST;
                MaxSubBSTSize = size;
                Min = min;
                Max = max;
            }
        }

        public static int MaxSubBSTSize2(Node head)
        {
            if (head == null)
                return 0;

            return Process(head).MaxSubBSTSize;
        }

        public static Info Process(Node head)
        {
            if (head == null)
                return null;

            Info leftInfo = Process(head.Left);
            Info rightInfo = Process(head.Right);

            var min = head.Value;
            var max = head.Value;

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

            int maxSubBSTSize = 0;
            if (leftInfo != null)
                maxSubBSTSize = leftInfo.MaxSubBSTSize;

            if (rightInfo != null)
                maxSubBSTSize = Math.Max(maxSubBSTSize, rightInfo.MaxSubBSTSize);

            bool isAllBST = false;

            if((leftInfo?.IsAllBST??true)&&(leftInfo?.IsAllBST??true)&&(leftInfo?.Max??0)<head.Value&&(rightInfo?.Max??0)<head.Value)
            {
                maxSubBSTSize = leftInfo?.MaxSubBSTSize ?? 0 + rightInfo?.MaxSubBSTSize ?? 0 + 1;
                isAllBST = true;
            }
            return new Info(isAllBST, maxSubBSTSize, min, max);
        }
    }
}
