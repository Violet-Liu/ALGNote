using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class TreeMaxWidth
    {
        public static int MaxWidthUseMap(Node head)
        {
            if (head == null)
                return 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(head);
            Dictionary<Node, int> levelMap = new Dictionary<Node, int>();
            levelMap.Add(head, 1);
            int curLevel = 1;
            int curLevelNodes = 0;
            int max = 0;

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                int curNodeLevel = levelMap[cur];
                if (cur.Left != null)
                {
                    levelMap.Add(cur.Left, curNodeLevel + 1);
                    queue.Enqueue(cur.Left);
                }

                if (cur.Right != null)
                {
                    levelMap.Add(cur.Right, curNodeLevel + 1);
                    queue.Enqueue(cur.Right);
                }

                if (curNodeLevel == curLevel)
                {
                    curLevelNodes++;
                }
                else
                {
                    max = Math.Max(max, curLevelNodes);
                    curLevel++;
                    curLevelNodes = 1;
                }
            }

            max = Math.Max(max, curLevelNodes);
            return max;

        }

        public static int MaxWidthNoMap(Node head)
        {
            if (head == null)
                return 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(head);
            Node curEnd = head;
            Node nexEnd = null;
            int max = 0;
            int curLevelNodes = 0;
            while(queue.Count>0)
            {
                Node cur = queue.Dequeue();
                if(cur.Left!=null)
                {
                    queue.Enqueue(cur.Left);
                    nexEnd = cur.Left;
                }

                if(cur.Right!=null)
                {
                    queue.Enqueue(cur.Right);
                    nexEnd = cur.Right;
                }
                curLevelNodes++;

                if(cur==curEnd)
                {
                    max = Math.Max(max, curLevelNodes);
                    curLevelNodes = 0;
                    curEnd = nexEnd;
                }
            }
            return max;
        }
    }
}
