using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitOfWork
{
    public class UnitOfWork
    {
        public static void Main()
        {
            //name/ type  
            Dictionary<string, string> searchedName = new Dictionary<string, string>();

            //type   
            Dictionary<string, OrderedSet<Unit>> dic = new Dictionary<string, OrderedSet<Unit>>();

            //power commamnds
            OrderedSet<Unit> orderSet = new OrderedSet<Unit>();


            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                string[] commandsParams = line.Split();
                //string newCommand = commandsParams[0];

                switch (commandsParams[0])
                {
                    case "add":

                        string name = commandsParams[1];
                        string type = commandsParams[2];
                        int attack = int.Parse(commandsParams[3]);

                        Unit unit = new Unit();
                        unit.Name = name;
                        unit.Attack = attack;
                        unit.Type = type;

                        if (!searchedName.ContainsKey(name))
                        {
                            if (!dic.ContainsKey(type))
                            {
                                dic.Add(type, new OrderedSet<Unit>());
                            }
                                
                            dic[type].Add(unit);
                            searchedName.Add(name, type);
                            orderSet.Add(unit);
                            Console.WriteLine("SUCCESS: {0} added!", unit.Name);
                        }
                        else
                        {
                            Console.WriteLine("FAIL: {0} already exists!", unit.Name);
                        }
                        break;

                    case "remove":
                        string nameRemove = commandsParams[1];
                        string typeRemove = "";

                        if (searchedName.ContainsKey(nameRemove))
                        {
                            typeRemove = searchedName[nameRemove];
                            searchedName.Remove(nameRemove);
                            Console.WriteLine("SUCCESS: {0} removed!", nameRemove);

                            var item = dic[typeRemove].SingleOrDefault(x => x.Name == nameRemove);
                            if (item != null)
                            {
                                dic[typeRemove].Remove(item);
                            }

                            orderSet.Remove(item);

                        }
                        else
                        {
                            Console.WriteLine("FAIL: {0} could not be found!", nameRemove);
                        }
                        break;

                    case "find":
                        string findType = commandsParams[1];
                        string result;
                        if (searchedName.ContainsKey(findType))
                        {
                            result = string.Format("RESULT: {0}", string.Join(", ",                searchedName[findType].Take(10)));
                            result.TrimEnd(',', ' ');

                        }
                        else
                        {
                            result = "RESULT: ";
                        }
                        break;

                    case "power":
                        int numPowerPrint = int.Parse(commandsParams[1]);

                        string resultPower = string.Format("RESULT: {0}", string.Join(", ", orderSet.Take(numPowerPrint)));
                        //resultPower.TrimEnd(',', ' ')
                        Console.WriteLine(resultPower);
                        break;
                }
                line = Console.ReadLine();
            }
        }
        public class Unit : IComparable<Unit>
        {
            public string Name { get; set; }
            public int Attack { get; set; }
            public string Type { get; set; }    

            public int CompareTo(Unit other)
            {
                int res = this.Attack.CompareTo(other.Attack) * -1;
                if (res == 0)
                {
                    res = this.Name.CompareTo(other.Name);
                }
                return res;
            }
            public override string ToString()
            {
                return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);

            }
        }
    }
}
