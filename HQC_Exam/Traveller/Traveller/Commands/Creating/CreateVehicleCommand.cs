using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public abstract  class CreateVehicleCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory travelerFactory;

        protected CreateVehicleCommand(IDatabase database, ITravellerFactory travelerFactory)
        {
            Guard.WhenArgument(database, "committee").IsNull().Throw();
            Guard.WhenArgument(travelerFactory, "travelerFactory").IsNull().Throw();

            this.database = database;
            this.travelerFactory = travelerFactory;
        }
        protected IDatabase Database { get; }

        protected ITravellerFactory Factory { get; }

        public virtual string Execute(IList<string> parameters)   
        {
            var vehicle = this.CreateVehicle(parameters);

            this.database.Vehicle.Add(vehicle);

            return string.Format("Created {0}\n{1}", vehicle.GetType().Name, vehicle);
        }

        protected abstract IVehicle CreateVehicle(IList<string> parameters);

    }
}
