using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitsOfWork
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, OrderedSet<Unit>> dict = new Dictionary<string, OrderedSet<Unit>>();
            OrderedSet<Unit> order = new OrderedSet<Unit>();
            Dictionary<string, string> searchedName = new Dictionary<string, string>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] parameters = command.Split(' ').ToArray();

                switch (parameters[0])
                {
                    case "add":
                        string name = parameters[1];
                        string type = parameters[2];
                        int attack = int.Parse(parameters[3]);

                        Unit unit = new Unit(name, type, attack);

                        if (!dict.ContainsKey(type))
                        {
                            dict.Add(type, new OrderedSet<Unit>());
                        }
                        else
                        {
                            if (dict[type].Contains(unit))
                            {
                                Console.WriteLine("FAIL: {0} already exists!", unit.Name);
                                break;
                            }
                        }

                        order.Add(unit);
                        dict[type].Add(unit);
                        searchedName.Add(name, type);
                        Console.WriteLine("SUCCESS: {0} added!", name);
                        break;


                    case "find":
                        string findType = parameters[1];
                        //finds the top 10 units per type, first ordered by attack in descending order and then by their name in ascending order
                        string result = "";
                        if (dict.ContainsKey(findType))
                        {
                            result = string.Format("RESULT: {0}", string.Join(", ", dict[findType].Take(10)));
                            result.TrimEnd(',', ' ');
                        }
                        else
                        {
                            result = "RESULT: ";
                        }
                        Console.WriteLine(result);
                        break;

                    case "remove":
                        string nameRemove = parameters[1];
                        string typeRemove = "";
                        Unit item = null;

                        if (searchedName.ContainsKey(nameRemove))
                        {
                            typeRemove = searchedName[nameRemove];
                            item = dict[typeRemove].SingleOrDefault(x => x.Name == nameRemove);
                        }

                        if (item != null)
                        {
                            dict[typeRemove].Remove(item);
                            order.Remove(item);
                            searchedName.Remove(nameRemove);
                            Console.WriteLine("SUCCESS: {0} removed!", nameRemove);
                        }
                        else
                        {
                            Console.WriteLine("FAIL: {0} could not be found!", parameters[1]);
                        }


                        break;
                    case "power":
                        //prints the top NUMBER_OF_UNITS most powerful units currently in the game in the same format as the "find" command
                        int position = int.Parse(parameters[1]);
                        string resultPower = string.Format("RESULT: {0}", string.Join(", ", order.Take(position)));
                        resultPower.TrimEnd(',', ' ');
                        Console.WriteLine(resultPower);
                        break;
                }
                command = Console.ReadLine();
            }
        }

        public class Unit : IComparable<Unit>
        {
            public Unit(string name, string type, int attack)
            {
                this.Name = name;
                this.Type = type;
                this.Attack = attack;
            }

            public string Name
            {
                get; set;
            }

            public string Type
            {
                get; set;
            }

            public int Attack
            {
                get; set;
            }

            public int CompareTo(Unit other)
            {
                //first ordered by attack in descending order and then by their name in ascending order
                int result = this.Attack.CompareTo(other.Attack) * -1;
                if (result == 0)
                {
                    result = this.Name.CompareTo(other.Name);
                    //result = other.Age.CompareTo(this.Age)
                }
                return result;
            }

            public override string ToString()
            {

                string line = string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
                return line;
            }
        }
    }
}

