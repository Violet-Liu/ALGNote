using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    public class LinkedListMid
    {
        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int v)
            {
                Value = v;
            }
        }

        //找出单链条，如果为奇数长度找出正中，偶数长度找出最中间两个的前一个
        public static Node MidOrUpMidNode(Node head)
        {
            if (head == null || head.Next == null || head.Next.Next == null)
                return head;

            Node slow = head.Next;
            Node fast = head.Next.Next;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        //找出单链条，如果为奇数长度找出正中，偶数长度找出最中间两个的后的一个
        public static Node MidOrDownMidNode(Node head)
        {
            if (head == null || head.Next == null)
                return head;

            Node slow = head.Next;
            Node fast = head.Next;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;

        }

        public static Node MidOrDownPreNode(Node head)
        {
            if (head == null || head.Next == null)
                return head;

            Node slow = head;
            Node fast = head.Next.Next;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        public static Node midOrDownMidPreNode(Node head)
        {
            if (head == null || head.Next == null)
                return head;

            Node slow = head;
            Node fast = head.Next;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }
    }
}
