namespace GameOfLife.Source
{
    /// <summary>
    /// Class for creating new game instance.
    /// </summary>
    public class Game
    {
        private Resources _resources;
        private Field field;
        private Cells cells;
        public bool shouldRun = false;

        /// <summary>
        /// Function that processes game and its logic.
        /// </summary>
        public void Play()
        {
            _resources = new Resources();
            ushort fieldWidth = UserInterface.ProcessInput(_resources.EnterGameFieldWidthInfo, _resources.MinimumFieldWidth, _resources.MaximumFieldWidth, _resources);
            ushort fieldHeight = UserInterface.ProcessInput(_resources.EnterGameFieldHeightInfo, _resources.MinimumFieldHeight, _resources.MaximumFieldHeight, _resources);
            field = new Field(fieldWidth, fieldHeight);
            cells = new Cells(fieldWidth, fieldHeight);
            shouldRun = true;
            Thread checkIfShouldRun = new Thread(CheckIfShouldRun);
            checkIfShouldRun.Start();
            cells.SetCellsRandomAlive();

            while (shouldRun)
            {
                field.UpdateDimensions(fieldWidth, fieldHeight);
                field.Render(cells, _resources);
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
