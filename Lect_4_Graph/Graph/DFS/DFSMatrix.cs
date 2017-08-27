using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    public class DFSs
    {
        public static void Main()
        {
            HashSet<int> visited = new HashSet<int>();

            //graph 
            int[,] graph = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
            };

            DFS(1);         // dfs is calling with input parameter

            void DFS(int node)
            {
                Stack stack = new Stack();

                stack.Push(node);
                visited.Add(node);

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
                            visited[r, c] = graph[r, c];
                            Console.WriteLine(visited[r, c]);
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
}
