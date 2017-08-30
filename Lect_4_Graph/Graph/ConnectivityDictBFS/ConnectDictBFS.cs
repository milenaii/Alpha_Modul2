using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSGraphMatrix
{
    //it still doesn't work

    public class ConnectivityDictBFS
    {
        private static Dictionary<string, List<string>> graph;

        private static HashSet<string> visited = new HashSet<string>();

        public static void Main()
        {
            graph
           = new Dictionary<string, List<string>>
           {
                {"sofiq", new List<string> {"burgas", "varna", "plovdiv", "kyustendil"} },
                {"burgas", new List<string> {"varna", "vidin", "gabrovo"} },
                {"plovdiv", new List<string> {"burgas", "vidin", "gabrovo"} },
                {"gabrovo", new List<string> {"sofiq"} },
                {"kyustendil", new List<string> {"blagoevgrad", "sofiq", "dupnica"} },
                {"varna", new List<string> {"sofiq", "burgas"} },
                {"vidin", new List<string> {"plovdiv", "burgas"} },
                {"dupnica", new List<string> {"kyustendil", "blagoevgrad"} },
                {"blagoevgrad", new List<string> {"sofiq", "kyustendil", "dupnica"} },
           };

            // Bfs("sofiq");
            int countOfComponents = 0;

            foreach (var key in graph)
            {
                if (!visited.Contains(key))
                {
                    Bfs(key);
                    countOfComponents = 0;
                }
            }
        }

        public static void Bfs(string node)
        {
            var queueNodes = new Queue<string>();

            queueNodes.Enqueue(node);
            visited.Add(node);


            while (queueNodes.Count != 0)
            {
                string currentNode = queueNodes.Dequeue();

                Console.WriteLine(currentNode);

                for (int i = 0; i < graph[currentNode].Count; i++)
                {
                    if (!visited.Contains(graph[currentNode][i]))
                    {
                        queueNodes.Enqueue(graph[currentNode][i]);
                        visited.Add(graph[currentNode][i]);
                    }
                }
            }
        }



    }
}
