using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class QuickSort
    {
        static void Main()
        {
            List<int> nums = new List<int>() { 8, 2, 4, 3, 15, 5, 8, 9, 49 };
            List<int> numsSort = new List<int>();

            var sorted = QuickSortRecursive(nums);
            for (int i = 0; i < sorted.Count; i++)
            {
                Console.Write(sorted[i] + " ");
            }
            //Print
            //numsSort.ForEach(x => Console.Write(x + " "));
        }

        public static List<int> QuickSortRecursive(List<int> nums)
        {
            if (nums.Count <= 1)
            {
                return nums;
            }

            int pivot = FindPivotElement(nums);

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] <= pivot)
                {
                    left.Add(nums[i]);
                }
                else
                {
                    right.Add(nums[i]);
                }
            }
            //if (left.Count == 1)
            //{
            //    return left;
            //}
            //if (right.Count == 1)
            //{
            //    return right;
            //}

            left = QuickSortRecursive(left);
            right = QuickSortRecursive(right);

            List<int> result = new List<int>();
            result.AddRange(left);
            result.Add(pivot);
            result.AddRange(right);

            return result;
        }


        public static int FindPivotElement(List<int> nums)
        {
            //Find the pivot element
            int firstElem = nums[0];
            int middleElem = nums[nums.Count / 2];
            int lastElem = nums[nums.Count - 1];
            int pivotElem;

            if (firstElem >= lastElem && firstElem >= middleElem)   // first is biggest
            {
                if (lastElem >= middleElem)
                {
                    pivotElem = lastElem;
                }
                else
                {
                    pivotElem = middleElem;
                }
            }
            else if (middleElem >= firstElem && middleElem >= lastElem)   // middle is biggest
            {
                if (firstElem > lastElem)
                {
                    pivotElem = firstElem;
                }
                else
                {
                    pivotElem = lastElem;
                }
            }
            else  // last is biggest
            {
                if (middleElem > firstElem)
                {
                    pivotElem = firstElem;
                }
                else
                {
                    pivotElem = middleElem;
                }
            }
            return (pivotElem);
        }
    }
}
