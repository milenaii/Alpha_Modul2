using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FibonRec
    {
        public static void Main()
        {
            Console.WriteLine("n = ");
            int n = int.Parse(Console.ReadLine());

            Factorial(n);
            Console.WriteLine(Factorial(n));

        }

        public static int Factorial(int n)
        {
            //the bottom of the recursion
            if (n == 0)
            {
                return 1;
            }
            //Recursive call
            return n * Factorial(n - 1);
        }



    }
}
