using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        public Command(IList<string> commandLine)
        {
            this.Committee = OlympicCommittee.Instance;
            this.Factory = OlympicsFactory.Instance;
            this.CommandParameters = commandLine;
        }

        public IList<string> CommandParameters { get; protected set; }

        public OlympicCommittee Committee { get; }

        public IOlympicsFactory Factory { get; }

        public abstract string Execute();
    }
}
