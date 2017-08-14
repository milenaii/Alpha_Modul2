using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcPrintSumAndAverageOfSequence
{
    //Write a program that reads from the console a sequence of positive integer numbers.
    //The sequence ends when empty line is entered.
    //Calculate and print the sum and average of the elements of the sequence.
    //Keep the sequence in List<int>.

    public class SumAndAverage
    {
        static void Main()
        {
            List<int> list = new List<int>();
            int sum = 0;

            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int num = int.Parse(input);
                sum += num;
                list.Add(num);

                input = Console.ReadLine();
            }

        }
    }
}
