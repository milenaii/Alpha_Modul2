using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Conference
{
    public class Conference
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numDevelopers = input[0];
            int m = input[1];

            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            bool[] visited = new bool[numDevelopers];

            for (int i = 0; i < m; i++)
            {
                int[] dev = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int first = dev[0];
                int second = dev[1];

                if (!graph.ContainsKey(first))
                {
                    graph.Add(first, new HashSet<int>());
                }
                if (!graph.ContainsKey(second))
                {
                    graph.Add(second, new HashSet<int>());
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

            //list to safe different company - people
            //if key is not visited - dfs - safe num dfs

            List<int> companyPeopleCount = new List<int>();
            foreach (var key in graph.Keys)
            {
                if (!visited[key])
                {
                    companyPeopleCount.Add(DFSRec(key, graph, visited));
                }
            }

            long result = 0;
            long single = numDevelopers - graph.Keys.Count;
            //count dev from each company * all other compani and +
            //list ex:  3  2  4 ->
            //  (3*2 + 3*4) + (2 * 3 + 2* 4) + (4 * 3 + 4 * 2)
            for (int i = 0; i < companyPeopleCount.Count - 1; i++)
            {
                result += single * companyPeopleCount[i];
                for (int j = i + 1; j < companyPeopleCount.Count; j++)
                {
                    result += companyPeopleCount[i] * companyPeopleCount[j];
                }
            }

            if (single > 0)
            {
                result += single * companyPeopleCount[companyPeopleCount.Count - 1];

                result += (single * (single - 1)) / 2;
            }
            Console.WriteLine(result);

        }

        //DFSRec with counter for topological sorting // CONNECTIVITY
        public static int DFSRec(int startNode, Dictionary<int, HashSet<int>> graph, bool[] visited)
        {
            int result = 0;
            if (visited[startNode])
            {
                return result;
            }

            result++;
            visited[startNode] = true;

            //var successors = graph[startNode];

            foreach (var succ in graph[startNode])
            {
                result += DFSRec(succ, graph, visited);
            }
            return result;
        }
    }
}
