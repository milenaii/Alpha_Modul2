using OlympicGames.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OlympicGamesNewClient.Decorator
{
    public class LoggerCommandDecorator : ICommand
    {
        private readonly ICommand command;

        public LoggerCommandDecorator(ICommand command)
        {
            this.command = command;
        }

        public string Execute(IList<string> commandLine)
        {
            string result = null;
            using (StreamWriter writer = new StreamWriter("logFile.txt", true))
            {
                Stopwatch watch = new Stopwatch();

                writer.WriteLine($"Command is executing at {DateTime.Now}");

                watch.Start();
                result = this.command.Execute(commandLine);
                watch.Stop();

                writer.WriteLine($"Command finnished executing at {DateTime.Now} and took {watch.ElapsedTicks}");
            }

            return result;
        }
    }
}
