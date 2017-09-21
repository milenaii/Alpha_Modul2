﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "commandFactory").IsNull().Throw();
            this.commandFactory = commandFactory;
        }
       

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];
            //var commandTypeInfo = this.FindCommand(commandName);

            var lineParameters = fullCommand.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            return this.commandFactory.CreateCommand(commandName);


            //var command = Activator.CreateInstance(commandTypeInfo) as ICommand;

            //return command;
        }

        //public IList<string> ParseParameters(string fullCommand)
        //{
        //    var commandParts = fullCommand.Split().Skip(1).ToList();
        //    if (commandParts.Count == 0)
        //    {
        //        return new List<string>();
        //    }

        //    return commandParts;
        //}

        //private TypeInfo FindCommand(string commandName)
        //{
        //    Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
        //    var commandTypeInfo = currentAssembly.DefinedTypes
        //        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
        //        .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
        //        .SingleOrDefault();

        //    if (commandTypeInfo == null)
        //    {
        //        throw new ArgumentException("The passed command is not found!");
        //    }

        //    return commandTypeInfo;
        //}
    }
}
