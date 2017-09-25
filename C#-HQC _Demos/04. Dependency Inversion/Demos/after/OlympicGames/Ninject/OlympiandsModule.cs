using Ninject.Modules;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.Ninject
{
    public class OlympiandsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IEngine>().To<Engine>()
                .InSingletonScope();
        }
    }
}