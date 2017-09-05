using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TaskOrdering
{
    public static void Main()
    {
        int[,] graph =
        {
        {0, 1, -1, 0, 0},
        {-1, 0, 0, 1, 1},
        {1, 0, 0, 0, 0},
        {0, -1, 0, 0, 0},
        {0, -1, 0, 0, 0},

      };

        int numberOfVertices = graph.GetLength(0);
        bool[] visited = new bool[numberOfVertices];

        int startingVertex = GetStartingVertex(graph);

        TransformToUndirectedGraph(graph);

        Console.WriteLine("Tasks ordering:");

        TraverseRecursiveDFS(graph, visited, startingVertex);
        Console.WriteLine();
    }

    private static void TransformToUndirectedGraph(int[,] graph)
    {
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                if (graph[i, j] == -1)
                {
                    graph[i, j] = 1;
                }
            }
        }
    }

    public static int GetStartingVertex(int[,] graph)
    {
        int startinVertex = -1;
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            bool hasParent = false;
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                if (graph[i, j] == -1)
                {
                    hasParent = true;
                    break;
                }
            }

            if (hasParent == false)
            {
                startinVertex = i;
                break;
            }
        }
        return startinVertex;
    }

    public static void TraverseRecursiveDFS(
      int[,] graph, bool[] visitedVertices, int currentVertex)
    {
        if (visitedVertices[currentVertex] == false)
        {
            visitedVertices[currentVertex] = true;
            Console.Write("{0} -> ", currentVertex + 1);
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if ((graph[currentVertex, i] == 1) && (visitedVertices[i] == false))
                {
                    TraverseRecursiveDFS(graph, visitedVertices, i);
                }
            }
        }
    }
}