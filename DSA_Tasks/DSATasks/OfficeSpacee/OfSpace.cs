using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSpace
{
    class Job : IComparable<Job>
    {
        public int Time { get; private set; }

        public int Id { get; private set; }

        public Job(int id, int time)
        {
            this.Id = id;
            this.Time = time;

        }
        public int CompareTo(Job other)
        {
            var timeComparison = this.Time.CompareTo(other.Time);

            return timeComparison != 0 ? timeComparison : this.Id.CompareTo(other.Id);
        }
    }


    public class OfficeSpace
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //spisak na nasledstvo -  adjList

            var dependencies = new List<int>[n];  // from child to parrent
            var parentToChildren = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                    // parents index
                    dependencies[i] = line.Split(' ').Select(x => int.Parse(x) - 1).ToList();

                    foreach (var dependencyId in dependencies[i])
                    {
                    if (dependencyId == -1)
                    {
                        break;
                    }
                        if (parentToChildren[dependencyId] == null)
                        {
                            parentToChildren[dependencyId] = new List<int>();
                        }
                        parentToChildren[dependencyId].Add(i);
                    }
                }
            
            var result = TraverseTopological(minutes, dependencies, parentToChildren);

            Console.WriteLine(result);
        }
        // while in Set there are things, continue input and lutput from there
        static int TraverseTopological(int minutes, List<int>[] dependancies, List<int> parents)
        {
            var jobs = new SortedSet<Job>();  // first must input theese that are

            for (int i = 0; i < dependancies.Length; i++)
            {
                if (dependancies[i]==null)
                {
                    jobs.Add(new Job(i, minutes[i]));
                }
            }
            return 0;                         // without dependencies
        }

    }
}
