using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DFSTraverse
{
    public class DFTDictionaryGraph
    {
        private static Dictionary<string, List<string>> graph;

        private static HashSet<string> visited = new HashSet<string>();

        public static void Main()
        {
            graph
            = new Dictionary<string, List<string>>
            {
                {"s", new List<string> {"g"} },
                {"b", new List<string> {"v"} },
                {"v", new List<string>{ "g"} },
                {"g", new List<string> {} },
                
            };

            DFS("s");
        }

        //DFS
        public static void DFS(string node)
        {
            Stack<string> nodes = new Stack<string>();

            nodes.Push(node);
            visited.Add(node);

            while (nodes.Count != 0)
            {
                string currentNode = nodes.Pop();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph[currentNode].Count; i++)
                {
                    if (!visited.Contains(graph[currentNode][i]))
                    {
                        nodes.Push(graph[currentNode][i]);
                        visited.Add(graph[currentNode][i]);
                    }
                }

            }


        }
    }
}
