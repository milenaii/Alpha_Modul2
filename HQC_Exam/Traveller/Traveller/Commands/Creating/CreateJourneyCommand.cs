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
    public class CreateJourneyCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory factory;

        public CreateJourneyCommand(IDatabase database, ITravellerFactory factory)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }

        public IDatabase Database { get; }
        public ITravellerFactory Factory { get; }

        public string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.Database.Vehicle[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = this.Factory.CreateJourney(startLocation, destination, distance, vehicle);
            this.Database.Journey.Add(journey);

            return $"Journey with ID {this.Database.Journey.Count - 1} was created.";
        }
    }
}
