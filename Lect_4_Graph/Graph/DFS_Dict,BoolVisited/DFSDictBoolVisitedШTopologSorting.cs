using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_Dict_BoolVisited
{
    class DFSDictBoolVisitedШTopologSorting
    {
        static void Main()
        {
        }

        public static int DFS(int start,
           Dictionary<int, HashSet<int>> graph, bool[] visited)
        {
            int result = 0;
            if (visited[start])
            {
                return result;
            }

            result++;
            visited[start] = true;
            var successors = graph[start];
            foreach (int succ in successors)
            {
                result += DFS(succ, graph, visited);
            }

            return result;
        }
    }
}
