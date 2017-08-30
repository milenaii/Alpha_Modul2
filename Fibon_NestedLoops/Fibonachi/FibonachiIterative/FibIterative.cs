using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonachiIterative
{
    public class FibIterative
    {
        public static void Main()
        {
            Console.WriteLine("n = ");
            int n = int.Parse(Console.ReadLine());

            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);

        }
    }
}
