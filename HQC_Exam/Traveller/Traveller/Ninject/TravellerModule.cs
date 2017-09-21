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
using System.Windows.Input;
using Traveller.Commands.Creating;

namespace Traveller.Ninject
{
    public class TravellerModule : NinjectModule
    {
        public override void Load()
        {

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named("createairplaincommand");
            this.Bind<ICommand>().To<CreateBusCommand>().Named("createbus");
            this.Bind<ICommand>().To<CreateTrainCommand>().Named("createtrain");

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<ITravellerFactory>().To<TravellerFactory>().InSingletonScope();
        }
    }
}
