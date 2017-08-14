using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ReverseIntegers
{
    class ReverseIntegers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> st = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                st.Push(num);
            }

            //1 way print & reverse

            //while (st.Count > 0)
            //{
            //    Console.WriteLine(st.Pop());
            //}


            //2 way print & reverse

            Console.WriteLine(string.Join(", ", st));

            Console.WriteLine(string.Join(", ", st.Reverse<int>()));


        }
    }
}
