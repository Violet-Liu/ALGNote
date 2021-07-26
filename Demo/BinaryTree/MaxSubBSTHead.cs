using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MaxSubBSTHead
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

        public static Node MaxSubBSTHead1(Node head)
        {
            if (head == null)
                return null;

            if (GetBSTSize(head) != 0)
                return head;

            Node left = MaxSubBSTHead1(head.Left);
            Node right = MaxSubBSTHead1(head.Right);

            return GetBSTSize(left) >= GetBSTSize(right) ? left : right;
        }

        public static Node MaxSubBSTHead2(Node head)
        {
            if (head == null)
                return null;

            return Process(head).maxSubBSTHead;
        }

        public class Info
        {
            public Node maxSubBSTHead { get; set; }

            public int maxSubBSTSize { get; set; }

            public int Min { get; set; }

            public int Max { get; set; }

            public Info(Node head, int size, int min, int max)
            {
                maxSubBSTHead = head;
                maxSubBSTSize = size;
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

            var min = head.Value;
            var max = head.Value;
            Node maxSubBSTHead = null;
            int maxSubBSTSize = 0;
            if (leftInfo != null)
            {
                min = Math.Min(min, leftInfo.Min);
                max = Math.Max(max, leftInfo.Max);
                maxSubBSTSize = leftInfo.maxSubBSTSize;
                maxSubBSTHead = leftInfo.maxSubBSTHead;
            }

            if (rightInfo != null)
            {
                min = Math.Min(min, rightInfo.Min);
                max = Math.Max(max, rightInfo.Max);
                if (rightInfo.maxSubBSTSize > maxSubBSTSize)
                {
                    maxSubBSTSize = rightInfo.maxSubBSTSize;
                    maxSubBSTHead = rightInfo.maxSubBSTHead;
                }
            }

            if (((leftInfo?.maxSubBSTHead ?? head.Left) == head.Left && (leftInfo?.Max ?? 0) < head.Value)
                && ((rightInfo?.maxSubBSTHead ?? head.Right) == head.Right && (rightInfo?.Min ?? (head.Value + 1)) > head.Value))
            {
                maxSubBSTHead = head;
                maxSubBSTSize = leftInfo?.maxSubBSTSize ?? 0 + rightInfo?.maxSubBSTSize ?? 0 + 1;
            }

            return new Info(maxSubBSTHead, maxSubBSTSize, min, max);

        }
    }
}
