using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _3.PlayerRanking
{
    public class PlayerRankingg
    {
        static void Main()
        {
            BigList<Player> playerRankList = new BigList<Player>();
            Dictionary<string, OrderedSet<Player>> players = new Dictionary<string, OrderedSet<Player>>();

            //По този начин -> безкраен цикъл
            //string command = Console.ReadLine();
            //while (command != "end")

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandsParams = command.Split();
                //string newCommand = commandsParams[0];

                switch (commandsParams[0])
                {
                    case "add":

                        string name = commandsParams[1];
                        string type = commandsParams[2];
                        int age = int.Parse(commandsParams[3]);
                        int pos = int.Parse(commandsParams[4]) - 1;

                        Player player = new Player();
                        player.Name = name;
                        player.Age = age;
                        player.Type = type;

                        //if there is no type(key) - create new key(type)
                        if (!players.ContainsKey(type))
                        {
                            players.Add(type, new OrderedSet<Player>());
                        }

                        playerRankList.Insert(pos, player); // insert in BigList
                        players[type].Add(player);  //Add to dict

                        Console.WriteLine("Added player {0} to position {1}", player.Name, pos + 1);
                        break;

                    case "find":
                        string findType = commandsParams[1];
                        if (players.ContainsKey(findType))
                        {

                            var pl = players[findType];

                            string result = string.Format("Type {0}: " + "{1}", findType, string.Join("; ", pl.Take(5)));

                            result.TrimEnd(';', ' ');

                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Type {0}: ", findType));
                            
                        }
                        break;

                    case "ranklist":
                        int start = int.Parse(commandsParams[1]) - 1;
                        int end = int.Parse(commandsParams[2]) - 1;
                        int count = end - start + 1;
                        var rankedPlayers = playerRankList.Range(start, count);

                        int playerPosition = start + 1;
                        string rankingResult = string.Join(";",
                            rankedPlayers.Select(p => string.Format("{0}. {1}", playerPosition++, p.ToString())));

                        rankingResult.TrimEnd(';', ' ');

                        Console.WriteLine(rankingResult);
                        break;
                        //case "ranklist ":
                        //    int startRange = int.Parse(commandsParams[1]) - 1;
                        //    int endRange = int.Parse(commandsParams[2]) - 1;

                        //    int count = endRange - startRange + 1;
                        //    var rankedPlayers = playerRankList.Range(startRange,count);

                        //    int playerPos = startRange + 1;
                        //    string rankingResult = string.Join(";", rankedPlayers.Select(p=>string.Format("{0}. {1}", playerPos++, p.ToString())));

                        //    rankingResult.TrimEnd(';', ' ');

                        //    Console.WriteLine(rankingResult);
                        //    break;
                }
            }
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
