using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    public class Graph
    {
        public Dictionary<int,Node> Nodes { get; set; }

        public HashSet<Edge> Edges { get; set; }

        public Graph()
        {
            Nodes = new Dictionary<int, Node>();
            Edges = new HashSet<Edge>();
        }

        public static Graph Create(int[][] matrix)
        {
            Graph graph = new Graph();
            for (int i = 0; i < matrix.Length; i++)
            {
                int weight = matrix[i][0];
                int from = matrix[i][1];
                int to = matrix[i][2];

                if (!graph.Nodes.ContainsKey(from))
                {
                    graph.Nodes.Add(from, new Node(from));

                }
                if (!graph.Nodes.ContainsKey(to))
                {
                    graph.Nodes.Add(from, new Node(to));
                }

                Node fromNode = graph.Nodes[from];
                Node toNode = graph.Nodes[to];

                var edge = new Edge(weight, fromNode, toNode);
                fromNode.Nexts.Add(toNode);
                fromNode.Edges.Add(edge);
                fromNode.In++;
                fromNode.Out++;
                graph.Edges.Add(edge);
            }
            return graph;
        }
    }
}
