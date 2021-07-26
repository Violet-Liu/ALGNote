using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static GraphDemo.Kruskal;

namespace GraphDemo
{
    /// <summary>
    /// 搜索最小生成树
    /// </summary>
    public class Prim
    {
        public static HashSet<Edge> PrimMST(Graph graph)
        {
            //解锁的边进入小根堆
            PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>(new EdgeComparator());
            HashSet<Node> nodeSet = new HashSet<Node>();
            HashSet<Edge> ans = new HashSet<Edge>();

            foreach (var node in graph.Nodes.Values)
            {
                if (!nodeSet.Contains(node))
                {
                    nodeSet.Add(node);
                    foreach (var edge in node.Edges)
                        priorityQueue.Enqueue(edge);

                    while (priorityQueue.Count > 0)
                    {
                        Edge cur = priorityQueue.Dequeue();
                        Node toNode = cur.To;
                        if (!nodeSet.Contains(toNode))
                        {
                            nodeSet.Add(toNode);
                            ans.Add(cur);
                            foreach (var edge in toNode.Edges)
                            {
                                priorityQueue.Enqueue(edge);
                            }
                        }
                    }
                }
            }
            return ans;
        }

        public static int Prims(int[][] graph)
        {
            int size = graph.Length;
            int[] distances = new int[size];
            bool[] visit = new bool[size];

            visit[0] = true;
            for(int i = 0; i < size; i++)
            {
                distances[i] = graph[0][i];
            }
            int sum = 0;
            for(int i = 1; i < size; i++)
            {
                int minPath = int.MaxValue;
                int minIndex = -1;
                for(int j = 0; j < size; j++)
                {
                    if (!visit[j] && distances[j] < minPath)
                    {
                        minPath = distances[j];
                        minIndex = j;
                    }
                }
                if (minIndex == -1)
                    return sum;
                visit[minIndex] = true;

                sum += minPath;
                for(int j = 0; j < size; j++)
                {
                    if (!visit[j] && distances[j] > graph[minIndex][j])
                    {
                        distances[j] = graph[minIndex][J];
                    }
                }

            }
            return sum;
        }
    }

    public class EdgeComparator : IComparer<Edge>
    {
        public int Compare([AllowNull] Edge x, [AllowNull] Edge y)
        {
            return x.Weight - y.Weight;
        }
    }
}
