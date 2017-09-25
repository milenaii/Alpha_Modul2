using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever
{
    // if tomorow the price is biggest, i will byu today and sell tomorrow, the profit will be 
    //  (countOunce * (priceTomorrow - priceToday)

    class StUpGoldFever
    {
        //private static int startProfit;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int [] dayPrices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxPrice = 0;
            long sum = 0;

            for (int i = dayPrices.Length - 1; i >= 0; i--)
            {
                if (dayPrices[i] > maxPrice)
                {
                    maxPrice = dayPrices[i];
                }
                else
                {
                    sum += maxPrice;
                    sum -= dayPrices[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
