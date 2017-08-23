using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortListIncreasing
{
    class SortListIncrease
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            numbers.Sort();

            //1 way print
            //Console.WriteLine(string.Join(", ",numbers));

            //2 way print
            numbers.ForEach(x => Console.WriteLine(x + " "));

        }
    }
}
