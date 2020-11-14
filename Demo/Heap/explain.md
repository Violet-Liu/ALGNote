###堆排序

> 把数组中的元素模拟成完全二叉树，某一个节点的左右子节点分别为 $（2*i+1）$和$（2*i+2）$，父节点为$\frac{i-1}{2}$(向下取整)

1. 先让整个数组都变成一个大根堆结构，建立堆的过程：
   * 从上到下的方法，时间复杂度为 $\omicron({N}*{\log N})$
   * 从下往上的方法，时间复杂度为 $\omicron(N)$

2. 把堆的最大值和堆末尾的值交换，然后减少堆的大小之后，再去调整堆，一直周而复始，时间复杂度为 $\omicron({N}*{\log N})$

3. 堆的大小减少为0之后，排序完成。


```csharp
    /// <summary>
    /// 大根堆
    /// 基于数组实现满二叉树
    /// </summary>
    public class MaxHeap
    {
        private int[] heap;
        private readonly int limit;
        private int heapSize;

        public MaxHeap(int limit)
        {
            heap = new int[limit];
            this.limit = limit;
            heapSize = 0;
        }

        private void Swap(int[] arr,int left,int right)
        {
            arr[left] = arr[left] ^ arr[right];
            arr[right] = arr[left] ^ arr[right];
            arr[left]  = arr[left] ^ arr[right];
        }

        public Boolean IsEmpty() => heapSize == 0;

        public Boolean IsFull() => heapSize == limit;

        public void Push(int value)
        {
            if (heapSize == limit)
                throw new IndexOutOfRangeException("Heap is full");

            heap[heapSize] = value;
            HeapInsert(heap, heapSize++);
        }

        public int Pop()
        {
            int ans = heap[0];
            Swap(heap, 0, --heapSize);
            Heapify(heap, 0, heapSize);
            return ans;
        }

        public void HeapSort(int[] arr)
        {
            if ((arr?.Length ?? 3) < 2)
            {
                return;
            }

            for(int i=0;i<arr.Length;i++)
            {
                HeapInsert(arr, i);
            }

            for(int i=arr.Length-1;i>=0;i++)
            {
                Heapify(arr, i, arr.Length);
            }

            int heapSize = arr.Length;
            Swap(arr, 0, --heapSize);

            while(heapSize>0)
            {
                Heapify(arr, 0, heapSize);
                Swap(arr, 0, --heapSize);
            }
        }

        private void HeapInsert(int[] arr,int index)
        {
            while(arr[index]>arr[(index-1)/2])
            {
                Swap(arr, index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <param name="heapSize"></param>
        private void Heapify(int[] arr,int index,int heapSize)
        {
            int left = index * 2 + 1;
            while(left<heapSize)
            {
                int largest = left + 1 < heapSize && arr[left + 1] > arr[left] ? left : left + 1;
                largest = arr[largest] > arr[index] ? largest : index;
                if (largest == index)
                    break;

                Swap(arr, largest, index);
                index = largest;
                left = index * 2 + 1;
            }
        }
    }
```