using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory factory;

        public CreateBusCommand(IDatabase database, ITravellerFactory factory)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(factory, "travellerFactory").IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }

        //public IDatabase Database
        //{
        //    get
        //    {
        //        return this.database;
        //    }
        //}
        //public ITravellerFactory Factory 
        //{
        //    get
        //    {
        //        return this.factory;
        //    }
        //}

        public string Execute(IList<string> parameters)
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

            var bus = this.factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.database.Vehicle.Add(bus);

            return $"Vehicle with ID {this.database.Vehicle.Count - 1} was created.";
        }

        //protected override string CreateVehicle(IList<string> parameters)
        //{
        //    int passengerCapacity;
        //    decimal pricePerKilometer;

        //    try
        //    {
        //        passengerCapacity = int.Parse(parameters[0]);
        //        pricePerKilometer = decimal.Parse(parameters[1]);
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("Failed to parse CreateBus command parameters.");
        //    }

        //    var bus = this.Factory.CreateBus(passengerCapacity, pricePerKilometer);
        //    this.Database.Vehicle.Add(bus);

        //    return $"Vehicle with ID {this.Database.Vehicle.Count - 1} was created.";
        //}
    }
}
