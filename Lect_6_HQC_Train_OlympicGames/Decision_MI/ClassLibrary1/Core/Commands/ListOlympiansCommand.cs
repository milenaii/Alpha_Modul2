using Bytes2you.Validation;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand :/* Command,*/ ICommand
    {
        //private string key;
        //private string order;

        private readonly IOlympicCommittee committee;

        public ListOlympiansCommand(/*IList<string> commandLine*/ IOlympicCommittee committee)
        {                           /*ICommand param in Execute*/
            Guard.WhenArgument(committee, "committee").IsNull().Throw();

            this.committee = committee;
        }

        // it is going in execute

        //    : base(commandParameters)
        //{
        //    if (this.CommandParameters == null || this.CommandParameters.Count == 0)
        //    {
        //        this.key = "firstname";
        //        this.order = "asc";
        //    }
        //    else if (this.CommandParameters.Count == 1)
        //    {
        //        this.key = this.CommandParameters[0];
        //        this.order = "asc";
        //    }
        //    else
        //    {
        //        if (commandParameters[1].ToLower() != "asc" && commandParameters[1].ToLower() != "desc")
        //        {
        //            this.order = "asc";
        //        }
        //        else
        //        {
        //            this.order = this.CommandParameters[1];
        //        }
        //        this.key = this.CommandParameters[0];
        //    }
        //}

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
