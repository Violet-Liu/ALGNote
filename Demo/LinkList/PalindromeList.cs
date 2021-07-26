using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    public class PalindromeList
    {
        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int v)
            {
                this.Value = v;
            }
        }

        public static bool IsPalindrom1(Node head)
        {
            Stack<Node> stack = new Stack<Node>();
            Node cur = head;
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.Next;
            }
            while (head != null)
            {
                if (head.Value != stack.Pop().Value)
                {
                    return false;
                }
                head = head.Next;
            }
            return true;
        }

        public static bool IsPalindrom2(Node head)
        {
            if (head == null || head.Next == null)
            {
                return true;
            }
            Node right = head.Next;
            Node cur = head;
            while (cur.Next != null && cur.Next.Next != null)
            {
                right = right.Next;
                cur = cur.Next.Next;
            }
            Stack<Node> stack = new Stack<Node>();
            while (right != null)
            {
                stack.Push(right);
                right = right.Next;
            }
            while (stack.Count==0)
            {
                if (head.Value != stack.Pop().Value)
                {
                    return false;
                }
                head = head.Next;
            }
            return true;
        }

        public static Boolean IsPalindrom3(Node head)
        {
            if (head == null || head.Next == null)
                return true;

            Node n1 = head;
            Node n2 = head;

            while (n2.Next != null && n2.Next.Next != null)
            {
                n1 = n1.Next;
                n2 = n2.Next.Next;
            }

            n2 = n1.Next;
            n1.Next = null;
            Node n3 = null;

            while (n2 != null)
            {
                n3 = n2.Next;
                n2.Next = n1;
                n1 = n2;
                n2 = n3;
            }
            n3 = n1;
            n2 = head;
            bool res = true;
            while (n1 != null && n2 != null)
            { // check palindrome
                if (n1.Value != n2.Value)
                {
                    res = false;
                    break;
                }
                n1 = n1.Next; // left to mid
                n2 = n2.Next; // right to mid
            }
            n1 = n3.Next;
            n3.Next = null;
            while (n1 != null)
            { // recover list
                n2 = n1.Next;
                n1.Next = n3;
                n3 = n1;
                n1 = n2;
            }
            return res;
        }
    }
}
