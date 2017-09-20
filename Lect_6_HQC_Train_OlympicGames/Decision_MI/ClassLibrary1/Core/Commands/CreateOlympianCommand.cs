using Bytes2you.Validation;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.Core.Commands
{
    public abstract class CreateOlympianCommand : ICommand
    {
        private readonly IOlympicCommittee committee;
        private readonly IOlympicsFactory factory;

        protected CreateOlympianCommand(IOlympicCommittee committee, IOlympicsFactory factory)
        {
            Guard.WhenArgument(committee, "committee").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.committee = committee;
            this.factory = factory;

            //commandParameters.ValidateIfNull();

            //this.CommandParameters = commandParameters;

            //if (commandParameters.Count < 3)
            //{
            //    throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            //}

            //this.FirstName = this.CommandParameters[0];
            //this.LastName = this.CommandParameters[1];
            //this.Country = this.CommandParameters[2];

            //this.CommandParameters = this.CommandParameters.Skip(3).ToList();
        }
        protected IOlympicCommittee Committee
        {
            get
            {
                return this.committee;
            }
        }
        protected IOlympicsFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        //public override string Execute()
        //{
        //    var olympian = this.CreatePerson();

        //    this.Committee.Olympians.Add(olympian);

        //    return string.Format("Created {0}\n{1}", olympian.GetType().Name, olympian);
        //}

        public virtual string Execute(IList<string> commandLine)
        {
            var olympian = this.CreatePerson(commandLine);

            this.Committee.Olympians.Add(olympian);

            return string.Format("Created {0}\n{1}", olympian.GetType().Name, olympian);
        }

        protected abstract IOlympian CreatePerson(IList<string> commandLine);
    }
}
