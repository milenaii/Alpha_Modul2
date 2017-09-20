using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddTrainerToSeasonCommand : ICommand
    {
        private readonly IDatabase database;

        public AddTrainerToSeasonCommand(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException("database");
        }

        public string Execute(IList<string> parameters)
        {
            var trainerUsername = parameters[0];
            var seasonId = parameters[1];

            var trainer = this.database.Trainers.Single(x => x.Username.ToLower() == trainerUsername.ToLower());
            var season = this.database.Seasons[int.Parse(seasonId)];

            if (season.Trainers.Any(x => x.Username.ToLower() == trainerUsername.ToLower()))
            {
                throw new ArgumentException($"The Trainer {trainerUsername} is already a part of Season {seasonId}!");
            }

            season.Trainers.Add(trainer);
            return $"Trainer {trainerUsername} was assigned to Season {seasonId}.";
        }
    }
}
