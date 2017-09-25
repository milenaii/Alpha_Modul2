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
    public class CreateAirplaneCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory factory;

        public CreateAirplaneCommand(IDatabase database, ITravellerFactory factory)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

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
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = this.factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            database.Vehicle.Add(airplane);

            return $"Vehicle with ID {database.Vehicle.Count - 1} was created.";
        }

        //protected override string CreateVehicle(IList<string> parameters)
        //{
        //    int passengerCapacity;
        //    decimal pricePerKilometer;
        //    bool hasFreeFood;

        //    try
        //    {
        //        passengerCapacity = int.Parse(parameters[0]);
        //        pricePerKilometer = decimal.Parse(parameters[1]);
        //        hasFreeFood = bool.Parse(parameters[2]);
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
        //    }

        //    var airplane = this.Factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
        //    this.Database.Vehicle.Add(airplane);

        //    return $"Vehicle with ID {this.Database.Ticket.Count} was created.";
        //}
    }
}
