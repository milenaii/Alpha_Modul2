using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.LongestSubsequenceOfList
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            // 5 осмици
            int[] arr = new int[] { 1, 8, 7, 8, 1, 4, 8, 1, 2, 6, 4, 8, 1, 2 ,8};

            Array.Sort(arr);

            int count = 1;
            int maxCount = 1;

            for (int i = 0;  i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i +1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                else
                {
                    count = 1;
                }
            }
            Console.WriteLine(maxCount);

        }
    }
}
