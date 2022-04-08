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
            Console.SetWindowSize(fieldWidth * 2, fieldHeight);
            Console.Clear();
            shouldRun = true;
            Thread checkIfShouldRun = new Thread(CheckIfShouldRun);
            checkIfShouldRun.Start();
            int[,] values = new int[fieldWidth, fieldHeight];
            for (int y = 0; y < fieldHeight; y++)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    Random random = new Random();
                    values[x, y] = random.Next(0, 2);
                }
            }
            while (shouldRun)
            {
                Console.Clear();
                for (int y = 0; y < fieldHeight; y++)
                {
                    for (int x = 0; x < fieldWidth; x++)
                    {
                        if (values[x, y] != 0)
                        {
                            Console.Write("--");
                        }
                        else
                        {
                            Console.Write("**");
                        }
                    }
                    Console.Write("\n");
                }
                Console.Beep(300, 100);
                Thread.Sleep(900);
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
