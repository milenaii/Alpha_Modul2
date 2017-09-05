using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ConsoleApp2
{
    class BigList
    {
        static void Main()
        {
            BigList<Player> playerRankList = new BigList<Player>();

           



            string name = "Pi";
            string type = "t";
            int age = 23;
            int pos = 0;

            Player player = new Player();
            player.Name = name;
            player.Age = age;
            player.Type = type;

            //insert
            playerRankList.Insert(pos, player); // insert in BigList

            // add
            playerRankList.Add(player);

            //delete
            playerRankList.Remove(player);
            playerRankList.RemoveAt(3);
            playerRankList.RemoveRange(2,5);




            int start = 0;
            int count = 4;

            int playerPosition = start + 1;

            var rankedPlayers = playerRankList.Range(start, count);
            string rankingResult = string.Join(";",
                           rankedPlayers.Select(p => string.Format("{0}. {1}",
                           playerPosition++, p.ToString())));


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
