using System;

namespace BasicSort
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack1 = new MyStack();
            stack1.push(2);
            stack1.push(3);
            Console.WriteLine(stack1.GetMin());
            stack1.push(4);
            Console.WriteLine(stack1.GetMin());
            stack1.push(1);
            Console.WriteLine(stack1.GetMin());
            Console.WriteLine(stack1.pop());
            Console.WriteLine(stack1.GetMin());

            Console.ReadLine();
        }

        public static int GetLessIndex(int[] arr)
        {
            if(arr==null||arr.Length==0)
            {
                return -1;
            }

            if (arr.Length == 2 || arr[0] < arr[1])
                return 0;
            if(arr[arr.Length-1]<arr[arr.Length-2])
            {
                return arr.Length - 1;
            }

            int left = 1;
            int right = arr.Length - 2;
            int mid = 0;
            while (left < right)
            {
                mid = (left + right) / 2;
                if (arr[mid] > arr[mid - 1])
                {
                    right = mid - 1;
                }
                else if (arr[mid] > arr[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return left;
        }

        /// <summary>
        /// 数组第二个数据开始往前比较，符合条件交换，然后第三个和第二个比较，符合交换，继续往前比较，重复
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            for(int i=1;i<arr.Length;i++)
            {
                for (int j = i - 1; i >= 0 && arr[j] > arr[j + 1]; j--)
                    Swap(arr, j, j + 1);
            }
        }

        /// <summary>
        /// 位置1和位置2交换，位置2与位置3交换...将最大的数放到最后，固定好最后的位置不参与下次排序
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            for(int e=arr.Length-1;e>0;e--)
            {
                for(int i=0;i<e;i++)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(arr, i, i + 1);
                }
            }
        }

        /// <summary>
        /// 第一次遍历所有的元素，拿到最小的元素与arr[0]替换
        /// 第二次遍历从1开始的位置，拿到最小的元素与arr[1]替换
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + i; j < arr.Length; j++)
                {
                    minIndex = arr[j] < arr[minIndex] ? j : minIndex;
                }
                Swap(arr, i, minIndex);
            }
        }

        public static Boolean BsSearch(int[] sortedArr,int num)
        {
            if(sortedArr==null||sortedArr.Length==0)
            {
                return false;
            }

            int L = 0;
            int R = sortedArr.Length - 1;
            int mid = 0;

            while(L<R)
            {
                mid = L + ((R - L) >> 1);
                if (sortedArr[mid] == num)
                    return true;
                else if (sortedArr[mid] > num)
                {
                    R = mid - 1;
                }
                else
                {
                    L = mid + 1;
                }
            }
            return sortedArr[L] == num;
        }

        public static int NearestLeftIndex(int[] arr,int value)
        {
            int L = 0;
            int R = arr.Length - 1;
            int index = -1;
            while (L <= R)
            {
                int mid = L + ((R - L) >> 1);
                if (arr[mid] >= value)
                {
                    index = mid;
                    R = mid - 1;
                }
                else
                {
                    L = mid + 1;
                }
            }
            return index;
        }

        public static int NearestRightIndex(int[] arr, int value)
        {
            int L = 0;
            int R = arr.Length - 1;
            int index = -1;
            while (L <= R)
            {
                int mid = L + ((R - L) >> 1);
                if (arr[mid] <= value)
                {
                    index = mid;
                    L = mid + 1;
                }
                else
                {
                    R = mid - 1;
                }
            }
            return index;
        }

        public static void Swap(int[] arr, int i, int j)
        {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[i] ^ arr[j];
        }

        public static void Comparator(int[] arr)
        {
            Array.Sort(arr);
        }

        public static int[] GenerateRandomArray(int maxSize, int maxValue)
        {
            int[] arr = new int[(int)((maxSize + 1) * new Random().NextDouble())];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (int)((maxValue + 1) * new Random().NextDouble()) - (int)((maxValue) * new Random().NextDouble());
            }
            return arr;
        }

        public static int[] CopyArray(int[] arr)
        {
            if (arr == null)
                return null;

            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                res[i] = arr[i];

            return res;
        }

        public static Boolean IsEqual(int[] arr1, int[] arr2)
        {
            if ((arr1 == null && arr2 != null) || (arr1 != null && arr2 == null))
                return false;

            if (arr1 == null && arr2 == null)
                return true;

            if (arr1.Length != arr2.Length)
                return false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }

        public static void PrintArray(int[] arr)
        {
            if (arr == null)
                return;

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i] + " ");

            Console.WriteLine();
        }
    }
}
