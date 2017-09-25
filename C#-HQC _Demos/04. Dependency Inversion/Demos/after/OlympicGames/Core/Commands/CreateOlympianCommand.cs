using System;
using System.Collections.Generic;
using System.Linq;

using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public abstract class CreateOlympianCommand : Command
    {
        protected CreateOlympianCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
            commandParameters.ValidateIfNull();

            this.CommandParameters = commandParameters;

            if (commandParameters.Count < 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            this.FirstName = this.CommandParameters[0];
            this.LastName = this.CommandParameters[1];
            this.Country = this.CommandParameters[2];

            this.CommandParameters = this.CommandParameters.Skip(3).ToList();
        }

        protected string FirstName { get; }

        protected string LastName { get; }

        protected string Country { get; }

        public override string Execute()
        {
            var olympian = this.CreatePerson();

            this.Committee.Olympians.Add(olympian);

            return string.Format("Created {0}\n{1}", olympian.GetType().Name, olympian);
        }

        protected abstract IOlympian CreatePerson();
    }
}
