using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ConsoleApp1
{
    public class OrderSystem
    {
        public static void Main()
        {

            // consumer/ price  
            Dictionary<string, List<double>> consumerPrice = new Dictionary<string, List<double>>();

            //price   
            Dictionary<double, OrderedSet<Order>> dic = new Dictionary<double, OrderedSet<Order>>();

            List<Order> list = new List<Order>();  //filter by price 

            OrderedSet<Order> orderSet = new OrderedSet<Order>();

            int n = int.Parse(Console.ReadLine());

            string line;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                string[] parameters = line.Split(new char[] { ' ', ';' }).ToArray();
                string command = parameters[0];

                switch (command)
                {
                    case "AddOrder":
                        if (parameters.Length == 4)
                        {
                            string name = parameters[1];
                            //string name2 = parameters[2];
                            //string name = name1 + name2;
                            double price = double.Parse(parameters[2]);
                            string consumer = parameters[3];

                            Order order = new Order();
                            order.Name = name;
                            order.Price = price;
                            order.Consumer = consumer;


                            if (!consumerPrice.ContainsKey(consumer))
                            {
                                if (!dic.ContainsKey(price))
                                {
                                    dic.Add(price, new OrderedSet<Order>());
                                    consumerPrice.Add(consumer, new List<double>());

                                }

                                dic[price].Add(order);
                                consumerPrice[consumer].Add(price);
                                orderSet.Add(order);
                                Console.WriteLine("Order added");
                            }
                        }
                        if (parameters.Length == 5)
                        {
                            string name1 = parameters[1];
                            string name2 = parameters[2];
                            string name = name1 + name2;
                            double price = double.Parse(parameters[3]);
                            string consumer = parameters[4];

                            Order order = new Order();
                            order.Name = name;
                            order.Price = price;
                            order.Consumer = consumer;


                            if (!consumerPrice.ContainsKey(consumer))
                            {
                                if (!dic.ContainsKey(price))
                                {
                                    dic.Add(price, new OrderedSet<Order>());
                                    consumerPrice.Add(consumer, new List<double>());
                                }

                                dic[price].Add(order);
                                consumerPrice[consumer].Add(price);
                                orderSet.Add(order);
                            }

                            Console.WriteLine("Order added");
                        }
                        if (parameters.Length == 6)
                        {
                            string name1 = parameters[1];
                            string name2 = parameters[2];
                            string name3 = parameters[3];

                            string name = name1 + name2 + name3;
                            double price = double.Parse(parameters[4]);
                            string consumer = parameters[5];

                            Order order = new Order();
                            order.Name = name;
                            order.Price = price;
                            order.Consumer = consumer;


                            if (!consumerPrice.ContainsKey(consumer))
                            {
                                if (!dic.ContainsKey(price))
                                {
                                    dic.Add(price, new OrderedSet<Order>());
                                    consumerPrice.Add(consumer, new List<double>());
                                }

                                dic[price].Add(order);
                                consumerPrice[consumer].Add(price);
                                orderSet.Add(order);
                            }
                            Console.WriteLine("Order added");
                        }

                        break;

                    case "DeleteOrders":

                        string consumerDel = parameters[1];
                        double consRemove;
                        int countPrint = 0;
                        for (int k = 0; k < dic.Keys.Count; k++)
                        {
                            if (consumerPrice.ContainsKey(consumerDel))
                            {
                                List<double> countDel = consumerPrice[consumerDel];
                                countPrint = countDel.Count;
                                for (int m = 0; m < countDel.Count; m++)
                                {
                                    consRemove = countDel[m];
                                    consumerPrice.Remove(consumerDel);

                                    var item = dic[consRemove].SingleOrDefault(x => x.Consumer == consumerDel);
                                    if (item != null)
                                    {
                                        dic[consRemove].Remove(item);
                                    }

                                    //orderSet.Remove();
                                }
                            }
                        }

                        if (countPrint == 0)
                        {
                            Console.WriteLine("No orders found");
                        }
                        else
                        {
                            Console.WriteLine("{0} orders deleted", countPrint);
                        }
                        break;

                    case "FindOrdersByPriceRange":
                        //FindOrdersByPriceRange fromPrice;toPrice 
                        string[] fromTo = parameters[1].Split(';').ToArray();
                        int fromPrice = int.Parse(parameters[1]);
                        int toPrice = int.Parse(parameters[2]);

                        var filtered = list.Where(x => x.Price >= fromPrice && x.Price <= toPrice).OrderBy(x => x.Price).Take(60000);

                        string filterFromTo = string.Format("{0}", string.Join("\n ", filtered));
                        filterFromTo.TrimEnd(' ');

                        if (filterFromTo.Length == 0)
                        {
                            Console.WriteLine("No orders found");
                        }
                        Console.WriteLine(filterFromTo);
                        break;

                    case "FindOrdersByConsumer":
                        string consDel = parameters[1];
                        if (consumerPrice.ContainsKey(consDel))
                        {
                            Console.WriteLine(consumerPrice[consDel]);
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
            public double Price { get; set; }
            public string Consumer { get; set; }

            public int CompareTo(Order other)
            {
                int res = this.Name.CompareTo(other.Name) * -1;
                if (res == 0)
                {
                    res = this.Consumer.CompareTo(other.Consumer);
                    if (res == 0)
                    {
                        res = this.Price.CompareTo(other.Price);

                    }
                }
                return res;
            }
            public override string ToString()
            {
                string product = string.Format("{" + "{0};{1};{2}" + "}", this.Name, this.Consumer, this.Price);

                product = "{" + product + "}";

                return product; //{name;consumer;price}
            }

        }
    }
}
