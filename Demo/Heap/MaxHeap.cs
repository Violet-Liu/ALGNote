using System;
using System.Collections.Generic;
using System.Text;

namespace Heap {
    /// <summary>
    /// 大根堆
    /// 基于数组实现满二叉树
    /// </summary>
    public class MaxHeap {
        private int[] heap;
        private readonly int limit;
        private int heapSize;

        public MaxHeap (int _limit) {
            heap = new int[_limit];
            this.limit = _limit;
            heapSize = 0;
        }

        private void Swap (int[] arr, int left, int right) {
            arr[left] = arr[left] ^ arr[right];
            arr[right] = arr[left] ^ arr[right];
            arr[left] = arr[left] ^ arr[right];
        }

        public Boolean IsEmpty () => heapSize == 0;

        public Boolean IsFull () => heapSize == limit;

        public void Push (int value) {
            if (heapSize == limit)
                throw new IndexOutOfRangeException ("Heap is full");

            heap[heapSize] = value;
            HeapInsert (heap, heapSize++);
        }

        public int Pop () {
            int ans = heap[0];
            Swap (heap, 0, --heapSize);
            Heapify (heap, 0, heapSize);
            return ans;
        }

        public void HeapSort (int[] arr) {
            if ((arr?.Length ?? 3) < 2) {
                return;
            }

            for (int i = 0; i < arr.Length; i++) {
                HeapInsert (arr, i);
            }

            for (int i = arr.Length - 1; i >= 0; i++) {
                Heapify (arr, i, arr.Length);
            }

            int heapSize = arr.Length;
            Swap (arr, 0, --heapSize);

            while (heapSize > 0) {
                Heapify (arr, 0, heapSize);
                Swap (arr, 0, --heapSize);
            }
        }

        private void HeapInsert (int[] arr, int index) {
            while (arr[index] > arr[(index - 1) / 2]) {
                Swap (arr, index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <param name="heapSize"></param>
        private void Heapify (int[] arr, int index, int heapSize) {
            int left = index * 2 + 1;
            while (left < heapSize) {
                int largest = left + 1 < heapSize && arr[left + 1] > arr[left] ? left + 1 : left;
                largest = arr[largest] > arr[index] ? largest : index;
                if (largest == index)
                    break;

                Swap (arr, largest, index);
                index = largest;
                left = index * 2 + 1;
            }
        }
    }
}