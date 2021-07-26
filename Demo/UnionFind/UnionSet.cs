using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{

    public class Node<V>
    {
        public V value { get; set; }

        public Node(V v)
        {
            value = v;
        }
    }


    /// <summary>
    /// 并查集
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class UnionSet<V>
    {
        public Dictionary<V, Node<V>> Nodes { get; set; } = new Dictionary<V, Node<V>>();
        public Dictionary<Node<V>, Node<V>> Parents { get; set; } = new Dictionary<Node<V>, Node<V>>();
        public Dictionary<Node<V>, int> SizeMap { get; set; } = new Dictionary<Node<V>, int>();

        public UnionSet(List<V> values)
        {
            values.ForEach(t => {
                var node = new Node<V>(t);
                Nodes.Add(t, node);
                Parents.Add(node, node);
                SizeMap.Add(node, 1);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cur"></param>
        /// <returns></returns>
        public Node<V> FindFather(Node<V> cur)
        {
            Stack<Node<V>> path = new Stack<Node<V>>();
            while (cur != Parents[cur])
            {
                path.Push(cur);
                cur = Parents[cur];
            }

            while (path.Count > 0)
            {
                Parents.Add(path.Pop(), cur);
            }
            return cur;
        }

        public bool IsSameSet(V a,V b)
        {
            if (!Nodes.ContainsKey(a) || !Nodes.ContainsKey(b))
                return false;

            return FindFather(Nodes[a]) == FindFather(Nodes[b]);
        }

        public void Union(V a,V b)
        {
            if (!Nodes.ContainsKey(a) || !Nodes.ContainsKey(b))
                return;

            var aHead = Parents[Nodes[a]];
            var bHead = Parents[Nodes[b]];

            if (aHead != bHead)
            {
                var aSize = SizeMap[aHead];
                var bSize = SizeMap[bHead];
                Node<V> big = aSize >= bSize ? aHead : bHead;
                Node<V> small = big == aHead ? bHead : aHead;
                Parents.Add(small, big);
                SizeMap.Add(big, aSize + bSize);
                SizeMap.Remove(small);
            }
        }


    }
}
