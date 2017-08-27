using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.BFsTMatrixGraph
{
    public class BFSMatrixGraph
    {
      //  private static 

        public static void Main()
        {

            int[,] graph = new[,]
                        {
                            { 0, 1, 0, 0, 1, 0 },
                            { 1, 0, 1, 0, 0, 1 },
                            { 0, 0, 0, 1, 0, 0 },
                            { 0, 1, 0, 0, 0, 1 },
                            { 1, 0, 0, 1, 0, 1 },
                            { 1, 0, 1, 0, 1, 0 }
                        };

            bool[] visited = new bool[6]; // number of nodes

            Bfs(1);
        }
        public static void Bfs(int node)
        {



        }
    }
}
