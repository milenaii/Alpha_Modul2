using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Aquapark
{
    public class Aquapark
    {
        public static void Main(string[] args)
        {
            BigList<int> list = new BigList<int>();

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
                        list.Insert(0, num);
                        Console.WriteLine("Added {0}", num);

                        break;

                    case "slide":
                        int k = int.Parse(parameters[1]);
                        for (int u = 0; u < k; u++)
                        {
                            int a = list[list.Count - 1];
                            list.RemoveAt(list.Count - 1);
                            list.Insert(0, a);
                        }
                        Console.WriteLine("Slided {0}", k);
                        break;

                    case "print":
                        for (int e = 0; e < list.Count; e++)
                        {
                            if (e == list.Count - 1)
                            {
                                Console.WriteLine(list[e]);
                            }
                            else
                            {
                                Console.Write(list[e] + " ");
                            }

                        }
                        break;
                }
            }
        }
    }
}