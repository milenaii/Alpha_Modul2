using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : CreateOlympianCommand, ICommand
    {
        public CreateSprinterCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected override IOlympian CreatePerson(IList<string> commandLine)
        {
            if (commandLine.Count < 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            string firstName = commandLine[0];
            string lastName = commandLine[1];
            string country = commandLine[2];

            Dictionary<string, double> records = new Dictionary<string, double>();
            commandLine = commandLine.Skip(3).ToList();

            foreach (var recordItem in commandLine)
            {
                var recordValue = recordItem.Split('/');
                records.Add(recordValue[0], double.Parse(recordValue[1]));
            }

            return this.Factory.CreateSprinter(firstName, lastName, country, records);
        }
    }
}
