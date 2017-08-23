using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class SelectionSort
    {
        static void Main()
        {
            List<int> nums = new List<int>() { 7, 8, 5, -8, 100, 48, 1, 78, 3};

            for (int i = 0; i < nums.Count; i++)
            {
                //Find min
                int min = i;

                for (int j = i; j < nums.Count; j++)
                {
                    if (nums[min] > nums[j])
                    {
                        min = j;
                    }
                }
                
                //swap the min with the current position j:
                int temp = nums[min];
                nums[min] = nums[i];
                nums[i] = temp;
            }
            //Print
            nums.ToList().ForEach(x => Console.Write(x + " "));
        }
    }
}
