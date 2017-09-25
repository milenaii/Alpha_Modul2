using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands
{
    public abstract class Command : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IEngine engine;

        public Command(ITravellerFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        protected ITravellerFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        protected IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }

        public abstract string Execute(IList<string> parameters);
    }
}