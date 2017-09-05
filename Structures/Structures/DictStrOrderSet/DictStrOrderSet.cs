using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace DictStrOrderSet
{
    class DictStrOrderSet
    {
        static void Main()
        {
            Dictionary<string, OrderedSet<Player>> players = new Dictionary<string, OrderedSet<Player>>();

            string name = "Pi";
            string type = "t";
            int age = 23;
           

            Player player = new Player();
            player.Name = name;
            player.Age = age;
            player.Type = type;

            //if there is no type(key) - create new key(type)
            if (!players.ContainsKey(type))
            {
                players.Add(type, new OrderedSet<Player>());
            }

            players[type].Add(player);  //Add to dict

            Console.WriteLine(player.Name);

            //find by key
            string findType = "Bum";
            if (players.ContainsKey(findType))
            {
                var pl = players[findType];
            }


        }


    public class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }

        public int CompareTo(Player other)
        {
            int res = this.Name.CompareTo(other.Name);
            if (res == 0)
            {
                res = other.Age.CompareTo(other.Age);
            }
            return res;
        }
        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);

        }
    }
}
