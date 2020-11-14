using System;

namespace PartitionAndQuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(18 | 1);
            Console.ReadLine();
        }
        public static void Swap(int[] arr, int L, int R)
        {
            arr[L] = arr[L] ^ arr[R];
            arr[R] = arr[L] ^ arr[R];
            arr[L] = arr[L] ^ arr[R];
        }

        public static int Partition(int[] arr,int L,int R)
        {
            if (L > R)
                return -1;

            if (L == R)
                return R;

            int less = L - 1;
            int index = L;

            while (index < R)
            {
                if(arr[index] < arr[R])
                {
                    if (arr[index] < arr[R])
                    {
                        Swap(arr, index++, ++less);
                    }
                    else 
                    {
                        index++; 
                    }
                }
            }

            return less;
        }

        /// <summary>
        /// 荷兰旗
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        public static (int left, int right) NetherlandsFlag(int[] arr, int L, int R)
        {
            if (L > R)
                return (-1, -1);

            if (L == R)
                return (L, R);

            int less = L - 1;  //找出小于区域 右边界
            int more = R;      //找出大于区域 左边界
            int index = L;
            while (index < more)
            {
                if (arr[index] == arr[R])
                {
                    index++;
                }
                else if (arr[index] < arr[R])
                {
                    Swap(arr, index++, ++less);
                }
                else
                {
                    Swap(arr, index, --more);
                }
            }
            Swap(arr, more, R);

            return (less+1 ,more);
        }

        /// <summary>
        /// 快排1.0
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        public static void Process1(int[] arr,int L,int R)
        {
            if (L >= R)
                return;

            int M = Partition(arr, L, R);
            Process1(arr, L, M - 1);
            Process1(arr, M + 1, R);
        }

        public static void Process2(int[] arr,int L,int R)
        {
            if (L >= R)
                return;

            var equalArea = NetherlandsFlag(arr, L, R);
            Process2(arr, L, equalArea.left-1);
            Process2(arr, equalArea.right+1, R);
        }

        public static void Process3(int[] arr,int L,int R)
        {
            if (L >= R)
                return;
            Swap(arr, L + (new Random().Next(R - L + 1)), R);
            var equalArea = NetherlandsFlag(arr, L, R);
            Process3(arr, L, equalArea.left - 1);
            Process3(arr, equalArea.right + 1, R);
        }
    }
}
