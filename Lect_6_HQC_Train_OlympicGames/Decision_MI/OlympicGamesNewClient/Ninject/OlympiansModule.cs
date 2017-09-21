using Ninject.Modules;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGamesNewClient.Provider;
using OlympicGames.Core;

namespace OlympicGamesNewClient.Ninject

{
    public class OlympiansModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<FileWriter>(); //this is the change for new client
            //this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IOlympicCommittee>().To<OlympicCommittee>().InSingletonScope();
            this.Bind<IOlympicsFactory>().To<OlympicsFactory>().InSingletonScope();

            //for decorator start
            bool isTestEnvironment = bool.Parse(ConfigurationManager.AppSettings["IsTestEnvironment"]);
            if (isTestEnvironment)
            {
                this.Bind<ICommand>().To<ListOlympiansCommand>().Named("InternalListCommand");
                this.Bind<ICommand>()
                    .To<LoggerCommandDecorator>()
                    .Named("listolympians")
                    .WithConstructorArgument(this.Kernel.Get<ICommand>("InternalListCommand"));
            }
            else
            {
                this.Bind<ICommand>().To<ListOlympiansCommand>().Named("listolympians");
            }
            // for Decorator end

            this.Bind<ICommand>().To<CreateBoxerCommand>().Named("createboxer");
            this.Bind<ICommand>().To<CreateSprinterCommand>().Named("createsprinter");
            this.Bind<ICommand>().To<ListOlympiansCommand>().Named("listolympians");

            this.Bind<ICommandFactory>().To<CommandFactory>();


        }
    }
}
