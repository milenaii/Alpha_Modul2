using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSort
    {
        public static void Main()
        {
            List<int> nums = new List<int>() { 8, 2, 4, 3 };
            List<int> numsSort = new List<int>();

            var sorted = QuickSortRecursive(nums);

            for (int i = 0; i < sorted.Count; i++)
            {
                Console.Write(sorted[i] + " ");
            }
        }

        public static List<int> QuickSortRecursive(List<int> nums)
        {
            if (nums.Count <= 1)
            {
                return nums;
            }

            int pivotIndex = FindPivotElement(nums);   //return IndexPivot

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < nums.Count; i++) // b/e we take away the Pivot element
            {
                if (i == pivotIndex)
                {
                    continue;
                }

                if (nums[i] < nums[pivotIndex])
                {
                    left.Add(nums[i]);
                }
                else
                {
                    right.Add(nums[i]);
                }
            }
            
            left = QuickSortRecursive(left);
            right = QuickSortRecursive(right);

            List<int> result = new List<int>();
            result.AddRange(left);
            result.Add(nums[pivotIndex]);
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
            int indexPivot;

            if (firstElem >= lastElem && firstElem >= middleElem)   // first is biggest
            {
                if (lastElem >= middleElem)
                {
                    pivotElem = lastElem;
                    indexPivot = nums.Count - 1;
                }
                else
                {
                    pivotElem = middleElem;
                    indexPivot = nums.Count / 2;

                }
            }
            else if (middleElem >= firstElem && middleElem >= lastElem)   // middle is biggest
            {
                if (firstElem > lastElem)
                {
                    pivotElem = firstElem;
                    indexPivot = 0;

                }
                else
                {
                    pivotElem = lastElem;
                    indexPivot = nums.Count - 1;

                }
            }
            else  // last is biggest
            {
                if (middleElem > firstElem)
                {
                    pivotElem = firstElem;
                    indexPivot = 0;

                }
                else
                {
                    pivotElem = middleElem;
                    indexPivot = nums.Count / 2;
                }
            }
            return (indexPivot);
        }
    }
}
