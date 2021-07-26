using System;
using System.Collections.Generic;
using System.Text;

namespace LinkList
{
    public class SmallerEqualBigger
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

        public static void Swap(Node[] nodeArr,int a,int b)
        {
            Node tmp = nodeArr[a];
            nodeArr[a] = nodeArr[b];
            nodeArr[b] = tmp;
        }

        public static Node ListPartition(Node head,int pivot)
        {
            if (head == null)
                return head;

            Node cur = head;
            int i = 0;
            while (cur != null)
            {
                i++;
                cur = cur.Next;
            }
            Node[] nodeArr = new Node[i];
            i = 0;
            cur = head;
            for (i = 0; i != nodeArr.Length; i++)
            {
                nodeArr[i] = cur;
                cur = cur.Next;
            }

            Partition(nodeArr, pivot);
            for(i=1;i!=nodeArr.Length;i++)
            {
                nodeArr[i - 1].Next = nodeArr[i];
            }
            nodeArr[i - 1].Next = null;
            return nodeArr[0];
        }

        public static void Partition(Node[] nodeArr, int pivot)
        {
            int small = -1;
            int big = nodeArr.Length;
            int index = 0;
            while (index != big)
            {
                if (nodeArr[index].Value < pivot)
                {
                    Swap(nodeArr, ++small, index++);
                }
                else if (nodeArr[index].Value == pivot)
                {
                    index++;
                }
                else
                {
                    Swap(nodeArr, --big, index);
                }
            }
        }

        public static Node ListPartition2(Node head,int pivot)
        {
            Node sH = null;
            Node sT = null;
            Node eH = null;
            Node eT = null;
            Node mH = null;
            Node mT = null;

            Node next = null;

            while(head!=null)
            {
                next = head.Next;
                head.Next = null;
                if(head.Value<pivot)
                {
                    if(sH==null)
                    {
                        sH = sT = head;
                    }
                    else
                    {
                        sT.Next = head;
                        sT = head;
                    }
                }
                else if (head.Value == pivot)
                {
                    if (eH == null)
                    {
                        eH = head;
                        eT = head;
                    }
                    else
                    {
                        eT.Next = head;
                        eT = head;
                    }
                }
                else
                {
                    if (mH == null)
                    {
                        mH = head;
                        mT = head;
                    }
                    else
                    {
                        mT.Next = head;
                        mT = head;
                    }
                }
                head = next;
            }
            // 小于区域的尾巴，连等于区域的头，等于区域的尾巴连大于区域的头
            if (sT != null)
            { // 如果有小于区域
                sT.Next = eH;
                eT = eT == null ? sT : eT; // 下一步，谁去连大于区域的头，谁就变成eT
            }
            // 上面的if，不管跑了没有，et
            // all reconnect
            if (eT != null)
            { // 如果小于区域和等于区域，不是都没有
                eT.Next = mH;
            }
            return sH != null ? sH : (eH != null ? eH : mH);
        }
    }
}
