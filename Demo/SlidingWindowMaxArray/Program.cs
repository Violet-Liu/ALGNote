using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindowMaxArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int testTimes = 2000000;
            Console.WriteLine("test begin");
            for (int i = 0; i < testTimes; i++)
            {
                int[] arr = gerenareRondomArray();
                if (max1(arr) != max2(arr))
                {
                   Console.WriteLine("FUCK!");
                    break;
                }
            }
            Console.WriteLine("Oops!");
            Console.ReadLine();
        }

        public static int max1(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    int minNum = int.MinValue;
                    int sum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        sum += arr[k];
                        minNum = Math.Min(minNum, arr[k]);
                    }
                    max = Math.Min(max, minNum * sum);
                }
            }
            return max;
        }

        public static int[] gerenareRondomArray()
        {
            var randon = new Random();
            int[] arr = new int[(int)(randon.NextDouble() * 20) + 10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (int)(randon.NextDouble() * 101);
            }
            return arr;
        }

        /// <summary>
        /// 给定一个数组，求组任何子数组乘以该子数组中最小值，求出最大值
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int max2(int[] arr)
        {
            int ans = 0;
            int[] sumArr = new int[arr.Length];
            sumArr[0] = arr[0];
            //保存每个区间的sum值,sum(arr[L...R])=sum(arr[0...R])-sum(arr[0...L-1])
            for (int i = 1; i < arr.Length; i++)
            {
                sumArr[i] = sumArr[i - 1] + arr[i];
            }
            var stack = new Stack<int>();
            //遍历每个元素index,取出index为最小值能得到最大的子数组，比较得出index*Sum(Max(Sub))的最大值
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    int j = stack.Pop();
                    ans = Math.Max(ans, (stack.Count == 0 ? sumArr[i - 1] : (sumArr[i - 1] - sumArr[stack.Peek()])) * arr[j]);
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
            {
                int j = stack.Pop();
                ans = Math.Max(ans, (stack.Count == 0 ? sumArr[arr.Length - 1] : (sumArr[arr.Length - 1] - sumArr[stack.Peek()])) * arr[j]);
            }

            

            return ans;

        }

        public static int[] GetMaxWindow(int[] arr,int w)
        {
            if (arr == null || w < 1 || arr.Length < w)
                return null;

            var qMax = new LinkedList<int>();

            int[] res = new int[arr.Length - w + 1];

            int index = 0;

            for(int R = 0; R < arr.Length; R++)
            {
                while (qMax.Count > 0 && arr[qMax.Last.Value] <= arr[R])
                {
                    qMax.RemoveLast();
                }
                qMax.AddLast(R);

                if (qMax.First.Value == R - w)
                    qMax.RemoveFirst();

                if (R > w - 1)
                {
                    res[index++] = arr[qMax.First.Value];
                }
            }

            return res;
        }
    }
}
