using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class LevelTraversal
    {
        public static void Level(Node head)
        {
            if (head == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(head);
            while(queue.Count>0)
            {
                var cur = queue.Dequeue();
                Console.WriteLine(cur.Value);
                if (cur.Left != null)
                    queue.Enqueue(cur.Left);

                if (cur.Right != null)
                    queue.Enqueue(cur.Right);
            }
        }
    }
}
