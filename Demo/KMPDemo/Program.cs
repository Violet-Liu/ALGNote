using System;

namespace KMPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int[] GetNextArray(char[] match)
        {
            if (match.Length == 1)
            {
                return new int[] { -1 };
            }

            int[] next = new int[match.Length];
            next[0] = -1;
            next[1] = 0;
            int i = 2;
            int cn = 0;

            while (i < next.Length)
            {
                if (match[i - 1] == match[cn])
                    next[i++] = ++cn;
                else if (cn > 0)
                    cn = next[cn];
                else
                    next[i++] = 0;
            }
            return next;
        }
    }
}
