using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowMaxArray
{
    public class AllLessNumSubArray
    {
        public static int GetNum(int[] arr,int num)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            LinkedList<int> qMin = new LinkedList<int>();
            LinkedList<int> qMax = new LinkedList<int>();
            int L = 0;
            int R = 0;

            int res = 0;
            while (L < arr.Length)
            {
                while (R < arr.Length)
                {
                    while (qMin.Count > 0 && arr[qMin.Last.Value] > arr[R])
                        qMin.RemoveLast();

                    qMin.AddLast(R);

                    while (qMax.Count > 0 && arr[qMax.Last.Value] < arr[R])
                        qMax.RemoveLast();

                    qMax.AddLast(R);

                    if (arr[qMax.First.Value] - arr[qMin.First.Value] > num)
                        break;

                    R++;
                }
                res += R - L;

                if (qMin.First.Value == L)
                    qMin.RemoveFirst();

                if (qMax.First.Value == L)
                    qMax.RemoveFirst();

                L++;
            }
            return res;
        }
    }
}
