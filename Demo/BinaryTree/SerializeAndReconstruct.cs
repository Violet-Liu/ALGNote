using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    /// <summary>
    /// 二叉树无法通过中序遍历进行序列化和反序列化，因为不同的两棵树，可能得到同样的中序序列
    /// </summary>
    public class SerializeAndReconstruct
    {
        public static Queue<String> PreSerial(Node head)
        {
            Queue<string> ans = new Queue<string>();
            Pres(head, ans);
            return ans;
        }

        public static void Pres(Node head,Queue<string> ans)
        {
            if (head == null)
                ans.Enqueue(null);
            else
            {
                ans.Enqueue(head.Value.ToString());
                Pres(head.Left, ans);
                Pres(head.Right, ans);
            }
        }

        public static Queue<String> InSerial(Node head)
        {
            Queue<string> ans = new Queue<string>();
            Ins(head, ans);
            return ans;
        }

        public static void Ins(Node head, Queue<string> ans)
        {
            if (head == null)
                ans.Enqueue(null);
            else
            {
                Ins(head.Left, ans);
                ans.Enqueue(head.Value.ToString());
                Ins(head.Right, ans);
            }
        }

        public static Queue<String> PosSerial(Node head)
        {
            Queue<string> ans = new Queue<string>();
            Poss(head, ans);
            return ans;
        }

        public static void Poss(Node head, Queue<string> ans)
        {
            if (head == null)
                ans.Enqueue(null);
            else
            {
                Poss(head.Left, ans);               
                Poss(head.Right, ans);
                ans.Enqueue(head.Value.ToString());
            }
        }

        public static Node Preb(Queue<string> prelist)
        {
            if (prelist == null || prelist.Count == 0)
                return null;

            var value = prelist.Dequeue();
            if (value == null)
                return null;

            var head = new Node(int.Parse(value));
            head.Left = Preb(prelist);
            head.Left = Preb(prelist);

            return head;
        }

        public static Node PosB(Queue<string> poslist)
        {
            if (poslist == null || poslist.Count == 0)
                return null;

            //左右中->中右左
            var stack = new Stack<string>();
            while (poslist.Count > 0)
                stack.Push(poslist.Dequeue());

            return Posb(stack);
        }

        public static Node Posb(Stack<string> poslist)
        {
            var value = poslist.Pop();
            if (value == null)
                return null;

            Node head = new Node(int.Parse(value));
            head.Right = Posb(poslist);
            head.Left = Posb(poslist);

            return head;
        }

        public static Queue<string> LevelSerial(Node head)
        {
            var ans = new Queue<string>();
            if (head == null)
                ans.Enqueue(null);
            else
            {
                ans.Enqueue(head.Value.ToString());
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(head);
                while(queue.Count>0)
                {
                    head = queue.Dequeue();
                    if(head.Left!=null)
                    {
                        ans.Enqueue(head.Left.Value.ToString());
                        queue.Enqueue(head.Left);
                    }
                    else
                    {
                        ans.Enqueue(null);
                    }

                    if(head.Right!=null)
                    {
                        ans.Enqueue(head.Right.Value.ToString());
                        queue.Enqueue(head.Right);
                    }
                    else
                    {
                        ans.Enqueue(null);
                    }
                }
            }
            return ans;

        }

        public static Node Levelb(Queue<string> levelList)
        {
            if (levelList == null || levelList.Count == 0)
                return null;

            Node head = GenerateNode(levelList.Dequeue());
            Queue<Node> queue = new Queue<Node>();
            if(head!=null)
            {
                queue.Enqueue(head);
            }
            Node node = null;
            while(queue.Count>0)
            {
                node = queue.Dequeue();
                node.Left = GenerateNode(levelList.Dequeue());
                node.Right = GenerateNode(levelList.Dequeue());
                if(node.Left!=null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return head;
        }

        public static Node GenerateNode(string val)
        {
            if (val == null)
                return null;

            return new Node(int.Parse(val));
        }

        // for test
        public static Node generate(int level, int maxLevel, int maxValue)
        {
            var random = new Random();
            if (level > maxLevel || random.NextDouble() < 0.5)
            {
                return null;
            }
            Node head = new Node((int)(random.NextDouble() * maxValue));
            head.Left = generate(level + 1, maxLevel, maxValue);
            head.Right = generate(level + 1, maxLevel, maxValue);
            return head;
        }

        public static Boolean IsSameValueStructure(Node head1, Node head2)
        {
            if (head1 == null && head2 != null)
            {
                return false;
            }
            if (head1 != null && head2 == null)
            {
                return false;
            }
            if (head1 == null && head2 == null)
            {
                return true;
            }
            if (head1.Value != head2.Value)
            {
                return false;
            }
            return IsSameValueStructure(head1.Left, head2.Left) && IsSameValueStructure(head1.Right, head2.Right);
        }

        // for test
        public static void printTree(Node head)
        {
            Console.WriteLine("Binary Tree:");
            printInOrder(head, 0, "H", 17);
            Console.WriteLine();
        }

        public static void printInOrder(Node head, int height, String to, int len)
        {
            if (head == null)
            {
                return;
            }
            printInOrder(head.Right, height + 1, "v", len);
            String val = to + head.Value + to;
            int lenM = val.Length;
            int lenL = (len - lenM) / 2;
            int lenR = len - lenM - lenL;
            val = getSpace(lenL) + val + getSpace(lenR);
            Console.WriteLine(getSpace(height * len) + val);
            printInOrder(head.Left, height + 1, "^", len);
        }

        public static String getSpace(int num)
        {
            String space = " ";
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                buf.Append(space);
            }
            return buf.ToString();
        }

        public static Node generateRandomBST(int maxLevel, int maxValue)
        {
            return generate(1, maxLevel, maxValue);
        }

        public static void main(String[] args)
        {
            int maxLevel = 5;
            int maxValue = 100;
            int testTimes = 1000000;
            Console.WriteLine("test begin");
            for (int i = 0; i < testTimes; i++)
            {
                Node head = generateRandomBST(maxLevel, maxValue);
                Queue<String> pre = PreSerial(head);
                Queue<String> pos = PosSerial(head);
                Queue<String> level = LevelSerial(head);
                Node preBuild = Preb(pre);
                Node posBuild = PosB(pos);
                Node levelBuild = Levelb(level);
                if (!IsSameValueStructure(preBuild, posBuild) || !IsSameValueStructure(posBuild, levelBuild))
                {
                    Console.WriteLine("Oops!");
                }
            }
            Console.WriteLine("test finish!");

        }

    }
}
