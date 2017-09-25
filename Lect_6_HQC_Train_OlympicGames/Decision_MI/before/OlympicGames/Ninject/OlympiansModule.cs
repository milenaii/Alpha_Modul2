using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Factories;

namespace OlympicGames.Core.Ninject
{
    public class OlympiansModule : NinjectModule
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
