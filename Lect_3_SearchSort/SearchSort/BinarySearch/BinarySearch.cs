using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearch
{
    public class BinarySearchh
    {
        public static void Main()
        {
            int searchedNumber = 8;

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            BinarySearch(searchedNumber, nums);

        }

        private static void BinarySearch(int searchedNumber, List<int> nums)
        {
            int minIndex = 0;
            int maxIndex = nums[nums.Count - 1];

            while (minIndex < maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;

                if (searchedNumber == nums[midIndex])
                {
                    Console.WriteLine(midIndex);
                    return;
                }
                else if (searchedNumber < nums[midIndex])
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    minIndex = midIndex + 1;
                }
            }
        }
    }
}
