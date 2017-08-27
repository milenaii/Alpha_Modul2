using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Conference
{
    public class ConferenceTest
    {
        public static void Run()
        {
            int[] props = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int numberOfPeople = props[0];
            int numberOfPairs = props[1];

            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            bool[] visited = new bool[numberOfPeople];

            for (int i = 0; i < numberOfPairs; i++)
            {
                int[] pair = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

                int first = pair[0];
                int second = pair[1];

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

            List<int> companiesPeopleCount = new List<int>();
            foreach (int key in graph.Keys)
            {
                if (!visited[key])
                {
                    companiesPeopleCount.Add(DFS(key, graph, visited));
                }
            }

            long result = 0;
            long singles = numberOfPeople - graph.Keys.Count;

            for (int i = 0; i < companiesPeopleCount.Count - 1; i++)
            {
                result += singles * companiesPeopleCount[i];
                for (int j = i + 1; j < companiesPeopleCount.Count; j++)
                {
                    result += companiesPeopleCount[i]
                        * companiesPeopleCount[j];
                }
            }

            if (singles > 0)
            {
                result += singles * companiesPeopleCount[companiesPeopleCount.Count - 1];

                result += (singles * (singles - 1)) / 2;
            }

            Console.WriteLine(result);
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