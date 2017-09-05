using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            bool hasCycles = false;
            List<Vertex<T>> tempVerts = new List<Vertex<T>>(vertices);
            int tempSize = tempVerts.Count;

            int[,] tempAdjMatrix = new int[maxVerts, maxVerts];

            for (int i = 0; i < maxVerts; i++)
            {
                for (int j = 0; j < maxVerts; j++)
                {
                    tempAdjMatrix[i, j] = adjacencyMatrix[i, j];
                }
            }

            while (tempSize > 0)
            {
                int v = GetVertNoSuccessor(tempAdjMatrix, tempSize);
                if (v == -1)
                {
                    hasCycles = true;
                    break;
                }

                output.Add(tempVerts[v].Node);

                if (v != tempSize - 1)
                {
                    tempVerts.RemoveAt(v);

                    for (int row = v; row < tempSize - 1; row++)
                    {
                        for (int col = 0; col < tempSize; col++)
                        {
                            tempAdjMatrix[row, col] = tempAdjMatrix[row + 1, col];
                        }
                    }

                    for (int col = v; col < tempSize - 1; col++)
                    {
                        for (int row = 0; row < tempSize; row++)
                        {
                            tempAdjMatrix[row, col] = tempAdjMatrix[row, col + 1];
                        }
                    }
                }

                tempSize--;
            }

            return !hasCycles;


        }
    }
}
