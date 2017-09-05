using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSortDfsList
    {
    //it still doesn't work  ???

    public class TopSortDfsList
    {
        private static bool[] visited;
        private static int[,] graph;

        public static void Main()
        {
            const int Nodes = 6;

            visited = new bool[Nodes];

            graph = new[,]
                        {
                            { 1, 1, 0, 0, 0},
                            { 1, 1, 1, 0, 0},
                            { 1, 0, 0, 1, 0},
                            { 1, 1, 0, 0, 1},
                            { 1, 0, 0, 0, 0},
                        };

            Dfs(0);
            
        }

        public static void Dfs(int node)
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
