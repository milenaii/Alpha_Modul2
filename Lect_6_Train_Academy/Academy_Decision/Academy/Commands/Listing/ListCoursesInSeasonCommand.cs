﻿using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListCoursesInSeasonCommand : ICommand
    {
        private readonly IDatabase database;

        public ListCoursesInSeasonCommand(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException("database");
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.database.Seasons[int.Parse(seasonId)];

            return season.ListCourses();
        }
    }
}
