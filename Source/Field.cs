namespace GameOfLife.Source
{
    /// <summary>
    /// Class for new fields to be created.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Constructor to construct new field instance.
        /// </summary>
        /// <param name="width">Field width.</param>
        /// <param name="height">Field height.</param>
        public Field()
        {
            Console.Clear();
        }

        /// <summary>
        /// Function for updating field dimensions.
        /// </summary>
        public void UpdateDimensions(ushort width, ushort height)
        {
            int windowWidth = width < ushort.Parse(Resources.Resources.GameMinimumConsoleWidth) ? windowWidth = ushort.Parse(Resources.Resources.GameMinimumConsoleWidth) : windowWidth = width;
            int windowHeight = height + ushort.Parse(Resources.Resources.TextHeightInGame); //because of space to render text
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(windowWidth, windowHeight);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Function that renders game field to show in console.
        /// </summary>
        /// <param name="cells">Cells to render on screen.</param>
        public void Render(Cells cells)
        {
            Console.SetCursorPosition(0, 0);
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine(Resources.Resources.GameGenerationDisplayInfo, cells.Generation);
            Utilities.ClearCurrentConsoleLine();
            Console.WriteLine(Resources.Resources.GameAliveCellDisplayInfo, cells.LiveCellCount);
            for (int currentRow = 0; currentRow < cells.CellArray.GetLength(0); currentRow++)
            {
                for (int currentColumn = 0; currentColumn < cells.CellArray.GetLength(1); currentColumn++)
                {
                    if (cells.CellArray[currentRow, currentColumn])
                    {
                        Console.Write(Resources.Resources.AliveCell);
                    }
                    else
                    {
                        Console.Write(Resources.Resources.DeadCell);
                    }
                }
                Console.Write('\n');
            }
        }
    }
}
