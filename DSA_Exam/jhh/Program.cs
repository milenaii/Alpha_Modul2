using System;

using System.Collections.Generic;

using System.Linq;

using System.Security.Cryptography.X509Certificates;

using System.Text;

using System.Threading.Tasks;



namespace Vegan_Bodybuilder

{

    public class VeganBodybuilder

    {

        public static Dictionary<int[], int> KSmem = new Dictionary<int[], int>();

        public static List<int[]> foodMenu = new List<int[]>();



        public static void Main(string[] args)

        {

            var M = int.Parse(Console.ReadLine());

            var N = int.Parse(Console.ReadLine());



            for (int i = 0; i < N; i++)

            {

                foodMenu.Add(Console.ReadLine().Split().Skip(1).Select(int.Parse).ToArray());

            }





            KS(N, M);

        }



        public static int KS(int n, int c)

        {

            if (KSmem.ContainsKey(new[] { n, c }))

            {

                return KSmem[new[] { n, c }];

            }



            int result;

            if (n == 0 || c == 0)

            {

                result = 0;

            }

            else if (foodMenu[n][0] > c)

            {

                result = KS(n - 1, c);

            }

            else

            {

                var tempOne = KS(n - 1, c);

                var tempTwo = foodMenu[n][1];



                result = new[] { tempOne, tempTwo }.Max();

            }



            return result;

        }

    }

}
