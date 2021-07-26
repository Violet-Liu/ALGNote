using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    /// <summary>
    /// 拓扑排序 针对有向无环图
    /// 比如项目之间的互相依赖 编译，有先后顺序，也有同步关系
    /// </summary>
    public class SortedTopology
    {
        public static List<Node> Process(Graph graph)
        {
            Dictionary<Node, int> inMap = new Dictionary<Node, int>();
            Queue<Node> zeroInQueue = new Queue<Node>();

            foreach(var node in graph.Nodes.Values)
            {
                inMap.Add(node, node.In);

                if (node.In == 0)
                {
                    zeroInQueue.Enqueue(node);
                }
            }

            List<Node> ans = new List<Node>();
            while (zeroInQueue.Count > 0)
            {
                var cur = zeroInQueue.Dequeue();
                ans.Add(cur);
                foreach(var next in cur.Nexts)
                {
                    inMap.Remove(next);
                    inMap.Add(next, next.In - 1);
                    if (inMap[next] == 0)
                    {
                        zeroInQueue.Enqueue(next);
                    }
                }
            }
            return ans;
        }
    }
}
