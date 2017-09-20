using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}