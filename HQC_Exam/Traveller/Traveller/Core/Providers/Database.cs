using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core.Providers
{
    public class Database : IDatabase
    {
        private readonly List<IVehicle> vehicle;
        private readonly List<IJourney> journey;
        private readonly List<ITicket> ticket;

        public Database()
        {
            this.vehicle = new List<IVehicle>();
            this.journey = new List<IJourney>();
            this.ticket = new List<ITicket>();

        }
        public IList<IVehicle> Vehicle { get; }

        public IList<IJourney> Journey { get; }

        public IList<ITicket> Ticket { get; }
    }
}
