using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prM
{
    public class Program
    {
        public static void Main()
        {
            int n = 2;
            Recursion(0, n);
        }

        public static void Recursion(int i, int n)
        {
            int[] A = new int[] { 1, 2 };
            int[] B = new int[] { 1, 2 };

            if (i == n)
            {
                return;
            }
            for (int j = i; j < n; j++)
            {
                Console.WriteLine($"({A[i]} {B[j]}), ");
                i++;
            }
            Recursion(i, n);
        }

    }
}
