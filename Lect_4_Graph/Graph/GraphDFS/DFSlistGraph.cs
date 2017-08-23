using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDFS
   //graph A -> B -> C
   // A -> D
   //D -> E-> F
   //E -> G
   //E -> H
{
    public class DFSlistGraph
    {
         public static void Main()
        {
            Dictionary<string, List<string>> dictGraph = new Dictionary<string, List<string>>();
            // List<List<int>> graph = new List<List<int>> ();

            dictGraph.Add("A", new List<string> { "B", "C","D" });
            dictGraph.Add("B", new List<string> { "B", "C" });
            dictGraph.Add("C", new List<string> { });
            dictGraph.Add("D", new List<string> { "E" });
            dictGraph.Add("E", new List<string> { "G", "H", "F" });
            dictGraph.Add("F", new List<string> {});

            Stack stack = new Stack();

            foreach (var item in dictGraph)
            {
                foreach (var str in new List<string>())
                {

                }
            }



        }
    }
}
