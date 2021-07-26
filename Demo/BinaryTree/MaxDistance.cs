using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MaxDistance
    {
        public static void FillParentMap(Node head, Dictionary<Node, Node> parentMap)
        {
            if (head.Left != null)
            {
                parentMap.Add(head.Left, head.Left);
                FillParentMap(head.Left, parentMap);
            }

            if (head.Right != null)
            {
                parentMap.Add(head.Right, head);
                FillParentMap(head.Right, parentMap);
            }
        }

        public static int MaxDistance1(Node head)
        {
            if (head == null)
                return 0;

            List<Node> arr = GetPreList(head);
            Dictionary<Node, Node> parentMap = GetParentMap(head);
            int max = 0;
            for(int i = 0; i < arr.Count; i++)
            {
                for(int j=i;j<arr.Count;j++)
                {
                    max = Math.Max(max, Distance(parentMap, arr[i], arr[j]));
                }
            }
            return max;
        }

        public static int Distance(Dictionary<Node,Node> parentMap,Node O1,Node O2)
        {
            HashSet<Node> o1Set = new HashSet<Node>();
            Node cur = O1;
            o1Set.Add(cur);
            while (parentMap[cur] != null)
            {
                cur = parentMap[cur];
                o1Set.Add(cur);
            }
            cur = O2;
            while(!o1Set.Contains(cur))
            {
                cur = parentMap[cur];
            }

            Node lowestAncestor = cur;
            cur = O1;
            int distance1 = 1;
            while (cur != lowestAncestor)
            {
                cur = parentMap[cur];
                distance1++;
            }
            cur = O2;
            int distance2 = 1;
            while (cur != lowestAncestor)
            {
                cur = parentMap[cur];
                distance2++;
            }
            return distance1 + distance2 - 1;
        }

        public static Dictionary<Node,Node> GetParentMap(Node head)
        {
            var map = new Dictionary<Node, Node>();
            map.Add(head, null);
            FillParentMap(head, map);

            return map;
        }

        public static List<Node> GetPreList(Node head)
        {
            var arr = new List<Node>();
            FillPreList(head,arr);
            return arr;
        }

        public static void FillPreList(Node head,List<Node> arr)
        {
            if (head == null)
                return;

            arr.Add(head);
            FillPreList(head.Left, arr);
            FillPreList(head.Right, arr);
        }

        public class Info
        {
            public int MaxDistance { get; set; }

            public int Height { get; set; }

            public Info(int maxDistance,int height)
            {
                MaxDistance = maxDistance;
                Height = height;
            }
        }

        public static Info Process(Node head)
        {
            if (head == null)
                return new Info(0, 0);

            Info leftInfo = Process(head.Left);
            Info rightInfo = Process(head.Right);
            int height = Math.Max(leftInfo.Height, rightInfo.Height) + 1;
            int maxDistance = Math.Max(Math.Max(leftInfo.MaxDistance, rightInfo.MaxDistance), leftInfo.Height + rightInfo.Height + 1);
            return new Info(maxDistance, height);
        }
    }
}
