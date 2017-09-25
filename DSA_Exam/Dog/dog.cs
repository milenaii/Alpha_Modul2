using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Dog
{
    class dog
    {
        static void Main()
        {         
            //    graph[parent].Add(child)
            //    List[]        List<int>
            List<List<int>> graph = new List<List<int>>();

            //    parents[children] = number of parents on this child
            List<int> parents = new List<int>(Enumerable.Repeat(int.MaxValue, 10));

            int numberOfLines = int.Parse(Console.ReadLine());
            // fill the graph with new list<int>  //the numbers are 10!!
            for (int i = 0; i < 10; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { " ", "is" }, StringSplitOptions.RemoveEmptyEntries);

                int firstNode = int.Parse(input[0]);
                int secondNode = int.Parse(input[2]);


                if (parents[firstNode] == int.MaxValue)
                {
                    parents[firstNode] = 0;
                }

                if (parents[secondNode] == int.MaxValue)
                {
                    parents[secondNode] = 0;
                }

                if (input[1] == "after")
                {
                    graph[secondNode].Add(firstNode);
                    {
                        parents[firstNode]++;
                    }   
                }
                else
                {
                    graph[firstNode].Add(secondNode);
                    {
                        parents[secondNode]++;
                    }
                }
            }

            bool firstIteration = true;  // for 0 -> do not be first

            int zeroValue = parents[0]; // for 0 -> do not be first

            StringBuilder result = new StringBuilder();

            while (!parents.All(x => x == int.MaxValue))
            {
                if (firstIteration)         // for 0 -> do not be first
                {
                    parents[0] = int.MaxValue;   // for 0 -> do not be first
                }

                int minNodeId = parents.IndexOf(parents.Min());

                if (firstIteration)       // for 0 -> do not be first
                {
                    parents[0] = zeroValue;   // for 0 -> do not be first
                }

                graph[minNodeId].ForEach(childId => parents[childId]--);

                parents[minNodeId] = int.MaxValue;

                result.Append(minNodeId);

                firstIteration = false;
            }
            Console.WriteLine(result.ToString());
        }
    }
}
