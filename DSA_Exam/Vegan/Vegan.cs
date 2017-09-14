using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan
{
    public class Vegannn
    {
        public static void Main()
        {
            // Dictionary<string, OrderedBag<Order>> veganByName = new Dictionary<string, OrderedBag<Order>>();
            // OrderedDictionary<int, List<Order>> proteinVegan = new OrderedDictionary<int, List<Order>>();

            List<Vegan> veganList = new List<Vegan>();

            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int weight = int.Parse(input[1]);
                int protein = int.Parse(input[1]);

                Vegan vegan = new Vegan(name, weight, protein);

                veganList.Add(vegan);

                for (int l = 0; l < veganList.Count; l++)
                {
                    if (veganList.Count == 1)
                    {
                        continue;
                    }
                    name = vegan.Name + veganList[l].Name;
                    weight = vegan.Weight + veganList[l].Weight;
                    protein = vegan.Protein + veganList[l].Protein;

                    Vegan vegan2 = new Vegan(name, weight, protein);

                    veganList.Add(vegan2);

                }
                //Add to base


            }
        }
    }

    public class Vegan : IComparable<Vegan>
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Protein { get; set; }

        public Vegan(string name, int weight, int protein)
        {
            this.Name = name;
            this.Weight = weight;
            this.Protein = protein;
        }


        public int CompareTo(Vegan other)
        {
            return this.Protein.CompareTo(other.Protein);
        }
    }
}
