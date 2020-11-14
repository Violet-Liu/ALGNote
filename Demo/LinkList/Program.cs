using System;
using static LinkList.FindFirstIntersectNode;

namespace LinkList
{
    class Program
    {
        static void Main(string[] args)
        {
			// 1->2->3->4->5->6->7->null
			Node head1 = new Node(1);
			head1.Next = new Node(2);
			head1.Next.Next = new Node(3);
			head1.Next.Next.Next = new Node(4);
			head1.Next.Next.Next.Next = new Node(5);
			head1.Next.Next.Next.Next.Next = new Node(6);
			head1.Next.Next.Next.Next.Next.Next = new Node(7);

			// 0->9->8->6->7->null
			Node head2 = new Node(0);
			head2.Next = new Node(9);
			head2.Next.Next = new Node(8);
			head2.Next.Next.Next = head1.Next.Next.Next.Next.Next; // 8->6
			Console.WriteLine(FindFirstIntersectNode.GetIntersectNode(head1, head2).Value);

			// 1->2->3->4->5->6->7->4...
			head1 = new Node(1);
			head1.Next = new Node(2);
			head1.Next.Next = new Node(3);
			head1.Next.Next.Next = new Node(4);
			head1.Next.Next.Next.Next = new Node(5);
			head1.Next.Next.Next.Next.Next = new Node(6);
			head1.Next.Next.Next.Next.Next.Next = new Node(7);
			head1.Next.Next.Next.Next.Next.Next = head1.Next.Next.Next; // 7->4

			// 0->9->8->2...
			head2 = new Node(0);
			head2.Next = new Node(9);
			head2.Next.Next = new Node(8);
			head2.Next.Next.Next = head1.Next; // 8->2
			Console.WriteLine(FindFirstIntersectNode.GetIntersectNode(head1, head2).Value);

			// 0->9->8->6->4->5->6..
			head2 = new Node(0);
			head2.Next = new Node(9);
			head2.Next.Next = new Node(8);
			head2.Next.Next.Next = head1.Next.Next.Next.Next.Next; // 8->6
			Console.WriteLine(FindFirstIntersectNode.GetIntersectNode(head1, head2).Value);
			Console.ReadLine();
		}
    }
}
