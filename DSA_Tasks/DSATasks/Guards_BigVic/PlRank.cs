using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace ConsoleApp7.Ranking
{
    public class RanklistTest
    {
        public static void Run()
        {
            BigList<Player> playersRanklist = new BigList<Player>();

            Dictionary<string, OrderedSet<Player>> typeToPlayerMap =
                new Dictionary<string, OrderedSet<Player>>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParams = command.Split();
                switch (commandParams[0])   
                {
                    case "add":
                        string name = commandParams[1];
                        string type = commandParams[2];
                        int age = int.Parse(commandParams[3]);
                        int position = int.Parse(commandParams[4]) - 1;

                        Player player = new Player();
                        player.Name = name;
                        player.Type = type;
                        player.Age = age;

                        if (!typeToPlayerMap.ContainsKey(type))
                        {
                            typeToPlayerMap.Add(type, new OrderedSet<Player>());
                        }

                        playersRanklist.Insert(position, player);
                        typeToPlayerMap[type].Add(player);

                        Console.WriteLine(string.Format("Added player {0} to position {1}", player.Name, position + 1));
                        break;

                    case "find":
                        string findType = commandParams[1];
                        if (typeToPlayerMap.ContainsKey(findType))
                        {
                            var players = typeToPlayerMap[findType];

                            string result = string.Format("Type {0}: " +
                                "{1}", findType, string.Join("; ", players.Take(5)));
                            result.TrimEnd(';', ' ');

                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Type {0}: ", findType));
                        }
                        break;

                    case "ranklist":
                        int start = int.Parse(commandParams[1]) - 1;
                        int end = int.Parse(commandParams[2]) - 1;
                        int count = end - start + 1;
                        var rankedPlayers = playersRanklist.Range(start, count);

                        int playerPosition = start + 1;
                        string rankingResult = string.Join(";",
                            rankedPlayers.Select(p=>string.Format("{0}. {1}", playerPosition++, p.ToString())));

                        rankingResult.TrimEnd(';', ' ');

                        Console.WriteLine(rankingResult);
                        break;
                }
            }
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public int CompareTo(Player other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age) * -1;
                // This also works
                // result = other.Age.CompareTo(this.Age)
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }
}