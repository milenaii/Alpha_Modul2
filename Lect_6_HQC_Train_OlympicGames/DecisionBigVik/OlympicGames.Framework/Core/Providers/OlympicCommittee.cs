using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using System.Collections.Generic;

namespace OlympicGames.Core.Providers
{
    public class OlympicCommittee : IOlympicCommittee
    {
        public OlympicCommittee()
        {
            this.Olympians = new List<IOlympian>();
        }

        public ICollection<IOlympian> Olympians { get; private set; }
    }
}
