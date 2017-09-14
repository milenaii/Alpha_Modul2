using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace playerRanking
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, OrderedBag<Order>> consumerToMap = new Dictionary<string, OrderedBag<Order>>();
            OrderedDictionary<double, List<Order>> priceToMap = new OrderedDictionary<double, List<Order>>();

            int numberOfTurns = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTurns; i++)
            {
                string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, 2).ToArray();

                switch (commandLine[0])
                {
                    case "AddOrder":
                        string[] addDetails = commandLine[1].Split(';');

                        string name = addDetails[0];
                        double price = double.Parse(addDetails[1]);
                        string consumer = addDetails[2];
                        Order order = new Order(name, consumer, price);

                        if (!priceToMap.ContainsKey(price))
                        {
                            priceToMap.Add(price, new List<Order>());
                        }
                        priceToMap[price].Add(order);

                        if (!consumerToMap.ContainsKey(consumer))
                        {
                            consumerToMap.Add(consumer, new OrderedBag<Order>());
                        }

                        consumerToMap[consumer].Add(order);

                        Console.WriteLine("Order added");
                        break;

                    case "DeleteOrders":

                        if (consumerToMap.ContainsKey(commandLine[1]))
                        {
                            OrderedBag<Order> subset = consumerToMap[commandLine[1]];
                            foreach (Order set in subset)
                            {
                                priceToMap[set.Price].Remove(set);
                            }
                            consumerToMap.Remove(commandLine[1]);

                            Console.WriteLine(subset.Count + " orders deleted");
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;

                    case "FindOrdersByPriceRange":
                        string[] priceDetails = commandLine[1].Split(';');

                        double min = double.Parse(priceDetails[0]);
                        double max = double.Parse(priceDetails[1]);

                        OrderedBag<Order> priceBetweenMinMax = new OrderedBag<Order>();

                        foreach (var items in priceToMap.Range(min, true, max, true).Values)
                        {
                            foreach (var item in items)
                            {
                                priceBetweenMinMax.Add(item);
                            }
                        }

                        if (priceBetweenMinMax.Any())
                        {
                            foreach (Order item in priceBetweenMinMax)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }

                        break;

                    case "FindOrdersByConsumer":
                        if (consumerToMap.ContainsKey(commandLine[1]))
                        {
                            foreach (Order purchase in consumerToMap[commandLine[1]])
                            {
                                Console.WriteLine(purchase);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;
                }
            }
        }
        public class Order : IComparable<Order>
        {
            public string Name { get; set; }

            public string Consumer { get; set; }

            public double Price { get; set; }

            public Order(string name, string consumer, double productPrice)
            {
                this.Consumer = consumer;
                this.Price = productPrice;
                this.Name = name;
            }

            public int CompareTo(Order otherProduct)
            {
                int result = this.Name.CompareTo(otherProduct.Name);
                return result;
            }

            public override string ToString()
            {
                string result = string.Format("{0};{1};{2:0.00}", this.Name, this.Consumer, this.Price);
                return "{" + result + "}";
            }
        }
    }
}
