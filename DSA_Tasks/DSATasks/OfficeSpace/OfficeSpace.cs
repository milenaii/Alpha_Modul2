using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSpace
{
    //8
    //1 2 3 децата на 0              0
    //4  децата на 1             1    2     3        1 2
    //-1                         4          5        5 6
    //5                          6          7        2 3
    //6                                              1 5  запазваме на всеки
    //7                                                 родителите, който няма -
    //- 1                                               той е корена
    // - 1      

    public class OfficeSpace
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            //    var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var adjList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                if (line != "-1")
                {
                    adjList[i] = line.Split(' ').Select(x => int.Parse(x)).ToList();
                }
            }
//знаем кой е коренар но ако не знаем
            var nodes = new Queue<int>();

            nodes.Enqueue(0);
            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();
                Console.WriteLine(current);

                if (adjList[current] != null) // if current have children
                {
                    foreach (var successor in adjList[current])
                    {
                        nodes.Enqueue(successor);
                    }
                }
            }

        }
    }
}
