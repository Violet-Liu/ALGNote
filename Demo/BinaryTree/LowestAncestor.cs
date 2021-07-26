using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 给定一颗二叉树的头节点head,和另外两个节点a和b，返回a和b的最低公共祖先
    /// </summary>
    public class LowestAncestor
    {
        public static void FillParentMap(Node head,Dictionary<Node,Node> parentMap)
        {
            if(head.Left!=null)
            {
                parentMap.Add(head.Left,head.Left);
                FillParentMap(head.Left, parentMap);
            }

            if(head.Right!=null)
            {
                parentMap.Add(head.Right, head);
                FillParentMap(head.Right, parentMap);
            }
        }

        public static Node LowestAncestor1(Node head,Node o1,Node o2)
        {
            if (head == null)
                return null;

            var parentMap = new Dictionary<Node, Node>();
            parentMap.Add(head, null);
            FillParentMap(head, parentMap);
            HashSet<Node> o1Sets = new HashSet<Node>();
            Node cur = o1;
            o1Sets.Add(o1);
            while(parentMap[o1]!=null)
            {
                cur = parentMap[o1];
                o1Sets.Add(cur);
            }

            cur = o2;

            while (!o1Sets.Contains(o2))
            {
                cur = parentMap[o2];
            }
            return cur;
        }

        public class Info 
        {
            public Node Ans;
            public bool FindO1;
            public bool FindO2;

            public Info(Node ans,bool findO1,bool findO2)
            {
                Ans = ans;
                FindO1 = findO1;
                FindO2 = findO2;
            }
        }

        public static Info Process(Node head,Node O1,Node O2)
        {
            if (head == null)
                return new Info(null, false, false);

            var leftInfo = Process(head.Left,O1,O2);
            var rightInfo = Process(head.Right,O1,O2);
            bool findO1 = head == O1 || leftInfo.FindO1 || leftInfo.FindO2;
            bool findO2 = head == O2 || leftInfo.FindO2 || rightInfo.FindO2;

            Node ans = null;

            if (leftInfo.Ans != null)
                ans = leftInfo.Ans;

            if (rightInfo.Ans != null)
                ans = rightInfo.Ans;

            if(ans==null)
            {
                if (findO1 && findO2)
                    ans = head;
            }

            return new Info(ans, findO1, findO2);

        }
        
    }
}
