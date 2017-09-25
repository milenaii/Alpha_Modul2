using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.UnitTests.Commands.Creating.CreateAirplaneCommandTests.Mocks
{
    public class TestEngine : IEngine
    {
        private IList<IVehicle> vehicles;
        private int vehiclesCalledCounter = 0;

        public IReader Reader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWriter Writer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IParser Parser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<IVehicle> Vehicles
        {
            get
            {
                this.vehiclesCalledCounter++;
                if (this.vehicles == null)
                {
                    this.vehicles = new List<IVehicle>();
                }

                return this.vehicles;
            }
        }

        public int VehiclesCalledCounter
        {
            get
            {
                return this.vehiclesCalledCounter;
            }
        }

        public IList<IJourney> Journeys => throw new NotImplementedException();

        public IList<ITicket> Tickets => throw new NotImplementedException();

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}