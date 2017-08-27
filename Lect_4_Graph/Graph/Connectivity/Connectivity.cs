using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivityy
{
    public class Connectivity
    {
        private static bool[] visited;
        private static int[,] graph;

        public static void Main()
        {
            const int Nodes = 6;

            visited = new bool[Nodes];

            graph = new[,]
                        {
                            { 0, 1, 0, 0, 1, 0 },    //{ 0, 1, 1, 0, 0, 0 },
                            { 1, 0, 1, 0, 0, 1 },    //{ 0, 0, 1, 0, 0, 0 },
                            { 0, 0, 0, 1, 0, 0 },    //{ 1, 1, 0, 0, 0, 0 },
                            { 0, 1, 0, 0, 0, 1 },    //{ 0, 0, 0, 0, 0, 0 },
                            { 1, 0, 0, 1, 0, 1 },    //{ 0, 0, 0, 0, 0, 1 },
                            { 1, 0, 1, 0, 1, 0 }     //{ 0, 0, 0, 0, 1, 0 },
                        };

           // Bfs(1);

           //Add  some code for connectivity
           // without it, the code is the same like bfsGraphMatrix
            int components = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    Bfs(i);
                    components++;
                }
            }
            Console.WriteLine("Connected components: " + components);

            if (components == 1)
            {
                Console.WriteLine("Graph is connected");
            }
            else
            {
                Console.WriteLine("Graph is not connected");
            }

        }

        public static void Bfs(int node)
        {
            var queueNodes = new Queue<int>();

            queueNodes.Enqueue(node);
            visited[node] = true;

            while (queueNodes.Count != 0)
            {
                int currentNode = queueNodes.Dequeue();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[currentNode, i] == 1 && !visited[i])
                    {
                        queueNodes.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }


    }
}
