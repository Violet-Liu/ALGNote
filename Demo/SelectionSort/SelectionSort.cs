using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSort
{
    public class SelectionSortClass
    {
        public static void SelectionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            for(int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for(int j=i+i;j<arr.Length;j++)
                {
                    minIndex = arr[j] < arr[minIndex] ? j : minIndex;
                }
                Swap(arr, i, minIndex);
            }
        }

        public static void Swap(int[] arr,int i,int j)
        {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[i] ^ arr[j];
        }

        public static void Comparator(int[] arr)
        {
            Array.Sort(arr);
        }

        public static int[] GenerateRandomArray(int maxSize,int maxValue)
        {
            int[] arr = new int[(int)((maxSize + 1) * new Random().NextDouble())];
            for(int i = 0; i < arr.Length; i++)
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

            for(int i=0;i<arr1.Length;i++)
            {
                if (arr1[i] != arr2[i])
                    return false;                       
            }

            return true;
        }
    }
}
