using System;
using System.Collections.Generic;
using System.Text;

namespace QueueAndStack
{
    public class TwoQueueImplementStack<T>
    {
        public Queue<T>  queue { get; set; }

        public Queue<T> help { get; set; }

        public void Push(T value) => queue.Enqueue(value);

        public T Poll()
        {
            while (queue.Count > 1)
                help.Enqueue(queue.Dequeue());

            T ans = queue.Dequeue();
            Queue<T> temp = queue;
            queue = help;
            help = temp;
            return ans;
        }

        public T Peek()
        {
            while (queue.Count > 1)
            {
                help.Enqueue(queue.Dequeue());
            }
            T ans = queue.Dequeue();
            help.Enqueue(ans);
            Queue<T> tmp = queue;
            queue = help;
            help = tmp;
            return ans;
        }

        public Boolean isEmpty()
        {
            return queue.Count > 0;
        }

        public static void Test()
        {
            Console.WriteLine("test begin");
            TwoQueueImplementStack<int> myStack = new TwoQueueImplementStack<int>();
            Stack<int> test = new Stack<int>();
            int testTime = 1000000;
            int max = 1000000;
            var random = new Random();
            for (int i = 0; i < testTime; i++)
            {
                if (myStack.isEmpty())
                {
                    if (test.Count>0)
                    {
                        Console.WriteLine("Oops");
                    }
                    int num = (int)(random.Next(max));
                    myStack.Push(num);
                    test.Push(num);
                }
                else
                {
                    if (random.Next() < 0.25)
                    {
                        int num = (int)(random.Next(max));
                        myStack.Push(num);
                        test.Push(num);
                    }
                    else if (random.Next() < 0.5)
                    {
                        if (!myStack.Peek().Equals(test.Peek()))
                        {
                           Console.WriteLine("Oops");
                        }
                    }
                    else if (random.Next() < 0.75)
                    {
                        if (!myStack.Poll().Equals(test.Pop()))
                        {
                            Console.WriteLine("Oops");
                        }
                    }
                    else
                    {
                        if (myStack.isEmpty() != test.Count>0)
                        {
                            Console.WriteLine("Oops");
                        }
                    }
                }
            }

            Console.WriteLine("test finish!");
        }
    }
}
