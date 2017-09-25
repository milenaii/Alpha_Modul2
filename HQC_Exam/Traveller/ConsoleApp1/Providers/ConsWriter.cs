using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Decorator.Providers
{
    public class ConsWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
