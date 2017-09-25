using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//GoldFever - not finished
namespace ppp
{
    // MI decision
    // example    
    //     6
    //     1 3 2 10 1
    //maxPrice
    //indexMaxPrice
    //profit = indexMaxPrice * maxPrice
    //lost = Sum do indexMaxPrice
    //Re profit = profit - lost
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dayPrices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxPrice = 0;
            int indexMaxPrice = int.MinValue;

            int counterMaxPriceHowManyTimes = 1;

            // i -> maxIndex

            // if maxPriceCount > 1

            for (int i = 0; i <= dayPrices.Length - 1; i++)
            {
                if (dayPrices[i] == maxPrice)
                {
                    counterMaxPriceHowManyTimes++;
                }

                if (dayPrices[i] > maxPrice)
                {
                    maxPrice = dayPrices[i];
                    indexMaxPrice = i; //for the case counterMaxPriceHowManyTimes ==1;
                }
            }

            if (counterMaxPriceHowManyTimes > 1) // if maxPriceCount > 1
            {
                int fullProfit = 0;
                int iSt = 0;
                int indexMax;

                for (int i = 0; i <= dayPrices.Length - 1; i++)
                {
                    if (dayPrices[i] == maxPrice)
                    {
                        int iMax = i;
                        int[] arr = new int[iMax + 1 - iSt];
                        int lost = 0;

                        for (int j = iSt; j <= iMax; j++)
                        {
                            arr[j - iSt] = dayPrices[j];
                        }
                        for (int l = 0; l < arr.Length - 1; l++)
                        {
                            lost += arr[l];
                        }
                        
                        
                        int profit = (iMax - iSt) * maxPrice;
                        int reProfit = profit - lost;

                        fullProfit += reProfit;

                        iSt = iMax + 1;
                    }
                }
                Console.WriteLine(fullProfit);

            }
            else //if maxPriceCount = 1
            {
                int lost = 0;
                for (int i = 0; i < indexMaxPrice; i++)
                {
                    lost += dayPrices[i];
                }
                int profit = indexMaxPrice * maxPrice;
                int reProfit = profit - lost;

                Console.WriteLine(reProfit);
            }


        }
    }
}
