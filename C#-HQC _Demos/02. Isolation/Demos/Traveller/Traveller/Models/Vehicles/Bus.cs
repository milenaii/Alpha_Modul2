using System;
using Traveller.Models.Vehicles.Enums;
using Traveller.Models.Vehicles.Abstractions;
using Traveller.Models.Vehicles.Contracts;
using System.Text;

namespace Traveller.Models.Vehicles
{
    public class Bus : Vehicle, IBus
    {        
        public Bus(int passengerCapacity, decimal pricePerKilometer) 
            : base(passengerCapacity, pricePerKilometer)
        {
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Land;
            }
        }

        protected override void ValidatePassangerCapacity(int value)
        {
            if (value < 10 || value > 50)
            {
                throw new ArgumentOutOfRangeException("A bus cannot have less than 10 passengers or more than 50 passengers.");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Bus ----");
            sb.Append(base.ToString());

            return sb.ToString();
        }
    }
}
