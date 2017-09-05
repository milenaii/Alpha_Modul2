using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace office
{
     class office
    {
         static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //масив от листове
            List<int>[] dependencies = new List<int>[n];

            for (var i = 0; i < n; i++)
            {
                dependencies[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToList();
            }

            //Console.WriteLine(1);
        }

         static int CalculateMinTime(int taskId, int [] minutes, List<int> dependencies)
        {
            if (dependencies[taskId].Count == 1 && dependencies[taskId][0] == -1)
            {
                return minutes[taskId];
            }
        }

    }
}
