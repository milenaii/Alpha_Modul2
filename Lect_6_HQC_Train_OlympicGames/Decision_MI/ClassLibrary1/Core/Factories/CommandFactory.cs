﻿using Ninject;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName); //named Binds, see  OlimpiansModule
        }
    }
}
