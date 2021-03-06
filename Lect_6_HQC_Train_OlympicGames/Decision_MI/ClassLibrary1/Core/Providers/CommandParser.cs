﻿using System;
using System.Linq;
using System.Reflection;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using Bytes2you.Validation;

namespace OlympicGames.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        //private static CommandParser instance = new CommandParser();
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "commandFactory").IsNull().Throw();
            this.commandFactory = commandFactory;
        }

        //public static CommandParser Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        public ICommand ParseCommand(string commandLine)    
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];
            //CheckForBaseClassImplementation(commandName);
            //CheckForBaseClassTwoDerivedClasses(commandName);
            //var parameters = lineParameters.Skip(1);

            //var typeInfo = FindCommand(commandName);
            //var command = Activator.CreateInstance(typeInfo, parameters.ToList()) as ICommand;
            //return command;

            return this.commandFactory.CreateCommand(commandName);
        }

        //private TypeInfo FindCommand(string commandName)
        //{
        //    Assembly commandAssembly = Assembly.GetAssembly(typeof(ICommand));

        //    var commandType = commandAssembly.DefinedTypes
        //        .Where(x => x.ImplementedInterfaces.Any(y => y == typeof(ICommand)))
        //        .Where(x => !x.IsAbstract)
        //        .SingleOrDefault(x => x.Name.ToLower() == (commandName.ToLower() + "command"));

        //    if (commandType == null)
        //    {
        //        throw new ArgumentException("No such command implemented! Consider implementing it before using!");
        //    }

        //    return commandType;
        //}

        #region DoNotTouch
        private void CheckForBaseClassImplementation(string commandName)
        {
            if (commandName == "checkbaseclass")
            {
                var assembly = Assembly.GetAssembly(typeof(IOlympian));
                var baseClass = assembly.DefinedTypes.Where(type => type.IsAbstract)
                    .Where(x => x.IsClass)
                    .FirstOrDefault(x => x.ImplementedInterfaces.Contains(typeof(IOlympian)));

                if (baseClass != null)
                {
                    throw new ArgumentException("BASE CLASS FOUND");
                }
            }
        }

        private void CheckForBaseClassTwoDerivedClasses(string commandName)
        {
            if (commandName == "checkbaseclassderived")
            {
                var assembly = Assembly.GetAssembly(typeof(IOlympian));
                var baseClass = assembly.DefinedTypes.Where(type => type.IsAbstract)
                    .Where(x => x.IsClass)
                    .FirstOrDefault(x => x.ImplementedInterfaces.Contains(typeof(IOlympian)));

                var baseClassesInheritans = assembly.DefinedTypes.Where(type => type.IsSubclassOf(baseClass)).Where(x => !x.IsAbstract);

                throw new ArgumentException(string.Format("BASE CLASS DERIVED COUNT: {0}", baseClassesInheritans.Count()));
            }
        }
        #endregion
    }
}
