using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _1.OrderedSystem
{
    // 1 -> == -1 в Compare, презаписваха се Ivan 1 и 3
    // 2 -> не бях изтрила ключа - ред 66 - изход - празен ред след втория findConsumer
    public class OrderedSystem
    {
        public static void Main()
        {
            //        consumer , Order
            Dictionary<string, OrderedSet<Order>> dic = new Dictionary<string, OrderedSet<Order>>();

            //         price,  consumer
            OrderedSet<Order> findByPrice = new OrderedSet<Order>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int ind = input.IndexOf(' ');
                string command = input.Substring(0, ind);

                string rest = input.Substring(ind + 1, input.Length - 1 - ind);

                string[] characters = rest.Split(';').ToArray();

                switch (command)
                {
                    case "AddOrder":
                        //name; price; consumer
                        string name = characters[0];
                        double price = double.Parse(characters[1]);
                        string consumer = characters[2];

                        Order order = new Order();
                        order.Name = name;
                        order.Consumer = consumer;
                        order.Price = price;

                        if (!dic.ContainsKey(consumer))
                        {
                            dic.Add(consumer, new OrderedSet<Order>());
                        }

                        findByPrice.Add(order);
                        dic[consumer].Add(order);

                        Console.WriteLine("Order added");
                        break;

                    case "DeleteOrders":
                        string consumerDel = characters[0];
                        if (dic.ContainsKey(consumerDel))
                        {
                            int x = dic[consumerDel].Count();

                            // delete values
                            dic[consumerDel].RemoveAll(o => o.Consumer == consumerDel);
                            //delete key
                            dic.Remove(consumerDel);
                            findByPrice.RemoveAll(o => o.Consumer == consumerDel);

                            Console.WriteLine("{0} orders deleted", x);
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }

                        break;

                    case "FindOrdersByPriceRange":
                        double fromPrice = double.Parse(characters[0]);
                        double toPrice = double.Parse(characters[1]);

                        var fPrice = findByPrice.Where(f => f.Price >= fromPrice && f.Price <= toPrice);
                        int has = fPrice.Count();

                        if (has == 0)
                        {
                            Console.WriteLine("No orders found");
                        }
                        else
                        {
                            foreach (var item in fPrice)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case "FindOrdersByConsumer":
                        string consumerFind = characters[0];

                        if (!dic.ContainsKey(consumerFind))
                        {
                            Console.WriteLine("No orders found");
                        }
                        else
                        {
                           Console.WriteLine(string.Join("\n", dic[consumerFind]));
                        }
                        break;
                }
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
            //1 way

            //int result;
            //result = this.Name.CompareTo(other.Name);
            //if (result == 0)
            //{
            //    result = this.Consumer.CompareTo(other.Consumer);
            //    if (result == 0)
            //    {
            //        result = this.Price.CompareTo(other.Price);
            //    }
            //}
            //return result;

            //2 way
           return this.ToString().CompareTo(other.ToString());
        }

        public override string ToString()
        {
            string product = string.Format("{0};{1};{2:00.00}", this.Name, this.Consumer, this.Price);
            product = "{" + product + "}";
            return product;
        }
    }
}

