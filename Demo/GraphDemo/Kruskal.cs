using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GraphDemo
{
    public class Kruskal
    {
        public class UnionFind
        {
            //Key 某一节点 value key 节点往上的节点
            private Dictionary<Node, Node> FatherMap;
            //Key 某一个集合的代表节点，value key 所在集合的节点个数
            private Dictionary<Node, int> SizeMap;

            public UnionFind()
            {
                FatherMap = new Dictionary<Node, Node>();
                SizeMap = new Dictionary<Node, int>();
            }

            public void MakeSets(IEnumerable<Node> nodes)
            {
                FatherMap.Clear();
                SizeMap.Clear();

                foreach(var node in nodes)
                {
                    FatherMap.Add(node, node);
                    SizeMap.Add(node, 1);
                }
            }

            private Node FindFather(Node cur)
            {
                Stack<Node> stack = new Stack<Node>();
                while (cur != FatherMap[cur])
                {
                    stack.Push(cur);
                    cur = FatherMap[cur];
                }

                while (stack.Count > 0)
                    FatherMap.Add(stack.Pop(), cur);

                return cur;
            }

            public bool IsSameSet(Node a, Node b) => FatherMap[a] == FatherMap[b];

            public void Union(Node a,Node b)
            {
                if (a == null || b == null)
                    return;

                Node aHead = FindFather(a);
                Node bHead = FindFather(b);
                if (aHead != bHead)
                {
                    int aSize = SizeMap[aHead];
                    int bSize = SizeMap[bHead];

                    var bigHead = aSize > bSize ? aHead : bHead;
                    var smallHead = aHead == bigHead ? bHead : aHead;

                    FatherMap.Remove(smallHead);
                    FatherMap.Add(smallHead, bigHead);

                    SizeMap.Remove(smallHead);
                    SizeMap.Remove(bigHead);
                    SizeMap.Add(bigHead, aSize + bSize);
                }
            }
        }

        public class PriorityQueue<T> : IEnumerable<T>
       where T : class
        {
            readonly IComparer<T> comparer;
            int count;
            int capacity;
            T[] items;

            public PriorityQueue(IComparer<T> comparer)
            {


                this.comparer = comparer;
                this.capacity = 11;
                this.items = new T[this.capacity];
            }

            public PriorityQueue()
                : this(Comparer<T>.Default)
            {
            }

            public int Count => this.count;

            public T Dequeue()
            {
                T result = this.Peek();
                if (result == null)
                {
                    return null;
                }

                int newCount = --this.count;
                T lastItem = this.items[newCount];
                this.items[newCount] = null;
                if (newCount > 0)
                {
                    this.TrickleDown(0, lastItem);
                }

                return result;
            }

            public T Peek() => this.count == 0 ? null : this.items[0];

            public void Enqueue(T item)
            {


                int oldCount = this.count;
                if (oldCount == this.capacity)
                {
                    this.GrowHeap();
                }
                this.count = oldCount + 1;
                this.BubbleUp(oldCount, item);
            }

            public void Remove(T item)
            {
                int index = Array.IndexOf(this.items, item);
                if (index == -1)
                {
                    return;
                }

                this.count--;
                if (index == this.count)
                {
                    this.items[index] = default(T);
                }
                else
                {
                    T last = this.items[this.count];
                    this.items[this.count] = default(T);
                    this.TrickleDown(index, last);
                    if (this.items[index] == last)
                    {
                        this.BubbleUp(index, last);
                    }
                }
            }

            void BubbleUp(int index, T item)
            {
                // index > 0 means there is a parent
                while (index > 0)
                {
                    int parentIndex = (index - 1) >> 1;
                    T parentItem = this.items[parentIndex];
                    if (this.comparer.Compare(item, parentItem) >= 0)
                    {
                        break;
                    }
                    this.items[index] = parentItem;
                    index = parentIndex;
                }
                this.items[index] = item;
            }

            void GrowHeap()
            {
                int oldCapacity = this.capacity;
                this.capacity = oldCapacity + (oldCapacity <= 64 ? oldCapacity + 2 : (oldCapacity >> 1));
                var newHeap = new T[this.capacity];
                Array.Copy(this.items, 0, newHeap, 0, this.count);
                this.items = newHeap;
            }

            void TrickleDown(int index, T item)
            {
                int middleIndex = this.count >> 1;
                while (index < middleIndex)
                {
                    int childIndex = (index << 1) + 1;
                    T childItem = this.items[childIndex];
                    int rightChildIndex = childIndex + 1;
                    if (rightChildIndex < this.count
                        && this.comparer.Compare(childItem, this.items[rightChildIndex]) > 0)
                    {
                        childIndex = rightChildIndex;
                        childItem = this.items[rightChildIndex];
                    }
                    if (this.comparer.Compare(item, childItem) <= 0)
                    {
                        break;
                    }
                    this.items[index] = childItem;
                    index = childIndex;
                }
                this.items[index] = item;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < this.count; i++)
                {
                    yield return this.items[i];
                }
            }

            public void Clear()
            {
                this.count = 0;
                Array.Clear(this.items, 0, 0);
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }


        public class EdgeComparator : IComparer<Edge>
        {
            public int Compare([AllowNull] Edge x, [AllowNull] Edge y)
            {
                return x.Weight - y.Weight;
            }
        }

        public HashSet<Edge> KruskaMST(Graph graph)
        {
            UnionFind unionFind = new UnionFind();
            unionFind.MakeSets(graph.Nodes.Values);

            PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>(new EdgeComparator());

            foreach (var edge in graph.Edges)
                priorityQueue.Enqueue(edge);

            HashSet<Edge> ans = new HashSet<Edge>();

            while (priorityQueue.Count > 0)
            {
                var edge = priorityQueue.Dequeue();
                if (!unionFind.IsSameSet(edge.From, edge.To))
                {
                    ans.Add(edge);
                    unionFind.Union(edge.From, edge.To);
                }
            }
            return ans;
        }
    }
}
