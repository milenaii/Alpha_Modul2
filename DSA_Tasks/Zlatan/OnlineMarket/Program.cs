using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OnlineMarket
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, OrderedSet<Product>> dict = new Dictionary<string, OrderedSet<Product>>();

            List<Product> set = new List<Product>();  //filter by price 2 %

            HashSet<string> names = new HashSet<string>();  // find name,after that - in dict

            while (line != "end")
            {
                string[] parameters = line.Split(' ').ToArray();
                string command = parameters[0];

                switch (command)
                {
                    case "add":
                        string name = parameters[1];
                        double price = double.Parse(parameters[2]);
                        string type = parameters[3];

                        Product product = new Product(name, type, price);

                        if (names.Contains(name))
                        {
                            Console.WriteLine("Error: Product {0} already exists", name);
                        }
                        else
                        {
                            names.Add(name);
                            set.Add(product);
                            if (!dict.ContainsKey(type))
                            {
                                dict.Add(type, new OrderedSet<Product>());
                            }
                            dict[type].Add(product);
                            Console.WriteLine("Ok: Product {0} added successfully", name);
                        }
                        
                        break;
                    case "filter":
                        if (parameters[2] == "type")
                        {
                            //– lists the first 10 products that have the given PRODUCT_TYPe
                            //Print "Error: Type PRODUCT_TYPE does not exists", if the given PRODUCT_TYPE is non - existent
                            string filterType = parameters[3];
                            if (!dict.ContainsKey(filterType))
                            {
                                Console.WriteLine("Error: Type {0} does not exists", filterType);
                            }
                            else
                            {
                                string result = string.Format("Ok: {0}", string.Join(", ", dict[filterType].Take(10)));
                                result.TrimEnd(',', ' ');
                                Console.WriteLine(result);
                            }
                        }
                        else
                        {
                            /*here are the cases with "filter by price"
                            •	filter by price from MIN_PRICE to MAX_PRICE – lists the first 10 products that have PRODUCT_PRICE in the given range, inclusive
                            •	filter by price from MIN_PRICE – lists the first 10 products that have a greater PRODUCT_PRICE than the given, inclusive
                            •	filter by price to MAX_PRICE – lists the first 10 products that have a smaller PRODUCT_PRICE that the given, inclusive */

                            if (parameters.Length > 5 && parameters[3] == "from" && parameters[5] == "to")
                            {
                                double fromPrice = double.Parse(parameters[4]);
                                double toPrice = double.Parse(parameters[6]);
                                var filtered = set.Where(x => x.Price >= fromPrice && x.Price <= toPrice).OrderBy(x => x.Price).Take(10);
                                string filterFromTo = string.Format("Ok: {0}", string.Join(", ", filtered));
                                filterFromTo.TrimEnd(',', ' ');
                                Console.WriteLine(filterFromTo);
                            }

                            else if(parameters[3] == "from")
                            {
                                double minPrice = double.Parse(parameters[4]);
                                var filteredTo = set.Where(x => x.Price > minPrice).OrderBy(x => x.Price).Take(10);
                                string filterTo = string.Format("Ok: {0}", string.Join(", ", filteredTo));
                                filterTo.TrimEnd(',', ' ');
                                Console.WriteLine(filterTo);
                            }
                            else if (parameters[3] == "to")
                            {
                                double maxPrice = double.Parse(parameters[4]);
                                var filteredTo = set.Where(x => x.Price < maxPrice).OrderBy(x => x.Price).Take(10);
                                string filterTo = string.Format("Ok: {0}", string.Join(", ", filteredTo));
                                filterTo.TrimEnd(',', ' ');
                                Console.WriteLine(filterTo);
                            }
                        }
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, string type, double price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }
        public string Name
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }

        public int CompareTo(Product other)
        {
            /*They must also be sorted by the following criteria:
•	First by PRODUCT_PRICE, ascending
•	Then by PRODUCT_NAME, ascending
•	Last by PRODUCT_TYPE, ascending*/
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Type.CompareTo(other.Type);
                }
            }
            return result;
        }


        public override string ToString()
        {
            string product = string.Format("{0}({1})",this.Name, this.Price); //PRODUCT_NAME(PRODUCT_PRICE)
            return product;
        }
    }
}
