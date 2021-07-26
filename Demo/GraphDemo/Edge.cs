using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    public class Edge
    {
        public int Weight { get; set; }

        public Node From { get; set; }

        public Node To { get; set; }

        public Edge(int weight,Node from,Node to)
        {
            this.Weight = weight;
            this.From = from;
            this.To = to;
        }
    }
}
