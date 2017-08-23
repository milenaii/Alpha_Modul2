using System.Collections.Generic;

public class BreadthFirstSearch
{
    public int[] edgeTo;
    public int[] distTo;
    public int s;

    public BreadthFirstSearch(GraphAdjList G, int s)
    {
        edgeTo = new int[G.VertexCount];
        distTo = new int[G.VertexCount];

        for (int i = 0; i < G.VertexCount; i++)
        {
            distTo[i] = -1;
            edgeTo[i] = -1;
        }

        this.s = s;

        BFS(G, s);
    }

    void BFS(GraphAdjList G, int s)
    {
        var queue = new Queue<int>();
        queue.Enqueue(s);
        distTo[s] = 0;

        while (queue.Count != 0)
        {
            int v = queue.Dequeue();

            foreach (var w in G.GetAdj(v))
            {
                if (distTo[w] == -1)
                {
                    queue.Enqueue(w);
                    distTo[w] = distTo[v] + 1;
                    edgeTo[w] = v;
                }
            }
        }
    }
}

