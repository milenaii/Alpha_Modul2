using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : CreateOlympianCommand, ICommand
    {
        private readonly string category;
        private readonly int wins;
        private readonly int losses;

        public CreateBoxerCommand(IList<string> commandLine)
            : base(commandLine)
        {
            if(this.CommandParameters.Count != 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            this.category = this.CommandParameters[0];

            bool checkWins = int.TryParse(this.CommandParameters[1], out this.wins);
            bool checkLosses = int.TryParse(this.CommandParameters[2], out this.losses);

            if (!checkWins || !checkLosses)
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }
        }

        protected override IOlympian CreatePerson()
        {
           return this.Factory.CreateBoxer(this.FirstName, this.LastName, this.Country, this.category, this.wins, this.losses);
        }
    }
}
