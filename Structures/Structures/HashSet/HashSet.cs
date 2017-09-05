using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet
{
    class HashSet
    {
        static void Main()
        {
            HashSet<string> hashset = new HashSet<string>();

            bool lk = hashset.Contains("Lili");

            hashset.Add("kiki");

            HashSet<int> hashsetInt = new HashSet<int>();

            bool lkwec = hashset.Contains("Lili");

            hashset.Add("kiki");


            string[] arr = new string [hashset.Count];
            hashset.CopyTo(arr);
            Console.WriteLine(hashset.Count);
        }
    }
}
