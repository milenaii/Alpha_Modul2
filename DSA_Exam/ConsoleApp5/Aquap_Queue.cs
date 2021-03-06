﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aquapark
{
    public class Program
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            int n = int.Parse(Console.ReadLine());

            string line;

            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                string[] parameters = line.Split(new char[] { ' ' }).ToArray();
                string command = parameters[0];

                switch (command)
                {
                    case "add":
                        int num = int.Parse(parameters[1]);
                        queue.Enqueue(num);
                        //Insert(0, num);
                        Console.WriteLine("Added {0}", num);
                        break;

                    case "slide":
                        int k = int.Parse(parameters[1]);
                        for (int u = 0; u < k; u++)
                        {
                            var deq = queue.Dequeue();
                            queue.Enqueue(deq);
                            // or
                            //queue.Enqueue(queue.Dequeue());
                        }
                        Console.WriteLine("Slided {0}", k);
                        break;

                    case "print":
                        int[] sec = new int[queue.Count];

                        Queue<int> second = new Queue<int>(queue);

                        Console.WriteLine(string.Join(" ",queue.Reverse()));


                        break;


                }
            }
        }
    }
}