using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Guards
    {
        public static int guardStep = 3;
        public static int Infinity = 1000000; //int.MaxValue;


        public static void Main()
        {
            //reading the input

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] maze = new int[rows, cols];

            int guardsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < guardsNum; i++)
            {
                string[] guardsPosit = Console.ReadLine().Split(' ').ToArray();
                int guardRow = int.Parse(guardsPosit[0]);
                int guardCol = int.Parse(guardsPosit[1]);

                //where is the guard it must be some different num, we do'not want to go there!!!
                maze[guardRow, guardCol] = Infinity;

                string guardSeeing = guardsPosit[2];

                //check if guard is in last coloumn and if there have not other guard and make the cells where he is looking == 3;
                switch (guardSeeing)
                {
                    case "U":
                        if (guardRow > 0 && maze[guardRow - 1, guardCol] == 0)
                        {
                            maze[guardRow - 1, guardCol] = guardStep;
                        }
                        break;

                    case "D":
                        if (guardRow < rows - 1 && maze[guardRow + 1, guardCol] == 0)
                        {
                            maze[guardRow + 1, guardCol] = guardStep;
                        }
                        break;
                    case "L":
                        if (guardCol > 0 && maze[guardRow, guardCol - 1] == 0)
                        {
                            maze[guardRow, guardCol - 1] = guardStep;
                        }
                        break;

                    case "R":
                        if (guardCol < cols - 1 && maze[guardRow, guardCol + 1] == 0)
                        {
                            maze[guardRow, guardCol + 1] = guardStep;
                        }
                        break;
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (maze[r, c] == 0) 
                    {
                        maze[r, c] = 1; // maze step = 1
                    }
                    if (r == 0 && c == 0)  //first cell
                    {
                        continue;
                    }
                    if (r == 0) //first row - take += left elem
                    {
                        maze[r, c] = maze[r, c] + maze[r, c - 1];
                    }
                    else if (c == 0)//first col - take += up elem
                    {
                        maze[r, c] = maze[r, c] + maze[r - 1,c];
                    }
                    else
                    {
                        maze[r, c] += Math.Min(maze[r, c - 1], maze[r - 1, c]);
                    }

                }
            }
            int result = maze[rows - 1, cols - 1];
            if (result >= Infinity)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
