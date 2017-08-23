using System.Collections.Generic;

public class GraphAdjList
{
    private readonly int V;

    private readonly List<int>[] Adj;

    public GraphAdjList(int v)
    {
        V = v;
        Adj = new List<int>[V];

        for (int i = 0; i < V; i++)
        {
            Adj[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        Adj[v].Add(w);
        Adj[w].Add(v);
    }

    public List<int> GetAdj(int v)
    {
        return Adj[v];
    }

    public int VertexCount
    {
        get
        {
            return V;
        }
    }
}