using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortListIncreaseing
{
    //Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order
    class SortListIncreasing
    {
        static void Main()
        {

            List<int> listNum = new List<int>();

            string input = Console.ReadLine();
            while (input!= string.Empty)
            {
                int num = int.Parse(input);
                listNum.Add(num);

                input = Console.ReadLine();
            }
            listNum.Sort();
            Console.WriteLine(string.Join(" ",listNum));
        }
    }
}
