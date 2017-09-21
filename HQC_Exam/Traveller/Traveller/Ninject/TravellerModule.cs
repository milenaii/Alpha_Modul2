using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Core.Factories;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;

namespace Traveller.Ninject
{
    public class TravellerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<Reader>();
            this.Bind<IWriter>().To<Writer>();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named("createairplain");
            this.Bind<ICommand>().To<CreateBusCommand>().Named("createbus");
            this.Bind<ICommand>().To<CreateJourneyCommand>().Named("createjourney");
            this.Bind<ICommand>().To<CreateTicketCommand>().Named("createticket");
            this.Bind<ICommand>().To<CreateTrainCommand>().Named("createtrain");

            this.Bind<ICommand>().To<ListJourneysCommand>().Named("listjourneys");
            this.Bind<ICommand>().To<ListTicketsCommand>().Named("listtickets");
            this.Bind<ICommand>().To<ListVehiclesCommand>().Named("listvehicles");

            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<ITravellerFactory>().To<TravellerFactory>().InSingletonScope();

        }
    }
}
