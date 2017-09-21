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
    public class CreateAirplaneCommand : CreateVehicleCommand, ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory travellerFactory;

        public CreateAirplaneCommand(IDatabase database, ITravellerFactory travellerFactory)
            :base(database, travellerFactory)
        {
           
        }

        //public string Execute(IList<string> parameters)
        //{
            //int passengerCapacity;
            //decimal pricePerKilometer;
            //bool hasFreeFood;

            //try
            //{
            //    passengerCapacity = int.Parse(parameters[0]);
            //    pricePerKilometer = decimal.Parse(parameters[1]);
            //    hasFreeFood = bool.Parse(parameters[2]);
            //}
            //catch
            //{
            //    throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            //}

            //var airplane = travellerFactory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            //database.Vehicle.Add(airplane);

            //return $"Vehicle with ID {database.Vehicle.Count - 1} was created.";
       // }

        protected override IVehicle CreateVehicle(IList<string> parameters)
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

            var airplane = travellerFactory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            database.Vehicle.Add(airplane);

            return $"Vehicle with ID {database.Vehicle.Count - 1} was created.";
        }
    }
}
