using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    public class BFS
    {
        /// <summary>
        /// 宽度排序
        /// </summary>
        /// <param name="node"></param>
        public static void bfs(Node node)
        {
            if (node == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> set = new HashSet<Node>();
            queue.Enqueue(node);
            set.Add(node);

            while (queue.Count > 0)
            {
                Node cur = queue.Dequeue();
                Console.WriteLine(cur.Value);
                foreach(var next in cur.Nexts)
                {
                    if (!set.Contains(next))
                    {
                        set.Add(next);
                        queue.Enqueue(next);
                    }
                }
            }
        }
    }
}
