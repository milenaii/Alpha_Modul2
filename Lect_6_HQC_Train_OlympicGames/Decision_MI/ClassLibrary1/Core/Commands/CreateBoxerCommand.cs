using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : CreateOlympianCommand, ICommand
    {
        //private readonly string category;
        //private readonly int wins;
        //private readonly int losses;

        public CreateBoxerCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
            //if(this.CommandParameters.Count != 3)
            //{
            //    throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            //}

            //this.category = this.CommandParameters[0];

            //bool checkWins = int.TryParse(this.CommandParameters[1], out this.wins);
            //bool checkLosses = int.TryParse(this.CommandParameters[2], out this.losses);

            //if (!checkWins || !checkLosses)
            //{
            //    throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            //}
        }

        //public string Execute(IList<string> commandLine)
        //{
        //    throw new NotImplementedException();
        //}

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
