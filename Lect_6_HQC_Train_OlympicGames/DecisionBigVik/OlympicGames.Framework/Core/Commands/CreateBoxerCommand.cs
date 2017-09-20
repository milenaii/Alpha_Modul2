using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : CreateOlympianCommand, ICommand
    {
        public CreateBoxerCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected override IOlympian CreatePerson(IList<string> commandLine)
        {
            if (commandLine.Count < 6)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            string firstName = commandLine[0];
            string lastName = commandLine[1];
            string country = commandLine[2];
            string category = commandLine[3];

            int wins;
            int losses;
            bool checkWins = int.TryParse(commandLine[4], out wins);
            bool checkLosses = int.TryParse(commandLine[5], out losses);

            if (!checkWins || !checkLosses)
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }

            return this.Factory.CreateBoxer(firstName, lastName, country, category, wins, losses);
        }
    }
}
