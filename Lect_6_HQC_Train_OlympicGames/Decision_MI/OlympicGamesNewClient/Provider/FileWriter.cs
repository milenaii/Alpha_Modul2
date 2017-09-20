using OlympicGames.Core.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesNewClient.Provider
{
    public class FileWriter : IWriter
    {
        public void Write(string text)
        {
            using (StreamWriter strWr = new StreamWriter("text.txt",true))
            {
                strWr.WriteLine(text);
            }
        }
    }
}
