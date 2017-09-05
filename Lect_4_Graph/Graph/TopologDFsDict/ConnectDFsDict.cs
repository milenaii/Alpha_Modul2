using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectivityDFsDict
{
    class ConnectivityDFsDict
    {
        static void Main()
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
            graph[second].Add(first);
            graph[third].Add(four);
            graph[four].Add(third);
            graph[four].Add(five);
            graph[five].Add(four);

            //graph[first].Add(third);
            //graph[third].Add(first);


            //connectivity/ companies
            List<int> conectivity = new List<int>();

            foreach (var key in graph.Keys)
            {
                if (!visited[key])
                {
                    conectivity.Add(DFSRec(key, graph, visited));
                }
              
            }
            //that prints the number of CONECTIVITY
            Console.WriteLine(conectivity.Count);
        }
        //DFSRec with counter for topological sorting // CONNECTIVITY
        public static int DFSRec(int startNode, Dictionary<int, HashSet<int>> graph, bool[] visited)
        {
            int result = 0;
            if (visited[startNode])
            {
                return result;
            }

            result++;
            visited[startNode] = true;

            //var successors = graph[startNode];

            foreach (var succ in graph[startNode])
            {
                result += DFSRec(succ, graph, visited);
            }
            return result;
        }

    }
}
