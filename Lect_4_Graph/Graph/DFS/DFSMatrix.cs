using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    class DFSs
    {
        static void Main()
        {
            //graph creation
            int[,] graph = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            DFS(graph);
        }

        private static void DFS(int[,] graph)
        {
            Stack stack = new Stack();
            //DFS + fill visited 
            int[,] visited = new int[graph.GetLength(0), graph.GetLength(1)];

            for (int c = 0; c < graph.GetLength(1); c++)
            {
                for (int r = 0; r < graph.GetLength(0); r++)
                {
                    if (visited[r, c] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        // Console.WriteLine(graph[r, c]);
                        stack.Push(graph[r, c]);
                        visited[r, c] = 1;
                    }
                }
            }
            //Print visited
            foreach (var vis in visited)
            {
                Console.WriteLine(vis);
            }
        }
    }
}
