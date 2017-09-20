using Ninject;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Ninject;

//Mimi is working in Folder Before
namespace OlympicGames
{
    public class StartUp
    {
        //public static INinjectModule[] OlympianModule { get; private set; }

        public static void Main(string[] args)
        {
            // Don not touch here (Magic Unicorns)
            // Engine.Instance.Run();

            IKernel kernel = new StandardKernel(new OlympiansModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Run();

        }
    }
}
