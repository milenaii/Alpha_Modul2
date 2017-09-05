using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DictIntHashset
    {
        static void Main()
        {
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            int m = 5;
            for (int i = 0; i < m; i++)
            {
                int[] dev = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int first = dev[0];
                int second = dev[1];

                if (!graph.ContainsKey(first))
                {
                    graph.Add(first, new HashSet<int>());
                }
                if (!graph.ContainsKey(second))
                {
                    graph.Add(second, new HashSet<int>());
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

        }
    }
}
