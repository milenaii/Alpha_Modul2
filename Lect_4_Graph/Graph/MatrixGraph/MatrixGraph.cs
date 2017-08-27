using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr
{
    public class MatrixGraph
    {
        //матрица на съседство

        //input         
        //3           output      ПО РЕДОВЕТЕ НА МАТРИЦАТА
        //1           0 1 0       0 -> 1
        //1           0 1 0       1 -> 1
        //2           0 0 1       2 -> 2
        //                  row -> inptu
        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());

            var graph = new int[nodes, nodes];

            // Read connections for each node
            for (int i = 0; i < nodes; i++)
            {
                string[] connections = Console.ReadLine().Split(' ');

                foreach (string connection in connections)
                {
                    graph[i, int.Parse(connection)] = 1;
                }
            }

            // Print the matrix
            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

    }
}
