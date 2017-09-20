using System;
using System.Collections.Generic;
using System.Linq;

using OlympicGames.Core.Contracts;
using Bytes2you.Validation;

namespace OlympicGames.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IWriter writer;

        public CommandProcessor(IWriter writer)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.writer = writer;
            this.Commands = new List<ICommand>();
        }
        
        public ICollection<ICommand> Commands { get; private set; }

        public void Add(ICommand command)
        {
            this.Commands.Add(command);
        }

        public void ProcessSingleCommand(ICommand command, string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();

            var result = command.Execute(lineParameters);
            var normalizedOutput = this.NormalizeOutput(result);
            this.writer.Write(normalizedOutput);
        }

            
        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}