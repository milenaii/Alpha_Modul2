using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory factory;

        public CreateTicketCommand(IDatabase database, ITravellerFactory factory)
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
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this.database.Journey[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.Factory.CreateTicket(journey, administrativeCosts);
            this.Database.Ticket.Add(ticket);

            return $"Ticket with ID {this.Database.Ticket.Count - 1} was created.";
        }
    }
}
