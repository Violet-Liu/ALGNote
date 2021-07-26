using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(1 << 3);

            var node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(3);
            node.Left.Left = new Node(4);
            node.Left.Right = new Node(5);

            node.Right.Left = new Node(6);
            node.Right.Right = new Node(7);

            var ans= SerializeAndReconstruct.PreSerial(node);


            Console.ReadLine();
        }
    }
}
