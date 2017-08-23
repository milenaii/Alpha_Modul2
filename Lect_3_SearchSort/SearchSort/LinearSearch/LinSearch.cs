using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearch
{
    public class LinSearch
    {
        public static void Main()
        {
            //input 1 
            int searchedInt = 56;
            List<int> arr = new List<int> { 1, 5, 48, 3, 56, 42, 14 };

            //input 2 
            string searchedStr = "mi";
            List<string> arrString = new List<string> { "ok", "lij", "mi", "gdf", "njbjs" };

            Console.WriteLine(LinearSearch(arr, searchedInt));
            Console.WriteLine(LinearSearch(arrString, searchedStr));
        }

        private static int LinearSearch(IList arr, object searchedObj )
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (searchedObj == arr[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
