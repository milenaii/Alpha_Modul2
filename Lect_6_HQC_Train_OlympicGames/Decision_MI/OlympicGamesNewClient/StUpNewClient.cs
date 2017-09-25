using Ninject;
using OlympicGames.Core.Contracts;
using OlympicGamesNewClient.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesNewClient
{
    public class StUpNewClient
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new OlympiansModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Run();
        }
    }
}
