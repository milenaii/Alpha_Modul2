using Ninject.Modules;
using OlympicGames.Core;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGamesNewClient.Decorators;
using OlympicGamesNewClient.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Configuration;

namespace OlympicGamesNewClient.Ninject
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<FileWriter>();
            this.Bind<IEngine>().To<Engine>()
                .InSingletonScope();

            this.Bind<IOlympicCommittee>().To<OlympicCommittee>().InSingletonScope();
            this.Bind<IOlympicsFactory>().To<OlympicsFactory>().InSingletonScope();

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

            this.Bind<ICommand>().To<CreateBoxerCommand>().Named("createboxer");
            this.Bind<ICommand>().To<CreateSprinterCommand>().Named("createsprinter");

            this.Bind<ICommandFactory>()
                .To<CommandFactory>();
            //.WithConstructorArgument(this.Kernel);
        }
    }
}
