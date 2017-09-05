using System;
using System.Linq;

namespace Swapping
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var swaps = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var nodes = new Node[n + 1];
            for (int i = 1; i <= n; ++i)
            {
                nodes[i] = new Node(nodes[i - 1], i);
            }

            var first = nodes[1];
            var last = nodes[n];

            foreach (int x in swaps)
            {
                var middle = nodes[x];
                var newFirst = middle.Right;
                var newLast = middle.Left;

                Node.Detach(middle);
                Node.Attach(last, middle);
                Node.Attach(middle, first);

                first = newFirst ?? middle;
                last = newLast ?? middle;
            }

            var numbers = new int[n];
            for (int i = 0; i < n; ++i)
            {
                numbers[i] = first.Value;
                first = first.Right;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class Node
    {
        public int Value { get; private set; }

        public Node Left { get; private set; }
        public Node Right { get; private set; }

        public Node(Node end, int x)
        {
            this.Value = x;

            this.Left = end;
            this.Right = null;

            if (end != null)
            {
                end.Right = this;
            }
        }

        public static void Detach(Node x)
        {
            if (x.Left != null)
            {
                x.Left.Right = null;
            }
            if (x.Right != null)
            {
                x.Right.Left = null;
            }

            x.Left = null;
            x.Right = null;
        }

        public static void Attach(Node l, Node r)
        {
            if (l == r)
            {
                return;
            }

            l.Right = r;
            r.Left = l;
        }
    }
}