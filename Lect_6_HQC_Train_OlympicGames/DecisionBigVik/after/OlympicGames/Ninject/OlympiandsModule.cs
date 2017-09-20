using Ninject.Modules;
using OlympicGames.Core;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
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

            this.Bind<ICommand>().To<ListOlympiansCommand>().Named("listolympians");
            this.Bind<ICommand>().To<CreateBoxerCommand>().Named("createboxer");
            this.Bind<ICommand>().To<CreateSprinterCommand>().Named("createsprinter");

            this.Bind<ICommandFactory>()
                .To<CommandFactory>();
            //.WithConstructorArgument(this.Kernel);

            this.Bind<IOlympicCommittee>().To<OlympicCommittee>().InSingletonScope();
            this.Bind<IOlympicsFactory>().To<OlympicsFactory>().InSingletonScope();
        }
    }
}