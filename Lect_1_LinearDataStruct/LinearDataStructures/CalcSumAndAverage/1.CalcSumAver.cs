using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcSumAndAverage
{
    public class Program
    {
        public static void Main()
        {
            List<int> list = FillList();

            Console.WriteLine($"sum is {list.Sum()}");
            Console.WriteLine($"average is {list.Average()}");

        }

        private static List<int> FillList()
        {
            List<int> list = new List<int> ();

            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int num = int.Parse(input);
                list.Add(num);

                input = Console.ReadLine();
            }
            return list;
        }

    }
}
