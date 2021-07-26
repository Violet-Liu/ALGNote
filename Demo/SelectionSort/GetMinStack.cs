using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSort
{
    public class MyStack
    {
        private Stack<int> stackData;
        private Stack<int> stackMin;

        public MyStack()
        {
            stackData = new Stack<int>();
            stackMin = new Stack<int>();
        }

        public void push(int newNum)
        {
            if (this.stackMin.Count==0)
            {
                this.stackMin.Push(newNum);
            }
            else if (newNum <= this.GetMin())
            {
                this.stackMin.Push(newNum);
            }
            this.stackData.Push(newNum);
        }

        public int pop()
        {
            if (this.stackData.Count==0)
            {
                throw new IndexOutOfRangeException("Your stack is empty.");
            }
            int value = this.stackData.Pop();
            if (value == this.GetMin())
            {
                this.stackMin.Pop();
            }
            return value;
        }

        public int GetMin()
        {
            if (stackMin.Count == 0)
            {
                throw new IndexOutOfRangeException("ooo");
            }

            return stackMin.Peek();
        }
    }
}
