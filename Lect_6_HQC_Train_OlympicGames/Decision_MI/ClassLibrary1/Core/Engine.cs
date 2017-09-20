using System;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        //private static readonly IEngine instance = new Engine();

        //private readonly ICommandParser parser;
        //private readonly ICommandProcessor commandProcessor;
        //private readonly IOlympicsFactory factory;
        //private readonly IOlympicCommittee commitee;

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;

        private const string Delimiter = "####################";

        public Engine(IReader reader, IWriter writer, ICommandParser parser, ICommandProcessor commandProcessor)
        {
            this.parser = parser;
            this.commandProcessor = commandProcessor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string commandLine = null;

            while ((commandLine = Console.ReadLine()) != "end")
            {
                try
                {
                    var command = this.parser.ParseCommand(commandLine);
                    if (command != null)
                    {
                        //this.commandProcessor.Add(command);
                        this.commandProcessor.ProcessSingleCommand(command,commandLine);
                        writer.Write(Delimiter);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    writer.Write(string.Format("ERROR: {0}", ex.Message));
                }
            }
        }

        //public static IEngine Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}
    }
}
