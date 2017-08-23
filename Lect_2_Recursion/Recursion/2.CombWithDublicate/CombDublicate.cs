using System;

namespace _2.CombWithDublicate
{
    public class CombDublicate
    {
        public static void Main()
        {
            int kMax = 2; /*int.Parse(Console.ReadLine());*/
            int nMax = 3; /*int.Parse(Console.ReadLine());*/

            int [] arrN = new int[nMax];
            int [] arrK = new int[kMax];

            for (int i = 0; i < nMax; i++)
            {
                arrN[i] = i + 1;
            }

            RecursiveCombWithDublicates(0, 0, kMax, nMax, arrN, arrK);
        }

        private static void RecursiveCombWithDublicates(int k, int n, int kMax, int nMax, int[]arrN, int[] arrK)
        {
            if (k == kMax)
            {
                Console.Write("({0}), ", string.Join(" ", arrK));
                return;
            }
            for (int i = n; i < nMax; i++)
            {
                arrK[k] = arrN[n];
                    
                RecursiveCombWithDublicates(n + 1, i, kMax, nMax);
            }
        }
    }
}
