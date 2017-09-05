using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSpace
{
    public class Program
    {
        private static Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        private static int[] times;
        private static int[] optimalTimes;

        public static void Main()
        {
            int tasks = int.Parse(Console.ReadLine());
            times = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            //reading in the dependancy data and setting our dictionary with descendants
            for (int i = 0; i < tasks; i++)
            {
                var parents = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                if (parents[0] == 0)
                {
                    dict.Add(i + 1, new List<int>());
                    continue;
                }

                dict.Add(i + 1, new List<int>());
                dict[i + 1].AddRange(parents);
            }
            optimalTimes = new int[tasks + 1];
            for (int i = 1; i < optimalTimes.Length; i++)
            {
                optimalTimes[i] = CalculateMinTime(i);
            }

            Console.WriteLine(optimalTimes.Max());
        }

        public static int CalculateMinTime(int task)
        {
            //if (optimalTimes[task] < 0)
            //{
            //    Console.WriteLine(-1);
            //    Environment.Exit(0);
            //}
            //optimalTimes[task] = -1;//i start processing it, if encountere again it's a sign for a cyclic dependency


            if (optimalTimes[task] != 0)
            {
                return optimalTimes[task];
            }

            if (dict[task].Count == 0)
            {
                return times[task - 1]; //times are zero based
            }

            int maxDependencyTime = 0;

            foreach (int parent in dict[task])
            {
                int dependencyTime = CalculateMinTime(parent);
                maxDependencyTime = Math.Max(dependencyTime, maxDependencyTime);
            }

            optimalTimes[task] = times[task - 1] + maxDependencyTime;
            return optimalTimes[task];
        }
    }
}
