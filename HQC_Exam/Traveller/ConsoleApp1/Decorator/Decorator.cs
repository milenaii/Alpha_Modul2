using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;

namespace ConsoleApp1.Decorator
{
    public class Decorator
    {
        private readonly ICommand command;

        public Decorator(ICommand command)
        {
            this.command = command;
        }

        public string Execute(IList<string> commandLine)
        {
           
                Stopwatch watch = new Stopwatch();

                writer.WriteLine($"The Engine is starting... { DateTime.Now}");

                watch.Start();
                result = this.command.Execute(commandLine);
                watch.Stop();

                writer.WriteLine($"Command finnished executing at {DateTime.Now} and took {watch.ElapsedTicks}");
            }

            return result;
        }

    }
}
