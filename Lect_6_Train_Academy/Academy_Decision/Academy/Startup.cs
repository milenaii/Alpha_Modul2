using Academy.Core.Contracts;
using Academy.Ninject;
using Ninject;

namespace Academy
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new AcademyModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
