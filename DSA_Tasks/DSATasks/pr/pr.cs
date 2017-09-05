using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr
{
    public class pr
    {
        public static void Main()
        {
            //   6 = n                                      graph         input         
            //   1 2 3 децата на 0   parents 0  - 1            0           5  
            //   4     децата на 1   parents 1    0       1    2     3     0 1   
            //   -1    децата на 2   parents 2    0       4          5     0 2  
            //   5     децата на 3   parents 3    0                        0 3
            //   -1    децата на 4   parents 4    1                        1 4 
            //   -1    децата на 5   parents 5    3                        3 5


            int n = int.Parse(Console.ReadLine()); //num of nodes

            //         Node      Children  
            Dictionary<int, List<int>> graphNodeChild = new Dictionary<int, List<int>>();
            //         Node      Parent  
            //Dictionary<int, List<int>> dicNodeParent = new Dictionary<int, List<int>>();
            //         Node num Parent      
            Dictionary<int, int> dicNumParent = new Dictionary<int, int>();

            //here the nodes without parents will stay
            List<int> resultList = new List<int>();

            //HashSet<int> children = new HashSet<int>();

           // int countAllChild = 0 + 1;
            //List<int> ch = new List<int>();

            //input; fill the graph
            for (int i = 0; i < n; i++)
            {
                int[] dev = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int first = dev[0];
                int second = dev[1];

                if (!graphNodeChild.ContainsKey(first))
                {
                    graphNodeChild.Add(first, new List<int>());
                    dicNodeParent.Add(first, new List<int>());
                }
                if (!graphNodeChild.ContainsKey(second))
                {
                    graphNodeChild.Add(second, new List<int>());
                    dicNodeParent.Add(second, new List<int>());
                }

                //children.Add(first);
                //children.Add(second);

                graphNodeChild[first].Add(second);
                dicNodeParent[second].Add(first);
                // ch.Add(second);
                //countAllChild++;
            }
            //serched for Node with No Parents
            //while (children.Count > 0)
            //{
                for (int i = 0; i < n; i++)
                {
                    if (dicNodeParent[i] == 0)
                    {
                        resultList.Add(i);
                        graphNodeChild[i].Remove(i);
                        //countAllChild--;
                        //children.Remove(i);

                        if (graphNodeChild.ContainsKey(i))
                        {
                            //delete all children
                            graphNodeChild[i].Clear();
                            //graphNodeChild.Select(x => x.Value);
                        }
                    }
                }
           // }
            foreach (var item in resultList)
            {
                Console.WriteLine(item);
            }

        }


    }
}