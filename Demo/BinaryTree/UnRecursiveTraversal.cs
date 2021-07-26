using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class UnRecursiveTraversal
    {
        /// <summary>
        /// 先序
        /// </summary>
        /// <param name="head"></param>
        public static void Pre(Node head)
        {
            if(head!=null)
            {
                Stack<Node> stack = new Stack<Node>();
                stack.Push(head);
                while(stack.Count>0)
                {
                    var node = stack.Pop();
                    Console.WriteLine(node.Value);
                    if (node.Right != null)
                        stack.Push(node.Right);

                    if (node.Left != null)
                        stack.Push(node.Left);                  
                }
            }
        }

        /// <summary>
        /// 中序
        /// 1)整条左边界依次入栈
        /// 2)步骤1无法，弹出打印，来到右树执行步骤1
        /// </summary>
        /// <param name="head"></param>
        public static void In(Node head)
        {
            if (head != null)
            {
                var stack = new Stack<Node>();
                while (stack.Count > 0 || head != null)
                {
                    if (head != null)
                    {
                        stack.Push(head);
                        head = head.Left;
                    }
                    else
                    {
                        head = stack.Pop();
                        Console.WriteLine(head.Value);
                        head = head.Right;
                    }
                }
            }
        }

        /// <summary>
        /// 后序
        /// 头->右->左 倒过来 就是左->右->头 如何倒，用另一个栈接
        /// </summary>
        /// <param name="head"></param>
        public static void Pos1(Node head)
        {
            if(head!=null)
            {
                var stack1 = new Stack<Node>();
                var stack2 = new Stack<Node>();
                stack1.Push(head);
                while (stack1.Count > 0)
                {
                    var node = stack1.Pop();
                    stack2.Push(node);
                    if (head.Left != null)
                        stack1.Push(node.Left);

                    if (head.Right != null)
                        stack1.Push(node.Right);
                }

                while (stack2.Count > 0)
                    Console.WriteLine(stack2.Pop().Value);
            }
        }

        /// <summary>
        /// 后序 省空间
        /// 把树当作全是左子树（右节点也当作自己的左子树），就像//////，就相当于无论左右树，一直往下压栈，最终实现左->右->中
        /// </summary>
        /// <param name="head"></param>
        public static void Pos2(Node head)
        {
            if (head != null)
            {
                var stack = new Stack<Node>();
                stack.Push(head);
                Node cur = null;

                while (stack.Count > 0)
                {
                    cur = stack.Peek();
                    //head指向处理完的节点， 判断左数是否处理完
                    if (cur.Left != null && head != cur.Left && head != cur.Right)
                    {
                        stack.Push(cur.Left);
                    }
                    //判断右树是否处理完
                    else if (cur.Right != null && head != cur.Right)
                    {
                        stack.Push(cur.Right);
                    }
                    //当作左右树都处理完成,弹出节点当作已处理，head指向处理的节点
                    else
                    {
                        Console.WriteLine(stack.Pop());
                        //把指针指到弹出打印的节点（处理的节点），cur的位置会在新的循环来到head的父节点
                        head = cur;
                    }
                }
            }
        }
    }
}
