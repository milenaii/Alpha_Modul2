using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchRecursiveee
{
    class BinarySearchRecursivee
    {
        static void Main()
        {
            int searchedNumber = 2;

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int minIndex = 0;
            int maxIndex = nums[nums.Count - 1];

            BinarySearchRecursive(searchedNumber, nums, minIndex, maxIndex);

        }

        private static void BinarySearchRecursive(int searchedNumber, List<int> nums, int minIndex, int maxIndex)
        {
            
            if (minIndex > maxIndex)
            {
                Console.WriteLine("The number is not in this list!");
                return;
            }
            int midIndex = (minIndex + maxIndex) / 2;

            if (searchedNumber == nums[midIndex])
            {
                Console.WriteLine(midIndex);
                return;
            }
            else if (searchedNumber < nums[midIndex])
            {
                maxIndex = midIndex - 1;
                BinarySearchRecursive(searchedNumber, nums, minIndex, maxIndex);
            }
            else
            {
                minIndex = midIndex + 1;
                BinarySearchRecursive(searchedNumber, nums, minIndex, maxIndex);
            }

        }
    }
}
