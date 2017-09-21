using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core
{
    public class Engine :IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        // private static readonly Engine instanceHolder = new Engine();

        //private readonly List<IVehicle> vehicles;
        //private readonly List<IJourney> journeys;
        //private readonly List<ITicket> tickets;

        private StringBuilder Builder = new StringBuilder();

        public Engine(/*List<IVehicle> vehicle, List<IJourney> journeys, List<ITicket> tickets*/)
        {
            //this.vehicles = vehicle;
            //this.journeys = journeys;
            //this.tickets = tickets;
        }

        //public static Engine Instance
        //{
        //    get
        //    {
        //        return instanceHolder;
        //    }
        //}

        //public IList<IVehicle> Vehicles
        //{
        //    get
        //    {
        //        return this.vehicles;
        //    }
        //}
        
        //public IList<IJourney> Journeys
        //{
        //    get
        //    {
        //        return this.journeys;
        //    }
        //}

        //public IList<ITicket> Tickets
        //{
        //    get
        //    {
        //        return this.tickets;
        //    }
        //}

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = Console.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        Console.Write(this.Builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var parser = new CommandParser();
            var command = parser.ParseCommand(commandAsString);
            var parameters = parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Builder.AppendLine(executionResult);
        }
    }
}
