using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DFsRecursMatr
{
    public class DFS
    {
        private static HashSet<int> visit = new HashSet<int>();
        private static int[][] nodess;

        public static void Main()
        {
            int[][] graph =

                new[]
                    {
                        new[] { 3, 6 }, // successors of vertice 0
                        new[] { 2, 3, 4, 5, 6 }, // successors of vertice 1
                        new[] { 1, 4, 5 }, // successors of vertice 2
                        new[] { 0, 1, 5 }, // successors of vertice 3
                        new[] { 1, 2, 6 }, // successors of vertice 4
                        new[] { 1, 2, 3 }, // successors of vertice 5
                        new[] { 0, 1, 4 } // successors of vertice 6
                };

            DfsRecursive(0);
        }

        public static void DfsRecursive(int node)
        {
            if (!visit.Contains(node))  
            {
                visit.Add(node);
                Console.WriteLine(node);

                for (int i = 0; i < nodess[node].Length; i++)
                {
                    DfsRecursive(nodess[node][i]);
                }
            }
        }
    }
}


