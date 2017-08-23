using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CombinationWithDublicates
{

    //Тук комбинирам елем от К с елем от N: not exactly the homework task
    class CombWithDublicates
    {
        public static void Main()
        {
            int kMax = 2; /*int.Parse(Console.ReadLine());*/
            int nMax = 3; /*int.Parse(Console.ReadLine());*/

            int currentK = 1;
            int currentN = 1;
            RecursiveCombWithDublicates(currentK, currentN, kMax, nMax);

        }

        public static void RecursiveCombWithDublicates(int currentK, int currentN, int kMax, int nMax)
        {
            if (currentK == kMax + 1)
            {
                return;
            }
            if (currentN == nMax + 1)
            {
                currentN = 1;
                currentK++;
            }

            Console.Write($"({currentK} {currentN}), " );
            currentN++;
            RecursiveCombWithDublicates(currentK, currentN, kMax, nMax);

        }
    }
}
