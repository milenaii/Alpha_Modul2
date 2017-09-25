using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogLovesPaper
{
    class Program
    {
        static void Main()
        {
            //   List<parent<List<children>
            //   graph[parent].Add(child)
            List<List<int>> graph = new List<List<int>>();

            //parents[children] - number of parents of this children
            List<int> parents = new List<int>(Enumerable.Repeat(int.MaxValue, 20));

            int numberOfLines = int.Parse(Console.ReadLine());

            //fill the graph with new List<int>
            for (int i = 0; i < numberOfLines; i++)
            {
                graph.Add(new List<int>());
            }
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { " ", "is" }, StringSplitOptions.RemoveEmptyEntries);  //.ToArray();

                int firstNode = int.Parse(line[0]);
                int secondNode = int.Parse(line[2]);

                if (parents[firstNode] == int.MaxValue)
                {
                    parents[firstNode] = 0;
                }

                if (parents[secondNode] == int.MaxValue)
                {
                    parents[secondNode] = 0;
                }

                if (line[2] == "after")
                {
                    //   [parent]       (child)
                    graph[secondNode].Add(firstNode);
                        //paren of child firstNode++
                        parents[firstNode]++;
                }

                else  //before case
                {
                    //   [parent]       (child)
                    graph[firstNode].Add(secondNode);
                        //paren of child firstNode++
                        parents[secondNode]++;
                }
            }

            StringBuilder result = new StringBuilder();

            while (!parents.All(x => x == int.MaxValue))
            {
                int minNodeId = parents.IndexOf(parents.Min());

                graph[minNodeId].ForEach(child => parents[child]--);

                parents[minNodeId] = int.MaxValue;

                result.Append(minNodeId);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
