using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryGraph
{
    public class DictGraph
    {
        public static void Main()
        {
            //input         output
            //1 2          1 -> 2 2
            //2 1          2 -> 1 1 3 5 
            //2 3          3 -> 2 4
            //2 5          5 -> 2
            //3 4          4 -> 3
            //     empty line stop input

            // списък на наследниците 

            var graph = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                string[] connection = line.Split(' ');

                string first = connection[0];
                string second = connection[1];

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<string>();
                }

                graph[first].Add(second);

                // Loop?
                if (first != second)
                {
                    if (!graph.ContainsKey(second))
                    {
                        graph[second] = new List<string>();
                    }

                    graph[second].Add(first);
                }

                line = Console.ReadLine();
            }

            //Print
            foreach (var node in graph)
            {
                Console.Write(node.Key + " -> ");

                foreach (string neighbors in node.Value)
                {
                    Console.Write(neighbors + " ");
                }

                Console.WriteLine();
            }
        }

    }
}
