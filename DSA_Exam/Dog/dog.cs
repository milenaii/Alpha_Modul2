﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Dog
{
    class dog
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigList<int> list = new BigList<int>();

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
                    {
                        list.Add(firstNum);

                    }
                }
                else  //before
                {
                   // list.Insert();
                }


            }

        }
    }
}