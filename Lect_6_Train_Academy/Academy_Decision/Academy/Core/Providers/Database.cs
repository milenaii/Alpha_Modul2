using Academy.Core.Contracts;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Providers
{
    public class Database : IDatabase
    {
        private readonly List<ISeason> seasons;
        private readonly List<IStudent> students;
        private readonly List<ITrainer> trainers;

        public Database()
        {
            this.seasons = new List<ISeason>();
            this.students = new List<IStudent>();
            this.trainers = new List<ITrainer>();
        }

        public IList<ISeason> Seasons
        {
            get
            {
                return this.seasons;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return this.students;
            }
        }

        public IList<ITrainer> Trainers
        {
            get
            {
                return this.trainers;
            }
        }
    }
}
