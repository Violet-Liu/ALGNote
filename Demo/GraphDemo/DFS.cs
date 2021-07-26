using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDemo
{
    public class DFS
    {
        /// <summary>
        /// 深度优先遍历
        /// 给定一个点，发起深度优先搜索，直至途中和v有路径相通的顶点都被访问
        /// 每个节点只能访问一次
        /// </summary>
        /// <param name="node"></param>
        public static void dfs(Node node)
        {
            if (node == null)
                return;

            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> set = new HashSet<Node>();
            stack.Push(node);
            set.Add(node);
            Console.WriteLine(node.Value);
            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                foreach (var next in node.Nexts)
                {
                    if (!set.Contains(next))
                    {
                        stack.Push(cur);
                        stack.Push(next);
                        set.Add(next);
                        Console.WriteLine(next.Value);
                        break; //先把一条路走到底，等没有路的时候，在找到上个节点的分支
                    }
                }
            }
        }
    }
}
