using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSquora
// 1.Graph should have method which returns all adjacency  vertex for concrete - like  public IEnumerable<int> GetAdj(int v)   - where parameter "v" is id of vertex, and method returns collection of neighbor vertexes.
// 2. Graph should have method VertexCount which returns count of all vertexes in Graph. In .NET world it would be convenient to use Property some thing like   public int VertexCount     
{
    class dfsQuora
    {
        public class DepthFirstSearch
        {
            private bool[] marked;
            private int[] edgeTo;
            private int s;
        }

        public DepthFirstSearch(GraphAdjList G, int s)
        {
            marked = new bool[G.VertexCount];
            edgeTo = new int[G.VertexCount];
            this.s = s;
        }

        public void DFS(GraphAdjList G, int v)
        {
            marked[s] = true;

            foreach (var w in G.GetAdj(v))
            {
                if (!marked[w])
                {
                    DFS(G, w);
                    edgeTo[w] = v;
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> GetPathTo(int v)
        {
            if (!HasPathTo(v))
                return null;

            var stack = new Stack<int>();

            for (var x = v; x != s; x = edgeTo[x])
            {
                stack.Push(x);
            }

            stack.Push(s);

            return stack;
        }
    }

}
