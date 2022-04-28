namespace GameOfLife.Source
{
    using GameOfLife.Resources;
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
            ushort fieldWidth = UserInterface.ProcessInput(
                Resources.EnterGameFieldWidthInfo,
                ushort.Parse(Resources.MinimumGameFieldWidth),
                ushort.Parse(Resources.MaximumGameFieldWidth));
            ushort fieldHeight = UserInterface.ProcessInput(
                Resources.EnterGameFieldHeightInfo,
                ushort.Parse(Resources.MinimumGameFieldHeight),
                ushort.Parse(Resources.MaximumGameFieldHeight));
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
