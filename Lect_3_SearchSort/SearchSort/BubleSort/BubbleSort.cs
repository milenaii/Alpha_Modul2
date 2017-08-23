using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
//Two by two we compare the items and if it is neccessary exchange them
{
    class BubleSort
    {
        static void Main()
        {
            List<int> nums = new List<int>() { 8, 3, 5, 9, 1,100, 45, 487, -25, -1 };

            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        //swap
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            //Print
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
    }
}


