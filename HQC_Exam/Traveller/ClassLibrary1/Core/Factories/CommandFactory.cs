using Ninject;
using Traveller.Commands.Contracts;


namespace Traveller.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;   //?? throw new ArgumentNullException("kernel");
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName); 
        }
    }
}
