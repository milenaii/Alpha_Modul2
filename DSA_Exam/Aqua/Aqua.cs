using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua
{
    public class Aqua
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            int n = int.Parse(Console.ReadLine());
            string line;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                string[] input = line.Split(new char[] { ' ' }).ToArray();
                switch (input[0])
                {
                    case "add":
                        int num = int.Parse(input[1]);
                        queue.Enqueue(num);
                        Console.WriteLine("Added {0}", num);
                        break;

                    case "slide":
                        int k = int.Parse(input[1]);
                        for (int l = 0; l < k; l++)
                        {
                            var por = queue.Dequeue();
                            queue.Enqueue(por);
                        }
                        Console.WriteLine("Slided {0}", k);
                        break;

                    case "print":
                        //int[] sec = new int[queue.Count];
                        //Queue<int> second = new Queue<int>(queue);

                        Console.WriteLine(string.Join(" ", queue.Reverse()));
                        break;

                }
            }
        }
    }
}
