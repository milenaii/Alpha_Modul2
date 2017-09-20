using Bytes2you.Validation;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : ICommand
    {
        private readonly IOlympicCommittee committee;

        public ListOlympiansCommand(IOlympicCommittee committee)
        {
            Guard.WhenArgument(committee, "committee").IsNull().Throw();

            this.committee = committee;
        }

        public string Execute(IList<string> commandLine)
        {
            string key;
            string order;

            if (commandLine == null || commandLine.Count == 0)
            {
                key = "firstname";
                order = "asc";
            }
            else if (commandLine.Count == 1)
            {
                key = commandLine[0];
                order = "asc";
            }
            else
            {
                if (commandLine[1].ToLower() != "asc" && commandLine[1].ToLower() != "desc")
                {
                    order = "asc";
                }
                else
                {
                    order = commandLine[1];
                }
                key = commandLine[0];
            }

            var stringBuilder = new StringBuilder();
            var sorted = this.committee.Olympians.ToList();

            if (sorted.Count == 0)
            {
                stringBuilder.AppendLine(GlobalConstants.NoOlympiansAdded);
                return stringBuilder.ToString();
            }

            stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, key, order));

            if (order.ToLower().Trim() == "desc")
            {
                sorted = this.committee.Olympians.OrderByDescending(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == key.ToLower()).GetValue(x, null);
                }).ToList();
            }
            else
            {
                sorted = this.committee.Olympians.OrderBy(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == key.ToLower()).GetValue(x, null);
                }).ToList();
            }

            foreach (var item in sorted)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
