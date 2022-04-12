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
            game.Play(UserInterface.ProcessInput("Enter game field width (4 - 120 characters long)", 4, 120), UserInterface.ProcessInput("Enter game field height (4 - 35 characters long)", 4, 35));
        }

        public static void Main()
        {
            App app = new App();
            app.Run();
        }
    }
}
