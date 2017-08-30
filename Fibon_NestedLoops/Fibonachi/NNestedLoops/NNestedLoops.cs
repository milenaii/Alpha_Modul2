using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNestedLoops
{
    //Да се напише програма, която симулира изпълнението на N вложени цикъ­ла от 1 до K, където N и K се въвеждат от потребителя
    public class NNestedLoops
    {
        public static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());  //num of loops

            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());  //num of iteration

            for (int i = 0; i < n; i++)
            {
                for (int a1 = 1; a1 <= k; a1++)
                {
                    for (int a2 = 1; a2 < k; a2++)
                    {
                        //..........
                    }
                }
            }

        }
    }
}
