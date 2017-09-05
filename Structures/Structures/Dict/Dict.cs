using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict
{
    class Dict
    {
        static void Main()
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            //add key
            dict.Add(1, new List<int>());
            dict.Add(5, new List<int>());
    //        dict.Add(1, new List<int>());  не дава повтарящи се стойности

            List<int> list = new List<int>();

            //add value by key
            dict[1].AddRange(list);
            dict[5].Add(3);

            //search key
            dict.Any(x => x.Key == 5);

            dict.ContainsKey(5);
            dict.ContainsValue(list);
            dict[1].Count();
        }
    }
}
