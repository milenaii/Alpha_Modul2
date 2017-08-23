using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    public static class Shuffle
    {
        public static void Main()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            nums.OrderBy(x => Guid.NewGuid()).ToList().ForEach(x => Console.Write(x + " "));

        }
    }
}
