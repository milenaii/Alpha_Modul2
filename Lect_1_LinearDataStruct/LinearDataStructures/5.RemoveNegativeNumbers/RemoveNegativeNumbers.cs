using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.RemoveNegativeNumbers
{
    class RemoveNegativeNumbers
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 8, -7, -8, -1, 4, -8, 1, -2, -6, 4, 8, 1, -2, -8 };

            List<int> positive = new List<int>() { };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    positive.Add(arr[i]);
                    Console.Write(arr[i] +" ");
                }
            }
        }
    }
}
