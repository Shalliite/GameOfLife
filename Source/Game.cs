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
            while (shouldRun)
            {
                Console.Write("s");
                Thread.Sleep(1000);
            }
            checkIfShouldRun.Join();
        }
        public void CheckIfShouldRun()
        {
            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {
                shouldRun = true;
            }
            shouldRun = false;
        }
    }
}
