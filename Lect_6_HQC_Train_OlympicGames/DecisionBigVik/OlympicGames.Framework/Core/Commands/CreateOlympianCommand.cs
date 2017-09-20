using Bytes2you.Validation;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using System.Collections.Generic;

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

        public virtual string Execute(IList<string> commandLine)
        {
            var olympian = this.CreatePerson(commandLine);

            this.Committee.Olympians.Add(olympian);

            return string.Format("Created {0}\n{1}", olympian.GetType().Name, olympian);
        }

        protected abstract IOlympian CreatePerson(IList<string> commandLine);
    }
}
