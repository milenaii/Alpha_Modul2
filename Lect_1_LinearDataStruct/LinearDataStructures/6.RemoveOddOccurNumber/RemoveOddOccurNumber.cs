using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.RemoveOddOccurNumber
{
    class RemoveOddOccurNumber
    {
        static void Main()
        {
            int[] arr = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Array.Sort(arr);
            // arr.ToList().ForEach(x => Console.Write(x + " "));

            List<int> nums = new List<int>() { };

            int count = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    count++;
                    //int  num = arr[i];
                }

                else
                {
                    if (count % 2 == 0 && i != arr.Length - 2)
                    {
                        for (int l = 0; l < count; l++)
                        {
                            nums.Add(arr[i]);
                        }
                    }
                    count = 1;
                }
                if (count % 2 == 0 && i == arr.Length - 2)
                {
                    for (int l = 0; l < count; l++)
                    {
                        nums.Add(arr[i]);
                    }
                }
            }
            nums.ForEach(x => Console.Write(x + " "));
        }
    }
}
