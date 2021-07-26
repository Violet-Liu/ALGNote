using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    /// <summary>
    /// 点结构的描述
    /// </summary>
    public class Node
    {
        public int Value { get; set; }

        public int In { get; set; }

        public int Out { get; set; }

        public List<Node> Nexts { get; set; }

        public List<Edge> Edges { get; set; }

        public Node(int value)
        {
            this.Value = value;
            Nexts = new List<Node>();
            Edges = new List<Edge>();
        }
    }
}
