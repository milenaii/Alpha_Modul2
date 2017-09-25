using System;
using System.Collections.Generic;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : CreateVehicleCommand
    {
        public CreateBusCommand(ITravellerFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.Factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.Engine.Vehicles.Add(bus);

            return base.Execute(parameters);
        }

    }
}
