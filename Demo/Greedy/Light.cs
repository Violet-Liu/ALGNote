using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy
{
   
    /// <summary>
    /// 一个数组中有两种元素重复随机排列，比如X,. X元素是一堵墙不能放灯也不需要照亮，b元素是路灯可以自己放灯，也能被旁边照亮
    /// 放灯的位置能照亮左右两边的元素
    /// 要求选出能照亮所有的方案中，最少需要多少灯
    /// </summary>
    public class Light
    {
        public static int MinLight1(string road)
        {
            if (road?.Length == 0)
                return 0;

            return Process(road.ToCharArray(), 0, new HashSet<int>());
        }

        /// <summary>
        /// 1) .X 那么b必须点亮自己
        /// 2）.. 第一个.可以选择点亮或者不点亮
        /// </summary>
        /// <param name="str">数组</param>
        /// <param name="index">当前位置</param>
        /// <param name="lights">点灯的位置</param>
        /// <returns></returns>
        public static int Process(char[] str, int index, HashSet<int> lights)
        {
            //结束的时候
            if (index == str.Length)
            {
                //校验
                for(int i = 0; i < str.Length; i++)
                {
                    if (str[i] != 'X')
                    {
                        //三个元素都没点灯，说明是失败的
                        if (!lights.Contains(i - 1) && !lights.Contains(i) && !lights.Contains(i + 1))
                            return int.MaxValue;
                    }
                }
                return lights.Count;
            }
            else
            {
                //不点亮场景,包括X
                int no = Process(str, index + 1, lights);
                int yes = int.MaxValue;
                if (str[index] == '.')
                {
                    lights.Add(index);
                    yes = Process(str, index + 1, lights);
                    //深度遍历，还原环境，得到排列组合
                    lights.Remove(index);
                }
                return Math.Min(no, yes);
            }
        }

        public static int MinLight2(string road)
        {
            char[] strs = road.ToCharArray();

            int index = 0;
            int light = 0;

            while (index < strs.Length)
            {
                if (strs[index] == 'X')
                    index++;
                else
                {
                    light++;
                    if (index + 1 == strs.Length)
                        break;
                    else
                    {
                        //贪心 假设... 点亮中间是最优的答案
                        if (strs[index + 1] == 'X')
                            index = index + 2;
                        else
                        {
                            index = index + 3;
                        }
                    }
                }
            }
            return light;
        }
    }
}
