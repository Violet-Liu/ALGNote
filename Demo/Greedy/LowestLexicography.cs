using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Greedy
{
    /// <summary>
    /// 将一个字符串数组按字典序排序进行组合，得到最小的组合 
    /// </summary>
    public class LowestLexicography
    {
        public static string Lowest1(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            HashSet<int> use = new HashSet<int>();
            List<string> all = new List<string>();
            Process(strs, use, "", all);
            string lowest = all[0];
            for (int i = 1; i < all.Count; i++)
            {
                if (all[i].CompareTo(lowest) < 0)
                {
                    lowest = all[i];
                }
            }
            return lowest;
        }

        /// <summary>
        /// 通过深度遍历实现排序组合
        /// </summary>
        /// <param name="strs">字符串数组</param>
        /// <param name="use">已经使用过的字符串下标</param>
        /// <param name="path">待拼接的</param>
        /// <param name="all">收集结果</param>
        public static void Process(string[] strs, HashSet<int> use, string path, List<string> all)
        {
            if (use.Count == strs.Length)
            {
                all.Add(path);
            }
            else
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!use.Contains(i))
                    {
                        use.Add(i);
                        Process(strs, use, path + strs[i], all);
                        //将环境还原
                        use.Remove(i);
                    }
                }
            }
        }

        public class StringComparator : IComparer<string>
        {
            public int Compare([AllowNull] string x, [AllowNull] string y)
            {
                //贪心证明
                return (x + y).CompareTo(y + x);
            }
        }

        public static string Lowest2(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            Array.Sort<string>(strs);
            string res = "";
            for(int i = 0; i < strs.Length; i++)
            {
                res += strs[i];
            }
            return res;
        }

        public static String GenerateRandomString(int strLen)
        {
            var random = new Random();
            char[] ans = new char[(int)(random.NextDouble() * strLen) + 1];
            for(int i = 0; i < ans.Length; i++)
            {
                int value = (int)(random.NextDouble() * 5);
                ans[i] = random.NextDouble() <= 0.5 ? (char)(65 + value) : (char)(97 + value);

            }
            return ans.ToString();

        }

        public static string[] GenerateRndomStringArray(int arrLen,int strLen)
        {
            string[] ans = new string[(int)(new Random().NextDouble() * arrLen) + 1];
            for(int i = 0; i < ans.Length; i++)
            {
                ans[i] = GenerateRandomString(strLen);
            }
            return ans;
        }

        public static string[] CopyStringArray(string[] arr)
        {
            string[] ans = new string[arr.Length];
            for(int i= 0; i < arr.Length; i++)
            {
                ans[i] = arr[i];
            }
            return ans;
        }
    }
}
