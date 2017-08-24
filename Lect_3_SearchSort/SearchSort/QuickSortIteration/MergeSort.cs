using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortIteration
{
    public class MergeSortt
    {
        public static void Main()
        {
            List<int> nums = new List<int>() { 8, 2, 4, 3, 15, 5, 8, 9, 49, 1 };
            nums = MergeSort(nums);
            nums.ForEach(x => Console.Write(x + " "));
        }

        public static List<int> MergeSort(List<int> nums)
        {
            if (nums.Count < 2)
            {
                return nums;
            }

            List<int> left = nums.Take(nums.Count / 2).ToList();
            List<int> right = nums.Skip(nums.Count / 2).ToList();
            //List<int> left = new List<int>();
            //List<int> right = new List<int>();

            //for (int i = 0; i < nums.Count; i++)

            //{
            //    if (i <= nums.Count / 2)
            //    {
            //        left.Add(nums[i]);
            //    }
            //    else
            //    {
            //        right.Add(nums[i]);
            //    }
            //}

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {

            int i = 0;
            int j = 0;
            List<int> mergedList = new List<int>();

            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    mergedList.Add(left[i]);
                    i++;
                }
                else
                {
                    mergedList.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                mergedList.Add(left[i]);
                i++;
            }
            while (j < right.Count)
            {
                mergedList.Add(right[j]);
                j++;
            }

            return mergedList;
        }


    }
}


