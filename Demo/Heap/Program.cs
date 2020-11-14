using System;

namespace Heap {
    class Program {
        static void Main (string[] args) {
            var heap = new MaxHeap (100);

            heap.Push (9);
            heap.Push (6);
            heap.Push (8);
            heap.Push (1);
            heap.Push (5);
            heap.Push (2);
            heap.Push (5);
            heap.Push (3);

            for (int i = 0; i < 8; i++) {
                Console.WriteLine (heap.Pop ());
            }

            Console.WriteLine ("Hello World!");
        }
    }
}