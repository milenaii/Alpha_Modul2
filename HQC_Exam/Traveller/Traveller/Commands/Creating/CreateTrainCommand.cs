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
    public class CreateTrainCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory factory;

        public CreateTrainCommand(IDatabase database, ITravellerFactory factory)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }
        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }
        public ITravellerFactory Factory
        {
            get
            {
                return this.factory;
            }
        }


        public string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = this.Factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.Database.Vehicle.Add(train);

            return $"Vehicle with ID {database.Vehicle.Count - 1} was created.";
        }

        //protected override string CreateVehicle(IList<string> parameters)
        //{
        //    int passengerCapacity;
        //    decimal pricePerKilometer;
        //    int cartsCount;

        //    try
        //    {
        //        passengerCapacity = int.Parse(parameters[0]);
        //        pricePerKilometer = decimal.Parse(parameters[1]);
        //        cartsCount = int.Parse(parameters[2]);
        //    }
        //    catch
        //    {
        //        throw new ArgumentException("Failed to parse CreateTrain command parameters.");
        //    }

        //    var train = this.Factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
        //    this.Database.Vehicle.Add(train);

        //    return $"Vehicle with ID {this.Database.Vehicle.Count - 1} was created.";
        //}
    }
}
