using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan2
{
    public class vegan2
    {
        public static void Main()
        {

            List<string> namesInput = new List<string>();
            List<int> weightInput = new List<int>();
            List<int> proteineInput = new List<int>();

            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int weight = int.Parse(input[1]);
                int protein = int.Parse(input[1]);

                namesInput.Add(name);
                weightInput.Add(weight);
                proteineInput.Add(protein);
            }

            Dictionary<int, List<string>> proteinListNames = new Dictionary<int, List<string>>();
            Dictionary<int, int> proteinWeight = new Dictionary<int, int>();

            for (int l = 0; l < namesInput.Count; l++)
            {
                for (int i = 0; i < l; i++)
                {
                    proteinListNames.Add(proteineInput[0] + proteineInput[i], new List<string>());
                    proteinListNames[proteineInput[0] + proteineInput[i]].Add(namesInput[0] + namesInput[i]);

                    proteinWeight.Add(proteineInput[0] + proteineInput[i], weightInput[0] + weightInput[i]);


                }
            }


        }
    }
}
