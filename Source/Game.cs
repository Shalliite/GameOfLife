﻿namespace GameOfLife.Source
{
    /// <summary>
    /// Class for creating new game instance.
    /// </summary>
    public class Game
    {
        private Field field;
        private Cells cells;
        public bool shouldRun = false;

        /// <summary>
        /// Function that processes game and its logic.
        /// </summary>
        public void Play()
        {
            const string fieldWidthInfo = "Enter game field width (4 - 120 characters long)";
            const string fieldHeightInfo = "Enter game field height (4 - 35 characters long)";
            ushort fieldWidth = UserInterface.ProcessInput(fieldWidthInfo, 4, 120);
            ushort fieldHeight = UserInterface.ProcessInput(fieldHeightInfo, 4, 35);
            field = new Field();
            cells = new Cells(fieldWidth, fieldHeight);
            shouldRun = true;
            Thread checkIfShouldRun = new Thread(CheckIfShouldRun);
            checkIfShouldRun.Start();
            cells.SetCellsRandomAlive();

            while (shouldRun)
            {
                field.UpdateDimensions(fieldWidth, fieldHeight);
                field.Render(cells);
                cells.CalculateNextIteration(900);
            }

            checkIfShouldRun.Join();
        }

        /// <summary>
        /// Function that is on seperate thread to wait for user to press ESC to exit game.
        /// </summary>
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
