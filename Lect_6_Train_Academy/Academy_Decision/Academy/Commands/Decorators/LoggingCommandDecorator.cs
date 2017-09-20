using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Commands.Decorators
{
    public class LoggingCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IWriter writer;

        public LoggingCommandDecorator(ICommand command, IWriter writer)
        {
            this.command = command ?? throw new ArgumentNullException("command");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public string Execute(IList<string> parameters)
        {
            this.writer.Write($"Command is called at {DateTime.Now}!");
            this.writer.Write(Environment.NewLine);
            return this.command.Execute(parameters);
        }
    }
}