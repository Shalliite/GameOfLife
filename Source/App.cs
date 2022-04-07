using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Source
{
    public class App
    {
        private Game? game;
        private bool shouldRun = false;
        public App()
        {
            shouldRun = true;
            game = new Game();
        }
        public void Run()
        {
            while (shouldRun)
            {
                Console.SetWindowSize(120, 30);
                Console.Clear();
                Console.WriteLine("1. 40x35 game");
                Console.WriteLine("2. 60x35 game");
                Console.WriteLine("3. 80x35 game");
                Console.WriteLine("ESC to exit");
                ConsoleKeyInfo selection = Console.ReadKey();
                Console.WriteLine();
                switch (selection.Key)
                {
                    case ConsoleKey.D1:
                        game.Play(40, 35);
                        break;
                    case ConsoleKey.D2:
                        game.Play(60, 35);
                        break;
                    case ConsoleKey.D3:
                        game.Play(80, 35);
                        break;
                    case ConsoleKey.Escape:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void Main()
        {
            App app = new App();
            app.Run();
        }
    }
}
