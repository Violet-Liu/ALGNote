using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class MaxHappy
    {
        public class Employee
        {
            public int Happy { get; set; }

            public List<Employee> Subs { get; set; }

            public Employee(int h)
            {
                Happy = h;
                Subs = new List<Employee>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cur">当前的节点</param>
        /// <param name="up">cur的上级是否来</param>
        /// <returns></returns>
        public static int Process1(Employee cur,Boolean up)
        {
            if(up)
            {
                int ans = 0;
                //上级来的话，cur只能不来
                cur.Subs.ForEach(t => ans += Process1(t, false));
                return ans;
            }
            else
            {
                int p1 = cur.Happy;
                cur.Subs.ForEach(t => p1 += Process1(t, true));
                int p2 = 0;
                cur.Subs.ForEach(t => p2 += Process1(t, false));

                return Math.Max(p1, p2);
            }
        }

        public class Info
        {
            public int Yes { get; set; }

            public int No { get; set; }

            public Info(int yes, int no)
            {
                Yes = yes;
                No = no;
            }
        }

        public static Info Process2(Employee node)
        {
            if (node.Subs == null)
                return new Info(node.Happy, 0);

            int yes = node.Happy;
            int no = 0;
            node.Subs.ForEach(t => {
                Info next = Process2(t);
                yes += next.Yes;
                no += Math.Max(next.Yes, next.No);

            });
            return new Info(yes, no);
        }
    }
}
