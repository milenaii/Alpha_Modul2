using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Aqua_Manch
    {
        static void Main( )
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "add":
                        queue.Enqueue(int.Parse(command[1]));
                        Console.WriteLine("Added " + command[1]);
                        break;
                    case "slide":
                        int times = int.Parse(command[1]);

                        for (int k = 0; k < times; k++)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }
                        Console.WriteLine("Slided " + times);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", queue.Reverse()));
                        break;
                }
            }
        }
    }
}


