using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcsSumAver3
{
    class CalcSumAver3
    {
        static void Main()
        {
            Console.WriteLine("Enter positive integer numbers (separated by space):");

            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());


        }
    }
}
