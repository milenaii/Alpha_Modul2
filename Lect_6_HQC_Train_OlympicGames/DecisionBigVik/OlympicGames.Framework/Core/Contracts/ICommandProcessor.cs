using System.Collections.Generic;

namespace OlympicGames.Core.Contracts
{
    public interface ICommandProcessor 
    {
        ICollection<ICommand> Commands { get; }

        void Add(ICommand command);

        void ProcessSingleCommand(ICommand command, string commandLine);
    }
}
