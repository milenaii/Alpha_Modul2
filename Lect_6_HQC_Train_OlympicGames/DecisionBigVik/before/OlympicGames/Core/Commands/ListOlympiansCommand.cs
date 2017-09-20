using System.Collections.Generic;
using System.Linq;
using System.Text;

using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command, ICommand
    {
        private string key;
        private string order;

        public ListOlympiansCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
            if (this.CommandParameters == null || this.CommandParameters.Count == 0)
            {
                this.key = "firstname";
                this.order = "asc";
            }
            else if (this.CommandParameters.Count == 1)
            {
                this.key = this.CommandParameters[0];
                this.order = "asc";
            }
            else
            {
                if (commandParameters[1].ToLower() != "asc" && commandParameters[1].ToLower() != "desc")
                {
                    this.order = "asc";
                }
                else
                {
                    this.order = this.CommandParameters[1];
                }
                this.key = this.CommandParameters[0];
            }
        }

        public override string Execute()
        {
            var stringBuilder = new StringBuilder();
            var sorted = this.Committee.Olympians.ToList();

            if (sorted.Count == 0)
            {
                stringBuilder.AppendLine(GlobalConstants.NoOlympiansAdded);
                return stringBuilder.ToString();
            }

            stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, this.key, this.order));

            if (this.order.ToLower().Trim() == "desc")
            {
                sorted = this.Committee.Olympians.OrderByDescending(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }
            else
            {
                sorted = this.Committee.Olympians.OrderBy(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
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
