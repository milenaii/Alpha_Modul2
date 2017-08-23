using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class InsertionSort
    {
        static void Main()
        {                                  
            List<int> nums = new List<int>() { 8,2, 4, 3, -3,5, 8, 9, 2 };

            for (int i = 1; i < nums.Count; i++)
            {
                int pos = i;

                while (pos > 0 && nums[pos] < nums[pos - 1])
                {
                    //swap nums[pos] and nums[pos - 1]
                    int temp = nums[pos];
                    nums[pos] = nums[pos - 1];
                    nums[pos - 1] = temp;

                    pos = pos - 1;
                }
            }
            //Print
            nums.ForEach(x => Console.Write(x + " "));
        }
    }
}

