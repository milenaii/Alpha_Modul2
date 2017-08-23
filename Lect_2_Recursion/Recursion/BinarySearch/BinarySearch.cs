using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearch
    {
        public static void Main()
        {
            int value = 6;
            int[] sortNums = { 1, 2, 3, 4, 5, 6, 17, 18, 19, 21, 22, 25 };

            int min = sortNums[0];
            int max = sortNums[sortNums.Length - 1];

            int searchedIndex = BinarySearchRecursion(value, min, max, sortNums);
        }

        public static int BinarySearchRecursion(int value, int min, int max, int[] sortNums)
        {
            if (min > max)   // bottom 1 - here is no searched element
            {
                return -1;
            }

            int midIndex = (min + max) / 2;
            int midElement = sortNums[midIndex];

            if (value == sortNums[midElement])  //bottom 2 - there is searched element
            {
                return midIndex;
            }

            if (value > sortNums[midElement])
            {
                min = midIndex + 1;
            }
            else
            {
                max = midIndex - 1;
            }

            return BinarySearchRecursion(value, min, max, sortNums);

        }
    }
}
