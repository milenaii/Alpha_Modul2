using System;
using System.Collections.Generic;
namespace TSUsingSourceDFS
{
    public class DFSTS
    {
        public static void Main()
        {
            //graph example: 1-2, 3-4-5,  nodes ->1,2,3,4,5; "-" -> edge;

            int n = 5;  // number of nodes in graph - developers

            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            bool[] visited = new bool[n + 1];

            int first = 1;  //1-2, 3-4-5,
            int second = 2;
            int third = 3;
            int four = 4;
            int five = 5;


            //fill The graph:
            if (!graph.ContainsKey(first))
            {
                graph.Add(first, new HashSet<int>());
            }
            if (!graph.ContainsKey(second))
            {
                graph.Add(second, new HashSet<int>());
            }
            if (!graph.ContainsKey(third))
            {
                graph.Add(third, new HashSet<int>());
            }
            if (!graph.ContainsKey(four))
            {
                graph.Add(four, new HashSet<int>());
            }
            if (!graph.ContainsKey(five))
            {
                graph.Add(five, new HashSet<int>());
            }
            graph[first].Add(second);
            graph[second].Add(third);
            graph[third].Add(four);
            graph[four].Add(five);

            //graph[first].Add(third);
            //graph[third].Add(first);

            //Empty list that will contain the sorted elements
            List<int> sortedElements = new List<int>();
            HashSet<int> nodesNoInomEdge = new HashSet<int>();

            while (nodesNoInomEdge.Count != 0)
            {
                nodesNoInomEdge.Remove(node);
            }
        }

    }
}
