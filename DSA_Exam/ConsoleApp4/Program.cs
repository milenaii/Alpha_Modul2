using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            string line;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                string[] parameters = line.Split(new char[] { ' ' }).ToArray();

                int firstNum = int.Parse(parameters[0]);
                string command = parameters[2];
                int secondNum = int.Parse(parameters[3]);

                if (command == "after")
                {
                    if (list.Contains(firstNum))
                    {
                        continue;
                    }
                    else


        }
    }
}
