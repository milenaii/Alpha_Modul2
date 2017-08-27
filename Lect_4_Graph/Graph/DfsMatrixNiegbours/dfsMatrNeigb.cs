using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSGraphMatrix
{
    public class BfsTraversal
    {
        private static bool[] visited;
        private static int[,] graph;

        public static void Main()
        {
            const int Nodes = 6;

            visited = new bool[Nodes];

            graph = new[,]
                        {
                            { 0, 1, 0, 0, 1, 0 },
                            { 1, 0, 1, 0, 0, 1 },
                            { 0, 0, 0, 1, 0, 0 },
                            { 0, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 1, 0, 1 },
                            { 1, 0, 1, 0, 1, 0 }
                        };

            Bfs(1);
        }

        public static void Bfs(int node)
        {
            var stackNodes = new Stack<int>();

            stackNodes.Push(node);
            visited[node] = true;

            while (stackNodes.Count != 0)
            {
                int currentNode = stackNodes.Pop();
                Console.WriteLine(currentNode);

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[currentNode, i] == 1 && !visited[i])
                    {
                        stackNodes.Push(i);
                        visited[i] = true;
                    }
                }
            }
        }


    }
}
