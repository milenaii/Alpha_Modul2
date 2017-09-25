using System;
using System.Collections.Generic;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : Command
    {
        public ListVehiclesCommand(ITravellerFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var vehicles = this.Engine.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}