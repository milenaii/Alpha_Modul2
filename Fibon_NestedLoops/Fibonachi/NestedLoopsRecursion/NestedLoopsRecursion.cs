using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoopsRecursion
{
    public class NestedLoopsRecursion
    {
        static int numberOfIteration;
        static int numberOfLoops;
        static int[] loops;

        static void Main()
        {
            Console.Write("N = ");
            int numberOfLoops = int.Parse(Console.ReadLine());  

            Console.Write("K = ");
            int numberOfIteration = int.Parse(Console.ReadLine());

            loops = new int[numberOfLoops];

            RecursiveNestedLoops(0);
        }
        public static  void RecursiveNestedLoops(int curLoops)
        {
            if (curLoops == numberOfLoops)
            {
                //Print
                for (int i = 0; i < numberOfLoops; i++)
                {
                    Console.Write("{0} ", loops[i]);
                }
                Console.WriteLine();
                return;
            }
            for (int counter = 1; counter <= numberOfIteration; counter++)
            {
                loops[curLoops] = counter;
                RecursiveNestedLoops(curLoops + 1);
            }
        }
    }
}
