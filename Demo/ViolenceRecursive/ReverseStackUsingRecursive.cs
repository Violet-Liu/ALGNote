using System;
using System.Collections.Generic;
using System.Text;

namespace ViolenceRecursive
{
    public class ReverseStackUsingRecursive
    {
        public static void Reverse(Stack<int> stack)
        {
            if (stack.Count == 0)
                return;

            int i = f(stack);
            Reverse(stack);
            stack.Push(i);
        }

        public static int f(Stack<int> stack)
        {
            int result = stack.Pop();
            if (stack.Count == 0)
            {
                return result;
            }
            else
            {
                int last = f(stack);
                stack.Push(result);
                return last;
            }
        }
    }
}
