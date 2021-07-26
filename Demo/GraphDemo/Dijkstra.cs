using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    public class Dijkstra
    {
        public static Dictionary<Node,int> Process(Node from)
        {
            Dictionary<Node, int> distanceMap = new Dictionary<Node, int>();
            distanceMap.Add(from, 0);
            HashSet<Node> selectedNodes = new HashSet<Node>();

            Node minNode = GetMinDistanceAndUnselectedNode(distanceMap, selectedNodes);
            while (minNode != null)
            {
                int distance = distanceMap[minNode];
                foreach(var edge in minNode.Edges)
                {
                    var node = edge.To;
                    if (!distanceMap.ContainsKey(node))
                    {
                        distanceMap.Add(node, edge.Weight + distance);
                    }
                    else
                    {
                        distanceMap[node] = distance + edge.Weight;
                    }
                }
                selectedNodes.Add(minNode);
                minNode = GetMinDistanceAndUnselectedNode(distanceMap, selectedNodes);
            }

            return distanceMap;
        }

        public static Node GetMinDistanceAndUnselectedNode(Dictionary<Node,int> distanceMap,HashSet<Node> touchedNodes)
        {
            Node minNode = null;
            int minDistance = int.MaxValue;

            foreach(var entry in distanceMap)
            {
                var node = entry.Key;
                int distance = entry.Value;
                if (!touchedNodes.Contains(node) && distance < minDistance)
                {
                    minNode = node;
                    minDistance = distance;
                }
            }

            return minNode;
        }

        public class NodeRecord
        {
            public Node Node { get; set; }

            public int Distance { get; set; }

            public NodeRecord(Node node,int distance)
            {
                Node = node;
                Distance = distance;
            }
        }

        public class NodeHeap
        {
            public Node[] Nodes { get; set; }

            public Dictionary<Node,int> HeapIndexMap { get; set; }

            public Dictionary<Node,int> DistanceMap { get; set; }

            private int _size;

            public NodeHeap(int size)
            {
                Nodes = new Node[size];
                HeapIndexMap = new Dictionary<Node, int>();
                DistanceMap = new Dictionary<Node, int>();
                _size = 0;
            }

            public void AddOrUpdateOrIgnore(Node node,int distance)
            {
                if (InHeap(node))
                {
                    var min = Math.Min(DistanceMap[node], distance);
                    DistanceMap[node] = min;
                    InsertHeapify(node, HeapIndexMap[node]);
                }

                if(!IsEntered(node))
                {
                    Nodes[_size] = node;
                    HeapIndexMap.Add(node, _size);
                    DistanceMap.Add(node, distance);
                    InsertHeapify(node, _size++);
                }
            }

            private void InsertHeapify(Node node,int index)
            {
                while (DistanceMap[Nodes[index]]<DistanceMap[Nodes[(index-1)/2]])
                {
                    Swap(index, (index - 1) / 2);
                    index = (index - 1) / 2;

                }
            }

            private void Heapify(int index,int size)
            {
                var left = index * 2 + 1;
                while (left < size)
                {
                    var smallSize = left + 1 < size && DistanceMap[Nodes[left + 1]] < DistanceMap[Nodes[left]] ? left + 1 : left;
                    smallSize = DistanceMap[Nodes[smallSize]] < DistanceMap[Nodes[index]] ? smallSize : index;
                    if (index == smallSize)
                        break;

                    Swap(smallSize, index);
                    index = smallSize;
                    left = index * 2 + 1;
                }
            }

            private bool IsEntered(Node node) => HeapIndexMap.ContainsKey(node);

            private bool InHeap(Node node) => IsEntered(node) && HeapIndexMap[node] != -1;

            public bool IsEmpty() => _size == 0;

            private void Swap(int index1,int index2)
            {
                HeapIndexMap[Nodes[index1]] = index2;
                HeapIndexMap[Nodes[index2]] = index1;
                Node temp = Nodes[index1];
                Nodes[index1] = Nodes[index2];
                Nodes[index2] = temp;
            }



        }
    }
}
