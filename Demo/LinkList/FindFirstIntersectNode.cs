using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    public class FindFirstIntersectNode
    {
        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int data)
            {
                Value = data;
            }
        }
        public static Node GetIntersectNode(Node head1, Node head2)
        {
            if (head1 == null || head2 == null)
            {
                return null;
            }
            Node loop1 = GetLoopNode(head1);
            Node loop2 = GetLoopNode(head2);
            
            if (loop1 == null && loop2 == null)
            {
                return NoLoop(head1, head2);
            }
            if (loop1 != null && loop2 != null)
            {
                return BothLoop(head1, loop1, head2, loop2);
            }
            return null;
        }

        //找到链表第一个换节点，如果无环，返回null
        public static Node GetLoopNode(Node head)
        {
            if(head==null||head.Next==null||head.Next.Next==null)
            {
                return null;
            }
            var slow = head.Next;  //慢指针
            var fast = head.Next.Next;  //快指针

            while(slow!=fast)
            {
                if (fast.Next == null || fast.Next.Next == null)
                    return null;
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            fast = head;
            while(slow!=fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow;
        }

        //假如两个链表都无环，单链表必定是从第一个相交点到最后是一条连接，返回第一个相交节点，如果不相交，返回null
        public static Node NoLoop(Node head1,Node head2)
        {
            if (head1 == null || head2 == null)
                return null;

            Node cur1 = head1;
            Node cur2 = head2;
            //计算两个链表的长度差
            int n = 0;
            while(cur1.Next!=null)
            {
                n++;
                cur1 = cur1.Next;
            }

            while (cur2.Next != null)
            {
                n--;
                cur2 = cur2.Next;
            }

            if (cur1 != cur2)
            {
                return null;
            }
            cur1 = n > 0 ? head1 : head2;
            cur2 = cur1 == head1 ? head2 : head1;
            n = Math.Abs(n);
            //让长的移动n的值
            while(n!=0)
            {
                n--;
                cur1 = cur1.Next;
            }

            //
            while (cur1 != cur2)
            {
                cur1 = cur1.Next;
                cur2 = cur2.Next;
            }
            return cur1;
        }

        //两个有环链表，返回第一个相交节点，如果不相交返回null
        public static Node BothLoop(Node head1,Node loop1,Node head2,Node loop2)
        {
            Node cur1 = null;
            Node cur2 = null;
            //还是因为单链表的特性，判断相交点要么在环内，要么在环外
            if (loop1 == loop2)
            {
                //在环外相交(包括环的起始点loop1==loop2)，两个链表共享同一个完整的环，可以当作两个无环相交处理，逻辑同上个
                cur1 = head1;
                cur2 = head2;
                int n = 0;
                while(cur1!=loop1)
                {
                    n++;
                    cur1 = cur1.Next;
                }
                while (cur2 != loop2)
                {
                    n--;
                    cur2 = cur2.Next;
                }
                cur1 = n > 0 ? head1 : head2;
                cur2 = cur1 == head1 ? head2 : head1;

                n = Math.Abs(n);
                while(n!=0)
                {
                    n--;
                    cur1 = cur1.Next;
                }

                while(cur1!=cur2)
                {
                    cur1 = cur1.Next;
                    cur2 = cur2.Next;
                }
                return cur1;
            }
            else
            {
                //让loop1去追loop2
                cur1 = loop1.Next;
                while (cur1 != loop1)
                {
                    if(cur1==loop2)
                    {
                        return loop1;
                    }
                    return cur1.Next;
                }
            }
            return null;
        }
    }
}
