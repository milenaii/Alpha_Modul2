using Ninject;
using OlympicGames.Core.Contracts;
using OlympicGames.Ninject;

namespace OlympicGames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new OlympiandsModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Run();
        }
    }
}