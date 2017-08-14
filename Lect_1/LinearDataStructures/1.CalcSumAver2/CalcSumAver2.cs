using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.CalcSumAver2
{
    public class CalcSumAver2
    {
        public static void Main()
        {
            List<int> list = new List<int>();

            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int num = int.Parse(input);
                list.Add(num);

                input = Console.ReadLine();
            }
            Console.WriteLine($"sum is {list.Sum()}");
            Console.WriteLine($"Average is {list.Average()}");

        }
    }
}
