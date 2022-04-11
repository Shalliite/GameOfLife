using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public class Game
    {
        public bool shouldRun = false;
        public void Play(ushort fieldWidth, ushort fieldHeight)
        {
            Console.SetWindowSize(fieldWidth, fieldHeight);
            Console.Clear();
            shouldRun = true;
            Thread checkIfShouldRun = new Thread(CheckIfShouldRun);
            checkIfShouldRun.Start();
            bool[,] values = new bool[fieldWidth, fieldHeight];

            for(int y = 0; y < fieldHeight; y++)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    values[x, y] = false;
                }
            }
            values[4, 4] = true;
            values[5, 5] = true;
            values[6, 5] = true;
            values[6, 4] = true;
            values[6, 3] = true;

            /*
            for (int y = 0; y < fieldHeight; y++)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    Random random = new Random();
                    values[x, y] = random.Next(2) == 0;
                }
            }
            */
            while (shouldRun)
            {
                Console.Clear();
                //update field
                for (int y = 0; y < fieldHeight; y++)
                {
                    for (int x = 0; x < fieldWidth; x++)
                    {
                        short liveCellCount = 0;
                        //check if there is something arround
                        if (values[x == 0 ? fieldWidth - 1 : x - 1, y] == true)
                            liveCellCount++;
                        if (values[x == 0 ? fieldWidth - 1 : x - 1, y == 0 ? fieldHeight - 1 : y - 1] == true)
                            liveCellCount++;
                        if (values[x, y == 0 ? fieldHeight - 1 : y - 1] == true)
                            liveCellCount++;
                        if (values[x == fieldWidth - 1 ? 0 : x + 1, y == 0 ? fieldHeight - 1 : y - 1] == true)
                            liveCellCount++;
                        if (values[x == fieldWidth - 1 ? 0 : x + 1, y] == true)
                            liveCellCount++;
                        if (values[x == fieldWidth - 1 ? 0 : x + 1, y == fieldHeight - 1 ? 0 : y + 1] == true)
                            liveCellCount++;
                        if (values[x, y == fieldHeight - 1 ? 0 : y + 1] == true)
                            liveCellCount++;
                        if (values[x == 0 ? fieldWidth - 1 : x - 1, y == fieldHeight - 1 ? 0 : y + 1] == true)
                            liveCellCount++;

                        if ((liveCellCount == 0 || liveCellCount == 1) && values[x, y] == true)
                            values[x, y] = false;
                        if ((liveCellCount == 2 || liveCellCount == 3) && values[x, y] == true)
                            values[x, y] = true;
                        if (liveCellCount > 3 && values[x, y] == true)
                            values[x, y] = false;
                        if (liveCellCount == 3 && values[x, y] == false)
                            values[x, y] = true;
                    }
                }

                //render field
                for (int y = 0; y < fieldHeight; y++)
                {
                    for (int x = 0; x < fieldWidth; x++)
                    {
                        if (values[x, y] == true)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    Console.Write("\n");
                }
                Thread.Sleep(300);
            }
            checkIfShouldRun.Join();
        }
        public void CheckIfShouldRun()
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                shouldRun = true;
            }
            shouldRun = false;
        }
    }
}
