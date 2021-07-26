using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    public class CopyListWithRandom
    {
        public class Node
        {
            public int Value;
            public Node Next;
            public Node Rand;

            public Node(int v)
            {
                this.Value = v;
            }
        }

        public static Node CopyListWithRand1(Node head)
        {
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            Node cur = head;
            while(cur!=null)
            {
                map.Add(cur, new Node(cur.Value));
                cur = cur.Next;
            }
            cur = head;
            while(cur!=null)
            {
                map[cur].Next = map[cur.Next];
                map[cur].Rand = map[cur.Rand];
                cur = cur.Next;
            }
            return map[head];
        }

        public static Node CopyListWithRand2(Node head)
        {
            if (head == null)
                return null;

            Node cur = head;
            Node next = null;

            while(cur!=null)
            {
                next = cur.Next;
                cur.Next = new Node(cur.Value);
                cur.Next.Next = next;
                cur = next;
            }
            cur = head;
            Node curCopy = null;
            while(cur!=null)
            {
                next = cur.Next.Next;
                curCopy = cur.Next;
                curCopy.Rand = cur.Rand != null ? cur.Rand.Next : null;
                cur = next;
            }
            Node res = head.Next;
            cur = head;
            while(cur!=null)
            {
                next = cur.Next.Next;
                curCopy = cur.Next;
                cur.Next = next;
                curCopy.Next = next != null ? next.Next : null;
                cur = next;
            }
            return res;
        }
    }
}
